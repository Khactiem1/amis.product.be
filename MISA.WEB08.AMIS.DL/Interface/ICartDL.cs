using MISA.WEB08.AMIS.Common.Entities;

namespace MISA.WEB08.AMIS.DL
{
    /// <summary>
    /// Dữ liệu thao tác với Database và trả về với bảng Unit từ tầng DL
    /// </summary>
    /// Create by: Nguyễn Khắc Tiềm (21/09/2022)
    public interface ICartDL : IBaseDL<Cart>
    {
        /// <summary>
        /// Cập nhật giỏ hàng
        /// </summary>
        /// <param name="recordID">ID bản ghi</param>
        /// <param name="stateForm">Trạng thái lấy (sửa hay nhân bản, ...)</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public object UpdateCart(string v_CurrentUser, string v_ProductID, string v_State);

        /// <summary>
        /// Thanh toán
        /// </summary>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public void Checkout(Order order);

        /// <summary>
        /// API lấy ra đơn đặt hàng 
        /// </summary>
        /// <param name="formData">Từ khoá tìm kiếm</param>
        /// <returns>Danh sách record và tổng số bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public object GetOrderUser(string v_CurrentUser);

        /// <summary>
        /// Hàm lấy ra bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID bản ghi</param>
        /// <param name="stateForm">Trạng thái lấy (sửa hay nhân bản, ...)</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public object GetOrderByID(string v_OrderID);
    }
}
