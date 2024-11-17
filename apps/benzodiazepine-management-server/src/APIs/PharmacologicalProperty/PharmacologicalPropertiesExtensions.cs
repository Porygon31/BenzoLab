using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.Infrastructure.Models;

namespace BenzodiazepineManagement.APIs.Extensions;

public static class PharmacologicalPropertiesExtensions
{
    public static PharmacologicalProperty ToDto(this PharmacologicalPropertyDbModel model)
    {
        return new PharmacologicalProperty
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PharmacologicalPropertyDbModel ToModel(
        this PharmacologicalPropertyUpdateInput updateDto,
        PharmacologicalPropertyWhereUniqueInput uniqueId
    )
    {
        var pharmacologicalProperty = new PharmacologicalPropertyDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            pharmacologicalProperty.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            pharmacologicalProperty.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return pharmacologicalProperty;
    }
}
