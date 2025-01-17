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
    public class DebtService
    {

        public static List<DebtModel> Debts { get; set; } = new List<DebtModel>();
        public static string DebtsFilePath = FolderAndFiles.DebtsFilePath;

        public static void AddDebt(DebtModel debt)
        {
            Debts.Add(debt);
            UserService.User.TotalIncome +=  debt.Amount ;
            UserService.User.TotalDebt += debt.Amount ;

        }


        public static void DeleteDebt(DebtModel debt)
        {
            if (debt.isPaid)
            {
                Debts.Remove(debt);
            }
            else
            {
                UserService.User.TotalDebt -= debt.Amount;
                UserService.User.TotalIncome -= debt.Amount;
                Debts.Remove(debt);
            }

            
        }

       

public static void payDebt(DebtModel debt)
    {
        // Find the debt in the list
        var existingDebt = Debts.FirstOrDefault(d => d.id == debt.id);

        if (existingDebt.Amount < UserService.User.TotalIncome)
        {
            // Edit the debt's properties
            existingDebt.isPaid = true;

            // Update user's total debt and income
            UserService.User.TotalDebt -= debt.Amount;
            UserService.User.TotalIncome -= debt.Amount;
        }
        else
        {
            Console.WriteLine("Debt not found.");
        }
    }


    public void GetSavedDebt()
        {
            string json = File.ReadAllText(DebtsFilePath);
            Debts = JsonSerializer.Deserialize<List<DebtModel>>(json);

        }

        public void SaveAllDebt()
        {
            string json = JsonSerializer.Serialize(Debts);
            File.WriteAllText(DebtsFilePath, json);

        }



        


    }
}
