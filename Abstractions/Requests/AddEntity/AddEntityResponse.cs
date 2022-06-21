namespace Abstractions.Requests.AddEntity;

public class AddEntityResponse
{
    public AddEntityResponse(int id) => Id = id;
    public int Id { get; }
}