namespace WebGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THIETKEGIAY")]
    public partial class THIETKEGIAY
    {
        [Key]
        [Column(Order = 0)]
        public int MaTKG { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Magiay { get; set; }

        [StringLength(50)]
        public string Vaitro { get; set; }

        [StringLength(50)]
        public string Vitri { get; set; }

        public virtual GIAY GIAY { get; set; }

        public virtual NHATHIETKE NHATHIETKE { get; set; }
    }
}
