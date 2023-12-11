using Animals.AnimalTypesEnum;
using Animals.Model;
using Animals.Presenter;
using System.Text;
using static Animals.Program;

namespace Animals.View
{
    internal class ViewAnimals
    {
        private AnimalRegistry registry;

        string[]? listsOfAnimals = new string[3];

        public ViewAnimals()
        {
            registry = new AnimalRegistry();
            this.listsOfAnimals = new string[] { " 1 - All animals", " 2 - Pets", " 3 - Pack animals" };
        }

        public ViewAnimals(AnimalRegistry registry)
        {
            this.registry = registry;
            this.listsOfAnimals = new string[] { " 1 - All animals", " 2 - Pets", " 3 - Pack animals" };
        }



        /// <summary>
        /// Запуск работы с реестром
        /// </summary>
        public void Start()
        {
            bool start = true;

            while (start)
            {
                Console.Clear();
                Console.WriteLine(
                   $"Реестр животных\n" +
                    new string('-', Console.WindowWidth) + "\n" +
                    "Выберите пункт меню\n" +
                    new string('-', Console.WindowWidth) + "\n" +
                    " 1 - Добавить новое животное\n" +
                    " 2 - Показать список команд животного\n" +
                    " 3 - Обучить животное новой команде\n" +
                    " 4 - Вывести животных по дате рождения\n" +
                    " 5 - Показать количество животных\n" +
                    " 6 - Показать всех животных\n" +
                    " 7 - Показать домашних питомцев\n" +
                    " 8 - Показать вьючных животных\n" +
                    "\n 0 - Для выхода из реестра"
                    );

                int mainNumber = InputIntValue();

                if (mainNumber == 0)
                {
                    start = false;
                    continue;
                }

                if (mainNumber < 0 || mainNumber > 8)
                {
                    Console.WriteLine("Такого пункта нет в меню. Нажмите клавишу и повторите ввод");
                    Console.ReadKey();
                    continue;
                }

                switch (mainNumber)
                {
                    case 1: // Добавить новое животное в реестр
                        {
                            bool isAddAnimal = false;

                            while (!isAddAnimal)
                            {
                                Console.Clear();
                                Console.WriteLine("Добавить животное -> Выбор типа животного\n" + new string('-', Console.WindowWidth));
                                Console.WriteLine("Для возврата в предыдущее меню нажмите 0\n" + new string('-', Console.WindowWidth));
                                Console.WriteLine("Кого вы хотите добавить?\n");

                                string[]? animals = new string[]
                                {
                                 " 1 - Кот",
                                 " 2 - Собака",
                                 " 3 - Хомяк",
                                 " 4 - Верблюд",
                                 " 5 - Лошадь",
                                 " 6 - Ослик"
                                };

                                foreach (var item in animals)
                                {
                                    Console.WriteLine(item);
                                }

                                int typeNum = InputIntValue();

                                if (typeNum == 0)
                                    break;

                                if (typeNum < 0 || typeNum > animals.Length)
                                {
                                    Console.WriteLine("Введено неверное значение, нажмите клавишу и попробуйте ещё раз");
                                    Console.ReadKey();
                                    continue;
                                }

                                AnimalType type = (AnimalType)(typeNum - 1);

                                AddAnimalToRegistry(type);
                                //isAddAnimal = true;
                            }

                            break;
                        }
                    case 2: // Показать список команд животного
                        {
                            bool selected = false;

                            while (!selected)
                            {
                                string path = $"Показать список команд -> Выберете список с животными\n";

                                var listToShow = NumberOfList(path);

                                if (listToShow.numberOfList == 0) break;

                                bool shown = false;

                                while (!shown)
                                {
                                    Console.Clear();

                                    if (listToShow.animals.Count > 0)
                                    {
                                        Console.WriteLine("Показать список команд -> Выберете список с животными -> Список животных");
                                        Console.WriteLine(new string('-', Console.WindowWidth));
                                        Console.WriteLine("Введите 0 для возврата в предыдущее меню");
                                        Console.WriteLine(new string('-', Console.WindowWidth));

                                        ShowTable(listToShow.animals);
                                        //registry.ShowAnimals(listToShow.numberOfList);

                                        int idToShow = InputIntValue("Введите id животного, команды которого надо посмотреть");

                                        if (idToShow == 0)
                                        {
                                            shown = true;
                                            continue;
                                        }

                                        Console.WriteLine();

                                        if (idToShow < 0 )
                                        {
                                            Console.WriteLine("Такого id нет в списке. Нажмите клавишу и попробуйте ещё раз");
                                            Console.ReadKey();
                                            continue;
                                        }

                                        foreach (var animal in listToShow.animals)
                                        {
                                            if (animal.FinalId == idToShow)
                                            {
                                                Console.WriteLine(animal.ShowCommands());
                                                Console.WriteLine("\nНажмите клавишу для продолжения");
                                                Console.ReadKey();
                                                //selected = true;
                                                //shown = true;
                                                break;
                                            }
                                        }

                                        //if (shown == false)
                                        //{
                                        //    Console.WriteLine("Введен неверный id. Нажмите кнопку и повторите ввод.");
                                        //    Console.ReadKey();
                                        //    continue;
                                        //}

                                    }
                                    else
                                    {
                                        Console.WriteLine("\nК сожалению животных пока нет. Нажмите клавишу для продолжения");
                                        Console.ReadKey();
                                        selected = true;
                                        shown = true;
                                        continue;
                                    }
                                }
                            }

                            break;
                        }
                    case 3: // обучить животное новой команде
                        {
                            bool trained = false;

                            while (!trained)
                            {
                                string path = $"Обучить новой команде -> Выбрать список с животными\n";

                                var listToShow = NumberOfList(path);

                                if (listToShow.numberOfList == 0) break;

                                bool shown = false;

                                while (!shown)
                                {

                                    if (listToShow.animals.Count > 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Обучить новой команде -> Выбрать список с животными -> Выбрать животное для обучения");
                                        Console.WriteLine(new string('-', Console.WindowWidth));
                                        Console.WriteLine("Введите 0 для возврата в предыдущее меню");
                                        Console.WriteLine(new string('-', Console.WindowWidth));

                                        ShowTable(listToShow.animals);
                                        // registry.ShowAnimals(listToShow.numberOfList);

                                        int idAnimalToTrain = InputIntValue("Введите id животного, которого надо обучить или 0 для возврата");

                                        if (idAnimalToTrain == 0)
                                        {
                                            shown = true;
                                            continue;
                                        }

                                        if (idAnimalToTrain < 0)
                                        {
                                            Console.WriteLine("Неверный ввод id. Нажмите клавишу и повторите ввод.");
                                            Console.ReadKey();
                                            continue;
                                        }

                                        foreach (var animal in listToShow.animals)
                                        {
                                            if (animal.FinalId == idAnimalToTrain)
                                            {
                                                string[]? commands = InputStrings("Введите команды, которым надо обучить животное");
                                                animal.AddCommand(commands);
                                                Console.WriteLine("Животное обучено. Нажмите клавишу для продолжения");
                                                Console.ReadKey();
                                                //shown = true;
                                                //trained = true;
                                                break;
                                            }
                                        }
                                        //if (trained == false)
                                        //{
                                        //    Console.WriteLine("Введен неверный id. Нажмите кнопку и повторите ввод.");
                                        //    Console.ReadKey();
                                        //    continue;
                                        //}
                                    }
                                    else
                                    {
                                        Console.WriteLine("К сожалению животных пока нет. Нажмите клавишу для продолжения");
                                        Console.ReadKey();
                                        shown = true;
                                        trained = true;
                                        break;
                                    }
                                }
                            }

                            break;
                        }
                    case 4: // Вывести животных по дате рождения
                        {
                            string path = $"Вывести животных по дате рождения -> Выберете список с животными\n";

                            var listToShow = NumberOfList(path);

                            if (listToShow.numberOfList == 0) break;

                            if (listToShow.animals.Count > 0)
                            {
                                List<Animal> sortedAnimalsByBirhDate = listToShow.animals.OrderBy(animal => animal.BirthDate).ToList();

                                Console.Clear();

                                ShowTable(sortedAnimalsByBirhDate);

                                //foreach (var animal in sortedAnimalsByBirhDate)
                                //{
                                //    Console.WriteLine(animal);
                                //}
                                Console.WriteLine("\nНажмите клавишу для продолжения");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Список животных пуст. Нажмите клавишу для продолжения");
                                Console.ReadKey();
                            }

                            break;
                        }
                    case 5: // Показать количество животных
                        {
                            string path = $"Показать количество животных -> Выберете список с животными\n";

                            var listToShow = NumberOfList(path);

                            if (listToShow.numberOfList == 0) break;

                            if (listToShow.animals.Count > 0)
                            {
                                Console.WriteLine($"\nВ списке {listToShow.animals.Count} животных");
                            }
                            else
                            {
                                Console.WriteLine("Список пуст. В нём 0 животных");
                            }

                            Console.WriteLine("\nНажмите клавишу для продолжения");
                            Console.ReadKey();

                            break;
                        }
                    case 6: // показать всех животных
                        {
                            Console.Clear();

                            ShowTable(registry.animals);

                            // registry.ShowAnimals(1);

                            Console.WriteLine("Нажмите клавишу, чтобы продолжить");
                            Console.ReadKey();

                            break;
                        }
                    case 7: // показать домашних животных
                        {
                            Console.Clear(); ;

                            ShowTable(registry.pets);

                            // registry.ShowAnimals(2);

                            Console.WriteLine("Нажмите клавишу, чтобы продолжить");
                            Console.ReadKey();

                            break;
                        }
                    case 8: // показать вьючных животных
                        {
                            Console.Clear();

                            ShowTable(registry.packAnimals);

                            // registry.ShowAnimals(3);

                            Console.WriteLine("Нажмите клавишу, чтобы продолжить");
                            Console.ReadKey();
                        }

                        break;
                }
            }
        }

