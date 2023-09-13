# LINQ Strongly Type Method Syntax Exercises

### Below are some questions to help you understand LINQ's method syntax in C#. These exercises assume that you have access to the "West Wind" database schema provided by the instructor.  You will have to use the C# Programming.

```csharp
void Main()
{
    // Linq Method
}
public class XXXXX
{
	public int ???? {get; set;}
	public string  ???? { {get; set;}
...
}
```

#### Question 1: Get All Customers and Address
<details>
Write a LINQ query to fetch all customer information based on the following class.  Sort by customer name.

```csharp
public class CustomerAddress
{
	public string CustomerID {get; set;}
	public string Customer {get; set;}
	public string Contact {get; set;}
	public string City {get; set;}
	public string Country {get; set;}
}
```

| CustomerID | Customer                               | Contact            | City          | Country   |
|------------|---------------------------------------|--------------------|---------------|-----------|
| ALFKI      | Alfreds Futterkiste                   | Maria Anders       | Berlin        | Germany   |
| ANATR      | Ana Trujillo Emparedados y helados    | Ana Trujillo       | México D.F.   | Mexico    |
| ANTON      | Antonio Moreno Taquería               | Antonio Moreno     | México D.F.   | Mexico    |
| AROUT      | Around the Horn                       | Thomas Hardy       | London        | UK        |

<details>
<summary>Solution</summary>

 ```cs
void Main()
{
	Customers
		.OrderBy(x => x.CompanyName)
		.Select(x => new CustomerAddress
		{
			CustomerID = x.CustomerID,
			Customer = x.CompanyName,
			Contact = x.ContactName,
			City = x.Address.City,
			Country = x.Address.Country
		}).Dump();
}
 ```
</details>
</details>

#### Question 2: Get All Employees and Address
<details>
Write a LINQ query to fetch all employee information based on the following class.  Sort by employee last name.

```csharp
public class EmployeeAddress
{
	public int EmployeeID { get; set; }
	public string Name { get; set; } // First & Last
	public string Title { get; set; }
	public string City { get; set; }
	public string Country { get; set; }
}
```

| EmployeeID | Name              | Title                     | City       | Country   |
|------------|-------------------|---------------------------|------------|-----------|
| 5          | Steven Buchanan   | Sales Manager             | London     | UK        |
| 8          | Laura Callahan    | Inside Sales Coordinator  | Seattle    | USA       |
| 1          | Nancy Davolio     | Sales Representative      | Seattle    | USA       |
| 9          | Anne Dodsworth    | Sales Representative      | London     | UK        |
| 2          | Andrew Fuller     | Vice President, Sales     | Tacoma     | USA       |
| 7          | Robert King       | Sales Representative      | London     | UK        |
| 3          | Janet Leverling   | Sales Representative      | Kirkland   | USA       |
| 4          | Margaret Peacock  | Sales Representative      | Redmond    | USA       |
| 6          | Michael Suyama    | Sales Representative      | London     | UK        |


<details>
<summary>Solution</summary>

 ```cs
void Main()
{
	Employees
		.OrderBy(x => x.LastName)
		.Select(x => new EmployeeAddress
		{
			EmployeeID = x.EmployeeID,
			Name = $"{x.FirstName} {x.LastName}",
			Title = x.JobTitle,
			City = x.Address.City,
			Country = x.Address.Country
		}).Dump();
}
 ```
</details>
</details>

#### Question 3: Get All Products with suppliers and address
<details>
Write a LINQ query to fetch all product information based on the following class.  Sort by product name.

```csharp
public class ProductSupplier
{
	public int ProductID {get; set;}
	public string Name {get; set;}
	public decimal Price {get; set;}
	public int QtyOnOrder {get; set;}
	public string Company {get; set;}
	public string Contact { get; set; }
	public string City { get; set; }
	public string Country { get; set; }
}
```

| ProductID | Name                              | Price | QtyOnOrder | Company                            | Contact                | City             | Country     |
|-----------|-----------------------------------|-------|------------|-----------------------------------|------------------------|------------------|-------------|
| 17        | Alice Mutton                      | 39    | 0          | Pavlova, Ltd.                      | Ian Devling            | Melbourne        | Australia   |
| 3         | Aniseed Syrup                     | 10    | 0          | Exotic Liquids                     | Charlotte Cooper       | London           | UK          |
| 40        | Boston Crab Meat                  | 18.4  | 0          | New England Seafood Cannery        | Robb Merchant           | Boston           | USA         |
| 60        | Camembert Pierrot                 | 34    | 0          | Gai pâturage                       | Eliane Noz              | Annecy           | France      |
| 18        | Carnarvon Tigers                  | 62.5  | 0          | Pavlova, Ltd.                      | Ian Devling            | Melbourne        | Australia   |
| 1         | Chai                              | 22    | 12         | Exotic Liquids                     | Charlotte Cooper       | London           | UK          |
| 2         | Chang                             | 19    | 0          | Exotic Liquids                     | Charlotte Cooper       | London           | UK          |




