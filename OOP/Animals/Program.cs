using Animals.Model;
using Animals.Presenter;
using Animals.View;

namespace Animals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Pets
            Animal dog1 = new Dog("Fido", new DateTime(2020, 01, 01), new string[] { "Sit,.#", "Stay;", "Fetch" } );
            Animal cat1 = new Cat("Whiskers", new DateTime(2019, 05, 15), new string[] { "Sit", "Pounce" } );
            Animal hamster1 = new Hamster("Hammy", new DateTime(2021, 03, 10), new string[] { "Roll", "Hide" } );
            Animal dog2 = new Dog("Buddy", new DateTime(2018, 12, 10), new string[] { "Sit", "Paw", "Bark" } );
            Animal cat2 = new Cat("Smudge", new DateTime(2020, 02, 20), new string[] { "Sit", "Pounce", "Scratch" } );            
            Animal hamster2 = new Hamster("Peanut", new DateTime(2021, 08, 01), new string[] { "Roll", "Spin" } );
            Animal dog3 = new Dog("Bella", new DateTime(2019, 11, 11), new string[] { "Sit", "Stay", "Roll" } );
            Animal cat3 = new Cat("Oliver", new DateTime(2020, 06, 30), new string[] { "Meow", "Scratch", "Jump" });

            // Pack Animals
            Animal horse1 = new Horse("Thunder", new DateTime(2015, 07, 21), new string[] { "Trot", "Canter", "Gallop" } );
            Animal camel1 = new Camel("Sandy", new DateTime(2016, 11, 03), new string[] { "Walk", "Carry", "Load" } );
            Animal donkey1 = new Donkey("Eeyore", new DateTime(2017, 09, 18), new string[] { "Walk", "Carry", "Load", "Bray" } );
            Animal horse2 = new Horse("Storm", new DateTime(2014, 05, 05), new string[] { "Trot", "Canter" } );
            Animal camel2 = new Camel("Dune", new DateTime(2018, 12, 12), new string[] { "Walk", "Sit" } );
            Animal donkey2 = new Donkey("Burro", new DateTime(2019, 01, 23), new string[] { "Walk", "Bray", "Kick" } );
            Animal horse3 = new Horse("Blaze", new DateTime(2016, 02, 29), new string[] { "Trot", "Jump", "Gallop" } );
            Animal camel3 = new Camel("Sahara", new DateTime(2015, 08, 14), new string[] { "Walk", "Run" } );

            AnimalRegistry registry = new AnimalRegistry();

            registry.AddAnimal(dog1);
            registry.AddAnimal(cat1);
            registry.AddAnimal(hamster1);
            registry.AddAnimal(dog2);
            registry.AddAnimal(cat2);
            registry.AddAnimal(hamster2);
            registry.AddAnimal(dog3);
            registry.AddAnimal(cat3);

            registry.AddAnimal(horse1);
            registry.AddAnimal(camel1);
            registry.AddAnimal(donkey1);
            registry.AddAnimal(horse2);
            registry.AddAnimal(camel2);
            registry.AddAnimal(donkey2);
            registry.AddAnimal(horse3);
            registry.AddAnimal(camel3);            

            ViewAnimals view = new ViewAnimals(registry);
            view.Start();
            
        }
    }
}