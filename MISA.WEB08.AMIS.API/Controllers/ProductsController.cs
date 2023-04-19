using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.BL;
using Microsoft.AspNetCore.Authorization;

namespace MISA.WEB08.AMIS.API.Controllers
{
    /// <summary>
    /// API dữ liệu với bảng Product
    /// </summary>
    /// Created by : Nguyễn Khắc Tiềm (21/09/2022)
    [Authorize]
    public class ProductsController : BasesController<Product>
    {
        #region Field

        private IProductBL _productBL;

        #endregion

        #region Contructor

        public ProductsController(IProductBL productBL) : base(productBL)
        {
            _productBL = productBL;
        }

        #endregion

        #region Method

        #endregion
    }
}