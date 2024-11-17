using BenzodiazepineManagement.APIs.Common;
using BenzodiazepineManagement.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace BenzodiazepineManagement.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ImageResourceFindManyArgs : FindManyInput<ImageResource, ImageResourceWhereInput> { }
