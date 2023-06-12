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
    public class DepartamentoVentaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDepartamentoVentaRepositorio _DepartamentoVentaRepositorio;
        public DepartamentoVentaController(IDepartamentoVentaRepositorio DepartamentoVentaRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _DepartamentoVentaRepositorio = DepartamentoVentaRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            Response<List<DepartamentoVentaDTO>> _response = new Response<List<DepartamentoVentaDTO>>();

            try
            {
                List<DepartamentoVentaDTO> _listaDepartamentoVentas = new List<DepartamentoVentaDTO>();
                _listaDepartamentoVentas = _mapper.Map<List<DepartamentoVentaDTO>>(await _DepartamentoVentaRepositorio.Lista());

                if (_listaDepartamentoVentas.Count > 0)
                    _response = new Response<List<DepartamentoVentaDTO>>() { status = true, msg = "ok", value = _listaDepartamentoVentas };
                else
                    _response = new Response<List<DepartamentoVentaDTO>>() { status = false, msg = "sin resultados", value = null };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<DepartamentoVentaDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
