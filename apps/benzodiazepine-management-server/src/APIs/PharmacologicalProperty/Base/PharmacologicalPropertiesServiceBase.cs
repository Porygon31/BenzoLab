using BenzodiazepineManagement.APIs;
using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.APIs.Errors;
using BenzodiazepineManagement.APIs.Extensions;
using BenzodiazepineManagement.Infrastructure;
using BenzodiazepineManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BenzodiazepineManagement.APIs;

public abstract class PharmacologicalPropertiesServiceBase : IPharmacologicalPropertiesService
{
    protected readonly BenzodiazepineManagementDbContext _context;

    public PharmacologicalPropertiesServiceBase(BenzodiazepineManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PharmacologicalProperty
    /// </summary>
    public async Task<PharmacologicalProperty> CreatePharmacologicalProperty(
        PharmacologicalPropertyCreateInput createDto
    )
    {
        var pharmacologicalProperty = new PharmacologicalPropertyDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            pharmacologicalProperty.Id = createDto.Id;
        }

        _context.PharmacologicalProperties.Add(pharmacologicalProperty);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PharmacologicalPropertyDbModel>(
            pharmacologicalProperty.Id
        );

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PharmacologicalProperty
    /// </summary>
    public async Task DeletePharmacologicalProperty(
        PharmacologicalPropertyWhereUniqueInput uniqueId
    )
    {
        var pharmacologicalProperty = await _context.PharmacologicalProperties.FindAsync(
            uniqueId.Id
        );
        if (pharmacologicalProperty == null)
        {
            throw new NotFoundException();
        }

        _context.PharmacologicalProperties.Remove(pharmacologicalProperty);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PharmacologicalProperties
    /// </summary>
    public async Task<List<PharmacologicalProperty>> PharmacologicalProperties(
        PharmacologicalPropertyFindManyArgs findManyArgs
    )
    {
        var pharmacologicalProperties = await _context
            .PharmacologicalProperties.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return pharmacologicalProperties.ConvertAll(pharmacologicalProperty =>
            pharmacologicalProperty.ToDto()
        );
    }

    /// <summary>
    /// Meta data about PharmacologicalProperty records
    /// </summary>
    public async Task<MetadataDto> PharmacologicalPropertiesMeta(
        PharmacologicalPropertyFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .PharmacologicalProperties.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PharmacologicalProperty
    /// </summary>
    public async Task<PharmacologicalProperty> PharmacologicalProperty(
        PharmacologicalPropertyWhereUniqueInput uniqueId
    )
    {
        var pharmacologicalProperties = await this.PharmacologicalProperties(
            new PharmacologicalPropertyFindManyArgs
            {
                Where = new PharmacologicalPropertyWhereInput { Id = uniqueId.Id }
            }
        );
        var pharmacologicalProperty = pharmacologicalProperties.FirstOrDefault();
        if (pharmacologicalProperty == null)
        {
            throw new NotFoundException();
        }

        return pharmacologicalProperty;
    }

    /// <summary>
    /// Update one PharmacologicalProperty
    /// </summary>
    public async Task UpdatePharmacologicalProperty(
        PharmacologicalPropertyWhereUniqueInput uniqueId,
        PharmacologicalPropertyUpdateInput updateDto
    )
    {
        var pharmacologicalProperty = updateDto.ToModel(uniqueId);

        _context.Entry(pharmacologicalProperty).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PharmacologicalProperties.Any(e => e.Id == pharmacologicalProperty.Id))
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
