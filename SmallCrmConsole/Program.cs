using SmallCrm.Core.Data;
using SmallCrm.Core.Services;

namespace SmallCrmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ps = new ProductService(new SmallCrmDbContext());

            //ps.PopulateDb();
        }
    }
}
