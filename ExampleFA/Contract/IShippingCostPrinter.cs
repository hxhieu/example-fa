using ExampleFA.Model;

namespace ExampleFA.Contract
{
    public interface IShippingCostPrinter
    {
        /// <summary>
        /// Print the consistent outputs of the shipping cost, regardless how it was calculated
        /// </summary>
        /// <param name="parcels"></param>
        /// <returns></returns>
        Task<Dictionary<string, float>> PrintShippingCost (params Parcel[] parcels);
    }
}
