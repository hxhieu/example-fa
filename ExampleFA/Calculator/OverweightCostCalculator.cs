using ExampleFA.Contract;
using ExampleFA.Model;
using System.Numerics;

namespace ExampleFA.Calculator
{
    public class OverweightCostCalculator : ICostCalculator<Parcel, CostType>
    {
        const float MAX_WEIGHT_SMALL = 1.0f;
        const float MAX_WEIGHT_MEDIUM = 3.0f;
        const float MAX_WEIGHT_LARGE = 6.0f;
        const float MAX_WEIGHT_XL = 10.0f;

        const decimal COST_PER_KG_OVERWEIGHT = 2.0m;

        public CostType CostType => CostType.Overweight;

        public Task CalcCost (params Parcel[] parcels)
        {
            foreach (var parcel in parcels)
            {
                // Weight not set or size not set
                if (parcel.Weight == null || parcel.Dimension.Equals(Vector3.Zero))
                {
                    parcel.Costs[CostType] = null;
                    continue;
                }

                // Calc overweight
                float? overweightKgs = null;
                if (parcel.IsSmall)
                {
                    overweightKgs = MAX_WEIGHT_SMALL - parcel.Weight;
                }
                else if (parcel.IsMedium)
                {
                    overweightKgs = MAX_WEIGHT_MEDIUM - parcel.Weight;
                }
                else if (parcel.IsLarge)
                {
                    overweightKgs = MAX_WEIGHT_LARGE - parcel.Weight;
                }
                else if (parcel.IsXL)
                {
                    overweightKgs = MAX_WEIGHT_XL - parcel.Weight;
                }

                // Finally the overweight cost
                parcel.Costs[CostType] = overweightKgs != null ? (decimal?)overweightKgs * COST_PER_KG_OVERWEIGHT : null;
            }

            return Task.CompletedTask;
        }
    }
}
