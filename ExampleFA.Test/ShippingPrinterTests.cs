using ExampleFA.Calculator;
using ExampleFA.Model;

namespace ExampleFA.Test
{
    [TestClass]
    public class ShippingPrinterTests
    {
        [TestMethod]
        public async Task ShippingPrinter_3Small_NoSpeedy ()
        {
            var printer = new ShippingCostPrinter();
            // 3 small parcels, assume already gone through the calculator correctly
            var parcels = new Parcel[]
            {
                new Parcel
                {
                    Id = "id-1",
                    Costs = new Dictionary<CostType, decimal?>
                    {
                        { CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST }
                    }
                },
                new Parcel
                {
                    Id = "id-2",
                    Costs = new Dictionary<CostType, decimal?>
                    {
                        { CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST }
                    }
                },
                new Parcel
                {
                    Id = "id-3",
                    Costs = new Dictionary<CostType, decimal?>
                    {
                        { CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST }
                    }
                }
            };

            var expectedOutput = new Dictionary<CostType, decimal?>
            {
                { CostType.Default, 3 * SizeCostCalculator.SMALL_PARCEL_COST },
            };

            var actualOutput = await printer.PrintShippingCost(parcels);

            CollectionAssert.AreEquivalent(actualOutput, expectedOutput);
        }

        [TestMethod]
        public async Task ShippingPrinter_3Small_WithSpeedy ()
        {
            var printer = new ShippingCostPrinter();
            // 3 small parcels, using Speedy shipping, assume already gone through the calculator correctly
            var parcels = new Parcel[]
            {
                new Parcel
                {
                    Id = "id-1",
                    UseSpeedy = true,
                    Costs = new Dictionary<CostType, decimal?>
                    {
                        { CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST },
                        { CostType.Speedy, SizeCostCalculator.SMALL_PARCEL_COST }
                    }
                },
                new Parcel
                {
                    Id = "id-2",
                    UseSpeedy = true,
                    Costs = new Dictionary<CostType, decimal?>
                    {
                        { CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST },
                        { CostType.Speedy, SizeCostCalculator.SMALL_PARCEL_COST }
                    }
                },
                new Parcel
                {
                    Id = "id-3",
                    UseSpeedy = true,
                    Costs = new Dictionary<CostType, decimal?>
                    {
                        { CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST },
                        { CostType.Speedy, SizeCostCalculator.SMALL_PARCEL_COST }
                    }
                }
            };

            var expectedOutput = new Dictionary<CostType, decimal?>
            {
                // Result should show both costs, separate from each other
                { CostType.Default, 3 * SizeCostCalculator.SMALL_PARCEL_COST },
                { CostType.Speedy, 3 * SizeCostCalculator.SMALL_PARCEL_COST },
            };

            var actualOutput = await printer.PrintShippingCost(parcels);

            CollectionAssert.AreEquivalent(actualOutput, expectedOutput);
        }

        [TestMethod]
        public async Task ShippingPrinter_3Small_WithInvalidSpeedy ()
        {
            var printer = new ShippingCostPrinter();
            // 3 small parcels, one not using Speedy, assume already gone through the calculator correctly
            var parcels = new Parcel[]
            {
                new Parcel
                {
                    Id = "id-1",
                    UseSpeedy = false,
                    Costs = new Dictionary<CostType, decimal?>
                    {
                        { CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST },
                        // This has no Speedy cost calculated
                        { CostType.Speedy, null }
                    }
                },
                new Parcel
                {
                    Id = "id-2",
                    UseSpeedy = true,
                    Costs = new Dictionary<CostType, decimal?>
                    {
                        { CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST },
                        { CostType.Speedy, SizeCostCalculator.SMALL_PARCEL_COST }
                    }
                },
                new Parcel
                {
                    Id = "id-3",
                    UseSpeedy = true,
                    Costs = new Dictionary<CostType, decimal?>
                    {
                        { CostType.Default, SizeCostCalculator.SMALL_PARCEL_COST },
                        { CostType.Speedy, SizeCostCalculator.SMALL_PARCEL_COST }
                    }
                }
            };

            var expectedOutput = new Dictionary<CostType, decimal?>
            {
                { CostType.Default, 3 * SizeCostCalculator.SMALL_PARCEL_COST },
                // Invalid Speedy cost, as one parcel didnt have it calculated
                { CostType.Speedy, null },
            };

            var actualOutput = await printer.PrintShippingCost(parcels);

            CollectionAssert.AreEquivalent(actualOutput, expectedOutput);
        }
    }
}