<details>
<summary>Solution</summary>

 ```cs
void Main()
{
	Products
		.OrderBy(x => x.ProductName)
		.Select(x => new ProductSupplier
		{
			ProductID = x.ProductID,
			Name = x.ProductName,
			Price = x.UnitPrice,
			QtyOnOrder = x.UnitsOnOrder,
			Company = x.Supplier.CompanyName,
			Contact = x.Supplier.ContactName,
			City = x.Supplier.Address.City,
			Country = x.Supplier.Address.Country
		}).Dump();
}
 ```
</details>
</details>

#### Question 4: Find all orders where the customers is from the United States
<details>
Write a LINQ query to fetch all orders where the customers is from the United States  based on the following class.  Sort by order date.

```csharp
public class CustomerOrder
{
	public int OrderID { get; set; }
	public DateTime? Date { get; set; }
	public string SaleRep { get; set; } //  First & Last
	public string Ship { get; set; } // Ternary Yes or No
	public string Customer { get; set; }
	public string Contact { get; set; }
	public string City { get; set; }
	public string Country { get; set; }
}
```

| OrderID | Date              | SaleRep           | Ship | Customer                       | Contact             | City           | Country |
|---------|-------------------|-------------------|------|--------------------------------|---------------------|----------------|---------|
| 10262   | 2016-07-25 0:00   | Janet Leverling   | Yes  | Rattlesnake Canyon Grocery    | Paula Wilson        | Albuquerque    | USA     |
| 10269   | 2016-08-03 0:00   | Margaret Peacock  | Yes  | White Clover Markets           | Karl Jablonski      | Seattle        | USA     |
| 10271   | 2016-08-04 0:00   | Anne Dodsworth    | Yes  | Split Rail Beer & Ale         | Art Braunschweiger  | Lander         | USA     |
| 10272   | 2016-08-05 0:00   | Anne Dodsworth    | Yes  | Rattlesnake Canyon Grocery    | Paula Wilson        | Albuquerque    | USA     |
| 10294   | 2016-09-02 0:00   | Michael Suyama    | Yes  | Rattlesnake Canyon Grocery    | Paula Wilson        | Albuquerque    | USA     |
| 10305   | 2016-09-16 0:00   | Janet Leverling   | Yes  | Old World Delicatessen        | Rene Phillips       | Anchorage      | USA     |
| 10307   | 2016-09-20 0:00   | Robert King       | Yes  | Lonesome Pine Restaurant      | Fran Wilson         | Portland       | USA     |
| 10310   | 2016-09-23 0:00   | Michael Suyama    | Yes  | The Big Cheese                | Liz Nixon           | Portland       | USA     |
| 10314   | 2016-09-28 0:00   | Nancy Davolio     | Yes  | Rattlesnake Canyon Grocery    | Paula Wilson        | Albuquerque    | USA     |
| 10316   | 2016-09-30 0:00   | Nancy Davolio     | Yes  | Rattlesnake Canyon Grocery    | Paula Wilson        | Albuquerque    | USA     |
| 10317   | 2016-10-03 0:00   | Robert King       | Yes  | Lonesome Pine Restaurant      | Fran Wilson         | Portland       | USA     |
| 10324   | 2016-10-11 0:00   | Janet Leverling   | Yes  | Save-a-lot Markets             | Jose Pavarotti      | Boise          | USA     |
| 10329   | 2016-10-18 0:00   | Anne Dodsworth    | Yes  | Split Rail Beer & Ale         | Art Braunschweiger  | Lander         | USA     |
| 10338   | 2016-10-28 0:00   | Michael Suyama    | Yes  | Old World Delicatessen        | Rene Phillips       | Anchorage      | USA     |





<details>
<summary>Solution</summary>

 ```cs
void Main()
{
	Orders
	.Where(x => x.Customer.Address.Country == "USA")
	.OrderBy(x => x.OrderDate)
	.Select(x => new CustomerOrder
	{
		OrderID = x.OrderID,
		Date = x.OrderDate,
		SaleRep = $"{x.SalesRep.FirstName} {x.SalesRep.LastName}",
		Ship = x.Shipped == true ? "Yes" : "No",
		Customer = x.Customer.CompanyName,
		Contact = x.Customer.ContactName,
		City = x.Customer.Address.City,
		Country = x.Customer.Address.Country
	}).Dump();
}
 ```
