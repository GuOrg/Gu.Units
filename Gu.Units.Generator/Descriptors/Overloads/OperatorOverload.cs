namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;

    [DebuggerDisplay("{Left.Name}{Operator}{Right.Name} = {Result.Name}")]
    public sealed class OperatorOverload
    {
        public static readonly string Divide = "/";
        public static readonly string Multiply = "*";

        public OperatorOverload(Quantity left, Operator @operator, Quantity right, Quantity result)
        {
            this.Left = left;
            this.Right = right;
            this.Result = result;

            this.Operator = @operator switch
            {
                Generator.Operator.None => throw new InvalidOperationException($"Could not create overload for {left} * x^y = {result}"),
                Generator.Operator.Multiply => Multiply,
                Generator.Operator.Divide => Divide,
                _ => throw new InvalidEnumArgumentException(nameof(@operator), (int)@operator, typeof(Operator)),
            };
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

        public override bool Equals(object obj)
        {
            return obj is OperatorOverload oo && this.Equals(oo);
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

        private bool Equals(OperatorOverload other)
        {
            return string.Equals(this.Left.Name, other.Left.Name, StringComparison.Ordinal) &&
                   string.Equals(this.Right.Name, other.Right.Name, StringComparison.Ordinal) &&
                   string.Equals(this.Result.Name, other.Result.Name, StringComparison.Ordinal) &&
                   string.Equals(this.Operator, other.Operator, StringComparison.Ordinal);
        }
    }
}