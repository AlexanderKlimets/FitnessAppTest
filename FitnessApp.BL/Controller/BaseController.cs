using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Базовый контроллер.
    /// </summary>
    public abstract class BaseController
    {
        /// <summary>
        /// Базовое сохранение данных.
        /// </summary>
        /// <param name="fileName"> Имя файла. </param>
        /// <param name="item"> Объект, который будеь сохранен. </param>
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        /// <summary>
        /// Базовая загрузка данных.
        /// </summary>
        /// <typeparam name="T"> Тип загружаемых данных. </typeparam>
        /// <param name="fileName"> Имя файла. </param>
        /// <returns> Загруженные данные или значение по умолчаю. </returns>
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items )
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
