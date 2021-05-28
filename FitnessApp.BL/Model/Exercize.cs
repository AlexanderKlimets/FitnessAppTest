using System;


namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Упражнение.
    /// </summary>
    [Serializable]
    public class Exercize
    {
        /// <summary>
        /// Время начала упражнения.
        /// </summary>
        public DateTime TimeOfStart { get; }

        /// <summary>
        /// Время окончания упражнения.
        /// </summary>
        public DateTime TimeOfStop { get; }

        /// <summary>
        /// Активность.
        /// </summary>
        public Activity Activity { get; set; }

        /// <summary>
        /// Пользователь, совершивший активность.
        /// </summary>
        public UserModel User { get; }

        /// <summary>
        /// Создать новое упражнение.
        /// </summary>
        /// <param name="timeOfStart"> Время начала упражнения. </param>
        /// <param name="timeOfStop"> Время окончания упражнения. </param>
        /// <param name="activity"> Активность. </param>
        /// <param name="user"> Пользователь, совершивший активность.</param>
        public Exercize (DateTime timeOfStart, 
                         DateTime timeOfStop, 
                         Activity activity,
                         UserModel user)
        {
            if (timeOfStart > DateTime.Now)
            {
                throw new ArgumentException("Некорректное время начала!", nameof(timeOfStart));
            }

            if (timeOfStop > DateTime.Now)
            {
                throw new ArgumentException("Некорректное время окончания!", nameof(timeOfStop));
            }

            TimeOfStart = timeOfStart;
            TimeOfStop = timeOfStop;
            Activity = activity ?? throw new ArgumentNullException("Активность не может быть пустым", nameof(activity));
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
        }

        public override string ToString()
        {
            return TimeOfStart.ToString() + TimeOfStop.ToString() + Activity.Name + User.Name;
        }
    }
}
