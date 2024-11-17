using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;

namespace BenzodiazepineManagement.APIs;

public interface IPharmacologicalPropertiesService
{
    /// <summary>
    /// Create one PharmacologicalProperty
    /// </summary>
    public Task<PharmacologicalProperty> CreatePharmacologicalProperty(
        PharmacologicalPropertyCreateInput pharmacologicalproperty
    );

    /// <summary>
    /// Delete one PharmacologicalProperty
    /// </summary>
    public Task DeletePharmacologicalProperty(PharmacologicalPropertyWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PharmacologicalProperties
    /// </summary>
    public Task<List<PharmacologicalProperty>> PharmacologicalProperties(
        PharmacologicalPropertyFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about PharmacologicalProperty records
    /// </summary>
    public Task<MetadataDto> PharmacologicalPropertiesMeta(
        PharmacologicalPropertyFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one PharmacologicalProperty
    /// </summary>
    public Task<PharmacologicalProperty> PharmacologicalProperty(
        PharmacologicalPropertyWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Update one PharmacologicalProperty
    /// </summary>
    public Task UpdatePharmacologicalProperty(
        PharmacologicalPropertyWhereUniqueInput uniqueId,
        PharmacologicalPropertyUpdateInput updateDto
    );
}
