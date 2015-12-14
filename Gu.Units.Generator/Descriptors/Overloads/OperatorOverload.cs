namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    [Serializable]
    [DebuggerDisplay("{Left.Name}{Operator}{Right.Name} = {Result.Name}")]
    public class OperatorOverload
    {
        public static readonly string Divide = "/";
        public static readonly string Multiply = "*";

        public OperatorOverload(Quantity left, Operator @operator, Quantity right, Quantity result)
        {
            Left = left;
            Right = right;
            Result = result;

            switch (@operator)
            {
                case Generator.Operator.None:
                    throw new InvalidOperationException($"Could not create overload for {left} * x^y = {result}");
                case Generator.Operator.Multiply:
                    Operator = Multiply;
                    break;
                case Generator.Operator.Divide:
                    Operator = Divide;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Quantity Left { get; }

        public Quantity Right { get; }

        public Quantity Result { get; }

        public string Operator { get; }

        public static bool operator ==(OperatorOverload left, OperatorOverload right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OperatorOverload left, OperatorOverload right)
        {
            return !Equals(left, right);
        }

        public static bool TryCreateMultiplication(Quantity left, Quantity right, IReadOnlyList<Unit> allUnits, out OperatorOverload result)
        {
            var prod = left.Unit.Parts * right.Unit.Parts;
            var product = allUnits.SingleOrDefault(u => u.Parts == prod)?.Quantity;
            if (product != null)
            {
                result = new OperatorOverload(left, Generator.Operator.Multiply, right, product);
                return true;
            }

            result = null;
            return false;
        }

        public static bool TryCreateDivision(Quantity left, Quantity right, IReadOnlyList<Unit> allUnits, out OperatorOverload result)
        {
            if (left == right)
            {
                result = null;
                return false;
            }

            var div = left.Unit.Parts / right.Unit.Parts;
            var division = allUnits.SingleOrDefault(u => u.Parts == div)?.Quantity;
            if (division != null)
            {
                result = new OperatorOverload(left, Generator.Operator.Divide, right, division);
                return true;
            }

            result = null;
            return false;
        }

        protected bool Equals(OperatorOverload other)
        {
            return Left.Name.Equals(other.Left.Name) &&
                   Right.Name.Equals(other.Right.Name) &&
                   Result.Name.Equals(other.Result.Name) &&
                   string.Equals(Operator, other.Operator);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((OperatorOverload)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Left.Name.GetHashCode();
                hashCode = (hashCode * 397) ^ Right.Name.GetHashCode();
                hashCode = (hashCode * 397) ^ Result.Name.GetHashCode();
                hashCode = (hashCode * 397) ^ Operator.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{Left.Name} {Operator} {Right.Name} = {Result.Name}";
        }

        /// <summary>
        /// Solves left * right^x = result
        /// Where x =±1
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private Power FindPower(Quantity left, Quantity right, Quantity result)
        {
            var leftParts = left.Unit.Parts;
            var rightParts = right.Unit.Parts;
            var resultParts = result.Unit.Parts;

            if (leftParts * rightParts == resultParts)
            {
                return Power.PlusOne;
            }

            if (leftParts / rightParts == resultParts)
            {
                return Power.NegOne;
            }

            return Power.None;
        }
    }
}