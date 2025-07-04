using LiteDB;

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
        public Common.Product.Product? Get(int id)
        {
			return _liteCollection.FindById(id);
        }

		public IEnumerable<Common.Product.Product> GetAll()
		{
		    return _liteCollection.FindAll();
        }
		public int Create(Common.Product.Product product)
        {
			var id = (int)_liteCollection.Insert(product);
            return id;
        }

        public bool Delete(int id)
        {
			return _liteCollection.Delete(id);
		}

        public bool Update(Common.Product.Product product)
        {
			return _liteCollection.Update(product);
		}
    }
}
