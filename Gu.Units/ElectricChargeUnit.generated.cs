﻿namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.ElectricChargeUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct ElectricChargeUnit : IUnit, IUnit<ElectricCharge>, IEquatable<ElectricChargeUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.Coulombs"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Coulombs = new ElectricChargeUnit(1.0, "C");
        /// <summary>
        /// The <see cref="T:Gu.Units.Coulombs"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit C = Coulombs;

        private readonly double _conversionFactor;
        private readonly string _symbol;

        public ElectricChargeUnit(double conversionFactor, string symbol)
        {
            _conversionFactor = conversionFactor;
            _symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.Coulombs"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

        public static ElectricCharge operator *(double left, ElectricChargeUnit right)
        {
            return ElectricCharge.From(left, right);
        }

        public static bool operator ==(ElectricChargeUnit left, ElectricChargeUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ElectricChargeUnit left, ElectricChargeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.Coulombs"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return _conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Coulombs.
        /// </summary>
        /// <param name="value">The value in Coulombs</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / _conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new TTQuantity(value, this)</returns>
        public ElectricCharge CreateQuantity(double value)
        {
            return new ElectricCharge(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double From(ElectricCharge quantity)
        {
            return FromSiUnit(quantity.coulombs);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", _symbol, this.ToSiUnit(1), Coulombs.Symbol);
        }

        public bool Equals(ElectricChargeUnit other)
        {
            return _symbol == other.Symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ElectricChargeUnit && Equals((ElectricChargeUnit)obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
    }
}