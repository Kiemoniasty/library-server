using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Library_WebServer.Models;

public class EnumTable<TEnum>
    where TEnum : struct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public TEnum Id { get; set; }

    [Required]
    [MaxLength(100)]
    [NotNull]
    public string Name { get; set; }

    protected EnumTable() { }

    public EnumTable(TEnum enumType)
    {
        Id = enumType;
        Name = enumType.ToString()!;
    }

    public static implicit operator EnumTable<TEnum>(TEnum enumType) => new EnumTable<TEnum>(enumType);
    public static implicit operator TEnum(EnumTable<TEnum> status) => status.Id;
}