namespace COMP2084_Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class game
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        [StringLength(50)]
        public string company { get; set; }

        [Required]
        [StringLength(50)]
        public string rating { get; set; }

        public int console_id { get; set; }

        public virtual console console { get; set; }
    }
}
