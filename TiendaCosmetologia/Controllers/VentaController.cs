using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVentaCosmeticos.DTOs;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using SistemaVentaCosmeticos.Utilidades;
using System.Globalization;

namespace SistemaVentaCosmeticos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IVentaRepositorio _ventaRepositorio;

        public VentaController(IVentaRepositorio ventaRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _ventaRepositorio = ventaRepositorio;
        }


        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO request)
        {
            Response<VentaDTO> _response = new Response<VentaDTO>();
            try
            {

                Venta venta_creada = await _ventaRepositorio.Registrar(_mapper.Map<Venta>(request));
                request = _mapper.Map<VentaDTO>(venta_creada);

              if(venta_creada.IdVenta != 0)
                    _response = new Response<VentaDTO>() { status = true, msg = "ok", value = request };
              else
                    _response = new Response<VentaDTO>() { status = false, msg = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<VentaDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
            

    }
}
