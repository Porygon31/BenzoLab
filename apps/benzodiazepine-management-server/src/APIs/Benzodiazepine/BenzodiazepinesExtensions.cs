using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.Infrastructure.Models;

namespace BenzodiazepineManagement.APIs.Extensions;

public static class BenzodiazepinesExtensions
{
    public static Benzodiazepine ToDto(this BenzodiazepineDbModel model)
    {
        return new Benzodiazepine
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static BenzodiazepineDbModel ToModel(
        this BenzodiazepineUpdateInput updateDto,
        BenzodiazepineWhereUniqueInput uniqueId
    )
    {
        var benzodiazepine = new BenzodiazepineDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            benzodiazepine.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            benzodiazepine.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return benzodiazepine;
    }
}
