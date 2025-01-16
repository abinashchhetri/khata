using finalKhata.Configs;
using finalKhata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace finalKhata.Services
{
    public class ExpenseService
    {
        public static List<ExpenseModel> Expenses { get; set; } = new List<ExpenseModel>();
        public static string ExpenseFilePath = FolderAndFiles.ExpenseFilePath;

        public static string AddExpense(ExpenseModel expense)
        {

            if (expense.Amount > UserService.User.TotalIncome) {
                return "You do not have enough Balance to Procide this transacton";
            }
            else
            {
                UserService.User.TotalIncome -= expense.Amount;


                

                UserService.User.TotalExpense = UserService.User.TotalExpense + expense.Amount;
                Expenses.Add(expense);
                return $" {expense.Amount} added your Expense, your current balance is {UserService.User.TotalIncome}";

            }
            

        }

        public void GetSavedExpense()
        {
            string json = File.ReadAllText(ExpenseFilePath);
            Expenses = JsonSerializer.Deserialize<List<ExpenseModel>>(json);

        }

        public void SaveAllExpense()
        {
            string json = JsonSerializer.Serialize(Expenses);
            File.WriteAllText(ExpenseFilePath, json);

        }
    }
}
