namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("{Parts.Symbol} Missing: {Missing.Count}")]
    public class MissingOverloads
    {
        public MissingOverloads(UnitParts parts,
            IReadOnlyList<MissingOverload> missing)
        {
            Parts = parts;
            Missing = missing;
        }

        public UnitParts Parts { get; }

        public IReadOnlyList<MissingOverload> Missing { get; }
    }
}