namespace WebGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIGIAY")]
    public partial class LOAIGIAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIGIAY()
        {
            GIAYs = new HashSet<GIAY>();
        }

        [Key]
        public int MaLG { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLoaiGiay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAY> GIAYs { get; set; }
    }
}
