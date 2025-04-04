using AwesomeSoft.Domain.Entities.Base;

namespace AwesomeSoft.Domain.Entities;

public class Person : BaseModel
{
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
}
