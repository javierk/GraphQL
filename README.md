# GraphQL Example Using a DB similar to Northwind Traders

using .net core 2.1, entity framework core  with local sqlite DB and graphql.net

## Example Queries for playground  

**Example Queries using variables, aliases and fragments**

``` json
query AllSuppliersWithProducts
{
 suppliersProducts: suppliers{... Supplierfields}
}

query supplierById($supplierId: ID = 9002)
{
 supplier9002: supplier (id:$supplierId) {... Supplierfields}
}

query suppliersByCountry($country: String = "UK")
{
 suppliersUK: suppliersByCountry (country:$country) {... Supplierfields}
}

query productsList
{
  products {
    productName,
    unitPrice
  }
}

query OrdersWithItems{
  orders{
    orderNumber,
    orderDate,
    orderItems{
      productId,
      quantity,
      unitPrice
    }
  }
}

query customersWithOrders
{
  customers
  {
    firstName,
    lastName,
    city,
  	country,
    orders
    {
      orderNumber,
      orderDate
    }
  }
}

fragment Supplierfields on SupplierType
{
  companyName,
  contactName,
  contactTitle,
  city,
  country,
  phone,
  products
  {
    productName,
    package,
    unitPrice
	}
}
```

*Query Variables*

``` json
{
  "supplierId": 9002
}
```


**Example Mutation**

``` json
mutation($product:productInput!){
  createProduct(product: $product){
    id,
    productName
  }
}
```

*Query Variables*

``` json
{
  "product": {
    "productName": "test product",
    "supplierId": 9002,
    "isDiscontinued": false
  }
}
```

after executing the mutation to add a product, the supplierById for 9002 will also return this new product
