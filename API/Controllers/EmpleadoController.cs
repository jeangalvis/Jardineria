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
public class EmpleadoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    //[Authorize(Roles = "Administrator,Employee")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get1()
    {
        var results = await _unitOfWork.Empleados
                                    .GetAllAsync();
        return _mapper.Map<List<EmpleadoDto>>(results);
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmpleadoDto>> Get2(int id)
    {
        var result = await _unitOfWork.Empleados.GetByIdAsync(id);
        return _mapper.Map<EmpleadoDto>(result);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Empleado>> Post(EmpleadoDto resultDto)
    {
        var result = _mapper.Map<Empleado>(resultDto);
        this._unitOfWork.Empleados.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
        {
            return BadRequest();
        }
        resultDto.CodigoEmpleado = result.CodigoEmpleado;
        return CreatedAtAction(nameof(Post), new { id = resultDto.CodigoEmpleado }, resultDto);
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Empleado>> Put(int id, [FromBody] EmpleadoDto resultDto)
    {
        var result = _mapper.Map<Empleado>(resultDto);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.Empleados.Update(result);
        await _unitOfWork.SaveAsync();
        return result;
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Empleados.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.Empleados.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EmpleadoDto>>> GetPag([FromQuery] Params resultParams)
    {
        var result = await _unitOfWork.Empleados.GetAllAsync(resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
        var lstResultDto = _mapper.Map<List<EmpleadoDto>>(result.registros);
        return new Pager<EmpleadoDto>(lstResultDto, result.totalRegistros, resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
    }
    [HttpGet("GetEmpleadosJefeDelJefe")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoJefeJefeDto>>> Get3()
    {
        var results = await _unitOfWork.Empleados
                                    .GetEmpleadosJefeDelJefe();
        return _mapper.Map<List<EmpleadoJefeJefeDto>>(results);
    }
    [HttpGet("GetEmpleadosSinClienteConOficina")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoOficinaDto>>> Get4()
    {
        var results = await _unitOfWork.Empleados
                                    .GetEmpleadosSinClienteConOficina();
        return _mapper.Map<List<EmpleadoOficinaDto>>(results);
    }
    [HttpGet("GetEmpleadosSinClienteSinOficina")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get5()
    {
        var results = await _unitOfWork.Empleados
                                    .GetEmpleadosSinClienteSinOficina();
        return _mapper.Map<List<EmpleadoDto>>(results);
    }
    [HttpGet("GetEmpleadosSinClienteSinJefe")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get6()
    {
        var results = await _unitOfWork.Empleados
                                    .GetEmpleadosSinClienteSinJefe();
        return _mapper.Map<List<EmpleadoDto>>(results);
    }
    [HttpGet("GetTotalEmpleados")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TotalEmpleadosDto>> Get7()
    {
        var results = await _unitOfWork.Empleados.GetTotalEmpleados();
        return _mapper.Map<TotalEmpleadosDto>(results);
    }
    [HttpGet("GetRepVentasConCantidadClientes")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RepVentasConClientesDto>>> Get8()
    {
        var results = await _unitOfWork.Empleados.GetRepVentasConCantidadClientes();
        return _mapper.Map<List<RepVentasConClientesDto>>(results);
    }
    [HttpGet("GetRepVentasSinCliente")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoTelefonoOficinaDto>>> Get9()
    {
        var results = await _unitOfWork.Empleados.GetRepVentasSinCliente();
        return _mapper.Map<List<EmpleadoTelefonoOficinaDto>>(results);
    }
}
