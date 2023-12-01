using ExampleFA.Contract;
using ExampleFA.Model;

namespace ExampleFA.Calculator
{
    public class SpeedyCostCalculator : ICostCalculator<CostType>
    {
        public Task CalcCost (params Parcel[] parcels)
        {
            foreach (var parcel in parcels)
            {
                var sizeCost = parcel.Costs[CostType.Default];
                // Missing default cost or not using Speedy
                if (sizeCost == null || !parcel.UseSpeedy)
                {
                    continue;
                }
                parcel.Costs.Add(CostType.Speedy, sizeCost);
            }

            return Task.CompletedTask;
        }
    }
}
