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
        public static String DebtsFilePath = FolderAndFiles.DebtsFilePath;

        public static void AddDebt(DebtModel debt)
        {
            Debts.Add(debt);
            UserService.User.TotalIncome +=  debt.Amount ;
            UserService.User.TotalDebt += debt.Amount ;

        }


        public static void DeleteDebt(DebtModel debt)
        {
            UserService.User.TotalDebt -= debt.Amount ;
            UserService.User.TotalIncome -= debt.Amount ;
            Debts.Remove(debt);
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
