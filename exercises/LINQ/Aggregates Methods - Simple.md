# LINQ "Simple Aggregates Method Syntax Exercises"

### Below are some questions to help you understand LINQ's method syntax in C#. These exercises assume that you have access to the West Wind database schema provided by the instructor.<br>

NOTE: All methods are just single command to show data ie:  Table.Sum(x => x.column).Dump()

**1. How many products have a unit price greater than $50 in the Northwind database?**

<details>
<summary>Solution</summary>

```csharp
Products.Where(p => p.UnitPrice > 50).Count().Dump();
```

</details>

---

**2. What is the total quantity of all products ordered in the Northwind database?**

<details>
<summary>Solution</summary>

```csharp
OrderDetails.Sum(od => od.Quantity).Dump();
```

</details>

---

**3. What's the lowest unit price for a product in the Northwind database?**

<details>
<summary>Solution</summary>

```csharp
Products.Min(p => p.UnitPrice).Dump();
```

</details>

---

**4. What's the highest unit price for a product in the Northwind database?**


<details>
<summary>Solution</summary>

```csharp
Products.Max(p => p.UnitPrice).Dump();
```

</details>

---

**5. What is the average unit price of products in the Northwind database?**

<details>
<summary>Solution</summary>

```csharp
Products.Average(p => p.UnitPrice).Dump();
```

</details>

---

I hope these questions and their respective solutions will be beneficial for your students! If you need any more questions or topics covered, please let me know.