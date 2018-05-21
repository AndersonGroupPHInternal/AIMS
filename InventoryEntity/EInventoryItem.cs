using BaseEntity;
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

        [StringLength(150)]
        public string ItemName { get; set; }

        public int? UnitOfMeasurementId { get; set; }

        public int? Location { get; set; }

        [StringLength(150)]
        public string ItemDescription { get; set; }


        public int ItemBegBal { get; set; }
        public string ItemCode { get; set; }
        public object RequestItemId { get; set; }




       



    }
}
