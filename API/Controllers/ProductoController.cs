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
public class ProductoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    //[Authorize(Roles = "Administrator,Employee")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> Get1()
    {
        var results = await _unitOfWork.Productos
                                    .GetAllAsync();
        return _mapper.Map<List<ProductoDto>>(results);
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductoDto>> Get2(int id)
    {
        var result = await _unitOfWork.Productos.GetByIdAsync(id);
        return _mapper.Map<ProductoDto>(result);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Producto>> Post(ProductoDto resultDto)
    {
        var result = _mapper.Map<Producto>(resultDto);
        this._unitOfWork.Productos.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
        {
            return BadRequest();
        }
        resultDto.CodigoProducto = result.CodigoProducto;
        return CreatedAtAction(nameof(Post), new { id = resultDto.CodigoProducto }, resultDto);
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Producto>> Put(int id, [FromBody] ProductoDto resultDto)
    {
        var result = _mapper.Map<Producto>(resultDto);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.Productos.Update(result);
        await _unitOfWork.SaveAsync();
        return result;
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Productos.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.Productos.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ProductoDto>>> GetPag([FromQuery] Params resultParams)
    {
        var result = await _unitOfWork.Productos.GetAllAsync(resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
        var lstResultDto = _mapper.Map<List<ProductoDto>>(result.registros);
        return new Pager<ProductoDto>(lstResultDto, result.totalRegistros, resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
    }
    [HttpGet("GetOrnamentalesStock100")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> Get3()
    {
        var results = await _unitOfWork.Productos
                                    .GetOrnamentalesStock100();
        return _mapper.Map<List<ProductoDto>>(results);
    }
    [HttpGet("GetProductosSinPedido")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> Get4()
    {
        var results = await _unitOfWork.Productos
                                    .GetProductosSinPedido();
        return _mapper.Map<List<ProductoDto>>(results);
    }
    [HttpGet("GetProductosGamaSinPedido")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductoGamaDto>>> Get5()
    {
        var results = await _unitOfWork.Productos
                                    .GetProductosGamaSinPedido();
        return _mapper.Map<List<ProductoGamaDto>>(results);
    }
    [HttpGet("GetProductosMasVendidos")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductosMasVendidosDto>>> Get6()
    {
        var results = await _unitOfWork.Productos
                                    .GetProductosMasVendidos();
        return _mapper.Map<List<ProductosMasVendidosDto>>(results);
    }
    [HttpGet("GetProductosMasVendidosAgrupadosCodigo")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductosMasVendidosDto>>> Get7()
    {
        var results = await _unitOfWork.Productos
                                    .GetProductosMasVendidosAgrupadosCodigo();
        return _mapper.Map<List<ProductosMasVendidosDto>>(results);
    }
    [HttpGet("GetProductosMasVendidosAgrupadosCodigoFiltradoOr")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductosMasVendidosDto>>> Get8()
    {
        var results = await _unitOfWork.Productos
                                    .GetProductosMasVendidosAgrupadosCodigoFiltradoOr();
        return _mapper.Map<List<ProductosMasVendidosDto>>(results);
    }
    [HttpGet("GetProductosVentasMas3000")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TotalFacturadoProductosDto>>> Get9()
    {
        var results = await _unitOfWork.Productos
                                    .GetProductosVentasMas3000();
        return _mapper.Map<List<TotalFacturadoProductosDto>>(results);
    }
}
