using Microsoft.AspNetCore.Mvc;

namespace BenzodiazepineManagement.APIs;

[ApiController()]
public class PharmacologicalPropertiesController : PharmacologicalPropertiesControllerBase
{
    public PharmacologicalPropertiesController(IPharmacologicalPropertiesService service)
        : base(service) { }
}
