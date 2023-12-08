namespace AppSpace.Domain.Room.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Size { get; private set; }
        public short Seats { get; private set; }
        public int CinemaId { get; private set; }

        public virtual Cinema.Entities.Cinema Cinema { get; private set; }
        public virtual List<Sessions.Entities.Session> Sessions { get; private set; }
    }
}