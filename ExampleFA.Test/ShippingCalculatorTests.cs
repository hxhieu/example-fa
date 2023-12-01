using ExampleFA.Calculator;
using ExampleFA.Contract;
using ExampleFA.Model;
using System.Numerics;

namespace ExampleFA.Test
{
    [TestClass]
    public class ShippingCalculatorTests
    {
        IEnumerable<ICostCalculator<Parcel, CostType>> _defaultCalculators = new List<ICostCalculator<Parcel, CostType>>
        {
            new SizeCostCalculator(),
            new SpeedyCostCalculator(),
             //new OverweightCostCalculator(),
        };

        [TestMethod]
        public async Task ShippingCalculator_SmallParcel_True ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var parcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(5,5,5),
            };
            var expectedCost = new Dictionary<CostType,decimal?>
            {
                { CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST },
                { CostType.Speedy, 0 },
            };
            await calc.ApplyCost(parcel);

            CollectionAssert.AreEquivalent(parcel.Costs, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_SmallParcel_WithSpeedy ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var parcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(5,5,5),
                UseSpeedy = true
            };
            var expectedCost = new Dictionary<CostType, decimal?>
            {
                {CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST },
                {CostType.Speedy, SizeCostCalculator.SMALL_PARCEL_COST }
            };
            await calc.ApplyCost(parcel);

            CollectionAssert.AreEquivalent(parcel.Costs, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_SmallParcel_NotAllDimensions ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var parcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(5,5,15),
            };
            var expectedCost = new Dictionary<CostType,decimal?>
            {
                { CostType.Default, SizeCostCalculator.MEDIUM_PARCEL_COST },
                { CostType.Speedy, 0 },
            };
            await calc.ApplyCost(parcel);

            CollectionAssert.AreEquivalent(parcel.Costs, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_MediumParcel_True ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var parcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(45,15,25),
            };
            var expectedCost = new Dictionary<CostType,decimal?>
            {
                { CostType.Default, SizeCostCalculator.MEDIUM_PARCEL_COST },
                { CostType.Speedy, 0 },
            };
            await calc.ApplyCost(parcel);

            CollectionAssert.AreEquivalent(parcel.Costs, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_LargeParcel_True ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var parcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(50,15,25),
            };
            var expectedCost = new Dictionary<CostType,decimal?>
            {
                { CostType.Default, SizeCostCalculator.LARGE_PARCEL_COST },
                { CostType.Speedy, 0 },
            };
            await calc.ApplyCost(parcel);

            CollectionAssert.AreEquivalent(parcel.Costs, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_XLParcel_True ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var parcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(110,100,50),
            };
            var expectedCost = new Dictionary<CostType,decimal?>
            {
                { CostType.Default, SizeCostCalculator.XL_PARCEL_COST },
                { CostType.Speedy, 0 },
            };
            await calc.ApplyCost(parcel);

            CollectionAssert.AreEquivalent(parcel.Costs, expectedCost);
        }
    }
}