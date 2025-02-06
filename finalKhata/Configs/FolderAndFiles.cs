using finalKhata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalKhata.Configs
{
    public class FolderAndFiles 
    {

        public static string KhataFolderPath = Path.Combine(FileSystem.AppDataDirectory, "khata");
        public static  string UserFilePath = Path.Combine(KhataFolderPath, "users.json");
        public static string IncomeFilePath = Path.Combine(KhataFolderPath, "incomes.json");
        public static string ExpenseFilePath = Path.Combine(KhataFolderPath, "expenses.json");
        public static string DebtsFilePath = Path.Combine(KhataFolderPath, "debts.json");
        public static bool   IsFirstStart = false;

        public static void CreateFolder()
        {
            //this is for the user if not registerd
            if (!Directory.Exists(KhataFolderPath))
            {
                Directory.CreateDirectory(KhataFolderPath);
                File.WriteAllText(Path.Combine(KhataFolderPath, "users.json"), "[]");
                File.WriteAllText(Path.Combine(KhataFolderPath, "incomes.json"), "[]");
                File.WriteAllText(Path.Combine(KhataFolderPath, "expenses.json"), "[]");
                File.WriteAllText(Path.Combine(KhataFolderPath, "debts.json"), "[]");

                Console.WriteLine($"Folder created at: {KhataFolderPath}");
                IsFirstStart = true;

            }
            else
            {
                OnStartUp();
            }

        }

        public static void OnStartUp()
        {
            UserService user = new UserService();
            user.GetUser();
            IncomeService incomeService = new IncomeService();
            incomeService.GetSavedIncome();

            ExpenseService expenseService = new ExpenseService();
            expenseService.GetSavedExpense();

            DebtService debtService = new DebtService();
            debtService.GetSavedDebt();
        }

        public static void SaveDataOnExit(object? sender, EventArgs e)
        {
            UserService userService = new UserService();
            userService.SaveUserData();

            IncomeService incomeService = new IncomeService();
            incomeService.SaveAllIncome();

            DebtService debtService = new DebtService();
            debtService.SaveAllDebt();

            ExpenseService expenseService = new ExpenseService();
            expenseService.SaveAllExpense();
        }


    }
}
