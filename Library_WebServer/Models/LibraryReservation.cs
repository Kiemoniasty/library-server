namespace Library_WebServer.Models;

public class LibraryReservation
{
    public Guid Id { get; set; }
    public DateTime Date{ get; set; }
    public Guid LibraryPublicationId {  get; set; }
    public Guid UserId { get; set; }

    public LibraryReservation() { }

    public LibraryReservation(Guid id, DateTime date, Guid publicationId, Guid userId)
    {
        Id = id;
        Date = date;
        LibraryPublicationId = publicationId;
        UserId = userId;
    }
}
