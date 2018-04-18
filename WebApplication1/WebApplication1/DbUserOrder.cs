using System.Data.Entity.ModelConfiguration.Conventions;

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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(128)]
        public string User1Id { get; set; }

        [StringLength(128)]
        public string User2Id { get; set; }

        public DateTime? DateIn { get; set; }

        public DateTime? DateOut { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        public string Discription { get; set; }

        public string WayFile { get; set; }

        public string MainName { get; set; }

    }
}
