using MISA.WEB08.AMIS.Common.Attributes;
using System;
using System.Collections.Generic;

namespace MISA.WEB08.AMIS.Common.Entities
{
    public class Cart : BaseEntity
    {
        [Validate(PrimaryKey = true)]
        public Guid CurrentUser { get; set; }
        public List<CartDetail> CartDetail { get; set; } = new List<CartDetail>();
    }
    public class CartDetail : Product
    {
        [Validate(PrimaryKey = true)]
        public Guid CartDetailID { get; set; }
        public Guid CurrentUser { get; set; }
        public int Quantity { get; set; }
    }
}
