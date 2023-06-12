using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVentaCosmeticos.DTOs;
using SistemaVentaCosmeticos.Repository.Contratos;
using SistemaVentaCosmeticos.Utilidades;

namespace SistemaVentaCosmeticos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardRepositorio _dashboardRepositorio;
        public DashBoardController(IDashBoardRepositorio dashboardRepositorio)
        {
            _dashboardRepositorio = dashboardRepositorio;
        }

        [HttpGet]
        [Route("Resumen")]
        public async Task<IActionResult> Resumen()
        {
            Response<DashBoardDTO> _response = new Response<DashBoardDTO>();

            try
            {

                DashBoardDTO vmDashboard = new DashBoardDTO();

                vmDashboard.TotalProductos = await _dashboardRepositorio.TotalProductos();

                
                _response = new Response<DashBoardDTO>() { status = true, msg = "ok", value = vmDashboard };
                return StatusCode(StatusCodes.Status200OK, _response);

            }
            catch (Exception ex)
            {
                _response = new Response<DashBoardDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }

        }
    }
}
