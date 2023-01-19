using System.Threading.Tasks;
using Warehouses.Models;

namespace Warehouses.Services
{
    public interface IDbProcedureService
    {
        Task<int> AddProductToWarehouseAsync(ProductWarehouse productWarehouse);
    } 
}