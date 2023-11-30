# Assumptions
Due to the scope of this quick exercise, the following assumptions are fully aware of but will not be addressed immediately

- This library solution only does the shipping cost, otherwise it should be a separate `ExampleFA.Shipping` assembly in this solution
- Only small amount of test cases
  - Should only cover some happy paths
  - May only has one fail case, per service
- The whole process relies on the nullable `decimal?` data type to respresent the shipping cost, so if this value is `null` then the shipping has not been calculated.