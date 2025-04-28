using Dominio.DTO.SupplierManagement;
using Dominio.Interface.Repository.SupplierManagement;
using Dominio.Request;
using Dominio.Request.SupplierManagement;
using Microsoft.EntityFrameworkCore;
using SistemasDeCuentaPorPagar.DB_Data_Context;

namespace SistemasDeCuentaPorPagar.Repository.SupplierManagement
{
    public class SupplierManagementRepository : ISupplierManagementRep
    {
        private readonly CuentasPorPagarContext _CuentasPorPagarContext;
        public SupplierManagementRepository(CuentasPorPagarContext cuentasPorPagarContext)
        {
            _CuentasPorPagarContext = cuentasPorPagarContext;
        }

        public async Task<bool> ExistSupplier(string rnc_Cedula)
        {
            try
            {
                return await _CuentasPorPagarContext.Suppliers.AnyAsync(s => s.RncCedula == rnc_Cedula);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<MessageResponse<string>> AddSupplier(SupplierReq suppliers)
        {
            try
            {
                if (await this.ExistSupplier(suppliers.Rnc_Cedula))
                {
                    return new MessageResponse<string>
                    {
                        IsSuccess = false,
                        Message = $"Este suplidor {suppliers.Rnc_Cedula}  ya existe",
                        StatuCode = 404
                    };
                }

                await _CuentasPorPagarContext.Suppliers.AddAsync(new Supplier
                {
                    Address = suppliers.Address,
                    Email = suppliers.Email,
                    Name = suppliers.Name,
                    Phone = suppliers.Phone,
                    RncCedula = suppliers.Rnc_Cedula
                });

                await _CuentasPorPagarContext.SaveChangesAsync();

                return new MessageResponse<string>
                {
                    IsSuccess = true,
                    Message = $"{suppliers.Rnc_Cedula} agregado",
                    StatuCode = 201
                };
            }
            catch (Exception ex)
            {
                return new MessageResponse<string>
                {
                    IsSuccess = false,
                    Message = "Ha ocurrido en el servidor",
                    StatuCode = 500
                };
            }
        }

        public async Task<MessageResponse<string>> DeleteSupplier(string rnc_Cedula)
        {
            try
            {
               
              var supplier = await _CuentasPorPagarContext.Suppliers.FirstOrDefaultAsync(s => s.RncCedula == rnc_Cedula);

                if (supplier != null && await _CuentasPorPagarContext.Invoices.AnyAsync(i => i.SupplierId == supplier.Id))
                    return new MessageResponse<string>
                    {
                        IsSuccess = false,
                        Message = "Este suplidor contiene factura vinculadas",
                        StatuCode = 500
                    };

                _CuentasPorPagarContext.Suppliers.Remove(supplier);
                await _CuentasPorPagarContext.SaveChangesAsync();


                return new MessageResponse<string>
                {
                    IsSuccess = true,
                    Message = $"{rnc_Cedula} eliminado",
                    StatuCode = 200
                };
            }
            catch (Exception ex)
            {
                return new MessageResponse<string>
                {
                    IsSuccess = false,
                    Message = "Ha ocurrido en el servidor",
                    StatuCode = 500
                };
            }
        }

        public async Task<MessageResponse<List<string>>> GetRncOrCedula()
        {
            try
            {
                return new MessageResponse<List<string>>
                {
                    IsSuccess = true,
                    Payload = await _CuentasPorPagarContext.Suppliers.Select(s => s.RncCedula).ToListAsync(),
                    StatuCode = 200
                };
            }
            catch (Exception ex)
            {
                return new MessageResponse<List<string>>
                {
                    IsSuccess = false,
                    Message = "Ha ocurrido en el servidor",
                    StatuCode = 500
                };
            }
        }

        public async Task<MessageResponse<SupplierRes>> GetSupplier(string rnc_Cedula)
        {
            try
            {
                SupplierRes supplier = await _CuentasPorPagarContext.Suppliers.Where(s => s.RncCedula == rnc_Cedula).Select(s => new SupplierRes
                {
                    Address = s.Address,
                    Email = s.Email,
                    Name = s.Name,
                    Phone = s.Phone,
                    Rnc_Cedula = s.RncCedula,
                } ).FirstOrDefaultAsync();

                if( supplier == null)
                    return new MessageResponse<SupplierRes>
                    {
                        IsSuccess = false,
                        Message = "Proveedor no encontrado",
                        StatuCode = 404
                    };
                
                return new MessageResponse<SupplierRes>
                {
                    IsSuccess = true,
                    Payload = supplier,
                    StatuCode = 200
                };
            }
            catch (Exception ex)
            {
                return new MessageResponse<SupplierRes>
                {
                    IsSuccess = false,
                    Message = "Ha ocurrido en el servidor",
                    StatuCode = 500
                };
            }
        }

        public async Task<MessageResponse<List<SupplierRes>>> GetSuppliers()
        {
            try
            {
               List<SupplierRes> suppliers = await _CuentasPorPagarContext.Suppliers.Select(s => new SupplierRes
                {
                    Address = s.Address,
                    Email = s.Email,
                    Name = s.Name,
                    Phone = s.Phone,
                    Rnc_Cedula = s.RncCedula,
                }).ToListAsync();

                return new MessageResponse<List<SupplierRes>>
                {
                    IsSuccess = true,
                    Payload = suppliers,
                    StatuCode = 200
                };
            }
            catch (Exception ex)
            {
                return new MessageResponse<List<SupplierRes>>
                {
                    IsSuccess = false,
                    Message = "Ha ocurrido en el servidor",
                    StatuCode = 500
                };
            }
        }

        public async Task<MessageResponse<string>> UpdateSupplier(SupplierReq suppliers)
        {
            try
            {
                var _suppliers = await _CuentasPorPagarContext.Suppliers.Where(s => s.RncCedula == suppliers.Rnc_Cedula).FirstOrDefaultAsync();
                if (_suppliers == null)
                    return new MessageResponse<string>
                    {
                        IsSuccess = false,
                        Message = $"Este {suppliers.Rnc_Cedula} suplidor no existe",
                        StatuCode = 404
                    };
                

                _suppliers.Address = suppliers.Address;
                _suppliers.Email = suppliers.Email;
                _suppliers.Name = suppliers.Name;
                _suppliers.Phone = suppliers.Phone;

                await _CuentasPorPagarContext.SaveChangesAsync();

                return new MessageResponse<string>
                {
                    IsSuccess = true,
                    Message = "Successful",
                    StatuCode = 200
                };
            }
            catch (Exception ex)
            {
                return new MessageResponse<string>
                {
                    IsSuccess = false,
                    Message = "Ha ocurrido en el servidor",
                    StatuCode = 500
                };
            }
        }
    }
}
