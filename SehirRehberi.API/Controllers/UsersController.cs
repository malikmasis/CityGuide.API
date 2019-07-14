using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Route("api/Users")]
    public class UsersController : BaseController
    {
        public UsersController(IAppRepository appRepository, IMapper mapper)
            : base(appRepository, mapper)
        {
        }

        [HttpGet("detail")]
        public ActionResult GetUserById(int id)
        {
            User user = _appRepository.GetById<User>(id);
            return Ok(user);
        }

        [HttpPost("delete")]
        public ActionResult Delete(int id)
        {
            var user = _appRepository.GetById<User>(id);
            _appRepository.Delete<User>(user);
            bool isDeleted = _appRepository.SaveAll();
            return Ok(isDeleted);
        }

        [HttpPost("update")]
        public ActionResult Update([FromBody]UserForUpdateDto user)
        {
            var mapToUser = _mapper.Map<User>(user);

            Helpers.PasswordHash.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            mapToUser.PasswordHash = passwordHash;
            mapToUser.PasswordSalt = passwordSalt;

            _appRepository.Update(mapToUser);

            bool isUpated = _appRepository.SaveAll();
            return Ok(isUpated);
        }
    }
}