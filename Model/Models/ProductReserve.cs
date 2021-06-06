namespace Model.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Production.ProductReserve")]
    public partial class ProductReserve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        public short? Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
