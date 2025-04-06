using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO.SupplierManagement;
using Dominio.Interface.CaseUse.SupplierManagement;
using Dominio.Interface.Repository.SupplierManagement;
using Dominio.Request;
using Dominio.Request.SupplierManagement;

namespace Aplication.SupplierManagement
{
    public class SupplierManagementUseCase : ISupplierManagementUseCase
    {
        private ISupplierManagementRep _SupplierManagementRep;
        public SupplierManagementUseCase(ISupplierManagementRep supplierManagementRep)
        {
            _SupplierManagementRep = supplierManagementRep;
        }
        public async Task<MessageResponse<string>> AddSupplier(SupplierReq suppliers)
        {
            return await _SupplierManagementRep.AddSupplier(suppliers);
        }

        public async Task<MessageResponse<string>> DeleteSupplier(string rnc_Cedula)
        {
            return await _SupplierManagementRep.DeleteSupplier(rnc_Cedula);
        }

        public async Task<MessageResponse<List<string>>> GetRncOrCedula()
        {
           return await _SupplierManagementRep.GetRncOrCedula();
        }

        public async Task<MessageResponse<SupplierRes>> GetSupplier(string rnc_Cedula)
        {
            return await _SupplierManagementRep.GetSupplier(rnc_Cedula);
        }

        public async Task<MessageResponse<List<SupplierRes>>> GetSuppliers()
        {
            return await _SupplierManagementRep.GetSuppliers();
        }

        public async Task<MessageResponse<string>> UpdateSupplier(SupplierReq suppliers)
        {
            return await _SupplierManagementRep.UpdateSupplier(suppliers);
        }
    }
}
