namespace Abstractions.Requests.DeleteEntity;

public class DeleteEntityResponse
{
    
    public DeleteEntityResponse(bool result) => Result = result;
    
    public bool Result { get; }
}