using Project_ChainOfResponsibility.DAL.Entities;
using Project_ChainOfResponsibility.DAL;

namespace Project_ChainOfResponsibility.ChainOfResponsibility
{
    public class RegionManager : Employee
    {
        public override void ProcessRequest(WithdrawViewModel p)
        {
            if (p.Amount <= 300000)
            {
               
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                  
                    bankProcess.EmployeeName = "Bölge Müdürü - Zeynep Dere";
                    bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi bölge müdürü tarafından gerçekleştirildi.";
                    bankProcess.Amount = p.Amount;
                    bankProcess.CustomerName = p.CustomerName;

                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();
                }

            }
            else  
            {

                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Bölge Müdürü - Zeynep Dere";
                    bankProcess.Description = "Müşterinin talep ettiği tutar banka limitlerinin günlük çekim tutarı üzerinde olduğu için müşteriye ödeme yapılamadı.";
                    bankProcess.Amount = p.Amount;
                    bankProcess.CustomerName = p.CustomerName;

                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();

                }


            }
        }
    }
}
