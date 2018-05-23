using AIMS.Models;
using InventoryData;
using InventoryEntity;
using System.Collections.Generic;
using System.Linq;

namespace InventoryFunction
{
    public class FRequest : IFRequest
    {
        private IDRequest _iDRequest;

        public FRequest(IDRequest iDRequest)
        {
            _iDRequest = iDRequest;
        }

        public FRequest()
        {
            _iDRequest = new DRequest();
        }

        #region CREATE
        public Request Create(Request request)
        {
            ERequest eRequest = ERequest(request);
            eRequest = _iDRequest.Create(eRequest);
            return Request(eRequest);
        }
        #endregion

        #region READ
        public Request Read(int requestId)
        {
            ERequest eRequest = _iDRequest.Read<ERequest>(a => a.RequestId == requestId);
            return Request(eRequest);
        }

        public List<Request> Read()
        {
            List<ERequest> eRequest = _iDRequest.List<ERequest>(a => true);
            return Request(eRequest);
        }

        public List<Request> ReadId(int requestId)
        {
            List<ERequest> eRequest = _iDRequest.List<ERequest>(a => a.RequestId == requestId);
            return Request(eRequest);
        }
        #endregion

        #region UPDATE
        public Request Update(Request request)
        {
            var eRequest = _iDRequest.Update(ERequest(request));
            return (Request(eRequest));
        }
        #endregion

        #region DELETE
        public void Delete(Request request)
        {
            _iDRequest.Delete(ERequest(request));
        }
        #endregion

        #region OTHER FUNCTION
        private ERequest ERequest(Request request)
        {
            ERequest returnERequest = new ERequest
            {
                RequestId= request.RequestID,
                RequiredDate= request.RequiredDate,

                RequisitionType= request.RequisitionType,
                SpecialInstruction= request.SpecialInstruction,
                Status= request.Status,

                ReasonForDeclined= request.ReasonForDeclined,
            };
            return returnERequest;
        }

        private Request Request(ERequest eRequest)
        {
            Request returnRequest = new Request
            {
                RequiredDate = eRequest.RequiredDate,

                RequisitionType = eRequest.RequisitionType,
                SpecialInstruction = eRequest.SpecialInstruction,
                Status = eRequest.Status,

                ReasonForDeclined = eRequest.ReasonForDeclined
            };
            return returnRequest;
        }

        private List<Request> Request(List<ERequest> eRequest)
        {
            var returnRequest = eRequest.Select(a => new Request
            {
                RequiredDate = a.RequiredDate,

                RequisitionType = a.RequisitionType,
                SpecialInstruction = a.SpecialInstruction,
                Status = a.Status,

                ReasonForDeclined = a.ReasonForDeclined
            });

            return returnRequest.ToList();
        }

        #endregion
    }
}