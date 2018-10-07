namespace keepr.Models
{
    public class Vault
    {
        private Vault vault;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description {get; set;}

        public Vault() { }
        public Vault(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}