using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Cat : Animal, IPet
    {
        public Cat(string name, DateTime birthDate, params string[]? commands)
            : base(name, birthDate, commands)
        {
            this.Type = AnimalType.Cat;
            this.GlobalType = AnimalType.Pet;
        }
    }
}
