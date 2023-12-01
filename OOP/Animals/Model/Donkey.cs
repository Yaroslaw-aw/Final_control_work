using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Donkey : Animal, IPackAnimal
    {
        public Donkey(string name, DateTime birthDate, params string[]? commands)
            : base(name, birthDate, commands)
        {
            this.Type = AnimalType.Donkey;
            this.GlobalType = AnimalType.PackAnimal;
        }
    }
}
