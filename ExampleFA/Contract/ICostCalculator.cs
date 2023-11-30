using ExampleFA.Model;

namespace ExampleFA.Contract
{
    public interface ICostCalculator<T> where T : struct, Enum
    {
        Task CalcCost (params Parcel[] parcels);
    }
}
