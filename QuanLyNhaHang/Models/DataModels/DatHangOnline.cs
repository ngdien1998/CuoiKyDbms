namespace QuanLyNhaHang.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatHangOnline")]
    public partial class DatHangOnline
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string IDNhanVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string EmailNguoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDatHang { get; set; }

        [Required]
        [StringLength(256)]
        public string GhiChu { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
