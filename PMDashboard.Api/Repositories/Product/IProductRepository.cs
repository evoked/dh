
using PMDashboard.Common;

namespace PMDashboard.Api.Repositories.Product
{
    public interface IProductRepository
    {
        int GetCountByCategory(CategoryTypes category);
        void Create(Common.Product.Product product);
        bool Delete(Guid id);
        Common.Product.Product? Get(Guid id);
        bool Update(Common.Product.Product product);
        IEnumerable<Common.Product.Product> GetAll();

	}
}