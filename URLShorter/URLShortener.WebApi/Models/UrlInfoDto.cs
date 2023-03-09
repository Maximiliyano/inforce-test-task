namespace URLShortener.WebApi.Models;

public sealed class UrlInfoDto : BaseEntity
{
    public string OriginalString { get; set; }
    
    public string ShortedString { get; set; }
    
    public string CreatedBy { get; set; }
}