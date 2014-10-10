using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBox.Generator.Sandbox
{
    using NUnit.Framework;

    class Meh
    {
        [Test]
        public void TestNameTest()
        {
            var unit = new UnitMetaData("Length", "GeneratorBox", "Meters", "1", "m")
                           {
                               Related = new List<UnitMetaData>
                                       {
                                           new UnitMetaData("Length", "GeneratorBox", "Millimeters", "1000", "mm"),
                                           new UnitMetaData("Length", "GeneratorBox", "CentiMeters", "100", "cm"),
                                       }
                           };
            var ns = unit.Namespace;
        }
    }
}
