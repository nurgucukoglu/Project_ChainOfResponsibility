using Project_ChainOfResponsibility.DAL.Entities;
using Project_ChainOfResponsibility.DAL;

namespace Project_ChainOfResponsibility.ChainOfResponsibility
{
    public class BranchManager : Employee
    {
        public override void ProcessRequest(WithdrawViewModel p)
        {
            if (p.Amount <= 150000)
            {

                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                  
                    bankProcess.EmployeeName = "Şube Müdürü-Hakan Kayalı";
                    bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi şube müdürü tarafından gerçekleştirildi.";
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
                    bankProcess.EmployeeName = "Şube Müdürü - Hakan Kayalı";
                    bankProcess.Description = "Müşterinin talep ettiği tutar yetkim dahilinde olmadığı için işlem Bölge Müdürüne gönderildi.";
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
