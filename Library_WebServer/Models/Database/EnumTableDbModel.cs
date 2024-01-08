using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Library_WebServer.Models.Database;

public class EnumTableDbModel<TEnum>
    where TEnum : struct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public TEnum Id { get; set; }

    [Required]
    [MaxLength(100)]
    [NotNull]
    public string Name { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected EnumTableDbModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public EnumTableDbModel(TEnum enumType)
    {
        Id = enumType;
        Name = enumType.ToString()!;
    }

    [JsonConstructor]
    public EnumTableDbModel(
        TEnum enumType, 
        string name)
    {
        Id = enumType;
        Name = name;
    }

    public static implicit operator EnumTableDbModel<TEnum>(TEnum enumType) => new EnumTableDbModel<TEnum>(enumType);
    public static implicit operator TEnum(EnumTableDbModel<TEnum> status) => status.Id;
}