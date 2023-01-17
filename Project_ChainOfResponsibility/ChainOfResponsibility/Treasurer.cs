using Project_ChainOfResponsibility.DAL.Entities;
using Project_ChainOfResponsibility.DAL;

namespace Project_ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer: Employee //veznedar
    {
        
        public override void ProcessRequest(WithdrawViewModel p)
        {
            if (p.Amount <= 40000)   //parmatre tutarı 40000'den küçükse o kişi tarafından onaylanır.
            {
                //db'ye kaydetme işlemi
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess(); //nesne örneklemesi üzerinden gidildi.
                  
                    bankProcess.EmployeeName = "Veznedar - Ayşenur Yıldız";
                    bankProcess.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi gerçekleştirildi.";
                    bankProcess.Amount = p.Amount;
                    bankProcess.CustomerName = p.CustomerName;

                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();
                }
                

            }
            else if (NextApprover != null)
            {
                //NextApprover Zincirin sonraki elemanını yönlendirecek tarafı temsil eder.
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Veznedar - Ayşenur Yıldız";
                    bankProcess.Description = "Müşterinin talep ettiği tutar yetkim dahilinde olmadığı için işlem Şube Müdür Yardımcısına gönderildi.";
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
