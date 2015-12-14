namespace Gu.Units.Generator
{
    using System;

    [Serializable]
    public class InverseOverload
    {
        public InverseOverload(Quantity original, Quantity inverted)
        {
            this.Original = original;
            this.Inverted = inverted;
        }

        public Quantity Original { get; }

        public Quantity Inverted { get; }

        public override string ToString()
        {
            return $"1 / {this.Original.Name} = {this.Inverted.Name}";
        }

        public static bool IsInverse(Quantity left, Quantity right)
        {
            var leftParts = left.Unit.Parts;
            var rightParts = right.Unit.Parts.Inverse();
            return leftParts == rightParts;
        }
    }
}