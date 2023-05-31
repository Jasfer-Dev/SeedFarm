using System;
using System.Collections.Generic;

namespace SeedFarm.Models
{
    public class BillDescriptionViewModel
    {
        public BillDescriptionViewModel()
        {
            BillDescList = new List<BillDescriptionViewModel>();
        }
        public List<BillDescriptionViewModel> BillDescList { get; set; }

        public int BillId { get; set; }
        public DateTime BillDate { get; set; }  
        public string CustomerName { get; set; }
        public string FatherName { get; set; } 
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; } 
        public string Description { get; set; }
        public string Packing { get; set; }
        public string RatePerPacking { get; set; }
        public string NoOfPacking { get; set; }
        public string Amount { get; set; } 
    }

    public class BillDescriptionListViewModel
    {
        public string Description { get; set; }
        public string Packing { get; set; }
        public string RatePerPacking { get; set; }
        public string NoOfPacking { get; set; }
        public string Amount { get; set; }
    }
}