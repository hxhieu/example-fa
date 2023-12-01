# Assumptions
Due to the scope of this quick exercise, the following assumptions are fully aware of but will not be addressed immediately

- This library solution only does the shipping cost, otherwise it should be a separate `ExampleFA.Shipping` assembly in this solution
- Only small amount of test cases
  - Should only cover some happy paths
  - May only has one fail case, per service
- The whole process relies on the nullable `decimal?` data type to respresent the shipping cost, so if this value is `null` then the shipping has not been calculated.

# Technical decisions and designs
- To get the required outputs, the consumers can
  - Call `IShippingCostCalculator.ApplyCost` on top of the `list of items`, to calculate their associated cost component
  - Then call `IShippingCostPrinter.PrintShippingCost` to get the `total shipping cost`, of the above items
- For now its all simple/local cost calculations but I make everything async, so it can scale easier i.e. if costs would need to be fetched from remote etc.
- I make generic cost calculators, to make it modular i.e. we can just add more cost calculations on top each other.
  - Some calculators would depend on other calculators to run before
  - For now the calculators run in the order they defined in the list
  - Could be nicer to have a way to sort the running order

# Improvements
- Probably introduce an `Order` class, to group the `Parcel`
- Also then we can have a new `ICostCalculator<Order, OrderType>` implementation
  - So that we can apply logic on the whole order as well