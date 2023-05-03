using MISA.WEB08.AMIS.Common.Entities;
using System.Collections.Generic;

namespace MISA.WEB08.AMIS.DL
{
    /// <summary>
    /// Dữ liệu thao tác với Database và trả về với bảng Unit từ tầng DL
    /// </summary>
    /// Create by: Nguyễn Khắc Tiềm (21/09/2022)
    public interface IProductDL : IBaseDL<Product>
    {
        /// <summary>
        /// API lấy ra 10 sản phẩm mới nhất
        /// </summary>
        /// <param name="formData">Từ khoá tìm kiếm</param>
        /// <returns>Danh sách record và tổng số bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public object GetProductHome(string keyWord);

        /// <summary>
        /// API lấy ra 10 sản phẩm mới nhất
        /// </summary>
        /// <param name="formData">Từ khoá tìm kiếm</param>
        /// <returns>Danh sách record và tổng số bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public object GetProductHot();

        /// <summary>
        /// API lấy ra 10 sản phẩm mới nhất
        /// </summary>
        /// <param name="formData">Từ khoá tìm kiếm</param>
        /// <returns>Danh sách record và tổng số bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public object GetProductPrice();
    }
}
