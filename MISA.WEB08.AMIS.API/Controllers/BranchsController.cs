using MISA.WEB08.AMIS.Common.Entities;
using MISA.WEB08.AMIS.BL;
using Microsoft.AspNetCore.Authorization;

namespace MISA.WEB08.AMIS.API.Controllers
{
    /// <summary>
    /// API dữ liệu với bảng unit
    /// </summary>
    /// Created by : Nguyễn Khắc Tiềm (21/09/2022)
    [Authorize]
    public class BranchsController : BasesController<Branch>
    {
        #region Field

        private IBranchBL _unitBL;

        #endregion

        #region Contructor

        public BranchsController(IBranchBL unitBL) : base(unitBL)
        {
            _unitBL = unitBL;
        }

        #endregion

        #region Method

        #endregion
    }
}