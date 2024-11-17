using BenzodiazepineManagement.Infrastructure;

namespace BenzodiazepineManagement.APIs;

public class ImageResourcesService : ImageResourcesServiceBase
{
    public ImageResourcesService(BenzodiazepineManagementDbContext context)
        : base(context) { }
}
