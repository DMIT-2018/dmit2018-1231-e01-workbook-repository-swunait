# LINQ "Nesting" Method Syntax Exercises

### Below are some questions to help you understand LINQ's method syntax in C#. These exercises assume that you have access to the West Wind database schema provided by the instructor.

## **Question 1: Grouping Orders by Customer and Year.**

 
 
 ![](Group%20By%20Methods%20-%20Q1.png)

<details>
<summary>Solution</summary>

```csharp
Orders
	   .GroupBy(x => new { x.Customer.CompanyName, Year = x.OrderDate.Value.Year })
	   .Select(x => new
	   {
		   CustomerName = x.Key.CompanyName,
		   OrderYear = x.Key.Year,
		   TotalOrders = x.Count()
	   }).OrderBy(x => x.CustomerName)
	   }).ToList().Dump();
```
</details>

---

## **Question 2: Grouping Products by Supplier and Category**

![](Group%20By%20Methods%20-%20Q2.png)
<details>
<summary>Solution</summary>

```csharp
Products
  .GroupBy(x => new {
    x.Supplier.CompanyName, x.Category.CategoryName
  })
  .Select(x => new {
    Supplier = x.Key.CompanyName,
      Category = x.Key.CategoryName,
      ProductCount = x.Count()
  }).ToList().Dump();
```
</details>

---

## **Question 3: Grouping Employees by Region and Territories**

**NOTE:** 
You need to start at the EmployeeTerritories tables.  Only Eastern -> New York has 2 values.

![](Group%20By%20Methods%20-%20Q3a.png)
![](Group%20By%20Methods%20-%20Q3b.png)

<details>
<summary>Solution</summary>

```csharp
EmployeeTerritories
  .GroupBy(x => new {
    x.Territory.Region.RegionDescription, x.Territory.TerritoryDescription
  })
  .Select(x => new {
    Region = x.Key.RegionDescription,
      Territory = x.Key.TerritoryDescription,
      Employees = x.Select(e => new {
        Name = e.Employee.FirstName + " " + e.Employee.LastName
      })

  }).ToList().Dump();
```
</details>

---

## **Question 4: Grouping Products by Supplier and Category**

![](Group%20By%20Methods%20-%20Q4.png)
<details>
<summary>Solution</summary>

```csharp
Products
  .GroupBy(x => new {
    x.Supplier.CompanyName, x.Category.CategoryName
  })
  .Select(x => new {
    Supplier = x.Key.CompanyName,
      Category = x.Key.CategoryName,
      Products = x.Select(x => new {
        Name = x.ProductName,
          QtyPerUnit = x.QuantityPerUnit,
          Price = x.UnitPrice
      })
  }).ToList().Dump();
```
</details>

---

