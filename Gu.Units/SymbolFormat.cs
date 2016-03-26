namespace Gu.Units
{
    /// <summary>
    /// Specifies how units are formatted
    /// </summary>
    public enum SymbolFormat
    {
        /// <summary>
        /// The default format
        /// </summary>
        Default,

        /// <summary>
        /// Example: N*mm^-2
        /// </summary>
        SignedHatPowers,

        /// <summary>
        /// Example: N/mm^2
        /// </summary>
        FractionHatPowers,

        /// <summary>
        /// Example: N⋅mm⁻²
        /// </summary>
        SignedSuperScript,

        /// <summary>
        /// Example: N/mm²
        /// </summary>
        FractionSuperScript,
    }
}