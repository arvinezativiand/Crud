namespace Crud.Domain.Entities;

public class ExternalUsers
{
    public int id { get; set; }
    public string uuid { get; set; }
    public string email { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string username { get; set; }
    public string status { get; set; }
    public object address { get; set; }
    public object city { get; set; }
    public object state { get; set; }
    public object postal { get; set; }
    public object country { get; set; }
    public string phone { get; set; }
    public object fax { get; set; }
    public object cell { get; set; }
    public object title { get; set; }
    public object birthdate { get; set; }
    public string timezone { get; set; }
    public string datetime_format { get; set; }
    public string language { get; set; }
    public object meta { get; set; }
    public object connected_accounts { get; set; }
    public bool is_administrator { get; set; }
    public int is_system { get; set; }
    public object expires_at { get; set; }
    public object loggedin_at { get; set; }
    public object active_at { get; set; }
    public object remember_token { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public object deleted_at { get; set; }
    public object delegation_user_id { get; set; }
    public object manager_id { get; set; }
    public object schedule { get; set; }
    public int force_change_password { get; set; }
    public string avatar { get; set; }
    public object password_changed_at { get; set; }
    public object preferences_2fa { get; set; }
    public string fullname { get; set; }
}