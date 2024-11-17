using BenzodiazepineManagement.APIs;
using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.APIs.Errors;
using BenzodiazepineManagement.APIs.Extensions;
using BenzodiazepineManagement.Infrastructure;
using BenzodiazepineManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BenzodiazepineManagement.APIs;

public abstract class UserActionsServiceBase : IUserActionsService
{
    protected readonly BenzodiazepineManagementDbContext _context;

    public UserActionsServiceBase(BenzodiazepineManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one UserAction
    /// </summary>
    public async Task<UserAction> CreateUserAction(UserActionCreateInput createDto)
    {
        var userAction = new UserActionDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            userAction.Id = createDto.Id;
        }

        _context.UserActions.Add(userAction);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<UserActionDbModel>(userAction.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one UserAction
    /// </summary>
    public async Task DeleteUserAction(UserActionWhereUniqueInput uniqueId)
    {
        var userAction = await _context.UserActions.FindAsync(uniqueId.Id);
        if (userAction == null)
        {
            throw new NotFoundException();
        }

        _context.UserActions.Remove(userAction);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many UserActions
    /// </summary>
    public async Task<List<UserAction>> UserActions(UserActionFindManyArgs findManyArgs)
    {
        var userActions = await _context
            .UserActions.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return userActions.ConvertAll(userAction => userAction.ToDto());
    }

    /// <summary>
    /// Meta data about UserAction records
    /// </summary>
    public async Task<MetadataDto> UserActionsMeta(UserActionFindManyArgs findManyArgs)
    {
        var count = await _context.UserActions.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one UserAction
    /// </summary>
    public async Task<UserAction> UserAction(UserActionWhereUniqueInput uniqueId)
    {
        var userActions = await this.UserActions(
            new UserActionFindManyArgs { Where = new UserActionWhereInput { Id = uniqueId.Id } }
        );
        var userAction = userActions.FirstOrDefault();
        if (userAction == null)
        {
            throw new NotFoundException();
        }

        return userAction;
    }

    /// <summary>
    /// Update one UserAction
    /// </summary>
    public async Task UpdateUserAction(
        UserActionWhereUniqueInput uniqueId,
        UserActionUpdateInput updateDto
    )
    {
        var userAction = updateDto.ToModel(uniqueId);

        _context.Entry(userAction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.UserActions.Any(e => e.Id == userAction.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
