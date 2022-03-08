namespace TumblrClient.Core.Models
{
    public class StringWithId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
