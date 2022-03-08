namespace Gu.Units.Generator
{
    using System.Diagnostics;

    [DebuggerDisplay("{Left.Name}{Operator}{Right.Name} = {Result.Symbol}")]
    public class MissingOverload
    {
        public MissingOverload(Quantity left, string @operator, Quantity right, UnitParts result)
        {
            this.Left = left;
            this.Operator = @operator;
            this.Right = right;
            this.Result = result;
        }

        public Quantity Left { get; }

        public string Operator { get; }

        public Quantity Right { get; }

        public UnitParts Result { get; }
    }
}