</details>
</details>

#### Question 5: Find all employee who region is from Southern, Northern, or Eastern     
<details>
Write a LINQ query to fetch all employee who regions are either from Southern, Northern      or Eastern region based on the following class.  Sort by region, territories,  then employee last name.

**NOTE:  You will need to figure out the start table in which to build the data from**

```csharp
public class EmployeeRegionTerritory
{
	public string Region { get; set; }
	public string Territory { get; set; }
	public string Name { get; set; } //  First & Last
	public string City { get; set; }
	public string Country { get; set; }
}
```

| Region    | Territory          | Name              | City        | Country   |
|-----------|--------------------|-------------------|-------------|-----------|
| Eastern   | Bedford            | Andrew Fuller     | Tacoma      | USA       |
| Eastern   | Boston             | Andrew Fuller     | Tacoma      | USA       |
| Eastern   | Braintree          | Andrew Fuller     | Tacoma      | USA       |
| Eastern   | Cambridge          | Andrew Fuller     | Tacoma      | USA       |
| Eastern   | Cary               | Margaret Peacock  | Redmond     | USA       |
| Eastern   | Edison             | Steven Buchanan   | London      | UK        |
| Eastern   | Fairport           | Steven Buchanan   | London      | UK        |
| Eastern   | Georgetown         | Andrew Fuller     | Tacoma      | USA       |
| Eastern   | Greensboro         | Margaret Peacock  | Redmond     | USA       |
| Eastern   | Louisville          | Andrew Fuller     | Tacoma      | USA       |
| Eastern   | Melville           | Steven Buchanan   | London      | UK        |
| Eastern   | Morristown         | Steven Buchanan   | London      | UK        |
| Eastern   | New York           | Steven Buchanan   | London      | UK        |
| Eastern   | New York           | Steven Buchanan   | London      | UK        |
| Eastern   | Newark             | Nancy Davolio     | Seattle     | USA       |
| Eastern   | Providence          | Steven Buchanan   | London      | UK        |
| Eastern   | Rockville          | Margaret Peacock  | Redmond     | USA       |
| Eastern   | Westboro           | Andrew Fuller     | Tacoma      | USA       |
| Eastern   | Wilton             | Nancy Davolio     | Seattle     | USA       |
| Northern  | Beachwood          | Laura Callahan    | Seattle     | USA       |
| Northern  | Bloomfield Hills   | Anne Dodsworth    | London      | UK        |
| Northern  | Findlay            | Laura Callahan    | Seattle     | USA       |
| Northern  | Hollis             | Anne Dodsworth    | London      | UK        |
| Northern  | Minneapolis        | Anne Dodsworth    | London      | UK        |
| Northern  | Philadelphia       | Laura Callahan    | Seattle     | USA       |
| Northern  | Portsmouth         | Anne Dodsworth    | London      | UK        |
| Northern  | Racine             | Laura Callahan    | Seattle     | USA       |
| Northern  | Roseville          | Anne Dodsworth    | London      | UK        |
| Northern  | Southfield         | Anne Dodsworth    | London      | UK        |
| Northern  | Troy               | Anne Dodsworth    | London      | UK        |
| Southern  | Atlanta            | Janet Leverling   | Kirkland    | USA       |
| Southern  | Orlando            | Janet Leverling   | Kirkland    | USA       |
| Southern  | Savannah           | Janet Leverling   | Kirkland    | USA       |
| Southern  | Tampa              | Janet Leverling   | Kirkland    | USA       |






<details>
<summary>Solution</summary>

 ```cs
void Main()
{
	EmployeeTerritories
	.Where(x => x.Territory.Region.RegionDescription == "Southern" ||
				x.Territory.Region.RegionDescription == "Eastern" ||
				x.Territory.Region.RegionDescription == "Northern")
	.OrderBy(x => x.Territory.Region.RegionDescription)
	.ThenBy(x => x.Territory.TerritoryDescription)
	.ThenBy(x => x.Employee.LastName)
	.Select(x => new EmployeeRegionTerritory
	{
		Region = x.Territory.Region.RegionDescription,
		Territory = x.Territory.TerritoryDescription,
		Name = $"{x.Employee.FirstName} {x.Employee.LastName}",
		City = x.Employee.Address.City,
		Country = x.Employee.Address.Country
	}).Dump();
}
 ```
</details>
</details>

<br />

[Readme.md](./Readme.md)
