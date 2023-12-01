# Assumptions
Due to the scope of this quick exercise, the following assumptions are fully aware of but will not be addressed immediately

- This library solution only does the shipping cost, otherwise it should be a separate `ExampleFA.Shipping` assembly in this solution
- Only small amount of test cases
  - Should only cover some happy paths
  - May only has one fail case, per service
- The whole process relies on the nullable `decimal?` data type to respresent the shipping cost, so if this value is `null` then the shipping has not been calculated.
- 

# Technical decisions and designs
- For now its all simple/local cost calculations but I make everything async, so it can scale easier i.e. if costs would need to be fetched from remote etc.
- I make generic cost calculators, to make it modular i.e. we can just add more cost calculations on top each other.
  - Some calculators would depend on other calculators to run before
  - For now the calculators run in the order they defined in the list
  - Could be nicer to have a way to sort the running order