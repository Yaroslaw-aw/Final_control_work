using Animals.AnimalTypesEnum;
using Animals.Model;
using static Animals.Program;

namespace Animals.Presenter
{
    internal class AnimalRegistry
    {
        internal List<Animal> animals;
        internal List<Animal> pets;
        internal List<Animal> packAnimals;
        public int Size { get; private set; }       // количество всех животных
        public int numOfPets { get; private set; }  // количество домашних животных
        public int numOfPacks { get; private set; } // количество вьючных животных

        public AnimalRegistry()
        {
            animals = new List<Animal>();
            Size = 0;            
            
            pets = new List<Animal>();
            numOfPets = 0;

            packAnimals = new List<Animal>();
            numOfPacks = 0;
        }

        /// <summary>
        /// Добавление нового животного в реестр а так же в список по типу домашнее/вьючное
        /// </summary>
        /// <param name="newAnimal"></param>
        public void AddAnimal(Animal newAnimal)
        {
            animals.Add(newAnimal);
            Size++;

            if (newAnimal is IPet)
            {
                pets.Add(newAnimal);
                numOfPets++;
            }
            else if (newAnimal is IPackAnimal)
            {
                packAnimals.Add(newAnimal);
                numOfPacks++;
            }

            //count.Count++;
        }

        /// <summary>
        /// Создание нового животного
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="commands"></param>
        public void CreateNewAnimal(AnimalType type, string name, DateTime birthDate, params string[]? commands)
        {
            switch (type)
            {
                case AnimalType.Cat:
                    {
                        Animal newAnimal = new Cat(name, birthDate, commands);
                        AddAnimal(newAnimal);
                        break;
                    }
                case AnimalType.Dog:
                    {
                        Animal newAnimal = new Dog(name, birthDate, commands);
                        AddAnimal(newAnimal);
                        break;
                    }
                case AnimalType.Hamster:
                    {
                        Animal newAnimal = new Hamster(name, birthDate, commands);
                        AddAnimal(newAnimal);
                        break;
                    }
                case AnimalType.Horse:
                    {
                        Animal newAnimal = new Horse(name, birthDate, commands);
                        AddAnimal(newAnimal);
                        break;
                    }
                case AnimalType.Camel:
                    {
                        Animal newAnimal = new Camel(name, birthDate, commands);
                        AddAnimal(newAnimal);
                        break;
                    }
                case AnimalType.Donkey:
                    {
                        Animal newAnimal = new Donkey(name, birthDate, commands);
                        AddAnimal(newAnimal);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Введено неверное название животного");
                        break;
                    }
            }
            
        }

        /// <summary>
        /// Выводит список животных все/домашние/вьючные
        /// </summary>
        /// <param name="number"></param>
        public void ShowAnimals(int number)
        {
            switch (number)
            {
                case 1:
                    {
                        Console.WriteLine("Все животные\n");

                        Show(animals);

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Домашние животные\n");

                        Show(pets);

                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Вьючные животные\n");

                        Show(packAnimals);

                        break;
                    }
            }            
        }  

        private void Show(List<Animal> animals)
        {
            if (animals.Count > 0)
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal);
                }
                Console.WriteLine();
            }
        }
        
    }
}
