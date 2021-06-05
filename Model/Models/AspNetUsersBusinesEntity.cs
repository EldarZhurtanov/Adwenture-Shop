namespace Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AspNetUsersBusinesEntity")]
    public partial class AspNetUsersBusinesEntity
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public int? BusinessEntityID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
