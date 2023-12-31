using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class PedidoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PedidoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    //[Authorize(Roles = "Administrator,Employee")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PedidoDto>>> Get1()
    {
        var results = await _unitOfWork.Pedidos
                                    .GetAllAsync();
        return _mapper.Map<List<PedidoDto>>(results);
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PedidoDto>> Get2(int id)
    {
        var result = await _unitOfWork.Pedidos.GetByIdAsync(id);
        return _mapper.Map<PedidoDto>(result);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pedido>> Post(PedidoDto resultDto)
    {
        var result = _mapper.Map<Pedido>(resultDto);
        this._unitOfWork.Pedidos.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
        {
            return BadRequest();
        }
        resultDto.CodigoPedido = result.CodigoPedido;
        return CreatedAtAction(nameof(Post), new { id = resultDto.CodigoPedido }, resultDto);
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pedido>> Put(int id, [FromBody] PedidoDto resultDto)
    {
        var result = _mapper.Map<Pedido>(resultDto);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.Pedidos.Update(result);
        await _unitOfWork.SaveAsync();
        return result;
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Pedidos.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.Pedidos.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PedidoDto>>> GetPag([FromQuery] Params resultParams)
    {
        var result = await _unitOfWork.Pedidos.GetAllAsync(resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
        var lstResultDto = _mapper.Map<List<PedidoDto>>(result.registros);
        return new Pager<PedidoDto>(lstResultDto, result.totalRegistros, resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
    }
    [HttpGet("GetDistintosEstados")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EstadosPedidosDto>>> Get3()
    {
        var results = await _unitOfWork.Pedidos
                                    .GetDistintosEstados();
        return _mapper.Map<List<EstadosPedidosDto>>(results);
    }
    [HttpGet("GetNoEntregadosATiempo")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<NoEntregadosATiempoDto>>> Get4()
    {
        var results = await _unitOfWork.Pedidos
                                    .GetNoEntregadosATiempo();
        return _mapper.Map<List<NoEntregadosATiempoDto>>(results);
    }
    [HttpGet("GetNoEntregadosATiempov2")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<NoEntregadosATiempoDto>>> Get5()
    {
        var results = await _unitOfWork.Pedidos
                                    .GetNoEntregadosATiempov2();
        return _mapper.Map<List<NoEntregadosATiempoDto>>(results);
    }
    [HttpGet("GetPedidosRechazados")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PedidoDto>>> Get6()
    {
        var results = await _unitOfWork.Pedidos
                                    .GetPedidosRechazados();
        return _mapper.Map<List<PedidoDto>>(results);
    }
    [HttpGet("GetPedidosEntregadosEnero")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PedidoDto>>> Get7()
    {
        var results = await _unitOfWork.Pedidos
                                    .GetPedidosEntregadosEnero();
        return _mapper.Map<List<PedidoDto>>(results);
    }
    [HttpGet("GetPedidoPorEstados")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PedidosPorEstadoDto>>> Get8()
    {
        var results = await _unitOfWork.Pedidos
                                    .GetPedidoPorEstados();
        return _mapper.Map<List<PedidosPorEstadoDto>>(results);

    }
    [HttpGet("GetPedidoConCantidadProductos")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PedidosConCantidadProductosDto>>> Get9()
    {
        var results = await _unitOfWork.Pedidos
                                    .GetPedidoConCantidadProductos();
        return _mapper.Map<List<PedidosConCantidadProductosDto>>(results);

    }
    [HttpGet("GetPedidosConSumaCantidadTotal")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PedidosConSumaCantidaTotalDto>>> Get10()
    {
        var results = await _unitOfWork.Pedidos
                                    .GetPedidosConSumaCantidadTotal();
        return _mapper.Map<List<PedidosConSumaCantidaTotalDto>>(results);

    }

}
