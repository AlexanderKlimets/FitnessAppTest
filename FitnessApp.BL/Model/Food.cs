using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Продукт.
    /// </summary>
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки на 100 гр. продукта.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры на 100 гр. продукта.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы на 100 гр. продукта.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Количество калорий на 100 гр. продукта.
        /// </summary>
        public double Callories { get; }

        /// <summary>
        /// Количество калорий на 1 гр. продукта.
        /// </summary>
        private double CaloriesPerGram { get { return Callories / 100.0; } }

        /// <summary>
        /// Количество калорий на 1 гр. продукта.
        /// </summary>
        private double ProteinsPerGram { get { return Proteins / 100.0; } }

        /// <summary>
        /// Количество калорий на 1 гр. продукта.
        /// </summary>
        private double FatsPerGram { get { return Fats / 100.0; } }

        /// <summary>
        /// Количество калорий на 1 гр. продукта.
        /// </summary>
        private double CarbohydratesPerGram { get { return Carbohydrates / 100.0; } }

        /// <summary>
        /// Создать новый продукт.
        /// </summary>
        /// <param name="foodName">Название.</param>
        public Food (string foodName) : this(foodName, 0, 0, 0, 0) { }

        /// <summary>
        /// Создать новый продукт.
        /// </summary>
        /// <param name="foodName">Название.</param>
        /// <param name="callories">Калорийность.</param>
        /// <param name="proteins">Количество белков.</param>
        /// <param name="fats">Количество жиров.</param>
        /// <param name="carbohydrates">Количество углеводов.</param>
        public Food(string foodName, double callories, double proteins, double fats, double carbohydrates)
        {
            if (string.IsNullOrWhiteSpace(foodName))
            {
                throw new ArgumentNullException("Название продукта питания не может быть пустым!", nameof(foodName));
            }
            if (callories <= 0)
            {
                throw new ArgumentException("Количество каллорий не может быть отрицательным!", nameof(callories));
            }
            if (proteins <= 0)
            {
                throw new ArgumentException("Количество белков не может быть отрицательным!", nameof(proteins));
            }
            if (fats <= 0)
            {
                throw new ArgumentException("Количество жиров не может быть отрицательным!", nameof(fats));
            }
            if (carbohydrates <= 0)
            {
                throw new ArgumentException("Количество углеводов не может быть отрицательным!", nameof(carbohydrates));
            }

            Name = foodName;
            Callories = callories;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}