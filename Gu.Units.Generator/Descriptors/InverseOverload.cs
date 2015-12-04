namespace Gu.Units.Generator
{
    using System.Linq;

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
            return $"1 / {this.Original.ClassName} = {this.Inverted.ClassName}";
        }

        public static bool IsInverse(Quantity left, Quantity right)
        {
            var leftParts = UnitParts.CreateFrom(left);
            var rightParts = UnitParts.CreateFrom(right);
            return leftParts.Flattened.SequenceEqual(rightParts.Flattened.Select(x => x ^ -1));
        }
    }
}