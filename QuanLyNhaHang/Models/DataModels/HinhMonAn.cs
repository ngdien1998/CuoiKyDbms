namespace QuanLyNhaHang.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhMonAn")]
    public partial class HinhMonAn
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDMonAn { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(256)]
        public string UrlHinh { get; set; }

        public virtual MonAn MonAn { get; set; }
    }
}
