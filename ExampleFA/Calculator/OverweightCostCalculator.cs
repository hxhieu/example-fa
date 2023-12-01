using ExampleFA.Contract;
using ExampleFA.Model;
using System.Numerics;

namespace ExampleFA.Calculator
{
    public class OverweightCostCalculator : ICostCalculator<Parcel, CostType>
    {
        public const float MAX_WEIGHT_SMALL = 1.0f;
        public const float MAX_WEIGHT_MEDIUM = 3.0f;
        public const float MAX_WEIGHT_LARGE = 6.0f;
        public const float MAX_WEIGHT_XL = 10.0f;

        public const decimal COST_PER_KG_OVERWEIGHT = 2.0m;

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
                    overweightKgs = parcel.Weight - MAX_WEIGHT_SMALL;
                }
                else if (parcel.IsMedium)
                {
                    overweightKgs = parcel.Weight - MAX_WEIGHT_MEDIUM;
                }
                else if (parcel.IsLarge)
                {
                    overweightKgs = parcel.Weight - MAX_WEIGHT_LARGE;
                }
                else if (parcel.IsXL)
                {
                    overweightKgs = parcel.Weight - MAX_WEIGHT_XL;
                }

                // Not overweight, not charge
                if (overweightKgs < 0)
                {
                    overweightKgs = 0;
                }

                // Finally the overweight cost
                parcel.Costs[CostType] = overweightKgs != null ? (decimal?)overweightKgs * COST_PER_KG_OVERWEIGHT : null;
            }

            return Task.CompletedTask;
        }
    }
}
