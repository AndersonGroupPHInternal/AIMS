using BaseData;
using InventoryContext;

namespace InventoryData
{
    public class DRequest : DBase, IDRequest
    {

        public DRequest() : base(new InventoryDbContext())
        {

        }
    }
}
