using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO.SupplierManagement;
using Dominio.Request.SupplierManagement;
using Dominio.Request;

namespace Dominio.Interface.Repository.SupplierManagement
{
    public interface ISupplierManagementRep
    {
        Task<MessageResponse<string>> AddSupplier(SupplierReq suppliers);
        Task<MessageResponse<string>> DeleteSupplier(string rnc_Cedula);
        Task<MessageResponse<string>> UpdateSupplier(SupplierReq suppliers);
        Task<MessageResponse<SupplierRes>> GetSupplier(string rnc_Cedula);
        Task<MessageResponse<List<string>>> GetRncOrCedula();
        Task<MessageResponse<List<SupplierRes>>> GetSuppliers();
    }
}
