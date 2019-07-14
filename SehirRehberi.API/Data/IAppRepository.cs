using System.Collections.Generic;
using System.Threading.Tasks;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T:class ;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<T> GetByIdAsync<T>(int id) where T : class;
        T GetById<T>(int id) where T : class;
        bool SaveAll();
        List<City> GetCities();
        List<Photo> GetPhotosByCity(int cityId);
        City GetCityById(int cityId);
        Photo GetPhoto(int id);
    }
}
