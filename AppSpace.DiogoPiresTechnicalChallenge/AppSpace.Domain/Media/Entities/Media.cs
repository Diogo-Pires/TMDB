namespace AppSpace.Domain.Media.Entities
{
    public abstract class Media
    {
        public string Title { get; private set; }
        public string Overview { get; private set; }
        public string Genre { get; private set; }
        public string Language { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string WebSite { get; private set; }
        public string[] AssociateKeywords { get; private set; }
    }
}