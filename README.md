Overall Design

I split the logic into Controller, Service, and Repository layers. This follows the Single Responsibility Principle — each layer has one job. That way, if I ever change the storage mechanism, I don’t need to touch my business logic or controllers.

Controller

The controller handles incoming HTTP requests.

I used Dependency Injection to inject my service.

The field is marked readonly, which means it can only be set once in the constructor and cannot be overwritten later — this makes the code safer.

I expose two endpoints:

POST to add items

GET to retrieve the cart total.


 Service

The service is the brain of the application — it contains the business logic.

It inherits from a service interface, which defines methods like AddItem() and GetTotal().

I injected the repository into the service, so the service can use the repository methods without depending on a concrete implementation.

I used the expression-bodied syntax (=>) for one-liner methods to make the code more concise (it’s just shorthand for a normal return statement).


Repository

The repository is responsible for data storage and management.

I used a Dictionary as in-memory storage for carts.

It has three main methods:

GetCart(cartId)

Checks if a cart exists.

If not, creates a new cart and stores it in the dictionary.

Returns the cart.

AddItem(cartId, name, price, qty)

Calls GetCart() to fetch or create the cart.

Uses LINQ to check if an item with the same name and price already exists.

If it exists → update the quantity.

If not → add it as a new item.

Returns the updated cart.

GetTotal(cartId)

Calls GetCart().

Returns the Total property from the ShoppingCart model, which uses LINQ (Items.Sum(i => i.Price * i.Quantity)) to calculate the total cost.


*LINQ Choice*

I chose LINQ for calculating totals (Items.Sum(i => i.Price * i.Quantity)) because it makes the intent very clear — “sum up the total for all items.” It’s shorter and more readable than writing manual loops, and it’s easy to extend later if I need to add tax or discounts.
