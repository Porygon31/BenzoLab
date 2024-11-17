using BenzodiazepineManagement.APIs;
using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BenzodiazepineManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class UserActionsControllerBase : ControllerBase
{
    protected readonly IUserActionsService _service;

    public UserActionsControllerBase(IUserActionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one UserAction
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<UserAction>> CreateUserAction(UserActionCreateInput input)
    {
        var userAction = await _service.CreateUserAction(input);

        return CreatedAtAction(nameof(UserAction), new { id = userAction.Id }, userAction);
    }

    /// <summary>
    /// Delete one UserAction
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteUserAction(
        [FromRoute()] UserActionWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteUserAction(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many UserActions
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<UserAction>>> UserActions(
        [FromQuery()] UserActionFindManyArgs filter
    )
    {
        return Ok(await _service.UserActions(filter));
    }

    /// <summary>
    /// Meta data about UserAction records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> UserActionsMeta(
        [FromQuery()] UserActionFindManyArgs filter
    )
    {
        return Ok(await _service.UserActionsMeta(filter));
    }

    /// <summary>
    /// Get one UserAction
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<UserAction>> UserAction(
        [FromRoute()] UserActionWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.UserAction(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one UserAction
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateUserAction(
        [FromRoute()] UserActionWhereUniqueInput uniqueId,
        [FromQuery()] UserActionUpdateInput userActionUpdateDto
    )
    {
        try
        {
            await _service.UpdateUserAction(uniqueId, userActionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
