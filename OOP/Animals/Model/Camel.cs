using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Camel : Animal, IPackAnimal
    {
        public Camel(string name, DateTime birthDate)
            : base(name, birthDate)
        {
            this.Type = AnimalType.Camel;
            this.GlobalType = AnimalType.PackAnimal;
        }

        public Camel(string name, DateTime birthDate, params string[]? commands)
            : this(name, birthDate)
        {
            AddCommand(commands);
        }

    }
}
