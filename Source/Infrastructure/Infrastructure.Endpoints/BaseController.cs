using Microsoft.AspNetCore.Mvc;

namespace LP.Common.Infrastructure.Endpoints;

public class BaseController(IGate gate) : ControllerBase
{
    protected IGate Gate { get; } = gate;
}