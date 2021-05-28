using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер приема пищи.
    /// </summary>
    public class EatingController : BaseController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        private readonly UserModel User;

        /// <summary>
        /// Список продуктов.
        /// </summary>
        public List<Food> Foods { get; }

        /// <summary>
        /// Список приемов пищи.
        /// </summary>
        public FoodEating Eating { get; }


        /// <summary>
        /// Имя файла для сохранения списка продуктов по умолчанию.
        /// </summary>
        private const string FOODS_FILE_NAME = "foods.data";

        /// <summary>
        /// Имя файла для сохранения списка продуктов по умолчанию.
        /// </summary>
        private const string EATINGS_FILE_NAME = "eating.data";

        /// <summary>
        /// Создать новый контроллер приема пищи.
        /// </summary>
        /// <param name="user"> Пользователь приложения. </param>
        public EatingController (UserModel user)
        {
            this.User = user ?? throw new ArgumentNullException ("Пользователь не может быть пустым!", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        /// <summary>
        /// Добавить еду в список.
        /// </summary>
        /// <param name="foodName"> Название продукта. </param>
        /// <param name="weight"> Вес продукта. </param>
        public void Add(Food foodName, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == foodName.Name);
            if (product == null)
            {
                Foods.Add(foodName);
                Eating.Add(foodName, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        /// <summary>
        /// Получить список продуктов.
        /// </summary>
        public List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        /// <summary>
        /// Получить данные приема пищи.
        /// </summary>
        public FoodEating GetEating()
        {
            return Load<FoodEating>(EATINGS_FILE_NAME) ?? new FoodEating(User);
        }


        /// <summary>
        /// Сохранить список продуктов.
        /// </summary>
        public void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}
