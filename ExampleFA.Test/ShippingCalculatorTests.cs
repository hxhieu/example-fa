using ExampleFA.Calculator;
using ExampleFA.Contract;
using ExampleFA.Model;
using System.Numerics;

namespace ExampleFA.Test
{
    [TestClass]
    public class ShippingCalculatorTests
    {
        IEnumerable<ICostCalculator<CostType>> _defaultCalculators = new List<ICostCalculator<CostType>>
        {
            new SizeCostCalculator(),
            new SpeedyCostCalculator(),
        };

        [TestMethod]
        public async Task ShippingCalculator_SmallParcel_True ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var smallParcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(5,5,5),
            };
            var expectedCost = 3.0m;
            await calc.ApplyCost(smallParcel);

            Assert.AreEqual(smallParcel.ShippingCost, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_SmallParcel_WithSpeedy ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var smallParcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(5,5,5),
                UseSpeedy = true
            };
            var expectedCost = new Dictionary<CostType, decimal?>
            {
                {CostType.Default, 3.0m },
                {CostType.Speedy, 3.0m }
            };
            await calc.ApplyCost(smallParcel);

            CollectionAssert.AreEquivalent(smallParcel.Costs, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_SmallParcel_NotAllDimensions ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var smallParcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(5,5,15),
            };
            var expectedCost = 3.0m;
            await calc.ApplyCost(smallParcel);

            Assert.AreNotEqual(smallParcel.ShippingCost, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_MediumParcel_True ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var smallParcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(45,15,25),
            };
            var expectedCost = 8.0m;
            await calc.ApplyCost(smallParcel);

            Assert.AreEqual(smallParcel.ShippingCost, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_LargeParcel_True ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var smallParcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(50,15,25),
            };
            var expectedCost = 15.0m;
            await calc.ApplyCost(smallParcel);

            Assert.AreEqual(smallParcel.ShippingCost, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_XLParcel_True ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var smallParcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(110,100,50),
            };
            var expectedCost = 25.0m;
            await calc.ApplyCost(smallParcel);

            Assert.AreEqual(smallParcel.ShippingCost, expectedCost);
        }
    }
}