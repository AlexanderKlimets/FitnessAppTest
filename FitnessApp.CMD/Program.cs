using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace FitnessApp.CMD
{
    class Program
    {

        public void SetUpNewDoubleValue(string question, out double newDoubleValue)
        {
            while (true)
            {
                Console.WriteLine(question);
                if (double.TryParse(Console.ReadLine(), out newDoubleValue))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения.");
                }
            }
        }



        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            //TODO: Определять язык системы и на его основе подгружать нужный файл ресурсов
            var resourseManager = new ResourceManager("FitnessApp.CMD.Languages.Message", typeof(Program).Assembly);

            //TODO: Получать строки от ResourceManager, а не из паки Languages
            Console.WriteLine(resourseManager.GetString("Greetings", culture));
            //Console.WriteLine(Languages.Message_ru_ru.Greetings);

            Console.WriteLine(resourseManager.GetString("EnterUserName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);


            if (userController.IsNewUser)
            {
                Console.WriteLine(resourseManager.GetString("EnterUserGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime(resourseManager.GetString("EnterUserBirthDate", culture));
                var weight = ParseDouble(resourseManager.GetString("EnterUserWeight", culture));
                var height = ParseDouble(resourseManager.GetString("EnterUserHeight", culture));

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            var eatingController = new EatingController(userController.CurrentUser);

            var exersizeController = new ExercizeController(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - прием пищи");
                Console.WriteLine("A - добавить упражнение");
                Console.WriteLine("Q - Выход");
                var key = Console.ReadKey();


                switch (key.Key)
                {
                    case ConsoleKey.E:
                        {
                            var product = EnterEating(resourseManager, culture);
                            eatingController.Add(product.Product, product.Weight);

                            foreach (var item in eatingController.Eating.Foods)
                            {
                                Console.WriteLine($"\t{item.Key} - {item.Value}");
                            }
                            eatingController.Save();
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            var ex = EnterExersize();                    
                            exersizeController.Add(ex.activity, ex.begin, ex.stop);
                            foreach(var item in exersizeController.Exercizes)
                            {
                                Console.WriteLine($"\t{item.Activity} " +
                                                  $"c {item.TimeOfStart.ToShortTimeString()} " +
                                                  $"до {item.TimeOfStop.ToShortTimeString()}");
                            }

                            break;
                        }
                    case ConsoleKey.Q:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }

                Console.ReadLine();
            }
        }

        private static (DateTime begin, DateTime stop, Activity activity) EnterExersize()
        {
            Console.WriteLine("Введите название упражнения: ");
            var name = Console.ReadLine();

            var begin = ParseDateTime("начало упражения");
            var stop = ParseDateTime("окончание упражения");
            var caloriesPerMinute = ParseDouble("каллорийность упражнения");
            var activity = new Activity(name, caloriesPerMinute);

            return (begin, stop, activity);
        }

        private static (Food Product, double Weight) EnterEating(ResourceManager resourceManager, CultureInfo culture)
        {
            Console.WriteLine( "EnterProductName");
            var foodName = Console.ReadLine();

            var weight = ParseDouble( "EnterProductWeight");

            var callories = ParseDouble(resourceManager.GetString("EnterProductCallories", culture));
            var proteins = ParseDouble(resourceManager.GetString("EnterProductProteins", culture));
            var fats = ParseDouble(resourceManager.GetString("EnterProductFats", culture));
            var carbohydrates = ParseDouble(resourceManager.GetString("EnterProductCarbohydrates", culture));

            var product = new Food(foodName, callories, proteins, fats, carbohydrates);

            return (product, weight);
        }

        private static DateTime ParseDateTime(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}.");
                }
            }

            
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double newDoubleValue))
                {
                    return newDoubleValue;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля: {name}.");
                }
            }
        } 
    }
}
