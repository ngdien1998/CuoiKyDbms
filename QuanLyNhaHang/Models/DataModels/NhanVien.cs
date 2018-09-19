namespace QuanLyNhaHang.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            BaiViets = new HashSet<BaiViet>();
            DatHangOnlines = new HashSet<DatHangOnline>();
        }

        [Key]
        [StringLength(50)]
        public string IDNhanVien { get; set; }

        [StringLength(100)]
        public string TenNhanVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [Required]
        [StringLength(256)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        public bool? LaQTV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatHangOnline> DatHangOnlines { get; set; }
    }
}
