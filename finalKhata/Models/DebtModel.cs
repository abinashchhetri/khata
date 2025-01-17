using finalKhata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalKhata.Models
{
    public class DebtModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; } = string.Empty;

        public string Source { get; set; }

        public DateTime ReceivedDate { get; set; } = DateTime.Now;
        public string SelectedTag { get; set; }

        public DateTime DueDate { get; set; }


        public bool isPaid { get; set; } = false;

        public DebtModel(string title, int amount, string source, string selectedTag, DateTime dueDate, string note = "")
        {
            id  = DebtService.Debts.Count + 1;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Amount = amount;
            Note = note ;
            Source = source ?? throw new ArgumentNullException(nameof(source));
            SelectedTag = selectedTag ?? throw new ArgumentNullException(nameof(selectedTag));
            DueDate = dueDate; 
        }
    }
}
