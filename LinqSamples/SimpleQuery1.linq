<Query Kind="Statements">
  <Connection>
    <ID>0e267760-1c8f-40d7-b41f-6d2013b040b5</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>IQSchool</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

// Write a C# statement to query for all Students
Students
	.Dump("All Students");
// Write a C# statement to query for all Students in Edmonton
Students
	.Where(x => x.City == "Edmonton")
	.Dump("All Students in Edmonton");
// Write a C# statement to query for the 
// StudentID, FirstName, LastName
// with birthdate after 1980
Students
	.Where(x => x.Birthdate.Year > 1980)
	.Select(x => new 
		{
			StudentID = x.StudentID,
			FName = x.FirstName,
			LName = x.LastName
		}
	)
	.Dump("StudentID, FirstName, LastName");

