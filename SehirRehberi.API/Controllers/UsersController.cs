using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public UsersController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [Route("detail")]
        public ActionResult GetUserById(int id)
        {
            var user = _appRepository.GetByIdAsync<User>(id);
            var userToReturn = _mapper.Map<UserForRegisterDto>(user);
            return Ok(userToReturn);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var user = _appRepository.GetById<User>(id);
            _appRepository.Delete<User>(user);
            bool isDeleted = _appRepository.SaveAll();
            return Ok(isDeleted);
        }

        [HttpPost]
        [Route("update")]
        public ActionResult Update([FromBody]UserForRegisterDto user)
        {
            var mapToUser = _mapper.Map<User>(user);
            _appRepository.Update(mapToUser);
            _appRepository.SaveAll();
            return Ok(user);

        }
    }
}