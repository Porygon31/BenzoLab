using BenzodiazepineManagement.APIs;
using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.APIs.Errors;
using BenzodiazepineManagement.APIs.Extensions;
using BenzodiazepineManagement.Infrastructure;
using BenzodiazepineManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BenzodiazepineManagement.APIs;

public abstract class BenzodiazepinesServiceBase : IBenzodiazepinesService
{
    protected readonly BenzodiazepineManagementDbContext _context;

    public BenzodiazepinesServiceBase(BenzodiazepineManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Benzodiazepine
    /// </summary>
    public async Task<Benzodiazepine> CreateBenzodiazepine(BenzodiazepineCreateInput createDto)
    {
        var benzodiazepine = new BenzodiazepineDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            benzodiazepine.Id = createDto.Id;
        }

        _context.Benzodiazepines.Add(benzodiazepine);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BenzodiazepineDbModel>(benzodiazepine.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Benzodiazepine
    /// </summary>
    public async Task DeleteBenzodiazepine(BenzodiazepineWhereUniqueInput uniqueId)
    {
        var benzodiazepine = await _context.Benzodiazepines.FindAsync(uniqueId.Id);
        if (benzodiazepine == null)
        {
            throw new NotFoundException();
        }

        _context.Benzodiazepines.Remove(benzodiazepine);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Benzodiazepines
    /// </summary>
    public async Task<List<Benzodiazepine>> Benzodiazepines(BenzodiazepineFindManyArgs findManyArgs)
    {
        var benzodiazepines = await _context
            .Benzodiazepines.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return benzodiazepines.ConvertAll(benzodiazepine => benzodiazepine.ToDto());
    }

    /// <summary>
    /// Meta data about Benzodiazepine records
    /// </summary>
    public async Task<MetadataDto> BenzodiazepinesMeta(BenzodiazepineFindManyArgs findManyArgs)
    {
        var count = await _context.Benzodiazepines.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Benzodiazepine
    /// </summary>
    public async Task<Benzodiazepine> Benzodiazepine(BenzodiazepineWhereUniqueInput uniqueId)
    {
        var benzodiazepines = await this.Benzodiazepines(
            new BenzodiazepineFindManyArgs
            {
                Where = new BenzodiazepineWhereInput { Id = uniqueId.Id }
            }
        );
        var benzodiazepine = benzodiazepines.FirstOrDefault();
        if (benzodiazepine == null)
        {
            throw new NotFoundException();
        }

        return benzodiazepine;
    }

    /// <summary>
    /// Update one Benzodiazepine
    /// </summary>
    public async Task UpdateBenzodiazepine(
        BenzodiazepineWhereUniqueInput uniqueId,
        BenzodiazepineUpdateInput updateDto
    )
    {
        var benzodiazepine = updateDto.ToModel(uniqueId);

        _context.Entry(benzodiazepine).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Benzodiazepines.Any(e => e.Id == benzodiazepine.Id))
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
