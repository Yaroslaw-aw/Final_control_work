using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Dog : Animal, IPet
    {
        public Dog(string name, DateTime birthDate)
            : base(name, birthDate)
        {
            this.Type = AnimalType.Dog;
            this.GlobalType = AnimalType.Pet;
        }

        public Dog(string name, DateTime birthDate, params string[]? commands)
            : this(name, birthDate)
        {
            AddCommand(commands);
        }
    }
}
