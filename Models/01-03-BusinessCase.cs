using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSProjectFollowUp.Models
{
    public class BusinessCase
    {
        [Key]
        public int BId { get; set; }
        public int PId { get; set; }
        [ForeignKey("PId")]
        [ValidateNever]
        public Project Project { get; set; }
        public string DefinitionOfSuccess { get; set; }
        public string CalculationExplanation { get; set; }
        public double BaseLine{ get; set; }
        public double BaseLineTarget{ get; set; }
        public int Budget { get; set; }
        public string Currency { get; set; }
        public string BudgetInfo { get; set; }
    }
}
