using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Hamster : Animal, IPet
    {
        public Hamster(string name, DateTime birthDate)
            : base(name, birthDate)
        {
            this.Type = AnimalType.Hamster;
            this.GlobalType = AnimalType.Pet;
        }

        public Hamster(string name, DateTime birthDate, params string[]? commands)
            : this(name, birthDate)
        {
            AddCommand(commands);
        }
    }
}
