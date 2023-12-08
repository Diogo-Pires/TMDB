namespace AppSpace.Domain.Cinema.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public DateTime OpenSince { get; private set; }
        public int CityId { get; private set; }

        public virtual City City { get; private set; }
        public virtual List<Room.Entities.Room> Rooms { get; private set; }
    }
}