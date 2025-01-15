using finalKhata.Configs;
using finalKhata.Data;
using finalKhata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace finalKhata.Services
{
    public class IncomeService
    {

        public static List<IncomeModel> Incomes { get; set; } = new List<IncomeModel>();
        public  static String IncomeFilePath = FolderAndFiles.IncomeFilePath;

        public static void AddIncome(IncomeModel income )
        {
            Incomes.Add( income );
          UserService.User.TotalIncome =  UserService.User.TotalIncome + income.Amount;
            
        }

        public void  GetSavedIncome()
        {
          string json = File.ReadAllText(IncomeFilePath);
          Incomes =  JsonSerializer.Deserialize<List<IncomeModel>>(json) ;

        }

        public  void SaveAllIncome()
        {
            string json = JsonSerializer.Serialize(Incomes);
            File.WriteAllText(IncomeFilePath, json);

        }
   
    
    } 
}
