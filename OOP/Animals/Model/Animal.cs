using Animals.AnimalTypesEnum;

namespace Animals.Model
{
    internal abstract class Animal
    {
        private static int id;

        public AnimalType Type { get; protected set ; }
        public AnimalType GlobalType { get; protected set; }

        public int FinalId { get;  private set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; }

        protected List<string> commands;

        static Animal()
        {
            id = 0;
        }

        public Animal(string name, DateTime birthDate, string[]? commands)
        {
            this.commands = new List<string>();
            this.Name = name;
            this.BirthDate = birthDate;
            ++id;
            this.FinalId = id;
            AddCommand(commands);
        }

        public override string ToString()
        {
            return
                $"id {this.FinalId, 3} | " +
                $"Name {this.Name, 8} | " +
                $"Type {GetType().Name, 7} | " +
                $"BirthDate {this.BirthDate.ToString("dd.MM.yyyy")} | " +
                $"Commands {ShowCommands(), 24} | " +
                $"GlobalType {GlobalType}";
        }

        /// <summary>
        /// Обучает команде/командам животное
        /// </summary>
        /// <param name="commands"></param>
        public void AddCommand(params string[]? commands)
        {
            foreach (var command in commands)
            {
                if (command != null && command != " " && command != string.Empty) this.commands.Add(command.ToString());
            }            
        }

        /// <summary>
        /// Показывает команды, которым обучено животное
        /// </summary>
        /// <returns></returns>
        public virtual string ShowCommands()
        {
            if (commands.Count == 0) return "Ничего не умеет";
            else return string.Join(", ", commands);            
        }
    }
}
