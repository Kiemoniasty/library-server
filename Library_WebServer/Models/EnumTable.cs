using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Library_WebServer.Enums;

namespace Library_WebServer.Models;

[JsonDerivedType(typeof(UserAccountType))]
public class EnumTable<TEnum>
    where TEnum : struct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [JsonPropertyName("Id")]
    public TEnum Id { get; set; }

    [Required]
    [MaxLength(100)]
    [NotNull]
    [JsonPropertyName("Name")]
    public string Name { get; set; }

    protected EnumTable() { }

    public EnumTable(TEnum enumType)
    {
        Id = enumType;
        Name = enumType.ToString()!;
    }

    [JsonConstructor]
    public EnumTable(TEnum enumType, string name)
    {
        Id = enumType;
        Name = name;
    }

    public static implicit operator EnumTable<TEnum>(TEnum enumType) => new EnumTable<TEnum>(enumType);
    public static implicit operator TEnum(EnumTable<TEnum> status) => status.Id;
}