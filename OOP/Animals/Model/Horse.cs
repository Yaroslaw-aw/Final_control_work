using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Horse : Animal, IPackAnimal
    {
        public Horse(string name, DateTime birthDate, params string[]? commands)
            : base(name, birthDate, commands)
        {
            this.Type = AnimalType.Horse;
            this.GlobalType = AnimalType.PackAnimal;
        }
    }
}
