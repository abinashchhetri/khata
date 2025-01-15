using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalKhata.Models
{
    public class UserModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Password { get; set; }

        public string Currency { get; set; }

        public int TotalIncome { get; set; } = 0;

        public int TotalDebt { get; set; } = 0;

        public int TotalExpense { get; set; } = 0;

        public UserModel(string name, string password, string currency)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }
    }
}
