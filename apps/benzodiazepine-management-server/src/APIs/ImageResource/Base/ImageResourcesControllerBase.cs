using BenzodiazepineManagement.APIs;
using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BenzodiazepineManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ImageResourcesControllerBase : ControllerBase
{
    protected readonly IImageResourcesService _service;

    public ImageResourcesControllerBase(IImageResourcesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ImageResource
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ImageResource>> CreateImageResource(
        ImageResourceCreateInput input
    )
    {
        var imageResource = await _service.CreateImageResource(input);

        return CreatedAtAction(nameof(ImageResource), new { id = imageResource.Id }, imageResource);
    }

    /// <summary>
    /// Delete one ImageResource
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteImageResource(
        [FromRoute()] ImageResourceWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteImageResource(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ImageResources
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ImageResource>>> ImageResources(
        [FromQuery()] ImageResourceFindManyArgs filter
    )
    {
        return Ok(await _service.ImageResources(filter));
    }

    /// <summary>
    /// Meta data about ImageResource records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ImageResourcesMeta(
        [FromQuery()] ImageResourceFindManyArgs filter
    )
    {
        return Ok(await _service.ImageResourcesMeta(filter));
    }

    /// <summary>
    /// Get one ImageResource
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ImageResource>> ImageResource(
        [FromRoute()] ImageResourceWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ImageResource(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ImageResource
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateImageResource(
        [FromRoute()] ImageResourceWhereUniqueInput uniqueId,
        [FromQuery()] ImageResourceUpdateInput imageResourceUpdateDto
    )
    {
        try
        {
            await _service.UpdateImageResource(uniqueId, imageResourceUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
