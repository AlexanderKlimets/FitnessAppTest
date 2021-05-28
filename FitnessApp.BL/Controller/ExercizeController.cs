using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер упражнений.
    /// </summary>
    public class ExercizeController : BaseController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        private readonly UserModel user;
        
        /// <summary>
        /// Имя файла для сохранения списка упражнений по умолчанию.
        /// </summary>
        private const string EXERSIZE_FILE_NAME = "exersize.data";
        
        /// <summary>
        /// Имя файла для сохранения списка активностей по умолчанию.
        /// </summary>
        private const string ACTIVITY_FILE_NAME = "activity.data";

        /// <summary>
        /// Список упражнений.
        /// </summary>
        public List<Exercize> Exercizes;

        /// <summary>
        /// Список активностей.
        /// </summary>
        public List<Activity> Activities;

        /// <summary>
        /// Создать новый контроллер упражений.
        /// </summary>
        /// <param name="user"> Имя пользователя. </param>
        public ExercizeController(UserModel user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Exercizes = GetAllExersises();
            Activities = GetAllActivities();
        }

        /// <summary>
        /// Добавить активность в список.
        /// </summary>
        /// <param name="activity"> Новая активность. </param>
        /// <param name="start"> Время начала упражения. </param>
        /// <param name="stop">Время окончания упражнения. </param>
        public void Add (Activity activity, DateTime start, DateTime stop)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);                         
            }
         
            var exersize = new Exercize(start, stop, activity, user);
            Exercizes.Add(exersize);
            Save();
        }

        /// <summary>
        /// Получить список упражнений.
        /// </summary>
        private List<Exercize> GetAllExersises()
        {
            return Load<List<Exercize>>(EXERSIZE_FILE_NAME) ?? new List<Exercize>();
        }

        /// <summary>
        /// Получить список активностей.
        /// </summary>
        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITY_FILE_NAME) ?? new List<Activity>();
        }

        /// <summary>
        /// Сохранить список активностей.
        /// </summary>
        private void Save()
        {
            Save(EXERSIZE_FILE_NAME, Exercizes);
            Save(ACTIVITY_FILE_NAME, Activities);
        }
    }
}
