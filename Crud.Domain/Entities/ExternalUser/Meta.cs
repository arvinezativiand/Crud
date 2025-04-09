namespace Crud.Domain.Entities.ExternalUser;

public class Meta
{
    public string? Filter { get; set; }
    public string? Sort_by { get; set; }
    public string? Sort_order { get; set; }
    public int Count { get; set; }
    public int? Total_pages { get; set; }
    public int? Current_page { get; set; }
    public int? From { get; set; }
    public int? Last_page { get; set; }
    public List<Link>? Links { get; set; }
    public string? Path { get; set; }
    public int Per_page { get; set; }
    public int? To { get; set; }
    public int Total { get; set; }
}
public class Link
{
    public string? Url { get; set; }
    public string? Label { get; set; }
    public bool? Active { get; set; }
}