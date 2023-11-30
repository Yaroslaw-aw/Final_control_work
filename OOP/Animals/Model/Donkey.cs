using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Donkey : Animal, IPackAnimal
    {
        public Donkey(string name, DateTime birthDate)
            : base(name, birthDate)
        {
            this.Type = AnimalType.Donkey;
            this.GlobalType = AnimalType.PackAnimal;
        }

        public Donkey(string name, DateTime birthDate, params string[]? commands)
            : this(name, birthDate)
        {
            AddCommand(commands);
        }
    }
}
