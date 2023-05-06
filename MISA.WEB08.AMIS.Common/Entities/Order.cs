using MISA.WEB08.AMIS.Common.Attributes;
using MISA.WEB08.AMIS.Common.Enums;
using System;
using System.Collections.Generic;

namespace MISA.WEB08.AMIS.Common.Entities
{
    public class Order : BaseEntity
    {
        [Validate(PrimaryKey = true)]
        public Guid? OrderID { get; set; }
        public Guid? CurrentUser { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public TypeCheckout? TypeCheckout { get; set; }
        public List<OrderDetail> OrderDetail { get; set; } = new List<OrderDetail>();
    }
    public class OrderDetail : Product
    {
        [Validate(PrimaryKey = true)]
        public Guid? OrderDetailID { get; set; }
        public Guid? OrderID { get; set; }
        public int? Quantity { get; set; }
        public double? PriceOrder { get; set; }
    }
}
