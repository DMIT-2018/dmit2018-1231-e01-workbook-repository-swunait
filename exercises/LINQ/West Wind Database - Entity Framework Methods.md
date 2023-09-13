# Entity Framework Methods using West Wind Database

This document contains six Entity Framework methods for interacting with the West Wind Database. Each method has a fictional reason for being needed, and the corresponding LINQ queries and data models are provided where necessary.

For the purpose of demonstrating real-world data, let's assume that the West Wind Database contains a table called `Products` with the following columns: `ProductId`, `ProductName`, `SupplierId`, `CategoryId`, `QuantityPerUnit`, `UnitPrice`, `UnitsInStock`, `UnitsOnOrder`, `ReorderLevel`, and `Discontinued`. 

**NOTE:  You can run the LINQ statements in LINQPad.  You will just need to remove the "using (var context = new WestWindContext())".  To run the code in LINQPad, you could run the following coding example base on the C# code found in method #1**

```csharp
var newProduct = new Product
        {
            ProductName = "Organic Honey",
            SupplierID = 5,
            CategoryID = 2,
            QuantityPerUnit = "12 jars per box",
            UnitPrice = 15.00m,
            UnitsInStock = 25,
            UnitsOnOrder = 0,
            ReorderLevel = 10,
            Discontinued = false
        };

context.Products.Add(newProduct);
context.SaveChanges();
```



## 1. Add a New Product

**Fictional reason**: A new product, "Organic Honey", is being added to the inventory and needs to be added to the database.

```csharp
public void AddNewProduct()
{
    using (var context = new WestWindContext())
    {
        var newProduct = new Product
        {
            ProductName = "Organic Honey",
            SupplierID = 5,
            CategoryID = 2,
            QuantityPerUnit = "12 jars per box",
            UnitPrice = 15.00m,
            UnitsInStock = 25,
            UnitsOnOrder = 0,
            ReorderLevel = 10,
            Discontinued = false
        };

        context.Products.Add(newProduct);
        context.SaveChanges();
    }
}
```

**Data model**:

```csharp
public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int SupplierID { get; set; }
    public int CategoryID { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public int UnitsOnOrder { get; set; }
    public int ReorderLevel { get; set; }
    public bool Discontinued { get; set; }
}
```

## 2. Update Product Price

**Fictional reason**: The price of the product "Organic Honey" has changed from $15.00 to $17.00 and needs to be updated in the database.

```csharp
public void UpdateProductPrice(int productId, decimal newPrice)
{
    using (var context = new WestWindContext())
    {
        var product = context.Products.SingleOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
            product.UnitPrice = newPrice;
            context.SaveChanges();
        }
    }
}

// Usage
UpdateProductPrice(1, 17.00m); // Assuming the ProductID of Organic Honey is 1
```

## 3. Add a New Category

**Fictional reason**: A new category, "Superfoods", is being introduced and needs to be added to the database.

```csharp
public void AddNewCategory()
{
    using (var context = new WestWindContext())
    {
        var newCategory = new Category
        {
            CategoryName = "Superfoods",
            Description = "Nutrient-rich foods considered to be especially beneficial for health and well-being"
        };

        context.Categories.Add(newCategory);
        context.SaveChanges();
    }
}
```

**Data model**:

```csharp
public class Category
{
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
```

## 4. Update Supplier Information

**Fictional reason**: The contact person and phone number for a supplier have changed and need to be updated in the database.

```csharp
public void UpdateSupplierContactInfo(int supplierId, string newContactName, string newPhoneNumber)
{
    using (var context = new WestWindContext())
    {
        var supplier = context.Suppliers.SingleOrDefault(s => s.SupplierID == supplierId);
        if (supplier != null)
        {
            supplier.ContactName = newContactName;
            supplier.Phone = newPhoneNumber;
            context.SaveChanges();
        }
    }
}

// Usage
UpdateSupplierContactInfo(5, "John Doe", "555-1234"); // Assuming the SupplierID of the supplier is 5
```

**Data model**:

```csharp
public class Supplier
{
    public int SupplierID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string HomePage { get; set; }
}
```

## 5. Update Order Status

**Fictional reason**: The order for "Organic Honey" has been shipped, and the order status and shipping date need to be updated in the database.

```csharp
public void UpdateOrderStatus(int orderId, DateTime shippedDate)
{
    using (var context = new WestWindContext())
    {
        var order = context.Orders.SingleOrDefault(o => o.OrderID == orderId);
        if (order != null)
        {
            order.ShippedDate = shippedDate;
            context.SaveChanges();
        }
    }
}

// Usage
UpdateOrderStatus(10248, DateTime.Now); // Assuming the OrderID of the Organic Honey order is 10248
```

**Data models**:

```csharp
public class Order
{
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int? EmployeeID { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public int? ShipVia { get; set; }
    public decimal? Freight { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }
}
```

## 6. Add a New Employee

**Fictional reason**: A new employee, Jane Doe, is joining the company and her information needs to be added to the database.

```csharp
public void AddNewEmployee()
{
    using (var context = new WestWindContext())
    {
        var newEmployee = new Employee
        {
            LastName = "Doe",
            FirstName = "Jane",
            Title = "Sales Representative",
            TitleOfCourtesy = "Ms.",
            BirthDate = new DateTime(1990, 5, 15),
            HireDate = DateTime.Now,
            Address = "5678 Oak St",
            City = "Los Angeles",
            Region = "CA",
            PostalCode = "90001",
            Country = "USA",
            HomePhone = "555-5678",
            Extension = "123",
            Notes = "New sales representative",
            ReportsTo = 3 // Assuming Jane reports to an employee with EmployeeID 3
        };

        context.Employees.Add(newEmployee);
        context.SaveChanges();
    }
}
```

**Data model**:

```csharp
public class Employee
{
    public int EmployeeID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
    public string TitleOfCourtesy { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? HireDate { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string HomePhone { get; set; }
    public string Extension { get; set; }
    public byte[] Photo { get; set; }
    public string Notes { get; set; }
    public int? ReportsTo { get; set; }
    public string PhotoPath { get; set; }
}
```

These methods show how to perform various operations such as adding new records and updating existing records using Entity Framework in a real-world context, with sample data from a fictional West Wind Database.

## Review Questions - West Wind Database using Entity Framework Methods

1. What is the purpose of the `using` statement in the provided Entity Framework methods?
2. How do you add a new record to the database using Entity Framework?
3. How do you update an existing record in the database using Entity Framework?
4. How do you perform a single record lookup using LINQ and Entity Framework?
5. In the example provided, what method is used to save changes to the database?
6. What is the difference between `SingleOrDefault` and `FirstOrDefault` LINQ methods when querying the database?
7. Can you briefly explain the purpose of navigation properties in Entity Framework data models?
8. When updating a record, if the record is not found in the database, what should the method do?
9. How do you remove a record from the database using Entity Framework? (Not shown in examples)
10. What is the advantage of using Entity Framework and LINQ for database operations compared to writing raw SQL queries?

</br>

[Readme.md](./Readme.md)
