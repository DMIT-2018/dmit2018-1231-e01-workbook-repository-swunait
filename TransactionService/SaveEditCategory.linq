<Query Kind="Program">
  <Connection>
    <ID>a233c8dd-fd7f-4f98-973f-d8a10526b16b</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>.</Server>
    <Database>WestWind</Database>
    <DisplayName>WestWind-Entity</DisplayName>
    <DriverData>
      <EncryptSqlTraffic>False</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
      <TrustServerCertificate>False</TrustServerCertificate>
    </DriverData>
  </Connection>
  <NuGetReference>FluentAssertions</NuGetReference>
  <Namespace>FluentAssertions</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

#load ".\*.cs"
#nullable enable

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.

	//	unit test to be ran to validate the method listed in the "Method Region"
	//Test_XXX();
}

/// <summary>
/// Contains unit tests.
/// </summary>
/// <remarks>
/// It's important to note that in typical development, actual code and unit tests should 
/// not reside in the same file. They should be separated, often into different projects 
/// within a solution, to maintain a clear distinction between production code and testing code.
/// </remarks>
#region Unit Test
public void Test_XXX()
{
	
}
#endregion

/// <summary>
/// Defines methods that are a part of the application (service).
/// </summary>
#region Method

/// <summary>
/// Adds or edits a customer/address/invoice etc in the system based on the provided xxxx view model.
/// </summary>
/// <param name="XXXView">The  view model containing details to be added or edited.</param>
/// <returns>
/// The result of the addition or edit operation, currently set to return null.
/// NOTE: The return value may need adjustment based on intended behavior.
/// </returns>
public CategoryView? AddEditCategory(CategoryView categoryView)
{
    // --- Business Logic and Parameter Exception Section ---
    #region Business Logic and Parameter Exception

    // List initialization to capture potential errors during processing.
    List<Exception> errorList = new List<Exception>();

    // All business rules are placed here. 
    // They are crucial for ensuring data integrity and validation.
	if (string.IsNullOrWhiteSpace(categoryView.CategoryName))
	{
		errorList.Add(new Exception("Category name is required and cannot be empty"));
	}
    
    // The logic to validate incoming parameters goes here.

    #endregion

    // --- Main Method Logic Section ---
    #region Method Code

    // Actual logic to add or edit data in the database goes here.
	var currentCategory = Categories
							.Where(c => c.CategoryID == categoryView.CategoryID)
							.FirstOrDefault();
	if (currentCategory == null)
	{
		currentCategory = new Categories();
	}
	
	// Copy data from the view model to the entity class
	currentCategory.CategoryName = categoryView.CategoryName;
	currentCategory.Description = categoryView.Description;
	currentCategory.Picture = categoryView.Picture;
	currentCategory.PictureMimeType = categoryView.PictureMimeType;
	
	// check to see if we are adding a new category
	if (currentCategory.CategoryID == 0) 
	{
		// add the currentCategory entity to the Categories collection
		Categories.Add(currentCategory);
	}
	
    #endregion

    // --- Error Handling and Database Changes Section ---
    #region Check for errors and SaveChanges

    // Check for the presence of any errors.
    if (errorList.Count() > 0)
    {
		// If errors are present, clear any changes tracked by Entity Framework 
		// to avoid persisting erroneous data.
		ChangeTracker.Clear();

		// Throw an aggregate exception containing all errors found during processing.
		throw new AggregateException("Unable to proceed!  Check concerns", errorList);
	}
	else
	{
		// If no errors are present, commit changes to the database.
		SaveChanges();
	}

	// Return null; this return value may require further specification based on requirements.
	return GetCategory(currentCategory.CategoryID);

	#endregion
}

#endregion

public CategoryView? GetCategory(int categoryID)
{
	var query = Categories
				.Where(c => c.CategoryID == categoryID);
	Categories? querySingleResult = query.FirstOrDefault();
	CategoryView? viewModel = null;
	if (querySingleResult != null) 
	{
		viewModel = new CategoryView
		{
			CategoryID = querySingleResult.CategoryID,
			CategoryName = querySingleResult.CategoryName,
			Description = querySingleResult.Description,
			Picture = querySingleResult.Picture,
			PictureMimeType = querySingleResult.PictureMimeType
		};
	}
	return viewModel;
}

/// <summary>
/// Contains class definitions that are referenced in the current LINQ file.
/// </summary>
/// <remarks>
/// It's crucial to highlight that in standard development practices, code and class definitions 
/// should not be mixed in the same file. Proper separation of concerns dictates that classes 
/// should have their own dedicated files, promoting modularity and maintainability.
/// </remarks>
#region Class

// TODO: Place your class definitions inside this region.
public class CategoryView
{
	public int CategoryID {get; set;}
	public string CategoryName {get; set;} = string.Empty;
	public string? Description {get; set;}
	public byte[]? Picture {get; set;}
	public string? PictureMimeType {get; set;}
}

#endregion

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

[Fact]
void AddEditCategory_AddAndEdit_AddedThenUpdated() 
{
	// Arrange
	CategoryView beforeAdd = new CategoryView 
	{
		CategoryName = "Add - James",
		Description = "Add - James was here!"
	};
	
	// Act
	CategoryView? afterAdd = AddEditCategory(beforeAdd);
	
	// Assert
	afterAdd.Should().NotBeNull();
	afterAdd!.CategoryID.Should().BeGreaterThan(0);
	afterAdd!.CategoryName.Should().Be(beforeAdd.CategoryName);
	afterAdd!.Description.Should().Be(beforeAdd.Description);
}

#endregion