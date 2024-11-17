using BenzodiazepineManagement.APIs;
using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BenzodiazepineManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PharmacologicalPropertiesControllerBase : ControllerBase
{
    protected readonly IPharmacologicalPropertiesService _service;

    public PharmacologicalPropertiesControllerBase(IPharmacologicalPropertiesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PharmacologicalProperty
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PharmacologicalProperty>> CreatePharmacologicalProperty(
        PharmacologicalPropertyCreateInput input
    )
    {
        var pharmacologicalProperty = await _service.CreatePharmacologicalProperty(input);

        return CreatedAtAction(
            nameof(PharmacologicalProperty),
            new { id = pharmacologicalProperty.Id },
            pharmacologicalProperty
        );
    }

    /// <summary>
    /// Delete one PharmacologicalProperty
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePharmacologicalProperty(
        [FromRoute()] PharmacologicalPropertyWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePharmacologicalProperty(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PharmacologicalProperties
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PharmacologicalProperty>>> PharmacologicalProperties(
        [FromQuery()] PharmacologicalPropertyFindManyArgs filter
    )
    {
        return Ok(await _service.PharmacologicalProperties(filter));
    }

    /// <summary>
    /// Meta data about PharmacologicalProperty records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PharmacologicalPropertiesMeta(
        [FromQuery()] PharmacologicalPropertyFindManyArgs filter
    )
    {
        return Ok(await _service.PharmacologicalPropertiesMeta(filter));
    }

    /// <summary>
    /// Get one PharmacologicalProperty
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PharmacologicalProperty>> PharmacologicalProperty(
        [FromRoute()] PharmacologicalPropertyWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PharmacologicalProperty(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PharmacologicalProperty
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePharmacologicalProperty(
        [FromRoute()] PharmacologicalPropertyWhereUniqueInput uniqueId,
        [FromQuery()] PharmacologicalPropertyUpdateInput pharmacologicalPropertyUpdateDto
    )
    {
        try
        {
            await _service.UpdatePharmacologicalProperty(
                uniqueId,
                pharmacologicalPropertyUpdateDto
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
