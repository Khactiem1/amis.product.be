﻿using Dapper;
using MISA.WEB08.AMIS.Common.Entities;

namespace MISA.WEB08.AMIS.DL
{
    /// <summary>
    /// Dữ liệu thao tác với Database và trả về với bảng Product từ tầng DL
    /// </summary>
    /// Create by: Nguyễn Khắc Tiềm (21/09/2022)
    public class ProductDL : BaseDL<Product>, IProductDL
    {
        #region Field

        private IDatabaseHelper<Product> _dbHelper;

        #endregion

        #region Contructor

        public ProductDL(IDatabaseHelper<Product> dbHelper) : base(dbHelper)
        {
            _dbHelper = dbHelper;
        }

        #endregion

        #region Method

        /// <summary>
        /// Hàm xử lý custom các tham số parameter truyền vào proc create ngoài những tham số mặc định
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="record"></param>
        /// create by: nguyễn khắc tiềm (21/10/2022)
        public override void CustomParameterForCreate(ref DynamicParameters? parameters, Product record)
        {
            string prefix = "";
            string number = "";
            string last = "";
            _dbHelper.SaveCode(record.ProductCode, ref prefix, ref number, ref last);
            parameters.Add($"v_prefix", prefix);
            parameters.Add($"v_number", number);
            parameters.Add($"v_last", last);
            parameters.Add($"v_lengthNumber", number.Length);
        }

        #endregion
    }
}
