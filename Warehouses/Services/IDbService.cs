using System.Threading.Tasks;
using Warehouses.Models;

namespace Warehouses.Services
{
    public interface IDbService
    {
        Task<int> AddProductToWarehouseAsync(ProductWarehouse productWarehouse);
    }
}