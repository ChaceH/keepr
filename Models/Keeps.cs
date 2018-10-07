namespace keepr.Models
{
    public class Keep
    {
        private Keep keep;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description {get; set;}

        public Keep() { }
        public Keep(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}