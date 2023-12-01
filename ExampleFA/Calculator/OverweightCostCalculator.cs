using ExampleFA.Contract;
using ExampleFA.Model;

namespace ExampleFA.Calculator
{
    public class OverweightCostCalculator : ICostCalculator<Parcel, CostType>
    {
        const float MAX_WEIGHT_SMALL = 1.0f;
        const float MAX_WEIGHT_MEDIUM = 3.0f;
        const float MAX_WEIGHT_LARGE = 6.0f;
        const float MAX_WEIGHT_XL = 10.0f;

        public CostType CostType => CostType.Overweight;

        public Task CalcCost (params Parcel[] parcels)
        {
            foreach (var parcel in parcels)
            {
                // Weight not set
                if (parcel.Weight == null)
                {
                    parcel.Costs[CostType] = null;
                }
            }

            return Task.CompletedTask;
        }
    }
}
