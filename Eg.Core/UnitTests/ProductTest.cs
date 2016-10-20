using Eg.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void CRUDTest()
        {
            var product = new Product();

            product.Name = "P1";
            product.Description = "Producto 1";
            product.UnitPrice = 10.5M;


        }
    }
}
