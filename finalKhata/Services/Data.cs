using finalKhata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalKhata.Services
{
    public  class Data
    {
        public  UserModel user = UserService.User;
        public List<IncomeModel> incomes = IncomeService.Incomes; 
        public List<ExpenseModel> expenses = ExpenseService.Expenses;
        public List<DebtModel> debts = DebtService.Debts;
        public List<string> filters = new List<string>();
        public DateTime FromDate;
        public DateTime ToDate;

        public Data() { 
        
        GetFilteredData();
        }

        public  void GetFilteredData()
        {
            // If no filters are specified, keep all data
            if (filters.Count == 0)
            {
                incomes = IncomeService.Incomes;
                expenses = ExpenseService.Expenses;
                debts = DebtService.Debts;
                return;
            }

            // Filter incomes by tags and date range
            incomes = IncomeService.Incomes
                .Where(income =>
                    filters.Contains(income.SelectedTag, StringComparer.OrdinalIgnoreCase) &&
                    income.IncomeDate >= FromDate &&
                    income.IncomeDate <= ToDate)
                .ToList();

            // Filter expenses by tags and date range
            expenses = ExpenseService.Expenses
                .Where(expense =>
                    filters.Contains(expense.SelectedTag, StringComparer.OrdinalIgnoreCase) &&
                    expense.ExpenseDate >= FromDate &&
                    expense.ExpenseDate <= ToDate)
                .ToList();

            // Filter debts by tags and date range
            debts = DebtService.Debts
                .Where(debt =>
                    filters.Contains(debt.SelectedTag, StringComparer.OrdinalIgnoreCase) &&
                    debt.ReceivedDate >= FromDate &&
                    debt.ReceivedDate <= ToDate)
                .ToList();
        }


    }
}
