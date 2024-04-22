using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;

namespace WpfApp1.Messages
{
    internal class HostMef
    {
        [Import]
        public ILogger logger { get; set; }
        public HostMef()
        {
        }
        /*
            So when you call batch.AddPart(something) then you are telling MEF that "something" is a component that may provide exports and depends on one or more imports.
            If you call batch.AddExport(new Export("someExport", () => something)) then you are telling MEF that "something" is a component that just provides exports without requiring any imports, i.e. MEF will ignore any [Import] annotations that may be specified in the "something" class.

            Internally AddExport actually calls AddPart, but prior to that it wraps the passed object in a "SingleExportComposablePart"
         */
        public void Run()
        {
            string strReturn;
            //strReturn = Compose1(); // ok
            //strReturn = Compose2(); // ok
            strReturn = Compose3();

            logger.Write(strReturn);

        }
        private void Compose2()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
       
        private string  Compose1()
        {
            var container = new CompositionContainer();
            CompositionBatch batch = new CompositionBatch();
            batch.AddPart(new ConsoleLogger());
            batch.AddPart(this);
            //batch.AddPart( logger); //new ConsoleLogger()
            //batch.AddExport(logger);
            container.Compose(batch);

            return "log: sample log writing";
        }

        private string Compose3()
        {
            AggregateCatalog aggCatalog = new AggregateCatalog(); // if from different assembly
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            aggCatalog.Catalogs.Add(catalog);
            aggCatalog.Catalogs.Add(new AssemblyCatalog(typeof(One.TestExport.TestExportOne).Assembly));
            //
            var container = new CompositionContainer(aggCatalog);
            container.ComposeParts(this);
            //
            One.TestExport.TestExportOne oneExport = container.GetExportedValue<One.TestExport.TestExportOne>();
            return oneExport.Method();

        }
    }
}

