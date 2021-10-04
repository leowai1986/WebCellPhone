using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using static WebApplication1.Program;
using System.Linq;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDatabase()
        {
            var query = new List<CellPhone>();
            using (var db = new CodeFirstContext())
            {
                query = db.CellPhones.ToList();
            }

            Assert.IsTrue(query.Count() > 0);
        }

        [TestMethod]
        public void TestAddToDatabase()
        {
            var query = new List<CellPhone>();
            using (var db = new CodeFirstContext())
            {
                var cellPhone = new CellPhone { cellPhoneBrand = "Motorola", cellPhoneModel = "E5", price = 300 };
                db.CellPhones.Add(cellPhone);
                db.SaveChanges();

                query = db.CellPhones.ToList();
            }

            Assert.IsTrue(query.Where(x => x.cellPhoneBrand == "Motorola").Where(x => x.price == 300)
                            .Where(x => x.cellPhoneModel == "E5").FirstOrDefault().cellPhoneID != 0);
        }
    }
}
