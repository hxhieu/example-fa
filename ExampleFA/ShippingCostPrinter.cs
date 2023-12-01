using ExampleFA.Contract;
using ExampleFA.Model;

namespace ExampleFA
{
    public class ShippingCostPrinter : IShippingCostPrinter
    {
        public Task<Dictionary<CostType, decimal?>> PrintShippingCost (params Parcel[] parcels)
        {
            var total = new Dictionary<CostType, decimal?>();
            foreach (var item in parcels)
            {
                foreach (var cost in item.Costs)
                {
                    // If one item has the invalid cost, then the whole Total is also invalid
                    if (cost.Value == null)
                    {
                        total[cost.Key] = null;
                        break;
                    }

                    var nextValue = cost.Value;
                    if (total.ContainsKey(cost.Key))
                    {
                        nextValue += total[cost.Key];
                    }

                    total[cost.Key] = nextValue;
                }
            }
            return Task.FromResult(total);
        }
    }
}
