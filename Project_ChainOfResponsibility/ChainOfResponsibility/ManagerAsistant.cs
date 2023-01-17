using Project_ChainOfResponsibility.DAL.Entities;
using Project_ChainOfResponsibility.DAL;

namespace Project_ChainOfResponsibility.ChainOfResponsibility
{
    public class ManagerAsistant : Employee
    {
        public override void ProcessRequest(WithdrawViewModel p)
        {
            if (p.Amount <= 70000)
            {
                //tutar değişiyor sadece. 
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                  

                    bankProcess.EmployeeName = "Şube Müdürü-Hilal Sarı";
                    bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi şube müdür yardımcısı tarafından gerçekleştirildi.";
                    bankProcess.Amount = p.Amount;
                    bankProcess.CustomerName = p.CustomerName;

                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();
                }

            }
            else if (NextApprover != null)
            {
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Şube Müdür Yardımcısı - Hilal Sarı";
                    bankProcess.Description = "Müşterinin talep ettiği tutar yetkim dahilinde olmadığı için işlem Şube Müdürüne gönderildi.";
                    bankProcess.Amount = p.Amount;
                    bankProcess.CustomerName = p.CustomerName;

                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();

                    NextApprover.ProcessRequest(p);
                }

            }
        }
    }
}
