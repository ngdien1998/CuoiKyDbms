namespace QuanLyNhaHang.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiViet")]
    public partial class BaiViet
    {
        [Key]
        public int IDBaiViet { get; set; }

        [StringLength(256)]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDang { get; set; }

        [Required]
        [StringLength(50)]
        public string IDNhanVien { get; set; }

        public int IDLoaiBaiViet { get; set; }

        public virtual LoaiBaiViet LoaiBaiViet { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
