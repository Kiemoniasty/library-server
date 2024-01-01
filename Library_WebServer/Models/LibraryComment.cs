namespace Library_WebServer.Models;

public class LibraryComment 
{
    public Guid Id { get; set; }
    public ushort Grade { get; set; }
    public string Contents { get; set; } = string.Empty;
    public Guid PublicationId {  get; set; }
    public Guid UserId { get; set; }

    public LibraryComment() { }

    public LibraryComment(Guid id, ushort grade, string contents, Guid publicationId, Guid userId)
    {
        Id = id;
        Grade = grade;
        Contents = contents;
        PublicationId = publicationId;
        UserId = userId;
    }
}
