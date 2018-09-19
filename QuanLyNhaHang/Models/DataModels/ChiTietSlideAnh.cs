namespace QuanLyNhaHang.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSlideAnh")]
    public partial class ChiTietSlideAnh
    {
        [Key]
        public int IDChiTietSlide { get; set; }

        [Required]
        [StringLength(256)]
        public string UrlHinh { get; set; }

        public int? IDSlideAnh { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        public virtual SlideAnh SlideAnh { get; set; }
    }
}
