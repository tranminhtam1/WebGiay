namespace WebGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHATHIETKE")]
    public partial class NHATHIETKE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHATHIETKE()
        {
            THIETKEGIAYs = new HashSet<THIETKEGIAY>();
        }

        [Key]
        public int MaNTK { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNTK { get; set; }

        [StringLength(100)]
        public string Diachi { get; set; }

        public string Tieusu { get; set; }

        [StringLength(50)]
        public string Dienthoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THIETKEGIAY> THIETKEGIAYs { get; set; }
    }
}
