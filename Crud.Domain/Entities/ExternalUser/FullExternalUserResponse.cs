namespace Crud.Domain.Entities.ExternalUser;

public class FullExternalUserResponse
{
    public IEnumerable<ExternalUsers> Data { get; set; }
    public Meta Meta { get; set; }
}
