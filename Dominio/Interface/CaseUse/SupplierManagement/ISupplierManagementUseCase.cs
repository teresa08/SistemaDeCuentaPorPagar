using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO.SupplierManagement;
using Dominio.Request;
using Dominio.Request.SupplierManagement;

namespace Dominio.Interface.CaseUse.SupplierManagement
{
    public interface ISupplierManagementUseCase
    {
       Task<MessageResponse<string>> AddSupplier(SupplierReq suppliers);
       Task<MessageResponse<string>> DeleteSupplier(string rnc_Cedula);
       Task<MessageResponse<string>> UpdateSupplier(SupplierReq suppliers);
       Task<MessageResponse<SupplierRes>> GetSupplier(string rnc_Cedula);
       Task<MessageResponse<List<string>>> GetRncOrCedula();
       Task<MessageResponse<List<SupplierRes>>> GetSuppliers();
    }
}
