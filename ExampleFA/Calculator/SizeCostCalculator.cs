using ExampleFA.Contract;
using ExampleFA.Model;
using System.Numerics;

namespace ExampleFA.Calculator
{
    public class SizeCostCalculator : ICostCalculator<CostType>
    {
        const decimal SMALL_PARCEL_COST = 3.0m;
        const decimal MEDIUM_PARCEL_COST = 8.0m;
        const decimal LARGE_PARCEL_COST = 15.0m;
        const decimal XL_PARCEL_COST = 25.0m;

        public Task CalcCost (params Parcel[] parcels)
        {
            foreach (var parcel in parcels)
            {
                var costLayout = new KeyValuePair<CostType, decimal?> (CostType.Default, null);
                
                // Won't be able to calculate non-set parcel's size
                if (parcel.Dimension.Equals(Vector3.Zero))
                {
                    continue;
                }

                if (parcel.IsSmall)
                {
                    parcel.ShippingCost = SMALL_PARCEL_COST;
                }
                else if (parcel.IsMedium)
                {
                    parcel.ShippingCost = MEDIUM_PARCEL_COST;
                }
                else if (parcel.IsLarge)
                {
                    parcel.ShippingCost = LARGE_PARCEL_COST;
                }
                else if (parcel.IsXL)
                {
                    parcel.ShippingCost = XL_PARCEL_COST;
                }
            }
            
            return Task.CompletedTask;
        }
    }
}
