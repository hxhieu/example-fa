using ExampleFA.Contract;
using ExampleFA.Model;

namespace ExampleFA.Calculator
{
    public class DiscountCostCalculator : ICostCalculator<Parcel, CostType>
    {
        public const decimal HARD_CODE_DISCOUNT = 4.5m;

        public CostType CostType => CostType.Discount;

        public Task CalcCost (params Parcel[] items)
        {
            foreach (var item in items)
            {
                // Just an example how we could keep adding more calculator
                item.Costs[CostType] = HARD_CODE_DISCOUNT;
            }
            return Task.CompletedTask;
        }
    }
}
