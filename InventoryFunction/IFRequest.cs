using AIMS.Models;
using System.Collections.Generic;

namespace InventoryFunction
{
    public interface IFRequest
    {

        #region CREATE
        Request Create(Request request);
        #endregion

        #region READ
        Request Read(int requestId);

        List<Request> Read();

        List<Request> ReadId(int requestId);
        #endregion

        #region UPDATE
        Request Update(Request request);
        #endregion

        #region DELETE
        void Delete(Request request);
        #endregion
    }
}