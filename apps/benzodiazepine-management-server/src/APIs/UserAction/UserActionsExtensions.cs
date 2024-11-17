using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.Infrastructure.Models;

namespace BenzodiazepineManagement.APIs.Extensions;

public static class UserActionsExtensions
{
    public static UserAction ToDto(this UserActionDbModel model)
    {
        return new UserAction
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static UserActionDbModel ToModel(
        this UserActionUpdateInput updateDto,
        UserActionWhereUniqueInput uniqueId
    )
    {
        var userAction = new UserActionDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            userAction.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            userAction.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return userAction;
    }
}
