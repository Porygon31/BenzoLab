using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;

namespace BenzodiazepineManagement.APIs;

public interface IBenzodiazepinesService
{
    /// <summary>
    /// Create one Benzodiazepine
    /// </summary>
    public Task<Benzodiazepine> CreateBenzodiazepine(BenzodiazepineCreateInput benzodiazepine);

    /// <summary>
    /// Delete one Benzodiazepine
    /// </summary>
    public Task DeleteBenzodiazepine(BenzodiazepineWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Benzodiazepines
    /// </summary>
    public Task<List<Benzodiazepine>> Benzodiazepines(BenzodiazepineFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Benzodiazepine records
    /// </summary>
    public Task<MetadataDto> BenzodiazepinesMeta(BenzodiazepineFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Benzodiazepine
    /// </summary>
    public Task<Benzodiazepine> Benzodiazepine(BenzodiazepineWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Benzodiazepine
    /// </summary>
    public Task UpdateBenzodiazepine(
        BenzodiazepineWhereUniqueInput uniqueId,
        BenzodiazepineUpdateInput updateDto
    );
}
