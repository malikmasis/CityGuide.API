using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;

namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    public class BaseController : Controller
    {
        protected readonly IAppRepository _appRepository;
        protected readonly IMapper _mapper;

        public BaseController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }
    }
}