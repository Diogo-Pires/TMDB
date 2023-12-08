namespace AppSpace.Domain.Sessions.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public int RoomId { get; private set; }
        public int MovieId { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public short SeatsSold { get; private set; }


        public virtual Room.Entities.Room Room { get; private set; }
        public virtual Movie.Entities.Movie Movie { get; private set; }
    }
}