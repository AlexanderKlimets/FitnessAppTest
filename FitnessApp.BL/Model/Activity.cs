using System;


namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Активность.
    /// </summary>
    [Serializable]
    public class Activity
    {
        /// <summary>
        /// Название активности.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Расход калорий в минуту.
        /// </summary>
        public double CaloriesPerMinute { get; set; }

        /// <summary>
        /// Создать новую активность.
        /// </summary>
        /// <param name="name"> Название активности. </param>
        /// <param name="caloriesPerMinute"> Расход калорий в минуту. </param>
        public Activity (string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException("Название активности не может быть пустым!", nameof(name));
                }
            Name = name;
            if(caloriesPerMinute <= 0)
            {
                throw new ArgumentException("Количество сжигаемых каллорий не может быть отрицательным!", nameof(caloriesPerMinute));
            }
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return (Name + "-" + CaloriesPerMinute.ToString());
        }
    }
}
