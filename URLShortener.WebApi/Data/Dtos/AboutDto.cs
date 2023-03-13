using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Data.Dtos;

public sealed class AboutDto : BaseEntity
{
    public string Text { get; set; }
}