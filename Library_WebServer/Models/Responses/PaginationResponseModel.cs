using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Responses;

public class PaginationResponseModel<T>
    where T : class
{
    [JsonPropertyName("ItemCount")]
    public int ItemCount { get; set; } = 0;

    [JsonPropertyName("Items")]
    public List<T> Items { get; set; } = new();

    [JsonConstructor]
    public PaginationResponseModel(List<T> items, int itemCount)
    {
        Items = items;
        ItemCount = itemCount;
    }
}
