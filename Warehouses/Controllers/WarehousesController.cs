using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Warehouses.Exceptions;
using Warehouses.Models;
using Warehouses.Services;

namespace Warehouses.Controllers
{
    [Route("api/warehouses")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IDbService DbService;

        public WarehousesController(IDbService DbService)
        {
            this.DbService = DbService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToWarehouse([FromBody] ProductWarehouse productWarehouse)
        {
            int idProductWarehouse;
            try { idProductWarehouse = await DbService.AddProductToWarehouseAsync(productWarehouse); }
            catch (NoRowsException e) { return NotFound(e.Message); }
            catch (SomethingWentWrongException) { return NotFound(); }
            catch (Exception e) { return NotFound(e.Message); }
            return Ok($"Succsesfully added! ID: {idProductWarehouse}!");
        }
    }
}