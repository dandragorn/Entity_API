namespace Abstractions.Requests.UpdateEntity;

public class UpdateEntityResponse
{
    public UpdateEntityResponse(string? title) => Title = title;
    
    public string? Title { get; set; }
}