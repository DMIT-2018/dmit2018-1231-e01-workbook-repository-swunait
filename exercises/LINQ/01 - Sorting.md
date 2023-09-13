# LINQ Sorting and Where Method Syntax Exercises

### Below are some questions to help you understand LINQ's method syntax in C#. These exercises assume that you have access to the Chinook database schema provided by the instructor.

#### Question 1: Get All Artists' Names
Write a LINQ query to fetch all artists' names from the Artists table order by name and dump them to the output.

<details>
<summary>Solution</summary>

 ```cs
var artists = Artists.OrderBy(a => a.Name).Select(a => a.Name).ToList();
artists.Dump();
 ```
</details>

#### Question 2: Get All Albums Released After 2000
Write a LINQ query to fetch all album titles from the Albums table order by title descending where the release year is after 2000.

<details>
<summary>Solution</summary>

 ```cs
var albums = Albums.Where(a => a.ReleaseYear > 2000)
				.OrderByDescending(a => a.Title)
				.Select(a => a.Title)
				.ToList();
albums.Dump();
 ```
</details>

#### Question 3: Sort Customers by Country
Write a LINQ query to fetch all customer names and sort them by their country in ascending order.


<details>
<summary>Solution</summary>

 ```cs
var sortedCustomers = Customers.OrderBy(c => c.Country)
                                .Select(c => $"{c.FirstName} {c.LastName}")
                                .ToList();
sortedCustomers.Dump();
 ```
</details>

#### Question 4: Get All Tracks for a Specific Genre (GenreId = 1)
Write a LINQ query to fetch all track names for the genre with GenreId = 1.

<details>
<summary>Solution</summary>

 ```cs
var genreTracks = Tracks.Where(t => t.GenreId == 1)
                         .Select(t => t.Name)
                         .ToList();
genreTracks.Dump();
 ```
</details>

#### Question 5: Get All Tracks for a Specific Genre (Name = Blues)
Write a LINQ query to fetch all track names for the genre with Genre Name = Blues in descending order.

<details>
<summary>Solution</summary>

 ```cs
var genreTracks = Tracks.Where(t => t.Genre.Name == "Blues")
						.OrderByDescending(t => t.Name)
						.Select(t => t.Name)						
						.ToList();
genreTracks.Dump();
 ```
</details>