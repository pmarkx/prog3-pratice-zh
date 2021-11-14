using NUnit.Framework;
using System;
using System.Collections.Generic;
using zhprobalkozas.ZH.DataLoader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void LoaderXmlnotfound()
        {
            Assert.That(
                () => { Loader loader = new Loader(""); },Throws.TypeOf<ArgumentException>()
                );
        }
        [Test]
        public void PlaneLoaderTest()
        {
            Loader loader = new Loader("data.xml");
            var result = loader.LoadPlanes();
            Assert.IsNotNull(result);
        }
        [Test]
        public void OrderLoaderTest()
        {
            Loader loader = new Loader("data.xml");
            var result = loader.LoadOrders();
            Assert.IsNotNull(result);
        }
    }
}
