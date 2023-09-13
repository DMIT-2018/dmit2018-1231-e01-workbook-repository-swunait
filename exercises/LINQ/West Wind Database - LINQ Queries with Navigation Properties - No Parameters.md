# West Wind Database LINQ Queries with Navigation Properties - No Parameters

Below are five LINQ methods using the West Wind database that include joins between tables. Each method comes with a fictional reason for needing the data, the corresponding LINQ query, and the required data models.

## 1. Get all orders with customer and employee information

**Scenario:** As a sales manager, you want to review all orders along with the customer and employee information to analyze the sales performance and customer relations.

```csharp
public List<OrderInfo> GetAllOrdersWithCustomerAndEmployeeInfo();
```

**Data Model:**

```csharp
public class OrderInfo
{
    public int OrderID { get; set; }
    public DateTime? OrderDate { get; set; }
    public string CustomerName { get; set; }
    public string EmployeeName { get; set; }
}
```

<details>
<summary>LINQ Query:</summary>

```csharp
var orders = context.Orders
    .Select(o => new OrderInfo
    {
        OrderID = o.OrderID,
        OrderDate = o.OrderDate,
        CustomerName = o.Customer.CompanyName,
        EmployeeName = o.Employee.FirstName + " " + o.Employee.LastName
    })
    .ToList();
```
</details>


**Example:**

```markdown
### List all orders with customer and employee information

| Order ID | Order Date  | Customer Name          | Employee Name     |
|----------|-------------|------------------------|-------------------|
| 10248    | 2023-07-04  | Vins et alcools Chevalier | Nancy Davolio  |
| 10249    | 2023-07-05  | Toms Spezialitäten       | Andrew Fuller   |
| ...      | ...         | ...                      | ...             |
```

## 2. Get products with their total sales amount

**Scenario:** As a product manager, you want to analyze the total sales amount for each product to determine their popularity and profitability.

```csharp
public List<ProductSalesInfo> GetProductsWithTotalSalesAmount();
```

**Data Model:**

```csharp
public class ProductSalesInfo
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal TotalSalesAmount { get; set; }
}
```

<details>
<summary>LINQ Query:</summary>

```csharp
var productSales = context.Products
    .Select(p => new ProductSalesInfo
    {
        ProductID = p.ProductID,
        ProductName = p.ProductName,
        TotalSalesAmount = p.OrderDetails.Sum(od => od.Quantity * od.UnitPrice)
    })
    .ToList();
```
</details>


**Example:**

```markdown
### Total sales amount for each product

| Product ID | Product Name   | Total Sales Amount |
|------------|----------------|--------------------|
| 1          | Chai           | 20000.00           |
| 2          | Chang          | 18000.00           |
| ...        | ...            | ...                |
```

## 3. Get suppliers and the total number of products they supply

**Scenario:** As a procurement specialist, you want to determine the number of products each supplier provides to assess their importance and potential for negotiating better deals.

```csharp
public List<SupplierProductCountInfo> GetSuppliersWithProductCount();
```

**Data Model:**

```csharp
public class SupplierProductCountInfo
{
    public int SupplierID { get; set; }
    public string SupplierName { get; set; }
    public int ProductCount { get; set; }
}
```

<details>
<summary>LINQ Query:</summary>

```csharp
var suppliersWithProductCount = context.Suppliers
    .Select(s => new SupplierProductCountInfo
    {
        SupplierID = s.SupplierID,
        SupplierName = s.CompanyName,
        ProductCount = s.Products.Count()
    })
    .ToList();
```
</details>


**Example:**

```markdown
### List of suppliers and the total number of products they supply

| Supplier ID | Supplier Name       | Product Count |
|-------------|---------------------|---------------|
| 1           | Exotic LiquIDs      | 3             |
| 2           | New Orleans Cajun Delights | 5     |
| ...         | ...                 | ...           |
```

## 4. Get customers and their total orders

**Scenario:** As a customer relations manager, you want to identify the total number of orders placed by each customer to determine their value and tailor special offers accordingly.

```csharp
public List<CustomerOrderCountInfo> GetCustomersWithTotalOrders();
```

**Data Model:**

```csharp
public class CustomerOrderCountInfo
{
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
    public int TotalOrders { get; set; }
}
```

<details>
<summary>LINQ Query:</summary>

```csharp
var customersWithTotalOrders = context.Customers
    .Select(c => new CustomerOrderCountInfo
    {
        CustomerID = c.CustomerID,
        CustomerName = c.CompanyName,
        TotalOrders = c.Orders.Count()
    })
    .ToList();
```
</details>


**Example:**

```markdown
### List of customers and their total orders

| Customer ID | Customer Name          | Total Orders |
|-------------|------------------------|--------------|
| ALFKI       | Alfreds Futterkiste    | 6            |
| ANATR       | Ana Trujillo Empared.  | 4            |
| ...         | ...                    | ...          |
```

## 5. Get employees and the total number of customers they support

**Scenario:** As a human resources manager, you want to analyze the number of customers each employee supports to evaluate their workload and determine if additional staff is needed.

```csharp
public List<EmployeeCustomerCountInfo> GetEmployeesWithCustomerCount();
```

**Data Model:**

```csharp
public class EmployeeCustomerCountInfo
{
    public int EmployeeID { get; set; }
    public string FullName { get; set; }
    public int CustomerCount { get; set; }
}
```

<details>
<summary>LINQ Query:</summary>

```csharp
var employeesWithCustomerCount = context.Employees
    .Select(e => new EmployeeCustomerCountInfo
    {
        EmployeeID = e.EmployeeID,
        FullName = e.FirstName + " " + e.LastName,
        CustomerCount = e.Orders.Select(o => o.CustomerID).Distinct().Count()
    })
    .ToList();
```
</details>


**Example:**

```markdown
### List of employees and the total number of customers they support

| Employee ID | Full Name         | Customer Count |
|-------------|-------------------|----------------|
| 1           | Nancy Davolio     | 45             |
| 2           | Andrew Fuller     | 50             |
| ...         | ...               | ...            |
```

Remember to replace `context` with the actual instance of your Entity Framework or LINQ to SQL context class for the West Wind database.

## Review Questions: West Wind Database LINQ Queries with Navigation Properties - No Parameters
1. What is the purpose of the `GetAllOrdersWithCustomerAndEmployeeInfo()` method and which data model does it use?
   
2. How does the `GetProductsWithTotalSalesAmount()` method calculate the total sales amount for each product?
   
3. How can you use LINQ to determine the number of products provided by each supplier in the `GetSuppliersWithProductCount()` method?
   
4. How can you use LINQ to identify the total number of orders placed by each customer in the `GetCustomersWithTotalOrders()` method?
   
5. In the `GetEmployeesWithCustomerCount()` method, how does LINQ help analyze the number of customers supported by each employee?
   
6. What is the main purpose of the `.Select()` function in LINQ, and how is it used in each of the given methods?
   
7. How does the `.Count()` function work in LINQ, and in which scenarios is it used in the examples provided?
   
8. In the `GetEmployeesWithCustomerCount()` method, how is the `.Distinct()` function used, and what is its purpose?
   
9. In the `GetAllOrdersWithCustomerAndEmployeeInfo()` method, how does LINQ create a projection to include the customer and employee names?
   
10. What is the significance of using the `.ToList()` function at the end of each LINQ query in the provided examples?

</br>

[Readme.md](./Readme.md)
