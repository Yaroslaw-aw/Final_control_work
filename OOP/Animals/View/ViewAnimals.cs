using Animals.AnimalTypesEnum;
using Animals.Model;
using Animals.Presenter;

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
                    new string('-', 100) + "\n" +
                    "Выберите пункт меню\n" +
                    new string('-', 100) + "\n" +
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

                int mainNumber = InputIntValue("");

                if ( mainNumber == 0 )
                {
                    start = false;
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
                                Console.WriteLine("Добавить животное -> Выбор типа животного\n" + new string('-', 100) );
                                Console.WriteLine("Для возврата в предыдущее меню нажмите 0\n" + new string('-', 100) );
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

                                int typeNum = InputIntValue("");

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
                                isAddAnimal = true;
                            }

                            break;
                        }
                    case 2: // Показать список команд животного
                        {
                            bool commands = false;

                            while (!commands)
                            {                                
                                string path = $"Показать список команд -> Выберете список с животными\n";

                                var listToShow = NumberOfList(path);

                                if (listToShow.numberOfList == 0)
                                    break;

                                int idAnimalToShow = 0;

                                bool isSelectAnimalToShow = false;

                                while (!isSelectAnimalToShow)
                                {
                                    Console.Clear();                                    

                                    if (listToShow.listOfAnimals.Count > 0)
                                    {
                                        Console.WriteLine("Показать список команд -> Выберете список с животными -> Список животных\n");
                                        registry.ShowAnimals(listToShow.numberOfList);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nК сожалению животных пока нет. Нажмите клавишу для продолжения");
                                        Console.ReadKey();
                                        commands = true;
                                        isSelectAnimalToShow = true;
                                        continue;
                                    }

                                    idAnimalToShow = InputIntValue("Введите id животного, команды которого надо посмотреть");
                                    Console.WriteLine();
                                    if (idAnimalToShow < 0 || idAnimalToShow > listToShow.listOfAnimals.Count)
                                    {
                                        Console.WriteLine("Такого id нет в списке. Нажмите клавишу и попробуйте ещё раз");
                                        Console.ReadKey();
                                        continue;
                                    }
                                    else
                                    {
                                        isSelectAnimalToShow = true;
                                    }
                                }

                                if (idAnimalToShow == 0)
                                    continue;

                                foreach (var animal in listToShow.listOfAnimals)
                                {
                                    if (animal.FinalId == idAnimalToShow)
                                    {
                                        Console.WriteLine(animal.ShowCommands());
                                        Console.WriteLine("\nНажмите клавишу для продолжения");
                                        Console.ReadKey();
                                        commands = true;
                                        break;
                                    }
                                }
                            }

                            break;
                        }
                    case 3: // обучить животное новое команде
                        {
                            bool train = false;

                            while (!train)
                            {
                                string path = $"Обучить новой команде -> Выбрать список с животными\n";

                                var listToShow = NumberOfList(path);

                                if (listToShow.numberOfList == 0)
                                    break;                                                          

                                if (listToShow.listOfAnimals.Count > 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Обучить новой команде -> Выбрать список с животными -> Выбрать животное для обучения\n");
                                    registry.ShowAnimals(listToShow.numberOfList);

                                    int idAnimalToTrain = InputIntValue("Введите id животного, которого надо обучить или 0 для возврата");
                                    if (idAnimalToTrain < 0 || idAnimalToTrain > listToShow.listOfAnimals.Count)
                                    {
                                        Console.WriteLine("Неверный ввод id. Нажмине клавишу и повторите ввод.");
                                        Console.ReadKey();
                                        continue;
                                    }

                                    foreach (var animal in listToShow.listOfAnimals)
                                    {
                                        if (animal.FinalId == idAnimalToTrain)
                                        {
                                            string[]? commands = InputStrings("Введите команды, которым надо обучить животное");
                                            animal.AddCommand(commands);
                                            Console.WriteLine("Животное обучено. Нажмите клавишу для продолжения");
                                            Console.ReadKey();
                                            train = true;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("К сожалению животных пока нет. Нажмите клавишу для продолжения");
                                    Console.ReadKey();
                                    break;
                                }
                            }

                            break;
                        }
                    case 4: // Вывести животных по дате рождения
                        {                            
                            string path = $"Вывести животных по дате рождения -> Выберете список с животными\n";

                            var listToShow = NumberOfList(path);

                            if (listToShow.numberOfList == 0)
                                break;                            

                            if (listToShow.listOfAnimals.Count > 0)
                            {
                                List<Animal> sortedAnimalsByBirhDate = listToShow.listOfAnimals.OrderBy(x => x.BirthDate).ToList();

                                Console.Clear();

                                foreach (var animal in sortedAnimalsByBirhDate)
                                {
                                    Console.WriteLine(animal);
                                }
                                Console.WriteLine("\nНажмите клавишу для продолжения");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Спислк животных пуст. Нажмите клавишу для продолжения");
                                Console.ReadKey();
                            }
                            // Вывести животных по дате рождения
                            break;
                        }
                    case 5: // Показать количество животных
                        {
                            string path = $"Показать количество животных -> Выберете список с животными\n";

                            var listToShow = NumberOfList(path);

                            if (listToShow.numberOfList == 0)
                                break;                            

                            if (listToShow.listOfAnimals.Count > 0)
                            {
                                Console.WriteLine($"\nВ списке {listToShow.listOfAnimals.Count} животных");
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

                            registry.ShowAnimals(1);

                            Console.WriteLine("Нажмите клавишу, чтобы продолжить");
                            Console.ReadKey();

                            break;
                        }
                    case 7: // показать домашних животных
                        {
                            Console.Clear();;

                            registry.ShowAnimals(2);

                            Console.WriteLine("Нажмите клавишу, чтобы продолжить");
                            Console.ReadKey();

                            break;
                        }
                    case 8: // показать вьючных животных
                        {
                            Console.Clear();

                            registry.ShowAnimals(3);

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
        private (int numberOfList, List<Animal> listOfAnimals) NumberOfList(string path)
        {
            Console.Clear();
            Console.WriteLine(path + new string('-', 100));
            Console.WriteLine("Для возврата в предыдущее меню нажмите 0\n" + new string('-', 100));
            Console.WriteLine("Выберете список с животными\n");

            foreach (var listOfAnimals in listsOfAnimals)
            {
                Console.WriteLine(listOfAnimals);
            }

            int number = InputIntValue("");

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

        private List<Animal> ListToShow(int listNum)
        {
            switch (listNum)
            {
                case 1:
                    {
                        return registry.animals;
                    }
                case 2:
                    {
                        return registry.pets;
                    }
                case 3:
                    {
                        return registry.packAnimals;
                    }
                default:
                    {
                        return null;
                    }
            }
        }        

        /// <summary>
        /// Добавляет животное в реестр
        /// </summary>
        /// <param name="type"></param>
        /// <param name="numOfType"></param>
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

            int i = 0;

            foreach (string str in birth)
            {
                date[i] = 0;
                bool correctInput = int.TryParse(str, out date[i]);
                if (!correctInput) break;
                ++i;
            }

            try
            {
                DateTime time = new DateTime(date[0], date[1], date[2]);

                return time;
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine("Некорректная дата, нажмите любую клавишу и повторите ввод ещё раз");
                Console.ReadKey();
                return BirthDate();
                throw new InvalidDataException(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Некорректная дата, нажмите любую клавишу и повторите ввод ещё раз");
                Console.ReadKey();
                return BirthDate();
                throw new ArgumentOutOfRangeException(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Некорректная дата, нажмите любую клавишу и повторите ввод ещё раз");
                Console.ReadKey();
                return BirthDate();
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Ввод целочисленного значения с проверкой на корректность ввода
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private int InputIntValue(string message, int? number = null)
        {
            Console.WriteLine(message);

            bool isCorrectInput = int.TryParse(Console.ReadLine(), out int value);

            if (!isCorrectInput)
            {
                return InputIntValue("Некорректный ввод. Попробуйте ещё раз");
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
                .Split(' ', '-', ',', ';', '/', '\\', '"', '\'', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '=', '+', '|', '.', '<', '>')
                .ToArray();
        }
    }
}
