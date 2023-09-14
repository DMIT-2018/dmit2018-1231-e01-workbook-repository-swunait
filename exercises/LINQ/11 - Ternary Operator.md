# LINQ "Ternary" Method Syntax Exercises

### Below are some questions to help you understand LINQ's method syntax in C#. These exercises assume that you have access to the Chinook database schema provided by the instructor.

#### Question 1: Display if an employee is a manager or employee
From the Employees table, list the first name of employees, and display "Employee" if they have someone reporting to them, otherwise "Manager".

<details>
<summary>Solution</summary>

 ```cs
Employees
	.Select(x => new
	{
		Name = x.FirstName,
		Role = x.ReportsTo == null ? "Manager" : "Employee"
	})
	.Dump();
 ```
</details>

#### Question 2: Show long play tracks
Using the Tracks table, display the track name and check if its Milliseconds length is more than 3 minutes (180,000 milliseconds). Display "Long" if true, otherwise "Short".

<details>
<summary>Solution</summary>

 ```cs
Tracks
    .Select(x => new
    {
        Name = x.Name,
		Duration = x.Milliseconds > 180000 ? "Long" : "Short"
	})
	.Dump();
 ```
</details>

#### Question 3: Display country types
From the Customers table, list customers by FirstName, Country and check if their country is "USA" or "Canada". Display "Domestic" if true, otherwise "International".


<details>
<summary>Solution</summary>

 ```cs
Customers
	.Select(x => new
	{
		Name = x.FirstName,
		Country = x.Country,
		Type = x.Country == "USA" || x.Country == "Canada" ? "Domestic" : "International"
	})
	.Dump();
 ```
</details>

<br />

[Readme.md](./Readme.md)
