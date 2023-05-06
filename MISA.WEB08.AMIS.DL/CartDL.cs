using Dapper;
using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.Common.Enums;
using MISA.WEB08.AMIS.Common.Resources;
using MySqlConnector;
using System.Data;
using System.Linq;

namespace MISA.WEB08.AMIS.DL
{
    /// <summary>
    /// Dữ liệu thao tác với Database và trả về với bảng Unit từ tầng DL
    /// </summary>
    /// Create by: Nguyễn Khắc Tiềm (21/09/2022)
    public class CartDL : BaseDL<Cart>, ICartDL
    {
        #region Field

        private IDatabaseHelper<Cart> _dbHelper;

        #endregion

        #region Contructor

        public CartDL(IDatabaseHelper<Cart> dbHelper) : base(dbHelper)
        {
            _dbHelper = dbHelper;
        }

        #endregion

        #region Method



        /// <summary>
        /// Hàm lấy ra bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID bản ghi</param>
        /// <param name="stateForm">Trạng thái lấy (sửa hay nhân bản, ...)</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public override object GetRecordByID(string recordID, string? stateForm)
        {
            Cart result;
            // Khởi tạo các parameter để chèn vào trong Proc
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"v_CurrentUser", recordID);
            // Khai báo stored procedure
            string storeProcedureName = string.Format(Resource.Proc_GetDetailOne, typeof(Cart).Name);
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                //nếu như kết nối đang đóng thì tiến hành mở lại
                if (mysqlConnection.State != ConnectionState.Open)
                {
                    mysqlConnection.Open();
                }
                // thực hiện gọi vào DB
                var records = mysqlConnection.QueryMultiple(
                    storeProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
                result = records.Read<Cart>().First();
                result.CartDetail = records.Read<CartDetail>().ToList();
                if (mysqlConnection.State == ConnectionState.Open)
                {
                    mysqlConnection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Cập nhật giỏ hàng
        /// </summary>
        /// <param name="recordID">ID bản ghi</param>
        /// <param name="stateForm">Trạng thái lấy (sửa hay nhân bản, ...)</param>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public object UpdateCart(string v_CurrentUser, string v_ProductID, string v_State)
        {
            Cart result;
            // Khởi tạo các parameter để chèn vào trong Proc
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"v_CurrentUser", v_CurrentUser);
            parameters.Add($"v_ProductID", v_ProductID);
            parameters.Add($"v_State", v_State);
            // Khai báo stored procedure
            string storeProcedureName = "Proc_cart_AddCartDetail";
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                //nếu như kết nối đang đóng thì tiến hành mở lại
                if (mysqlConnection.State != ConnectionState.Open)
                {
                    mysqlConnection.Open();
                }
                // thực hiện gọi vào DB
                var records = mysqlConnection.QueryMultiple(
                    storeProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
                result = records.Read<Cart>().First();
                result.CartDetail = records.Read<CartDetail>().ToList();
                if (mysqlConnection.State == ConnectionState.Open)
                {
                    mysqlConnection.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// Thanh toán
        /// </summary>
        /// <returns>Thông tin chi tiết một bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public void Checkout(Order order)
        {
            var v_MessOut = "";
            // Khởi tạo các parameter để chèn vào trong Proc
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("v_CurrentUser", order.CurrentUser);
            parameters.Add("v_UserName", order.UserName);
            parameters.Add("v_PhoneNumber", order.PhoneNumber);
            parameters.Add("v_Email", order.Email);
            parameters.Add("v_Province", order.Province);
            parameters.Add("v_District", order.District);
            parameters.Add("v_Ward", order.Ward);
            parameters.Add("v_Address", order.Address);
            parameters.Add("v_Description", order.Description);
            parameters.Add("v_TypeCheckout", order.TypeCheckout);
            // chuẩn bị câu lệnh MySQL
            string storeProcedureName = "Proc_order_Checkout";
            _dbHelper.RunProcWithExecute(storeProcedureName, parameters, ref v_MessOut);
        }

        /// <summary>
        /// API lấy ra đơn đặt hàng 
        /// </summary>
        /// <param name="formData">Từ khoá tìm kiếm</param>
        /// <returns>Danh sách record và tổng số bản ghi</returns>
        /// Create by: Nguyễn Khắc Tiềm (26/09/2022)
        public object GetOrderUser(string v_CurrentUser)
        {
            // Khởi tạo các parameter để chèn vào trong Proc
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"v_CurrentUser", v_CurrentUser);
            // Khai báo stored procedure
            string storeProcedureName = "Proc_order_GetListOrder";
            object result;
            // Khai báo stored procedure
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                //nếu như kết nối đang đóng thì tiến hành mở lại
                if (mysqlConnection.State != ConnectionState.Open)
                {
                    mysqlConnection.Open();
                }
                // thực hiện gọi vào DB
                result = mysqlConnection.Query<Order>(
                    storeProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
                if (mysqlConnection.State == ConnectionState.Open)
                {
                    mysqlConnection.Close();
                }
            }
            return result;
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
            Order result;
            // Khởi tạo các parameter để chèn vào trong Proc
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"v_OrderID", v_OrderID);
            // Khai báo stored procedure
            string storeProcedureName = "Proc_order_GetOrderDetail";
            using (var mysqlConnection = new MySqlConnection(DataContext.MySqlConnectionString))
            {
                //nếu như kết nối đang đóng thì tiến hành mở lại
                if (mysqlConnection.State != ConnectionState.Open)
                {
                    mysqlConnection.Open();
                }
                // thực hiện gọi vào DB
                var records = mysqlConnection.QueryMultiple(
                    storeProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
                result = records.Read<Order>().First();
                result.OrderDetail = records.Read<OrderDetail>().ToList();
                if (mysqlConnection.State == ConnectionState.Open)
                {
                    mysqlConnection.Close();
                }
            }
            return result;
        }

        #endregion
    }
}
