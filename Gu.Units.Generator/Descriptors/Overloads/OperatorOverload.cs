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
            this.Left = left;
            this.Right = right;
            this.Result = result;

            switch (@operator)
            {
                case Generator.Operator.None:
                    throw new InvalidOperationException($"Could not create overload for {left} * x^y = {result}");
                case Generator.Operator.Multiply:
                    this.Operator = Multiply;
                    break;
                case Generator.Operator.Divide:
                    this.Operator = Divide;
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
            return this.Left.Name.Equals(other.Left.Name) && this.Right.Name.Equals(other.Right.Name) && this.Result.Name.Equals(other.Result.Name) &&
                   string.Equals(this.Operator, other.Operator);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return this.Equals((OperatorOverload)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.Left.Name.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Right.Name.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Result.Name.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Operator.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{this.Left.Name} {this.Operator} {this.Right.Name} = {this.Result.Name}";
        }
    }
}