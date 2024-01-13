using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Responses;

public class PaginationResponseModel<T>
    where T : class
{
    [JsonPropertyName("ItemCount")]
    public int ItemCount { get; set; }

    [JsonPropertyName("Items")]
    List<T> Items { get; set; } = new List<T>();

    public PaginationResponseModel(List<T> items, int itemCount)
    {
        Items = items;
        ItemCount = itemCount;
    }
}
