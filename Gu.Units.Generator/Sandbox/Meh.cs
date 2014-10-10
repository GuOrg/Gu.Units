using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gu.Units.Generator.Sandbox
{
    using Gu.Units.Generator;
    using NUnit.Framework;

    class Meh
    {
        [Test]
        public void TestNameTest()
        {
            var unit = new UnitMetaData("Length", "Gu.Units", "Meters", "1", "m")
                           {
                               Related = new List<UnitMetaData>
                                       {
                                           new UnitMetaData("Length", "Gu.Units", "Millimeters", "1000", "mm"),
                                           new UnitMetaData("Length", "Gu.Units", "CentiMeters", "100", "cm"),
                                       }
                           };
            var ns = unit.Namespace;
        }
    }
}
