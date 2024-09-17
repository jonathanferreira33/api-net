using API.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovementController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IServiceMovement _service;
        public MovementController(IServiceMovement service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

    }
}
