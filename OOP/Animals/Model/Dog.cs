using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Dog : Animal, IPet
    {
        public Dog(string name, DateTime birthDate, params string[]? commands)
            : base(name, birthDate, commands)
        {
            this.Type = AnimalType.Dog;
            this.GlobalType = AnimalType.Pet;
        }
    }
}
