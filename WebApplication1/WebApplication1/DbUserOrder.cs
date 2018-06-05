using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DbUserOrder")]
    public partial class DbUserOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(128)]
        public string User1Id { get; set; }

        [StringLength(128)]
        public string User2Id { get; set; }

        public DateTime? DateIn { get; set; }

        public string DateOut { get; set; }

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        public string Discription { get; set; }

        public byte[] WayFile { get; set; }

        public string MainName { get; set; }
        public bool User1End { get; set; }
        public bool User2End { get; set; }

    }
}
