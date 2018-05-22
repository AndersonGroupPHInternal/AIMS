using AIMS.Models;
using InventoryData;
using InventoryEntity;
using System.Collections.Generic;
using System.Linq;

namespace InventoryFunction
{

    public class FRequisition : IFRequisition
    {
        private IDRequisition _iDRequisition;

        public FRequisition(IDRequisition iDRequisition)
        {
            _iDRequisition = iDRequisition;
        }

        public FRequisition()
        {
            _iDRequisition = new DRequisition();

        }
        #region Create
        #endregion

        #region Read
        public Requisition Read(int requisitionId)
        {
            var eRequisition = _iDRequisition.Read<ERequisition>(a => a.RequisitionId == requisitionId);
            return Requisition(eRequisition);
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion

        #region Other Function
        private ERequisition ERequisition(Requisition requisition)
        {
            return new ERequisition
            {
                RequiredDate = requisition.RequiredDate,
                RequisitionDate = requisition.RequisitionDate,

                CreatedDate = requisition.CreatedDate,
                UpdatedDate = requisition.UpdatedDate,

                DeliveryCharges = requisition.DeliveryCharges,

                CreatedBy = requisition.CreatedBy,
                LocationId = requisition.LocationId,
                RequisitionId = requisition.RequisitionId,
                SupplierId = requisition.SupplierId,
                UpdatedBy = requisition.UpdatedBy,

                UserId = requisition.UserID,

                RequisitionType = requisition.RequisitionType,
                ReasonForDeclined = requisition.ReasonForDeclined,
                SpecialInstruction = requisition.SpecialInstruction,
                Status = requisition.Status
            };
        }

        private Requisition Requisition(ERequisition eRequisition)
        {
            if (eRequisition == null)
                return new Requisition();

            return new Requisition
            {
                RequiredDate = eRequisition.RequiredDate,
                RequisitionDate = eRequisition.RequisitionDate,

                CreatedDate = eRequisition.CreatedDate,
                UpdatedDate = eRequisition.UpdatedDate,

                DeliveryCharges = eRequisition.DeliveryCharges,

                CreatedBy = eRequisition.CreatedBy,
                LocationId= eRequisition.LocationId,
                RequisitionId= eRequisition.RequisitionId,
                SupplierId = eRequisition.SupplierId,
                UpdatedBy = eRequisition.UpdatedBy,

                UserID= eRequisition.UserId,

                RequisitionType= eRequisition.RequisitionType,
                ReasonForDeclined = eRequisition.ReasonForDeclined,
                SpecialInstruction = eRequisition.SpecialInstruction,
                Status = eRequisition.Status,

                Location = new Location
                {
                    LocationAddress = eRequisition.Location?.LocationAddress ?? string.Empty,
                    LocationName = eRequisition.Location?.LocationName ?? string.Empty
                },
                RequisitionItems = eRequisition.RequisitionItems?.Select(b => new RequisitionItem
                {
                    Quantity = b.Quantity,
                    Description = b.Description,
                    WholdingTax = b.WholdingTax,
                    InventoryItem = new InventoryItem
                    {
                        ItemCode = b.InventoryItem?.ItemCode ?? string.Empty,
                        Description = b.InventoryItem?.ItemDescription ?? string.Empty,
                        ItemName = b.InventoryItem?.ItemName ?? string.Empty
                    }
                }).ToList() ?? new List<RequisitionItem>(),
                Supplier = new Supplier
                {
                    Address = eRequisition.Supplier?.Address ?? string.Empty,
                    ContactNo = eRequisition.Supplier?.ContactNo ?? string.Empty,
                    ContactPerson = eRequisition.Supplier?.ContactPerson ?? string.Empty,
                    Email = eRequisition.Supplier?.Email ?? string.Empty,
                    SupplierName = eRequisition.Supplier?.SupplierName ?? string.Empty,
                    TinNumber = eRequisition.Supplier?.TinNumber ?? string.Empty,
                    Vatable = eRequisition.Supplier?.Vatable ?? string.Empty,
                    WholdingTax = eRequisition.Supplier?.WholdingTax ?? string.Empty
                }
            };
        }
        private List<Requisition> Requisitions(List<ERequisition> eRequisitions)
        {
            return eRequisitions.Select(a => new Requisition
            {
                RequiredDate = a.RequiredDate,
                RequisitionDate = a.RequisitionDate,

                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                DeliveryCharges = a.DeliveryCharges,

                CreatedBy = a.CreatedBy,
                LocationId = a.LocationId,
                RequisitionId = a.RequisitionId,
                SupplierId = a.SupplierId,
                UpdatedBy = a.UpdatedBy,

                UserID = a.UserId,

                RequisitionType = a.RequisitionType,
                ReasonForDeclined = a.ReasonForDeclined,
                SpecialInstruction = a.SpecialInstruction,
                Status = a.Status,
                Location = new Location
                {
                    LocationAddress = a.Location?.LocationAddress ?? string.Empty,
                    LocationName = a.Location?.LocationName ?? string.Empty
                }
            }).ToList();
        }
        #endregion

    }
}
