# LINQ "Complex Aggregates Method Syntax Exercises"

### Below are some questions to help you understand LINQ's method syntax in C#. These exercises assume that you have access to the West Wind database schema provided by the instructor.


### Question 1:
Show the following "Order" information.  OrderID, Order Details Line Count, Average Line Price (Qty * Price).  Order by OrderID 

<details>
  <summary>Solution</summary>

```csharp
Orders
	.OrderBy(o => o.OrderID)
	.Select(o => new
	{
	   ID = o.OrderID,
	   LineCount = o.OrderDetails.Count(),
	   AverageLinePrice = o.OrderDetails.Average(o => o.UnitPrice * o.Quantity)
	}).Dump();
```
</details>

---

### Question 2:
Show the following "Customer" information.  Name, Average Order Amount, Max and Min Order Amount. 
You will need to use the **Ternary Operator** when do min and max to see if there are any orders to process.


<details>
  <summary>Solution</summary>

```csharp
Customers
	.OrderBy(x => x.CompanyName)
	.Select(x => new
	{
		Name = x.CompanyName,
		OrderCount = x.Orders.Count(),
		AverageOrder = x.Orders.Count() > 0
		? x.Orders.Average(x => x.OrderDetails.Sum(od => od.Quantity * od.UnitPrice))
		: 0,
		MaxOrder = x.Orders.Count() > 0
		? x.Orders.Max(x => x.OrderDetails.Sum(od => od.Quantity * od.UnitPrice))
		: 0,
		MinOrder = x.Orders.Count() > 0
		? x.Orders.Min(x => x.OrderDetails.Sum(od => od.Quantity * od.UnitPrice))
		: 0

	}).Dump();
```
</details>

---