using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Models
{
    public class DepositModel
    {
       
        public int Id { get; set; }        
        public DateTime Date { get; set; }
        public double AmountMoney { get; set; }
        public string Type {  get; set; } = string.Empty;     
        public int CustomerId {  get; set; }


    }
}
