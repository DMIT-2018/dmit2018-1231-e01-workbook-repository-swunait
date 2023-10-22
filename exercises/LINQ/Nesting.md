# LINQ "Nesting" Method Syntax Exercises

### Below are some questions to help you understand LINQ's method syntax in C#. These exercises assume that you have access to the West Wind database schema provided by the instructor.

## **Question 1: Find the Suppliers and their Products**

**Prompt:** 
Using the Northwind database, write a LINQ query to retrieve all suppliers and their associated products (name & price. Only consider suppliers who have more than 3 products. <br>  **NOTE:  You will need to use an aggregate function with this.**

<details>
<summary>Solution</summary>

```csharp
Suppliers
	.Where(s => s.Products.Count > 3)
	.Select(s => new
	{
		SupplierName = s.CompanyName,
		Products = Products
		.Where(p => p.SupplierID == s.SupplierID)
		.Select(p => new
		{
			Name = p.ProductName,
			Price = p.UnitPrice
		})
	}).Dump()
```
</details>

---

## **Question 2: List the Categories with Their Products**

**Prompt:** 
List all categories along with their products name and price. However, only consider products that have been discontinued.

<details>
<summary>Solution</summary>

```csharp
Categories
	.Select(c => new
	{
		CategoryName = c.CategoryName,
		DiscontinuedProducts = Products.Where(p => p.CategoryID == c.CategoryID && p.Discontinued)
		.Select(p => new
		{
			Name = p.ProductName,
			Price = p.UnitPrice
		})
	}).Dump();
```
</details>

---

## **Question 3: Find the Customers and their Orders**

**Prompt:** 
Write a LINQ query to fetch all customers and their respective orders, but only consider orders that were placed in the year 2016. Customer Name, Order Id, Order Date and Sale Rep.

<details>
<summary>Solution</summary>

```csharp
Customers
	.Select(c => new
	{
		Name = c.ContactName,
		Orders =Orders
		   .Where(o => o.CustomerID == c.CustomerID && o.OrderDate.Value.Year == 2016)
		   .Select(o =>new {
			   Id = o.OrderID,
			   Date = o.OrderDate,
			   SaleRep = o.SalesRep.FirstName + " " + o.SalesRep.LastName
		   })
	}).Dump();
```
</details>

---

