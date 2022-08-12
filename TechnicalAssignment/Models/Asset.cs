namespace TechnicalAssignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Asset
    {
        [StringLength(50)]
        public string AssetId { get; set; }

        [StringLength(50)]
        public string AssetName { get; set; }

        [StringLength(50)]
        public string ModelNumber { get; set; }

        [StringLength(50)]
        public string Vendor { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
    }
}
