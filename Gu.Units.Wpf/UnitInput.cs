namespace Gu.Units.Wpf
{
    public enum UnitInput
    {       
        /// <summary>
        /// Valid input cannot contain a unit symbol
        /// </summary>
        ScalarOnly,
       
        /// <summary>
        /// Input is valid with or without symbol.
        /// When no symbol the unit in the converter is used.
        /// </summary>
        SymbolAllowed,

        /// <summary>
        /// Valid input must contain a unit symbol.
        /// </summary>
        SymbolRequired
    }
}