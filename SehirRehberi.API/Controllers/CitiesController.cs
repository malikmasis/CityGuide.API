using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Route("api/Cities")]
    public class CitiesController : BaseController
    {
        public CitiesController(IAppRepository appRepository, IMapper mapper) : base(appRepository, mapper)
        {
        }

        public ActionResult GetCities()
        {
            var cities = _appRepository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(citiesToReturn);
        }

        [HttpPost("add")]
        public ActionResult Add([FromBody]City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();
            return Ok(city);
        }

        [HttpGet("detail")]
        public ActionResult GetCityById(int id)
        {
            var city = _appRepository.GetCityById(id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);
            return Ok(cityToReturn);
        }

        [HttpPost("delete")]
        public ActionResult Delete(int id)
        {
            var city = _appRepository.GetCityById(id);
            _appRepository.Delete<City>(city);
            bool isDeleted = _appRepository.SaveAll();
            return Ok(isDeleted);
        }

        [HttpGet("Photos")]
        public ActionResult GetPhotosByCity(int cityId)
        {
            var photos = _appRepository.GetPhotosByCity(cityId);
            return Ok(photos);
        }

        [HttpPost("update")]
        public ActionResult Update([FromBody]City city)
        {
            _appRepository.Update<City>(city);
            _appRepository.SaveAll();
            return Ok(city);

        }
    }
}