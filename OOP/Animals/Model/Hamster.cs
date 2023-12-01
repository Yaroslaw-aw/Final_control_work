using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Hamster : Animal, IPet
    {
        public Hamster(string name, DateTime birthDate, params string[]? commands)
            : base(name, birthDate, commands)
        {
            this.Type = AnimalType.Hamster;
            this.GlobalType = AnimalType.Pet;
        }
    }
}
