namespace QuanLyNhaHang.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonAn")]
    public partial class MonAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonAn()
        {
            DanhGiaMonAns = new HashSet<DanhGiaMonAn>();
            HinhMonAns = new HashSet<HinhMonAn>();
        }

        [Key]
        public int IDMonAn { get; set; }

        [StringLength(50)]
        public string TenMonAn { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        [StringLength(256)]
        public string MoTa { get; set; }

        [Column(TypeName = "text")]
        public string MoTaChiTiet { get; set; }

        public double? Gia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapNhat { get; set; }

        public int? PhanTramKM { get; set; }

        public int? IDLoaiMonAn { get; set; }

        public int? IDThucDon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGiaMonAn> DanhGiaMonAns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HinhMonAn> HinhMonAns { get; set; }

        public virtual LoaiMonAn LoaiMonAn { get; set; }

        public virtual ThucDon ThucDon { get; set; }
    }
}
