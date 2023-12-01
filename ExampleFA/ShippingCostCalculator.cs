using ExampleFA.Contract;
using ExampleFA.Model;

namespace ExampleFA
{
    public class ShippingCostCalculator : IShippingCostCalculator
    {
        private readonly List<ICostCalculator<Parcel>> _parcelCalculators = new List<ICostCalculator<Parcel>>();

        public ShippingCostCalculator (IEnumerable<ICostCalculator<Parcel>> parcelDefaults)
        {
            if (parcelDefaults != null)
            {
                _parcelCalculators.AddRange(parcelDefaults);
            }
        }

        public void AddCalculator (ICostCalculator<Parcel> calculator)
        {
            _parcelCalculators.Add(calculator);
        }

        public async Task ApplyCost (params Parcel[] parcels)
        {
            foreach (var calc in _parcelCalculators)
            {
                await calc.CalcCost(parcels);
            }
        }
    }
}