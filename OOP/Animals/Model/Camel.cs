using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Camel : Animal, IPackAnimal
    {
        public Camel(string name, DateTime birthDate, params string[]? commands)
            : base(name, birthDate, commands)
        {
            this.Type = AnimalType.Camel;
            this.GlobalType = AnimalType.PackAnimal;
        }

    }
}
