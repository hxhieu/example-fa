using ExampleFA.Contract;
using ExampleFA.Model;

namespace ExampleFA.Calculator
{
    public class OverweightCostCalculator : ICostCalculator<Parcel>
    {
        public Task CalcCost (params Parcel[] parcels)
        {
            throw new NotImplementedException();
        }
    }
}
