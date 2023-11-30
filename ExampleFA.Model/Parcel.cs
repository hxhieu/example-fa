using System.Numerics;

namespace ExampleFA.Model
{
    public class Parcel
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// In centimetres
        /// </summary>
        public Vector3 Dimension { get; set; }

        /// <summary>
        /// Null means not been calculated yet
        /// </summary>
        public decimal? ShippingCost { get; set; }

        // Size helpers

        public bool IsSmall => Dimension.X < 10 && Dimension.Y < 10 && Dimension.Z < 10;
        public bool IsMedium => !IsSmall && Dimension.X < 50 && Dimension.Y < 50 && Dimension.Z < 50;
        public bool IsLarge => !IsMedium && Dimension.X < 100 && Dimension.Y < 100 && Dimension.Z < 100;
        public bool IsXL => !IsLarge;
    }
}