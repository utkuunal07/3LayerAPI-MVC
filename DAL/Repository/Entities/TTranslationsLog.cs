using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TransaltorApi.Repository.Entities
{
    [Table("T_TRANSLATIONS_LOG")]
    public partial class TTranslationsLog
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("total")]
        public int? Total { get; set; }

        [Column("translated")]
        public string Translated { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("translation")]
        public string Translation { get; set; }

        [Column("create_time", TypeName = "date")]
        public DateTime CreateTime { get; set; }
    }
}