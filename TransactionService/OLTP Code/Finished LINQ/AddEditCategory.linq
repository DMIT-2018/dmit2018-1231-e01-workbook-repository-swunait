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
</Query>

#load ".\*.cs"

/// <summary>
/// Main entry point for the application.
/// </summary>
void Main()
{
	//	unit test to be ran to validate the method listed in the "Method Region"
	Test_Add_Category();
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
public void Test_Add_Category()
{
	// Arrange: Set up necessary preconditions and inputs.
	//  create a new category view to use.
	CategoryView expected = new CategoryView();
	
	//	create a unique temp placeholder
	string tempValue = $"{DateTime.Now.Second}:{DateTime.Now.Microsecond}";
	
	//	updated our two properties
	expected.CategoryName = $"Cat-{tempValue}"; 
	expected.Description = $"Description-{tempValue}"; 

	// Act: Execute the functionality being tested.
	CategoryView actual = AddEditCategory(expected);

	// Assert: Verify that the output matches expected results.
	// check if we have a new CategoryID
	string isValid = actual.CategoryID != expected.CategoryID ? "Pass" : "Fail";
	Console.WriteLine($"-- {isValid} -- New Category");
	Console.WriteLine($"CategoryID Expected: Not {expected.CategoryID} - Actual: {actual.CategoryID}");
	
	//  check category name and description
	isValid = actual.CategoryName == expected.CategoryName ? "Pass" : "Fail";
	Console.WriteLine($"-- {isValid} -- Category Name '{actual.CategoryName}' are the same");
	isValid = actual.Description == expected.Description ? "Pass" : "Fail";
	Console.WriteLine($"-- {isValid} -- Description '{actual.Description}' are the same");
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
public CategoryView AddEditCategory(CategoryView categoryView)
{
	// --- Business Logic and Parameter Exception Section ---
	#region Business Logic and Parameter Exception

	// List initialization to capture potential errors during processing.
	List<Exception> errorList = new List<Exception>();

	// All business rules are placed here. 
	// Rule:	“Category Name” cannot be empty.

	// The logic to validate incoming parameters goes here.
	if (string.IsNullOrWhiteSpace(categoryView.CategoryName))
	{
		throw new Exception("Category name is required and cannot be empty");
	}
	#endregion

	// --- Main Method Logic Section ---
	#region Method Code

	// "categories" represents the "Category" table in the database when using Entity Framework.
	var category = Categories
					.Where(x => x.CategoryID == categoryView.CategoryID)
					.Select(x => x).FirstOrDefault();

	//	if the CategoryID that we are passing in is "0"
	//		then we are adding a new category
	if (category == null)
	{
		category = new Categories();
	}

	//  update all category entity properties with the category view properties.
	//	NOTE:  Do not update the primary key (CategoryID)
	category.CategoryName = categoryView.CategoryName;
	category.Description = categoryView.Description;
	category.Picture = categoryView.Picture;
	category.PictureMimeType = categoryView.PictureMimeType;

	//	check to see if we adding a new category
	if (category.CategoryID == 0)
	{
		//	add the category entity to the categories collection
		Categories.Add(category);
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

	// return an updated Category View.
	return GetCategory(category.CategoryID);

	#endregion
}

public CategoryView GetCategory(int categoryID)
{
	//	we are assuming that we will always have a valid category ID (No error checking).
	return Categories
		.Where(x => x.CategoryID == categoryID)
		.Select(x => new CategoryView
		{
			CategoryID = x.CategoryID,
			CategoryName = x.CategoryName,
			Description = x.Description,
			Picture = x.Picture,
			PictureMimeType = x.PictureMimeType
		}).FirstOrDefault();
}
#endregion

/// <summary>
/// Contains class definitions that are referenced in the current LINQ file.
/// </summary>
/// <remarks>
/// It's crucial to highlight that in standard development practices, code and class definitions 
/// should not be mixed in the same file. Proper separation of concerns dictates that classes 
/// should have their own dedicated files, promoting modularity and maintainability.
/// </remarks>
#region Class
public class CategoryView
{
	public int CategoryID { get; set; }
	public string CategoryName { get; set; }
	public string Description { get; set; }
	public byte[] Picture { get; set; }
	public string PictureMimeType { get; set; }
}
#endregion
