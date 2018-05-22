using BaseData;
using InventoryContext;
using InventoryEntity;
using System.Linq;
using System.Data.Entity;

namespace InventoryData
{
    public class DRequisition : DBase, IDRequisition
    {
        public DRequisition() : base(new InventoryDbContext())
        {

        }

        #region Create
        #endregion

        #region Read
        public ERequisition Read(int requisitionId)
        {
            using (var context = new InventoryDbContext())
            {
                return context.Requisition
                    .Include(a => a.Location)
                    .Include(a => a.RequisitionItems.Select(b => b.InventoryItem))
                    .Include(a => a.Supplier)
                    .FirstOrDefault(a => a.RequisitionId == requisitionId);
            }
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion

        #region Other Function
        #endregion
    }
}
