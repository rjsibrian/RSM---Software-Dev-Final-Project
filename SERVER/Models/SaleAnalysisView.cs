using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppApi.Models
{
    [Table("SaleAnalysisView")]
    public class SaleAnalysisView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductCategory { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSales { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PercentageOfTotalSalesInRegion { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PercentageOfTotalCategorySalesInRegion { get; set; }
    }
}
