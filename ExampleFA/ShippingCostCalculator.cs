using ExampleFA.Contract;
using ExampleFA.Model;
using System.Numerics;

namespace ExampleFA
{
    public class ShippingCostCalculator : IShippingCostCalculator
    {
        public Task ApplyCost (params Parcel[] parcels)
        {
            foreach (var parcel in parcels)
            {
                // Won't be able to calculate non-set parcel's size
                if (parcel.Dimension.Equals(Vector3.Zero))
                {
                    continue;
                }

                if (parcel.IsSmall)
                {
                    parcel.ShippingCost = 3.0m;
                }
                else if (parcel.IsMedium)
                {
                    parcel.ShippingCost = 8.0m;
                }
                else if (parcel.IsLarge)
                {
                    parcel.ShippingCost = 15.0m;
                }
                else if (parcel.IsXL)
                {
                    parcel.ShippingCost = 25.0m;
                }
            }

            return Task.CompletedTask;
        }
    }
}