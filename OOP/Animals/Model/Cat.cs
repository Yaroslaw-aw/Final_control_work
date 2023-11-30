using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal class Cat : Animal, IPet
    {
        public Cat(string name, DateTime birthDate)
            : base(name, birthDate)
        {
            this.Type = AnimalType.Cat;
            this.GlobalType = AnimalType.Pet;
        }

        public Cat(string name, DateTime birthDate, params string[]? commands) 
            : this(name, birthDate)
        {
            AddCommand(commands);
        }
    }
}
