using finalKhata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalKhata.Models
{
    public class ExpenseModel
    {


        public int id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; } = string.Empty;

        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public string SelectedTag { get; set; }

        public ExpenseModel(string title, int amount,  string selectedTag, string note = "")
        {
            id = ExpenseService.Expenses.Count + 1;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Amount = amount;
            Note = note;
            SelectedTag = selectedTag ?? throw new ArgumentNullException(nameof(selectedTag));
        }
    }
}
