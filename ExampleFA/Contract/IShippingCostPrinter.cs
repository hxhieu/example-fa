using ExampleFA.Model;

namespace ExampleFA.Contract
{
    public interface IShippingCostPrinter
    {
        /// <summary>
        /// Output a generic list of costs for the given Parcel collection.
        /// This method will not need to change when adding new cost calculation.
        /// </summary>
        /// <param name="parcels"></param>
        /// <returns></returns>
        Task<Dictionary<CostType, decimal?>> PrintShippingCost (params Parcel[] parcels);
    }
}
