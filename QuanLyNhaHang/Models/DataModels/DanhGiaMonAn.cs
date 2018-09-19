namespace QuanLyNhaHang.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGiaMonAn")]
    public partial class DanhGiaMonAn
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDMonAn { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string EmailNguoiDung { get; set; }

        [StringLength(256)]
        public string NoiDung { get; set; }

        public int? DiemDanhGia { get; set; }

        public virtual MonAn MonAn { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
