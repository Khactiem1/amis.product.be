using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.DL;

namespace MISA.WEB08.AMIS.BL
{
    /// <summary>
    /// Dữ liệu thao tác với Database và trả về với bảng Unit từ tầng BL
    /// </summary>
    /// Create by: Nguyễn Khắc Tiềm (21/09/2022)
    public class CartBL : BaseBL<Cart>, ICartBL
    {
        #region Field

        private ICartDL _cartDL;

        #endregion

        #region Contructor

        public CartBL(ICartDL cartDL) : base(cartDL)
        {
            _cartDL = cartDL;
        }

        #endregion

        #region Method


        /// <summary>
        /// Cập nhật giỏ hàng
        /// </summary>
        /// <param name="recordID">ID bản ghi</param>
        /// <param name="stateForm">Trạng thái lấy (sửa hay nhân bản, ...)</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public object UpdateCart(string v_CurrentUser, string v_ProductID, string v_State)
        {
            return _cartDL.UpdateCart(v_CurrentUser, v_ProductID, v_State);
        }

        /// <summary>
        /// Thanh toán
        /// </summary>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public bool Checkout(Order order)
        {
            _cartDL.Checkout(order);
            return true;
        }

        /// <summary>
        /// API lấy ra đơn đặt hàng 
        /// </summary>
        /// <param name="formData">Từ khoá tìm kiếm</param>
        /// <returns>Danh sách record và tổng số bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public object GetOrderUser(string v_CurrentUser)
        {
            return _cartDL.GetOrderUser(v_CurrentUser);
        }

        /// <summary>
        /// Hàm lấy ra bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID bản ghi</param>
        /// <param name="stateForm">Trạng thái lấy (sửa hay nhân bản, ...)</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public object GetOrderByID(string v_OrderID)
        {
            return _cartDL.GetOrderByID(v_OrderID);
        }
        #endregion
    }
}
