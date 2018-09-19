namespace QuanLyNhaHang.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucDon")]
    public partial class ThucDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThucDon()
        {
            MonAns = new HashSet<MonAn>();
        }

        [Key]
        public int IDThucDon { get; set; }

        [StringLength(50)]
        public string TenThucDon { get; set; }

        [StringLength(256)]
        public string HinhThucDon { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        public double? Gia { get; set; }

        public int? PhanTramKM { get; set; }

        public int? SoLuongKhach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonAn> MonAns { get; set; }
    }
}
