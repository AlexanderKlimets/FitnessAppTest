using System;

namespace FitnessApp.BL.Model
{   /// <summary>
    /// Описывает данные пола
    /// </summary>
    [Serializable]
    public class GenderModel
    {
        /// <summary>
        /// Название пола. 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name"> Имя пола. </param>
        public GenderModel(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null");
            }
            Name = name;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
