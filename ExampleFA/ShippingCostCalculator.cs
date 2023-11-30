using ExampleFA.Contract;
using ExampleFA.Model;

namespace ExampleFA
{
    public class ShippingCostCalculator : IShippingCostCalculator
    {
        public Task ApplyCost (params Parcel[] parcels)
        {
            throw new NotImplementedException();
        }
    }
}