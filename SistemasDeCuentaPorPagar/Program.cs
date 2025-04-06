using Aplication.Invoice;
using Aplication.Payment;
using Aplication.SupplierManagement;
using Dominio.Interface.CaseUse.Invoices;
using Dominio.Interface.CaseUse.Payment;
using Dominio.Interface.CaseUse.SupplierManagement;
using Dominio.Interface.Repository.Invoice;
using Dominio.Interface.Repository.Payment;
using Dominio.Interface.Repository.SupplierManagement;
using Microsoft.EntityFrameworkCore;
using SistemasDeCuentaPorPagar.DB_Data_Context;
using SistemasDeCuentaPorPagar.Repository.Invoice;
using SistemasDeCuentaPorPagar.Repository.Payment;
using SistemasDeCuentaPorPagar.Repository.SupplierManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInvoiceUseCase, InvoiceUseCase>();
builder.Services.AddScoped<IInvoiceRep, InvoiceRepository>();

builder.Services.AddScoped<IPaymentUseCase, PaymentUseCase>();
builder.Services.AddScoped<IPaymentRep, PaymentRepository>();

builder.Services.AddScoped<ISupplierManagementUseCase, SupplierManagementUseCase>();
builder.Services.AddScoped<ISupplierManagementRep, SupplierManagementRepository>();


builder.Services.AddDbContext<CuentasPorPagarContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Conection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
