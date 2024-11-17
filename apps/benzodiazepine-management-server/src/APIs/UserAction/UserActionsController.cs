using Microsoft.AspNetCore.Mvc;

namespace BenzodiazepineManagement.APIs;

[ApiController()]
public class UserActionsController : UserActionsControllerBase
{
    public UserActionsController(IUserActionsService service)
        : base(service) { }
}
