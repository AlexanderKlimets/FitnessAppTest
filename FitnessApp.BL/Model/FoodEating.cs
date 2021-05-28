using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class FoodEating
    {
        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime EatingTime { get; }

        /// <summary>
        /// Набор употребленных продуктов и их весов.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }

        /// <summary>
        /// Пользователь пищи.
        /// </summary>
        public UserModel User { get; }

        /// <summary>
        /// Создать новый прием пищи.
        /// </summary>
        /// <param name="user"> Имя пользователя. </param>
        public FoodEating(UserModel user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            EatingTime = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Добавить еду в прием пищи.
        /// </summary>
        /// <param name="food"> Название продукта. </param>
        /// <param name="weight"> Вес продукта. </param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }           
        }
    }
}
