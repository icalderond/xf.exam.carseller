using System.Threading.Tasks;
using carseller.Abstractions;
using carseller.Models;
using Xamarin.Forms;

namespace carseller.Persistence
{
    public class DbContext
    {
        public readonly IRepository<Product> Products;
        public readonly IRepository<Account> Accounts;

        public DbContext()
        {
            var connectionString = DependencyService.Get<IFileManager>().GetSQLiteDBPath("carseller.db3");

            Products = new Repository<Product>(connectionString);
            Accounts = new Repository<Account>(connectionString);
        }

        public async Task Initialize()
        {
            await Products.Initialize();
            await Accounts.Initialize();
        }
    }
}
