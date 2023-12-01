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
            new OverweightCostCalculator(),
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
                { CostType.Overweight, null }, // Weight not set, expect no overwight cost set as well
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
                { CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST },
                { CostType.Speedy, SizeCostCalculator.SMALL_PARCEL_COST },
                { CostType.Overweight, null }, // Weight not set, expect no overwight cost set as well
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
                { CostType.Overweight, null }, // Weight not set, expect no overwight cost set as well
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
                { CostType.Overweight, null }, // Weight not set, expect no overwight cost set as well
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
                { CostType.Overweight, null }, // Weight not set, expect no overwight cost set as well
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
                { CostType.Overweight, null }, // Weight not set, expect no overwight cost set as well
            };

            await calc.ApplyCost(parcel);

            CollectionAssert.AreEquivalent(parcel.Costs, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_XLParcel_Overweight_Charge ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            // 10kg overweight
            var overweightKgs = 10.0f;
            var parcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(110,100,50),
                Weight = OverweightCostCalculator.MAX_WEIGHT_XL + overweightKgs, 
            };
            var expectedCost = new Dictionary<CostType,decimal?>
            {
                { CostType.Default, SizeCostCalculator.XL_PARCEL_COST },
                { CostType.Speedy, 0 },
                { CostType.Overweight, OverweightCostCalculator.COST_PER_KG_OVERWEIGHT * (decimal)overweightKgs },
            };

            await calc.ApplyCost(parcel);

            CollectionAssert.AreEquivalent(parcel.Costs, expectedCost);
        }

        [TestMethod]
        public async Task ShippingCalculator_XLParcel_Overweight_NoCharge ()
        {
            var calc = new ShippingCostCalculator(_defaultCalculators);
            var parcel = new Parcel
            {
                Id = Guid.NewGuid().ToString(),
                Dimension = new Vector3(110,100,50),
                Weight = OverweightCostCalculator.MAX_WEIGHT_XL - 2, // Less than weight limit, i.e. no charge
            };
            var expectedCost = new Dictionary<CostType,decimal?>
            {
                { CostType.Default, SizeCostCalculator.XL_PARCEL_COST },
                { CostType.Speedy, 0 },
                { CostType.Overweight, 0 }, // No charge
            };

            await calc.ApplyCost(parcel);

            CollectionAssert.AreEquivalent(parcel.Costs, expectedCost);
        }
    }
}