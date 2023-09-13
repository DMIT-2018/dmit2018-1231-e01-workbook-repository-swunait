# West Wind Database LINQ Queries with Parameters

Below are five LINQ methods using the West Wind database that include a `where` clause with parameters. Each method comes with a fictional reason for needing the data, the corresponding LINQ query, and the required data models.

## 1. Get all orders placed by a specific customer

**Scenario:** As a sales manager, you want to review all orders placed by a specific customer to analyze their purchase history and tailor special offers.

```csharp
public List<Order> GetOrdersByCustomerID(string customerID);
```

<details>
<summary>LINQ Query:</summary>

```csharp
var orders = context.Orders
    .Where(o => o.CustomerID == customerID)
    .ToList();
```
</details>

**Example:**

```markdown
### List all orders placed by customer 'ALFKI'

| Order ID | Order Date  | Customer ID |
|----------|-------------|-------------|
| 10643    | 2023-08-25  | ALFKI       |
| 10692    | 2023-10-03  | ALFKI       |
| ...      | ...         | ...         |
```

## 2. Get all products below a specified price

**Scenario:** As a procurement specialist, you want to identify all products below a specified price to target cost-saving opportunities.

```csharp
public List<Product> GetProductsBelowPrice(decimal maxPrice);
```

<details>
<summary>LINQ Query:</summary>

```csharp
var products = context.Products
    .Where(p => p.UnitPrice < maxPrice)
    .ToList();
```
</details>

**Example:**

```markdown
### List all products with a unit price below 10.00

| Product ID | Product Name   | Unit Price |
|------------|----------------|------------|
| 5          | Chef Anton's Gumbo Mix | 7.45  |
| 13         | Konbu          | 4.00       |
| ...        | ...            | ...        |
```

## 3. Get all employees with a specific title

**Scenario:** As a human resources manager, you want to retrieve all employees with a specific title to assess staffing levels for specific roles.

```csharp
public List<Employee> GetEmployeesByTitle(string title);
```

<details>
<summary>LINQ Query:</summary>

```csharp
var employees = context.Employees
    .Where(e => e.Title == title)
    .ToList();
```
</details>

**Example:**

```markdown
### List all employees with the title 'Sales Representative'

| Employee ID | Full Name         | Title                |
|-------------|-------------------|----------------------|
| 1           | Nancy Davolio     | Sales Representative |
| 3           | Janet Leverling   | Sales Representative |
| ...         | ...               | ...                  |
```

## 4. Get all suppliers from a specific region

**Scenario:** As a procurement specialist, you want to find all suppliers from a specific region to explore regional partnerships.

```csharp
public List<Supplier> GetSuppliersByRegion(string region);
```

<details>
<summary>LINQ Query:</summary>

```csharp
var suppliers = context.Suppliers
    .Where(s => s.Region == region)
    .ToList();
```
</details>

**Example:**

```markdown
### List all suppliers from the 'WA' region

| Supplier ID | Supplier Name       | Region |
|-------------|---------------------|--------|
| 1           | Exotic LiquIDs      | WA     |
| 15          | New England Seafood Cannery | WA |
| ...         | ...                 | ...    |
```

## 5. Get all customers with a specific postal code

**Scenario:** As a marketing manager, you want to identify all customers with a specific postal code to target local advertising campaigns.

```csharp
public List<Customer> GetCustomersByPostalCode(string postalCode);
```

<details>
<summary>LINQ Query:</summary>

```csharp
var customers = context.Customers
    .Where(c => c.PostalCode == postalCode)
    .ToList();
```
</details>

**Example:**

```markdown
### List all customers with the postal code '12209'

| Customer ID | Customer Name          | Postal Code |
|-------------|------------------------|-------------|
| ALFKI       | Alfreds Futterkiste    | 12209       |
| FOLKO       | Folk och fä HB         | 12209       |
| ...         | ...                    | ...         |
```

Remember to replace `context` with the actual instance of your Entity Framework or LINQ to SQL context class for the West Wind database.

# Review Questions: LINQ Queries with Parameters
1. How can you use LINQ to retrieve all orders placed by a specific customer using the `GetOrdersByCustomerID()` method?

2. What is the purpose of the `GetProductsBelowPrice()` method, and how does it utilize LINQ to filter products based on price?

3. In the `GetEmployeesByTitle()` method, how does LINQ help retrieve all employees with a specific title?

4. How does the `GetSuppliersByRegion()` method use LINQ to find suppliers from a specific region?

5. What is the main purpose of the `GetCustomersByPostalCode()` method, and how does LINQ help achieve it?

6. How does the `.Where()` function work in LINQ, and in which scenarios is it used in the examples provided?

7. What is the significance of using the `.ToList()` function at the end of each LINQ query in the provided examples?

8. How do you pass a parameter to a LINQ query, and how is it utilized in the `where` clause in the given methods?

9. In which ways can you modify the given LINQ methods to filter data based on different conditions?

10. How can you use LINQ to create projections with the filtered data in the given examples, and what would be the benefits of doing so?

</br>

[Readme.md](./Readme.md)
