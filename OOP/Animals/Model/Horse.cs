using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Horse : Animal, IPackAnimal
    {
        public Horse(string name, DateTime birthDate)
            : base(name, birthDate)
        {
            this.Type = AnimalType.Horse;
            this.GlobalType = AnimalType.PackAnimal;
        }

        public Horse(string name, DateTime birthDate, params string[]? commands)
            : this(name, birthDate)
        {
            AddCommand(commands);
        }
    }
}
