﻿using ExampleFA.Contract;
using ExampleFA.Model;
using System.Numerics;

namespace ExampleFA.Calculator
{
    public class SizeCostCalculator : ICostCalculator<Parcel, CostType>
    {
        public const decimal SMALL_PARCEL_COST = 3.0m;
        public const decimal  MEDIUM_PARCEL_COST = 8.0m;
        public const decimal  LARGE_PARCEL_COST = 15.0m;
        public const decimal  XL_PARCEL_COST = 25.0m;

        public CostType CostType => CostType.Default;

        public Task CalcCost (params Parcel[] parcels)
        {
            foreach (var parcel in parcels)
            {
                // Won't be able to calculate non-set parcel's size
                if (parcel.Dimension.Equals(Vector3.Zero))
                {
                    parcel.Costs.Add(CostType, null);
                    continue;
                }

                if (parcel.IsSmall)
                {
                    parcel.Costs.Add(CostType, SMALL_PARCEL_COST);
                }
                else if (parcel.IsMedium)
                {
                    parcel.Costs.Add(CostType, MEDIUM_PARCEL_COST);
                }
                else if (parcel.IsLarge)
                {
                    parcel.Costs.Add(CostType, LARGE_PARCEL_COST);
                }
                else if (parcel.IsXL)
                {
                    parcel.Costs.Add(CostType, XL_PARCEL_COST);
                }
                else
                {
                    // Undetermined size
                    parcel.Costs.Add(CostType, null);
                }
            }

            return Task.CompletedTask;
        }
    }
}
