# West Wind Database LINQ Queries with Navigation Properties and Parameters

Below are five LINQ methods using the West Wind database. Each method comes with a fictional reason for needing the data, the corresponding LINQ query, and the required data models.

## 1. Get all customers from a specific country

**Scenario:** As a sales manager, you need to find all customers from a specific country to plan targeted marketing campaigns.

```csharp
public List<Customer> GetCustomersByCountry(string country);
```


<details>
<summary>LINQ Query:</summary>

```csharp
var customers = context.Customers
    .Where(c => c.Country == country)
    .ToList();
```
</details>

**Example:**

```markdown
### List all customers from the United States

| Customer ID | Company Name          | Contact Name         | Country  |
|-------------|-----------------------|----------------------|----------|
| ALFKI       | Alfreds Futterkiste   | Maria Anders         | USA      |
| ANATR       | Ana Trujillo Empared. | Ana Trujillo         | USA      |
| ...         | ...                   | ...                  | ...      |
```

## 2. Get all products with their supplier and category information

**Scenario:** As a product manager, you want to review the list of products along with their supplier and category information to better understand the product portfolio.

```csharp
public List<ProductInfo> GetAllProductsWithSuppliersAndCategories();
```

**Data Model:**

```csharp
public class ProductInfo
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string SupplierName { get; set; }
    public string CategoryName { get; set; }
}
```

<details>
<summary>LINQ Query:</summary>

```csharp
var products = context.Products
    .Select(p => new ProductInfo
    {
        ProductID = p.ProductID,
        ProductName = p.ProductName,
        SupplierName = p.Supplier.CompanyName,
        CategoryName = p.Category.CategoryName
    })
    .ToList();
```
</details>


**Example:**

```markdown
### List all products along with their supplier and category information

| Product ID | Product Name   | Supplier Name         | Category Name |
|------------|----------------|-----------------------|---------------|
| 1          | Chai           | Exotic LiquIDs        | Beverages     |
| 2          | Chang          | Exotic LiquIDs        | Beverages     |
| ...        | ...            | ...                   | ...           |
```

## 3. Get the total quantity of products sold per category

**Scenario:** As an inventory manager, you want to determine the total quantity of products sold per category to plan inventory levels accordingly.

```csharp
public List<CategorySalesInfo> GetTotalQuantitySoldByCategory();
```

**Data Model:**

```csharp
public class CategorySalesInfo
{
    public string CategoryName { get; set; }
    public int TotalQuantitySold { get; set; }
}
```

<details>
<summary>LINQ Query:</summary>

```csharp
var categorySales = context.OrderDetails
    .GroupBy(od => od.Product.Category.CategoryName)
    .Select(g => new CategorySalesInfo
    {
        CategoryName = g.Key,
        TotalQuantitySold = g.Sum(od => od.Quantity)
    })
    .ToList();
```
</details>


**Example:**

```markdown
### Total quantity of products sold per category

| Category Name | Total Quantity Sold |
|---------------|---------------------|
| Beverages     | 10000               |
| Dairy Products| 8000                |
| ...           | ...                 |
```

## 4. Get the total sales amount for each employee

**Scenario:** As a human resources manager, you want to evaluate the total sales amount for each employee to determine their performance and make decisions about bonuses or promotions.

```csharp
public List<EmployeeSalesInfo> GetTotalSalesAmountByEmployee();
```

**Data Model:**

```csharp
public class EmployeeSalesInfo
{
    public int EmployeeID { get; set; }
    public string FullName { get; set; }
    public decimal? TotalSalesAmount { get; set; }
}
```

<details>
<summary>LINQ Query:</summary>

```csharp
var employeeSales = context.Employees
    .Select(e => new EmployeeSalesInfo
    {
        EmployeeID = e.EmployeeID,
        FullName = e.FirstName + " " + e.LastName,
        TotalSalesAmount = e.Orders.Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice))
    })
    .ToList();
```
</details>


**Example:**

```markdown
### Total sales amount for each employee

| Employee ID | Full Name         | Total Sales Amount |
|-------------|-------------------|--------------------|
| 1           | Nancy Davolio     | 25000.00           |
| 2           | Andrew Fuller     | 30000.00           |
| ...         | ...               | ...                |
```

## 5. Get the top 10 most expensive products

**Scenario:** As a procurement specialist, you want to identify the top 10 most expensive products in the database to negotiate better deals with suppliers or explore alternative products.

```csharp
public List<Product> GetTop10MostExpensiveProducts();
```

<details>
<summary>LINQ Query:</summary>

```csharp
var top10Products = context.Products
    .OrderByDescending(p => p.UnitPrice)
    .Take(10)
    .ToList();
```
</details>


**Example:**

```markdown
### Top 10 most expensive products

| Product ID | Product Name          | Unit Price |
|------------|-----------------------|------------|
| 38         | Côte de Blaye         | 263.50     |
| 29         | Thüringer Rostbratwurst| 123.79     |
| ...        | ...                   | ...        |
```

Remember to replace `context` with the actual instance of your Entity Framework or LINQ to SQL context class for the West Wind database.

## Review Questions: West Wind Database LINQ Queries with Navigation Properties and Parameters

1. What is the purpose of the `GetCustomersByCountry` method and what parameter does it take?
2. How can you retrieve all products with their supplier and category information using LINQ, and which data model is used to store the result?
3. Describe the scenario in which you would use the `GetTotalQuantitySoldByCategory` method and what data model is used to store the result.
4. In the `EmployeeSalesInfo` data model, what are the properties used to store an employee's ID, full name, and the total sales amount?
5. Write a LINQ query to retrieve the top 10 most expensive products in the database.
6. What is the purpose of the `GroupBy` method in the LINQ query for the `GetTotalQuantitySoldByCategory` method?
7. How do you combine the first name and last name of an employee in the LINQ query for the `GetTotalSalesAmountByEmployee` method?
8. In the `ProductInfo` data model, what are the properties used to store the product ID, product name, supplier name, and category name?
9. How do you use LINQ to retrieve the total sales amount for each employee in the `GetTotalSalesAmountByEmployee` method?
10. What is the purpose of the `Take` method in the LINQ query for the `GetTop10MostExpensiveProducts` method?

</br>

[Readme.md](./Readme.md)
