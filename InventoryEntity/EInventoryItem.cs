using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryEntity
{
    [Table("InventoryItem")]
    public class EInventoryItem : EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryItemId { get; set; }

        public int? Location { get; set; }
        public int? UnitOfMeasurementId { get; set; }

        public string ItemBegBal { get; set; }//Todo Remove this
        public string ItemCode { get; set; }
        [StringLength(150)]
        public string ItemDescription { get; set; }
        [StringLength(150)]
        public string ItemName { get; set; }

        public object RequestItemId { get; set; } //Todo Remove this

        public ICollection<ERequisitionItem> RequisitionItems { get; set; }
    }
}
