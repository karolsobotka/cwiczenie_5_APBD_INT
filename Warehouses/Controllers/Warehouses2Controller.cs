using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Warehouses.Models;
using Warehouses.Services;

namespace Warehouses.Controllers
{
    [Route("api/warehouses2")]
    [ApiController]
    public class Warehouses2Controller : ControllerBase
    {
        private readonly IDbProcedureService DbProcedureService;

        public Warehouses2Controller(IDbProcedureService DbProcedureService)
        {
            this.DbProcedureService = DbProcedureService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToWarehouse([FromBody] ProductWarehouse productWarehouse)
        {
            int idProductWarehouse;
            try { idProductWarehouse = await DbProcedureService.AddProductToWarehouseAsync(productWarehouse); }
            catch (Exception e) { return NotFound(e.Message); }
            return Ok($"Succsesfully added! ID: {idProductWarehouse}!");
        }
    }
}