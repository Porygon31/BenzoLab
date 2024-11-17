using BenzodiazepineManagement.Infrastructure;

namespace BenzodiazepineManagement.APIs;

public class PharmacologicalPropertiesService : PharmacologicalPropertiesServiceBase
{
    public PharmacologicalPropertiesService(BenzodiazepineManagementDbContext context)
        : base(context) { }
}
