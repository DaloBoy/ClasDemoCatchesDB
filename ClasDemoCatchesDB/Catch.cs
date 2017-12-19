namespace ClasDemoCatchesDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catch")]
    public partial class Catch
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Art { get; set; }

        public decimal Weigth { get; set; }

        [Required]
        [StringLength(30)]
        public string Location { get; set; }

        public int Week { get; set; }
    }
}
