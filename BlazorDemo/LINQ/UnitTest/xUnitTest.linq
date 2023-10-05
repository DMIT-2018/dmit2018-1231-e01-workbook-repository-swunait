<Query Kind="Program">
  <Connection>
    <ID>176562ea-b690-4682-88c3-09cd7346830f</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>ChinookSept2018</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
  <NuGetReference>FluentAssertions</NuGetReference>
  <Namespace>FluentAssertions</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public decimal Div(decimal a, decimal b)
{
	return a / b;
}

public Tracks ArgumentNullExceptionTest(int trackID)
{
	#region Business Logic and Parameter Exceptions
	List<Exception> errorList = new();
	
	var track = Tracks
					.Where(t => t.TrackId == trackID)
					.FirstOrDefault();
	if (track == null) 
	{
		throw new ArgumentNullException(nameof(trackID), $"No track was found for Track ID: {trackID}");	
	}
	#endregion
	
	
	if (errorList.Count() > 0)
	{
		throw new AggregateException("Unable to proceed! Check concerns", errorList);
	}
	return track;
}

#region private::Tests

[Theory]
[InlineData(10000)]
[InlineData(12345)]
[InlineData(-12345)]
public void ArgumentNullExceptionTest_NotFound_ThrowsArgumentNullException(int trackID)
{
	// Arrange
	
	// Act
	Action action = () => ArgumentNullExceptionTest(trackID);
	
	// Assert
	action.Should()
		.Throw<ArgumentNullException>()
		.WithParameterName("trackID")
		.WithMessage("No track was found*");
}

[Theory]
[InlineData(3,"Fast As a Shark")]
[InlineData(10,"Evil Walks")]
[InlineData(20,"Overdose")]
public void ArgumentNullExceptionTest_Found_ContainsExpectedValues(int trackID, string expectedName)
{
	// Arrange

	// Act
	var actual = ArgumentNullExceptionTest(trackID);

	// Assert
	actual.Should().NotBeNull();
	actual.Name.Should().Be(expectedName);
}

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

[Fact]
void Test_FluentAssertions()
{
	var actual = 1 + 1;
	actual.Should().Be(2);
}

[Theory]
[InlineData(6, 5, 1.2)]
[InlineData(9, 3, 3.0)]
[InlineData(4, 5, 0.8)]
public void Div_DividingNumber_ReturnsCorrectQuotient
(
	decimal num1,
	decimal num2,
	decimal expectedResult
)
{
	// Arrange
	
	// Act
	decimal actual = Div(num1, num2);
	
	// Assert
	actual.Should().BeApproximately(expectedResult, 0m);
}

[Fact]
public void Div_DivisionByZero_ThrowsDivideByZeroException()
{
	// Arrange 
	decimal num1 = 6;
	decimal num2 = 0;
	
	// Act
	Action action = () => Div(num1, num2);
	
	// Assert
	action.Should().Throw<DivideByZeroException>()
		.WithMessage("Attempted to divide by zero*");
}
#endregion