using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CerebellumRestLib.Models.JSON.Entities;
using CerebellumRestLib.Models.JSON.Results;

namespace CerebellumRestLib.Queries.Services.Abstract
{
    public interface IUsersService
    {
        Task<List<City>> GetCities();
        Task<List<DepUser>> GetDepUsers();
        Task<List<DepUser>> GetDepUsers(int? departmentId);
        Task<StandartDatastore> GetStandartDatastore();
        Task<List<DbDatastore>> GetStoresList();
        Task<int> GetUserCount();
        Task<UserInfo> UserRegister(UserRegister userRegister);

        Task RemoveUser(int userId);
        Task<UserInfo> AddUser(UserEdit user);
        /// <summary>
        /// Изменение данных пользователя
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="user">Изменяемые параметры</param>
        /// <returns></returns>
        Task<DepUser> EditUser(int id, UserEdit user);
        /// <summary>
        /// Получение аватара пользователя
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns></returns>
        Task<System.IO.Stream> GetUserAvatar(int userId);
        /// <summary>
        /// Получение аватара пользователя по размерам
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        /// <returns></returns>
        Task<System.IO.Stream> GetUserAvatarCrop(int id, int width, int height);
        /// <summary>
        /// Получить текущий срез значений всех датчиков
        /// </summary>
        /// <returns></returns>
        Task<List<Sensor>> GetSensorsValues();
        /// <summary>
        /// Получить историю значений датчиков пользователя за указанный период
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="from">Начало интервала</param>
        /// <param name="till">Конец интервала</param>
        /// <returns></returns>
        Task<List<Sensor>> GetSensorsHistory(int userId, DateTimeOffset from, DateTimeOffset till);
        /// <summary>
        /// Список меток пользователей.
        /// </summary>
        /// <param name="page">Страница для загрузки</param>
        /// <param name="limit">Лимит загружаемых элементов</param>
        /// <returns></returns>
        Task<List<Tag>> GetTagsList(int page = 1, int limit = 25);
        /// <summary>
        /// Получение конкретной метки
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        Task<Tag> GetTag(int tagId);
        /// <summary>
        /// Удаление аватара
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns></returns>
        Task DeleteAvatar(int userId);
        /// <summary>
        /// Получение типов пользователей
        /// </summary>
        /// <param name="page">Страница для загрузки</param>
        /// <param name="limit">Лимит загружаемых элементов</param>
        /// <returns></returns>
        Task<List<UserType>> GetUserTypes(int page = 1, int limit = 25);
        Task<CurrentUserInfo> GetCurrentUser();
    }
}