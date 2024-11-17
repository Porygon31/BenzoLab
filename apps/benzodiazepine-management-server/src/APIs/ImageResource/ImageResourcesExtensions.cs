using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.Infrastructure.Models;

namespace BenzodiazepineManagement.APIs.Extensions;

public static class ImageResourcesExtensions
{
    public static ImageResource ToDto(this ImageResourceDbModel model)
    {
        return new ImageResource
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ImageResourceDbModel ToModel(
        this ImageResourceUpdateInput updateDto,
        ImageResourceWhereUniqueInput uniqueId
    )
    {
        var imageResource = new ImageResourceDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            imageResource.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            imageResource.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return imageResource;
    }
}
