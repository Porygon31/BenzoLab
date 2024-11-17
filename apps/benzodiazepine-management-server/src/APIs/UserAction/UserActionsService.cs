using BenzodiazepineManagement.Infrastructure;

namespace BenzodiazepineManagement.APIs;

public class UserActionsService : UserActionsServiceBase
{
    public UserActionsService(BenzodiazepineManagementDbContext context)
        : base(context) { }
}
