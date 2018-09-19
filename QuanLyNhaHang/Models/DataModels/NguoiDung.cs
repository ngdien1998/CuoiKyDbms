namespace QuanLyNhaHang.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            DanhGiaMonAns = new HashSet<DanhGiaMonAn>();
            DatHangOnlines = new HashSet<DatHangOnline>();
        }

        [Key]
        [StringLength(50)]
        public string EmailNguoiDung { get; set; }

        [StringLength(100)]
        public string TenNguoiDung { get; set; }

        [StringLength(30)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(256)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGiaMonAn> DanhGiaMonAns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatHangOnline> DatHangOnlines { get; set; }
    }
}
