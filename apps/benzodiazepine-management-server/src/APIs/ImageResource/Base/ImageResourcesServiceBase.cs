using BenzodiazepineManagement.APIs;
using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.APIs.Dtos;
using BenzodiazepineManagement.APIs.Errors;
using BenzodiazepineManagement.APIs.Extensions;
using BenzodiazepineManagement.Infrastructure;
using BenzodiazepineManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BenzodiazepineManagement.APIs;

public abstract class ImageResourcesServiceBase : IImageResourcesService
{
    protected readonly BenzodiazepineManagementDbContext _context;

    public ImageResourcesServiceBase(BenzodiazepineManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ImageResource
    /// </summary>
    public async Task<ImageResource> CreateImageResource(ImageResourceCreateInput createDto)
    {
        var imageResource = new ImageResourceDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            imageResource.Id = createDto.Id;
        }

        _context.ImageResources.Add(imageResource);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ImageResourceDbModel>(imageResource.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ImageResource
    /// </summary>
    public async Task DeleteImageResource(ImageResourceWhereUniqueInput uniqueId)
    {
        var imageResource = await _context.ImageResources.FindAsync(uniqueId.Id);
        if (imageResource == null)
        {
            throw new NotFoundException();
        }

        _context.ImageResources.Remove(imageResource);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ImageResources
    /// </summary>
    public async Task<List<ImageResource>> ImageResources(ImageResourceFindManyArgs findManyArgs)
    {
        var imageResources = await _context
            .ImageResources.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return imageResources.ConvertAll(imageResource => imageResource.ToDto());
    }

    /// <summary>
    /// Meta data about ImageResource records
    /// </summary>
    public async Task<MetadataDto> ImageResourcesMeta(ImageResourceFindManyArgs findManyArgs)
    {
        var count = await _context.ImageResources.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ImageResource
    /// </summary>
    public async Task<ImageResource> ImageResource(ImageResourceWhereUniqueInput uniqueId)
    {
        var imageResources = await this.ImageResources(
            new ImageResourceFindManyArgs
            {
                Where = new ImageResourceWhereInput { Id = uniqueId.Id }
            }
        );
        var imageResource = imageResources.FirstOrDefault();
        if (imageResource == null)
        {
            throw new NotFoundException();
        }

        return imageResource;
    }

    /// <summary>
    /// Update one ImageResource
    /// </summary>
    public async Task UpdateImageResource(
        ImageResourceWhereUniqueInput uniqueId,
        ImageResourceUpdateInput updateDto
    )
    {
        var imageResource = updateDto.ToModel(uniqueId);

        _context.Entry(imageResource).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ImageResources.Any(e => e.Id == imageResource.Id))
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
