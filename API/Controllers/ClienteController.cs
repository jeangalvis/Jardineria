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
public class ClienteController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    //[Authorize(Roles = "Administrator,Employee")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get1()
    {
        var results = await _unitOfWork.Clientes
                                    .GetAllAsync();
        return _mapper.Map<List<ClienteDto>>(results);
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> Get2(int id)
    {
        var result = await _unitOfWork.Clientes.GetByIdAsync(id);
        return _mapper.Map<ClienteDto>(result);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Post(ClienteDto resultDto)
    {
        var result = _mapper.Map<Cliente>(resultDto);
        this._unitOfWork.Clientes.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
        {
            return BadRequest();
        }
        resultDto.CodigoCliente = result.CodigoCliente;
        return CreatedAtAction(nameof(Post), new { id = resultDto.CodigoCliente }, resultDto);
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Put(int id, [FromBody] ClienteDto resultDto)
    {
        var result = _mapper.Map<Cliente>(resultDto);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.Clientes.Update(result);
        await _unitOfWork.SaveAsync();
        return result;
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.Clientes.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ClienteDto>>> GetPag([FromQuery] Params resultParams)
    {
        var result = await _unitOfWork.Clientes.GetAllAsync(resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
        var lstResultDto = _mapper.Map<List<ClienteDto>>(result.registros);
        return new Pager<ClienteDto>(lstResultDto, result.totalRegistros, resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
    }
    [HttpGet("GetClientesEspañoles")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get3()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesEspañoles();
        return _mapper.Map<List<ClienteDto>>(results);
    }
    [HttpGet("GetCodigoPago2008")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CodigoPago2008Dto>>> Get4()
    {
        var results = await _unitOfWork.Clientes
                                    .GetCodigoPago2008();
        return _mapper.Map<List<CodigoPago2008Dto>>(results);
    }
    [HttpGet("GetClientesMadridRep11o30")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get5()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesMadridRep11o30();
        return _mapper.Map<List<ClienteDto>>(results);
    }
    [HttpGet("GetClienteRepresentanteVenta")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteConRepresentanteDto>>> Get6()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClienteRepresentanteVenta();
        return _mapper.Map<List<ClienteConRepresentanteDto>>(results);
    }
    [HttpGet("GetClienteRepresentanteVentaPago")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteConRepresentanteDto>>> Get7()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClienteRepresentanteVentaPago();
        return _mapper.Map<List<ClienteConRepresentanteDto>>(results);
    }
    [HttpGet("GetClienteRepresentanteVentaNoPago")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteConRepresentanteDto>>> Get8()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClienteRepresentanteVentaNoPago();
        return _mapper.Map<List<ClienteConRepresentanteDto>>(results);
    }
    [HttpGet("GetClienteRepresentanteVentaPagoOficina")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteRepresentanteOficinaDto>>> Get9()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClienteRepresentanteVentaPagoOficina();
        return _mapper.Map<List<ClienteRepresentanteOficinaDto>>(results);
    }
    [HttpGet("GetClienteRepresentanteVentaNoPagoOficina")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteRepresentanteOficinaDto>>> Get10()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClienteRepresentanteVentaNoPagoOficina();
        return _mapper.Map<List<ClienteRepresentanteOficinaDto>>(results);
    }
    [HttpGet("GetClientePedidoEntregadoTarde")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteNombreDto>>> Get11()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientePedidoEntregadoTarde();
        return _mapper.Map<List<ClienteNombreDto>>(results);
    }
    [HttpGet("GetGamaProductosxCliente")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteGamaDto>>> Get12()
    {
        var results = await _unitOfWork.Clientes
                                    .GetGamaProductosxCliente();
        return _mapper.Map<List<ClienteGamaDto>>(results);
    }
    [HttpGet("GetClientesNoHanPagado")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get13()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesNoHanPagado();
        return _mapper.Map<List<ClienteDto>>(results);
    }
    [HttpGet("GetClientesNoHanPagadoNiPedido")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get14()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesNoHanPagadoNiPedido();
        return _mapper.Map<List<ClienteDto>>(results);
    }
    [HttpGet("GetClientesHanPagadoNoPedido")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get15()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesHanPagadoNoPedido();
        return _mapper.Map<List<ClienteDto>>(results);
    }
    [HttpGet("GetClientesPorPais")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientesPorPaisDto>>> Get16()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesPorPais();
        return _mapper.Map<List<ClientesPorPaisDto>>(results);
    }
    [HttpGet("GetClientesPorCiudad")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientePorCiudadDto>>> Get17()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesPorCiudad();
        return _mapper.Map<List<ClientePorCiudadDto>>(results);
    }
    [HttpGet("GetClientesPorCiudadM")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientePorCiudadDto>>> Get18()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesPorCiudadM();
        return _mapper.Map<List<ClientePorCiudadDto>>(results);
    }
    [HttpGet("GetTotalClientesSinRep")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TotalClientesDto>> Get19()
    {
        var results = await _unitOfWork.Clientes
                                    .GetTotalClientesSinRep();
        return _mapper.Map<TotalClientesDto>(results);
    }
    [HttpGet("GetPrimerUltimoPago")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientePagosDto>>> Get20()
    {
        var results = await _unitOfWork.Clientes
                                    .GetPrimerUltimoPago();
        return _mapper.Map<List<ClientePagosDto>>(results);
    }
    [HttpGet("GetClienteMayorLimiteCredito")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> Get21()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClienteMayorLimiteCredito();
        return _mapper.Map<ClienteDto>(results);
    }
    [HttpGet("GetClienteCreditoMayorPagoRealizado")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get22()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClienteCreditoMayorPagoRealizado();
        return _mapper.Map<List<ClienteDto>>(results);
    }
    [HttpGet("GetClienteMayorLimiteCreditoV2")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> Get23()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClienteMayorLimiteCreditoV2();
        return _mapper.Map<ClienteDto>(results);
    }
    [HttpGet("GetClientesNoHanPagadoV2")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get24()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesNoHanPagadoV2();
        return _mapper.Map<List<ClienteDto>>(results);
    }
    [HttpGet("GetClientesSiHanPagado")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get25()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesSiHanPagado();
        return _mapper.Map<List<ClienteDto>>(results);
    }
    [HttpGet("GetClientesNoHanPagadoV3")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get26()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesNoHanPagadoV3();
        return _mapper.Map<List<ClienteDto>>(results);
    }
    [HttpGet("GetClientesSiHanPagadoV2")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get27()
    {
        var results = await _unitOfWork.Clientes
                                    .GetClientesSiHanPagadoV2();
        return _mapper.Map<List<ClienteDto>>(results);
    }
}
