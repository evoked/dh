using LiteDB;
using PMDashboard.Common;

namespace PMDashboard.Api.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private ILiteDb _liteDb;
        ILiteCollection<Common.Product.Product> _liteCollection;
        public ProductRepository(ILiteDb liteDb)
        {
            _liteDb = liteDb;
            _liteCollection = _liteDb.Database.GetCollection<Common.Product.Product>("products");
        }
        public Common.Product.Product? Get(Guid id)
        {
			return _liteCollection.Find(x => x.Id == id).First();
        }

		public IEnumerable<Common.Product.Product> GetAll()
		{
		    return _liteCollection.FindAll();
        }

		public int GetCountByCategory(CategoryTypes category)
		{
		    return _liteCollection.Find(x => x.Category == category).Count();
        }

		public void Create(Common.Product.Product product)
        {
			_liteCollection.Insert(product);
        }

        public bool Delete(Guid id)
        {
			return _liteCollection.Delete(id);
		}

        public bool Update(Common.Product.Product product)
        {
			return _liteCollection.Update(product);
		}


    }
}
