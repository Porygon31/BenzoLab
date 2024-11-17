using Microsoft.AspNetCore.Mvc;

namespace BenzodiazepineManagement.APIs;

[ApiController()]
public class BenzodiazepinesController : BenzodiazepinesControllerBase
{
    public BenzodiazepinesController(IBenzodiazepinesService service)
        : base(service) { }
}