        /// <summary>
        /// Кортеж
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Номер списка с животными и сам список</returns>
        private (int numberOfList, List<Animal> animals) NumberOfList(string path)
        {
            Console.Clear();
            Console.WriteLine(path + new string('-', Console.WindowWidth));
            Console.WriteLine("Для возврата в предыдущее меню нажмите 0\n" + new string('-', Console.WindowWidth));
            Console.WriteLine("Выберете список животных\n");

            foreach (var listOfAnimals in this.listsOfAnimals)
            {
                Console.WriteLine(listOfAnimals);
            }

            int number = InputIntValue();

            if (number < 0 || number > this.listsOfAnimals.Length)
            {
                Console.WriteLine("Неверный ввод. Нажмите клавишу и введите число заново");
                Console.ReadKey();
                return NumberOfList(path);
            }

            Console.WriteLine();

            List<Animal>? list = ListToShow(number);

            return (number, list);
        }

        private List<Animal>? ListToShow(int listNum)
        {
            switch (listNum)
            {
                case 1:
                    return registry.animals;
                case 2:
                    return registry.pets;
                case 3:
                    return registry.packAnimals;
                default:
                    return null;

            }
        }

        /// <summary>
        /// Добавляет животное в реестр
        /// </summary>
        /// <param name="type"></param>
        private void AddAnimalToRegistry(AnimalType type)
        {
            string animalType = string.Empty;
            switch (type)
            {
                case AnimalType.Cat:
                    {
                        animalType = "кота";
                        break;
                    }
                case AnimalType.Dog:
                    {
                        animalType = "собаки";
                        break;
                    }
                case AnimalType.Hamster:
                    {
                        animalType = "хомяка";
                        break;
                    }
                case AnimalType.Camel:
                    {
                        animalType = "верблюда";
                        break;
                    }
                case AnimalType.Horse:
                    {
                        animalType = "лошади";
                        break;
                    }
                case AnimalType.Donkey:
                    {
                        animalType = "ослика";
                        break;
                    }
            }
            Console.Clear();

            Console.WriteLine($"Добавить животное -> Выбор типа животного -> Ввод параметров {animalType}\n");

            string name = Input($"Введите имя {animalType}\n");

            DateTime birth = BirthDate(); // Ввод даты рождения животного

            string[]? commands = InputStrings("Обучите, если необходимо, животное командам");

            registry.CreateNewAnimal(type, name, birth, commands);
            Console.WriteLine($"\n{name} добавлен в список животных. Нажмите клавишу для продолжения");
            Console.ReadKey();
        }

