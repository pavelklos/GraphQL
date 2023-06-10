using GPL.DBModels;

namespace GPL.Queries
{
    public class Productdata
    {
        ProductDataContext _context = new ProductDataContext();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<TblProduct> GetProducts()
        {
            return _context.TblProducts.ToList();
        }
    }
}
