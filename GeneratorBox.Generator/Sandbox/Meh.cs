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
            var unit = new UnitMetaData("Length", "GeneratorBox", "Meters", "1/60.0", "m");
            var ns = unit.Namespace;
        }
    }
}
