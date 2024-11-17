using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;

namespace BenzodiazepineManagement.APIs;

public interface IImageResourcesService
{
    /// <summary>
    /// Create one ImageResource
    /// </summary>
    public Task<ImageResource> CreateImageResource(ImageResourceCreateInput imageresource);

    /// <summary>
    /// Delete one ImageResource
    /// </summary>
    public Task DeleteImageResource(ImageResourceWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ImageResources
    /// </summary>
    public Task<List<ImageResource>> ImageResources(ImageResourceFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about ImageResource records
    /// </summary>
    public Task<MetadataDto> ImageResourcesMeta(ImageResourceFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ImageResource
    /// </summary>
    public Task<ImageResource> ImageResource(ImageResourceWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ImageResource
    /// </summary>
    public Task UpdateImageResource(
        ImageResourceWhereUniqueInput uniqueId,
        ImageResourceUpdateInput updateDto
    );
}
