using ExampleFA.Contract;
using ExampleFA.Model;

namespace ExampleFA
{
    public class ShippingCostPrinter : IShippingCostPrinter
    {
        public Task<Dictionary<string, float>> PrintShippingCost (params Parcel[] parcels)
        {
            throw new NotImplementedException();
        }
    }
}
