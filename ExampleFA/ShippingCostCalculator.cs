using ExampleFA.Contract;
using ExampleFA.Model;

namespace ExampleFA
{
    public class ShippingCostCalculator : IShippingCostCalculator
    {
        private readonly List<ICostCalculator<CostType>> _calculators = new List<ICostCalculator<CostType>>();

        public ShippingCostCalculator (IEnumerable<ICostCalculator<CostType>> defaults)
        {
            if (defaults != null)
            {
                _calculators.AddRange(defaults);
            }
        }

        public void AddCalculator (ICostCalculator<CostType> calculator)
        {
            _calculators.Add(calculator);
        }

        public async Task ApplyCost (params Parcel[] parcels)
        {
            foreach (var calc in _calculators)
            {
                await calc.CalcCost(parcels);
            }
        }
    }
}