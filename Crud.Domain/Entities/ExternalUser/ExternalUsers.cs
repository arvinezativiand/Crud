namespace Crud.Domain.Entities.ExternalUser;

public class ExternalUsers
{
    public int? Id { get; set; }
    public string? Uuid { get; set; }
    public string? Email { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Status { get; set; }
    public object? Address { get; set; }
    public object? City { get; set; }
    public object? State { get; set; }
    public object? Postal { get; set; }
    public object? Country { get; set; }
    public string? Phone { get; set; }
    public object? Fax { get; set; }
    public object? Cell { get; set; }
    public object? Title { get; set; }
    public object? Birthdate { get; set; }
    public string? Timezone { get; set; }
    public string? DatetimeFormat { get; set; }
    public string? Language { get; set; }
    public object? Meta { get; set; }
    public object? ConnectedAccounts { get; set; }
    public bool? IsAdministrator { get; set; }
    public int? IsSystem { get; set; }
    public object? ExpiresAt { get; set; }
    public object? LoggedinAt { get; set; }
    public object? ActiveAt { get; set; }
    public object? RememberToken { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public object? DeletedAt { get; set; }
    public object? DelegationUserId { get; set; }
    public object? ManagerId { get; set; }
    public object? Schedule { get; set; }
    public int? ForceChangePassword { get; set; }
    public object? Avatar { get; set; }
    public string? PasswordChangedAt { get; set; }
    public object? Preferences2fa { get; set; }
    public string? Fullname { get; set; }
    
}

