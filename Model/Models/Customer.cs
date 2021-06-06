namespace Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Sales.Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        public int CustomerID { get; set; }

        public int? PersonID { get; set; }

        public int? StoreID { get; set; }

        public int? TerritoryID { get; set; }

        [StringLength(50)]
        public string AccountNumber { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Person Person { get; set; }

        public virtual SalesTerritory SalesTerritory { get; set; }

        public virtual Store Store { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
