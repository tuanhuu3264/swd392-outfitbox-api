using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.BusinessModels
{
 
    public class CustomerPackageModel
    {
 
        public int? Id { get; set; }
        public int? CustomerId { get; set; } 
        public int? PackageId { get; set; }
        public string? PackageName { get; set; } = string.Empty;
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public double? Price { get; set; }
        public string? ReceiverName { get; set; } = string.Empty; 
        public string? ReceiverPhone {  get; set; } = string.Empty;
        public string? ReceiverAddress { get; set; } = string.Empty; 
        public int? Status { get; set; }
        public int? TransactionId { get; set; }
    }
}
