
using PMDashboard.Common;

namespace PMDashboard.Api.Repositories.Product
{
    public interface IProductRepository
    {
		int Create(Common.Product.Product product);
        bool Delete(int id);
        Common.Product.Product? Get(int id);
        bool Update(Common.Product.Product product);
        IEnumerable<Common.Product.Product> GetAll();

	}
}