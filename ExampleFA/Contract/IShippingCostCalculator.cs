using ExampleFA.Model;

namespace ExampleFA.Contract
{
    internal interface IShippingCostCalculator
    {
        /// <summary>
        /// Update the parcel instances shipping cost after all the shipping logics
        /// </summary>
        /// <param name="parcels"></param>
        /// <returns></returns>
        Task ApplyCost (params Parcel[] parcels);

        void AddCalculator(ICostCalculator<CostType> calculator);
    }
}
