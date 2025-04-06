using Dominio.DTO.SupplierManagement;
using Dominio.Interface.CaseUse.Invoices;
using Dominio.Interface.CaseUse.SupplierManagement;
using Dominio.Request.SupplierManagement;
using Dominio.Request;
using Microsoft.AspNetCore.Mvc;

namespace SistemasDeCuentaPorPagar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierManagement : ControllerBase
    {
        private readonly ISupplierManagementUseCase _SupplierManagementUseCase;
        public SupplierManagement(ISupplierManagementUseCase supplierManagementUseCase)
        {
            _SupplierManagementUseCase = supplierManagementUseCase;
        }
        [HttpPost("new_supplier")]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierReq suppliers)
        {
            var res = await _SupplierManagementUseCase.AddSupplier(suppliers);
            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }

        [HttpPost("delete/{rnc_Cedula}")]
        public async Task<IActionResult> DeleteSupplier([FromRoute] string rnc_Cedula)
        {
            var res = await _SupplierManagementUseCase.DeleteSupplier(rnc_Cedula);
            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateSupplier([FromBody] SupplierReq suppliers)
        {
            var res = await _SupplierManagementUseCase.UpdateSupplier(suppliers);
            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }

        [HttpGet("{rnc_Cedula}")]
        public async Task<IActionResult> GetSupplier([FromRoute] string rnc_Cedula)
        {
            var res = await _SupplierManagementUseCase.GetSupplier(rnc_Cedula);
            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }
        [HttpGet("rnc_or_cedula")]
        public async Task<IActionResult> GetRncOrCedula()
        {
            var res = await _SupplierManagementUseCase.GetRncOrCedula();
            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }

        [HttpGet("suppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            var res = await _SupplierManagementUseCase.GetSuppliers();
            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }

    }
}
