using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.TestExport
{
    [Export]
    public class TestExportOne
    {
        public string Method()
        {
            return "log: TestExportOne::Method()";
        }
    }
}
