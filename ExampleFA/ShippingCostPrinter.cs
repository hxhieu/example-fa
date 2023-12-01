using ExampleFA.Contract;
using ExampleFA.Model;

namespace ExampleFA
{
    public class ShippingCostPrinter : IShippingCostPrinter
    {
        public Task<ShippingCostLayout> PrintShippingCost (params Parcel[] parcels)
        {
            return Task.FromResult(new ShippingCostLayout
            {
                //Items = parcels.ToDictionary(x => x.Id, x => x.ShippingCost)
            });
        }
    }
}
