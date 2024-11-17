using BenzodiazepineManagement.Infrastructure;

namespace BenzodiazepineManagement.APIs;

public class BenzodiazepinesService : BenzodiazepinesServiceBase
{
    public BenzodiazepinesService(BenzodiazepineManagementDbContext context)
        : base(context) { }
}
