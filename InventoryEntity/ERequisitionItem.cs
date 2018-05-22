using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryEntity
{
    [Table("RequisitionItem")]
    public class ERequisitionItem : EBase
    {
        public double UnitPrice { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequisitionItemId { get; set; }

        public int InventoryItemId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int Quantity { get; set; }
        public int RequisitionId { get; set; }
        public int SupplierId { get; set; }

        public string Description { get; set; }
        public string ItemBegBal { get; set; } //ToDo check if this is needed
        public string ItemDescription { get; set; }
        public string WholdingTax { get; set; }

        public EInventoryItem InventoryItem { get; set; }
        public ERequisition Requisition { get; set; }
    }
}