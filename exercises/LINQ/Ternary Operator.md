# LINQ "Navigational Properties and Anonymous Data Sets" Method Syntax Exercises

### Below are some questions to help you understand LINQ's method syntax in C#. These exercises assume that you have access to the Chinook database schema provided by the instructor.

#### Question 1: Get all album names and list as either classic or modern
Select all albums and show the following information: 
Album Name (Name)
Album Year (Year)
Album Type (ClassicOrModern). If the album was released in the year 2000 or later then it categories as "Modern" otherwise listed as "Classic".  Order by Year

<details>
<summary>Solution</summary>

 ```cs
var customers = Customers
		.OrderBy(x => x.LastName)
		.Select(x => new
		{
			FullName = $"{x.FirstName} {x.LastName}",
			Company = x.Company
		}
			)
		.ToList();
customers.Dump()
 ```
</details>

#### Question 2: Get All Tracks Released After 2000
Write a LINQ query to fetch all album titles (AlbumTitle), artist name (ArtistName), track name (TrackName), genres (GenreName) and release year (YearRelease) from the Track table where the release year is after 2000.  Order by Year, Album Name and Track name

<details>
<summary>Solution</summary>

 ```cs
var tracks = Tracks.Where(x => x.Album.ReleaseYear > 2000)
						.OrderBy(x => x.Album.ReleaseYear)
						.ThenBy(x => x.Album.Title)
						.ThenBy(x => x.Name)
						.Select(x => new
						{
							AlbumTitle = x.Album.Title,
							ArtistName = x.Album.Artist.Name,
							TrackName = x.Name,
							GenreName = x.Genre.Name,
							YearRelease = x.Album.ReleaseYear
						}
						)
						.ToList();
tracks.Dump();
 ```
</details>

#### Question 3: Sort Customers by Country
Write a LINQ query to fetch all customer full name (CustomerName), customer country (CustomerCountry),  support rep. name (SupportRepName) and country (SupportRepCountry) .  Sort them by their customer country in ascending order.


<details>
<summary>Solution</summary>

 ```cs
var sortedCustomers = Customers.OrderBy(x => x.Country)
								.Select(x => new
								{
									CustomerName = $"{x.FirstName} {x.LastName}",
									CustomerCountry = x.Country,
									SupportRepName = $"{x.SupportRep.FirstName} {x.SupportRep.LastName}",
									SupportRepCountry = x.SupportRep.Country
								})
								.ToList();
sortedCustomers.Dump();
 ```
</details>
