namespace Gu.Units.Generator
{
    using System.Diagnostics;

    [DebuggerDisplay("{Left.Name}{Operator}{Right.Name} = {Result.Symbol}")]
    public class MissingOverload
    {
        public MissingOverload(Quantity left,
            string @operator,
            Quantity right,
            UnitParts result)
        {
            Left = left;
            Operator = @operator;
            Right = right;
            Result = result;
        }

        public Quantity Left { get; }

        public string Operator { get; }

        public Quantity Right { get; }

        public UnitParts Result { get; }
    }
}