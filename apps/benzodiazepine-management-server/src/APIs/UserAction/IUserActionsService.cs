using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;

namespace BenzodiazepineManagement.APIs;

public interface IUserActionsService
{
    /// <summary>
    /// Create one UserAction
    /// </summary>
    public Task<UserAction> CreateUserAction(UserActionCreateInput useraction);

    /// <summary>
    /// Delete one UserAction
    /// </summary>
    public Task DeleteUserAction(UserActionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many UserActions
    /// </summary>
    public Task<List<UserAction>> UserActions(UserActionFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about UserAction records
    /// </summary>
    public Task<MetadataDto> UserActionsMeta(UserActionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one UserAction
    /// </summary>
    public Task<UserAction> UserAction(UserActionWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one UserAction
    /// </summary>
    public Task UpdateUserAction(
        UserActionWhereUniqueInput uniqueId,
        UserActionUpdateInput updateDto
    );
}
