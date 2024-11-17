using Microsoft.AspNetCore.Mvc;

namespace BenzodiazepineManagement.APIs;

[ApiController()]
public class ImageResourcesController : ImageResourcesControllerBase
{
    public ImageResourcesController(IImageResourcesService service)
        : base(service) { }
}
