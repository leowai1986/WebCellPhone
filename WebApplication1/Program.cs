using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Data.Entity;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using (var db = new CodeFirstContext())
            //{
            //    var cellPhone = new CellPhone { cellPhoneBrand = "Samsung", cellPhoneModel = "S7", price = 500 };
            //    db.CellPhones.Add(cellPhone);
            //    db.SaveChanges();
            //}

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        public class CellPhone
        {
            public int cellPhoneID { get; set; }

            public string cellPhoneBrand { get; set; }

            public string cellPhoneModel { get; set; }

            public decimal price { get; set; }
        }

        public class CodeFirstContext : DbContext
        {
            public DbSet<CellPhone> CellPhones
            {
                get;
                set;
            }
        }
    }
}