        /// <summary>
        /// Ввод даты рождения животного
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        private DateTime BirthDate()
        {
            string[] birth = InputStrings("Введите дату рождения (YYYY MM DD)");

            int[] date = new int[3];

            for (int i = 0; i < birth.Length; i++)
            {
                date[i] = 0;
                bool correctInput = int.TryParse(birth[i], out date[i]);
                if (!correctInput) break;
            }

            try
            {
                DateTime birthDate = new DateTime(date[0], date[1], date[2]);

                return birthDate;
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine("Некорректная дата, нажмите любую клавишу и повторите ввод ещё раз");
                Console.ReadKey();

                e.Data.Add(e.Message, DateTime.Now);                

                try
                {
                    string log = $"{e.GetObjectData}\n";
                    using (FileStream fstream = new FileStream(@".\logs.txt", FileMode.Append))
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(log);
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                }
                catch { }

                return BirthDate();

                throw new InvalidDataException(e.Message);
                
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Некорректная дата, нажмите любую клавишу и повторите ввод ещё раз");
                Console.ReadKey();

                e.Data.Add(e.Message, DateTime.Now);

                try
                {
                    string log = $"{e.Message}\n";
                    using (FileStream fstream = new FileStream(@".\logs.txt", FileMode.Append))
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(log);
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                }
                catch { }

                return BirthDate();

                throw new Exception(e.Message);
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Некорректная дата, нажмите любую клавишу и повторите ввод ещё раз");
                Console.ReadKey();

                e.Data.Add(e.Message, DateTime.Now);

                try
                {
                    string log = $"{e.Data}";
                    using (FileStream fstream = new FileStream(@".\logs.txt", FileMode.Append))
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(log);
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                }
                catch { }

                return BirthDate();

                throw new ArgumentOutOfRangeException(e.Message);
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// Ввод целочисленного значения с проверкой на корректность ввода
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private int InputIntValue(string? message = null, int? number = null)
        {
            Console.WriteLine(message);

            bool isCorrectInput = int.TryParse(Console.ReadLine(), out int value);

            if (!isCorrectInput)
            {
                return -1; 
            }
            else return value;
        }

        /// <summary>
        /// Ввод строкового значения
        /// </summary>
        /// <param name="message"></param>
        /// <returns>строку</returns>
        string Input(string message)
        {
            Console.WriteLine(message);

            return Console.ReadLine();
        }

        /// <summary>
        /// Ввод строки для разделения
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Массив строк</returns>
        string[] InputStrings(string message)
        {
            Console.WriteLine(message);

            return Console.ReadLine()
                .Split(' ', '-', ',', ';', '/', '\\', '"', '\'', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '=', '+', '|', '.', '<', '>', '?')
                .ToArray();
        }

        /// <summary>
        /// Выводит список в табличном виде
        /// </summary>
        /// <param name="animals"></param>
        public void ShowTable(List<Animal> animals)
        {
            Console.WriteLine('+' + new string('-', 4) + '+' + new string('-', 10) + '+' + new string('-', 9) + '+' + new string('-', 15) + '+' + new string('-', 26) + '+' + new string('-', 16) + '+');
            Console.WriteLine($"|{"id", 3} | {"Имя", 8} | {"Тип", 7} | {"Дата рождения", 13} | {"Команды", 24} | {"Глобальны  тип"} |");
            
            Console.WriteLine('+' + new string('-', 4) + '+' + new string('-', 10) + '+' + new string('-', 9) + '+' + new string('-', 15) + '+' + new string('-', 26) + '+' + new string('-', 16) + '+');

            foreach (var animal in animals)
            {
                Console.WriteLine($"|{animal.FinalId, 3} | {animal.Name, 8} | {animal.Type, 7} | {animal.BirthDate.ToString("dd.MM.yyyy"), 13} | {animal.ShowCommands(), 24} | {animal.GlobalType, 14} |");
            }
            Console.WriteLine(new string('-', 87));
            Console.WriteLine();
        }
    }
}
