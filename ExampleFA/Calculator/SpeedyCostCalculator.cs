using ExampleFA.Contract;
using ExampleFA.Model;

namespace ExampleFA.Calculator
{
    public class SpeedyCostCalculator : ICostCalculator<Parcel, CostType>
    {
        public CostType CostType => CostType.Speedy;

        public Task CalcCost (params Parcel[] parcels)
        {
            foreach (var parcel in parcels)
            {
                var sizeCost = parcel.Costs[CostType.Default];
                // Missing default cost
                if (sizeCost == null)
                {
                    parcel.Costs.Add(CostType, null);
                    continue;
                }
                // Make sure the calculator always populate the CostType.Speedy
                parcel.Costs.Add(CostType, parcel.UseSpeedy ? sizeCost : 0);
            }

            return Task.CompletedTask;
        }
    }
}
