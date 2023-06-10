using GPL.DBModels;
using Microsoft.AspNetCore.Mvc;

namespace GPL.Controllers
{

    [ApiController]
    public class DataController : ControllerBase
    {
        ProductDataContext _context = new ProductDataContext();

        [Route("GetProducts")]
        [HttpGet]
        public List<TblProduct> GetProducts()
        {
            return _context.TblProducts.ToList();
        }

        [Route("GetCategories")]
        [HttpGet]
        public List<TblCategory> GetCategories()
        {
            return _context.TblCategories.ToList();
        }

        [Route("GetVendors")]
        [HttpGet]
        public List<TblVendor> GetVendors()
        {
            return _context.TblVendors.ToList();
        }
    }
}
