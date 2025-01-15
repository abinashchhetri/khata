using finalKhata.Data;
using finalKhata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalKhata.Models
{
    public class IncomeModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; } = string.Empty;

        public DateTime IncomeDate { get; set; } = DateTime.Now;
        public string SelectedTag { get; set; }

        public IncomeModel(string title, int amount,  string selectedTag, string note = "")
        {

            if(IncomeService.Incomes == null)
            {
                id = 1;
            }
            else
            {

            id = IncomeService.Incomes.Count + 1;
            }

            Title = title ?? throw new ArgumentNullException(nameof(title));
            Amount = amount;
            Note = note;
            SelectedTag = selectedTag ?? throw new ArgumentNullException(nameof(selectedTag)); 
        }


        
    }
}
