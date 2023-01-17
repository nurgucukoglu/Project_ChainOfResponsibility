namespace Project_ChainOfResponsibility.ChainOfResponsibility
{
    public abstract class Employee //abstract class çünkü içine metot yazıcaz(override) burdan sonra şu yöneticiye gitsin vs diye
    {
        protected Employee NextApprover;
        public void SetNextApprover(Employee supervisor)
        {
            NextApprover = supervisor;//NextApprover 
                                           //sonraki onay veren kişiyi gösteriyor. 
                                           //önceki adımda onay alamadığında sonraki adıma geçmesini sağlıyor.

        }
        public abstract void ProcessRequest(WithdrawViewModel p);
        //para çekecek kişiden request parametresi almış olan para çekme talebi
    }
}
