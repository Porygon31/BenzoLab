using BenzodiazepineManagement.APIs;
using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BenzodiazepineManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BenzodiazepinesControllerBase : ControllerBase
{
    protected readonly IBenzodiazepinesService _service;

    public BenzodiazepinesControllerBase(IBenzodiazepinesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Benzodiazepine
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Benzodiazepine>> CreateBenzodiazepine(
        BenzodiazepineCreateInput input
    )
    {
        var benzodiazepine = await _service.CreateBenzodiazepine(input);

        return CreatedAtAction(
            nameof(Benzodiazepine),
            new { id = benzodiazepine.Id },
            benzodiazepine
        );
    }

    /// <summary>
    /// Delete one Benzodiazepine
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBenzodiazepine(
        [FromRoute()] BenzodiazepineWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteBenzodiazepine(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Benzodiazepines
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Benzodiazepine>>> Benzodiazepines(
        [FromQuery()] BenzodiazepineFindManyArgs filter
    )
    {
        return Ok(await _service.Benzodiazepines(filter));
    }

    /// <summary>
    /// Meta data about Benzodiazepine records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BenzodiazepinesMeta(
        [FromQuery()] BenzodiazepineFindManyArgs filter
    )
    {
        return Ok(await _service.BenzodiazepinesMeta(filter));
    }

    /// <summary>
    /// Get one Benzodiazepine
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Benzodiazepine>> Benzodiazepine(
        [FromRoute()] BenzodiazepineWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Benzodiazepine(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Benzodiazepine
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBenzodiazepine(
        [FromRoute()] BenzodiazepineWhereUniqueInput uniqueId,
        [FromQuery()] BenzodiazepineUpdateInput benzodiazepineUpdateDto
    )
    {
        try
        {
            await _service.UpdateBenzodiazepine(uniqueId, benzodiazepineUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
