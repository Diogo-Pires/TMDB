namespace AppSpace.Domain.Cinema.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public int Population { get; private set; }
    }
}