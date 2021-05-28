using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// Список пользователей приложения.
        /// </summary>
        public List<UserModel>  Users { get; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public UserModel CurrentUser { get; }

        /// <summary>
        /// Является ли пользователь вновь созданным.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Имя файла для сохранения списка пользователей по умолчанию.
        /// </summary>
        private const string USERS_FILE_NAME = "users.data";

        /// <summary>
        /// Создать новый контроллер пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new UserModel(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);

        }

        /// <summary>
        /// Получить сохраненный список ползователей.
        /// </summary>
        /// <returns> Пользователь приложения. </returns>
        private List<UserModel> GetUsersData()
        {
            return Load<List<UserModel>>(USERS_FILE_NAME) ?? new List<UserModel>();
     
        }
    
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //Проверка

            CurrentUser.Gender = new GenderModel(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

    }
}
