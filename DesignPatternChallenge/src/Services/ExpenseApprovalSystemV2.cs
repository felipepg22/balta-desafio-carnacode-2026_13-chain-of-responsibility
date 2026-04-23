using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Services
{
    // Alternativa problemática: Switch case
    public class ExpenseApprovalSystemV2
    {
        public void ProcessExpense(ExpenseRequest request)
        {
            var approvalLevel = DetermineApprovalLevel(request.Amount);

            // Problema: Ainda requer modificação para adicionar novos níveis
            switch (approvalLevel)
            {
                case "Supervisor":
                    ProcessBySupervisor(request);
                    break;
                case "Gerente":
                    ProcessBySupervisor(request); // Passa por todos
                    ProcessByManager(request);
                    break;
                case "Diretor":
                    ProcessBySupervisor(request);
                    ProcessByManager(request);
                    ProcessByDirector(request);
                    break;
                case "CEO":
                    ProcessBySupervisor(request);
                    ProcessByManager(request);
                    ProcessByDirector(request);
                    ProcessByCEO(request);
                    break;
            }
        }

        private string DetermineApprovalLevel(decimal amount)
        {
            if (amount <= 100) return "Supervisor";
            if (amount <= 500) return "Gerente";
            if (amount <= 5000) return "Diretor";
            return "CEO";
        }

        private void ProcessBySupervisor(ExpenseRequest request) { }
        private void ProcessByManager(ExpenseRequest request) { }
        private void ProcessByDirector(ExpenseRequest request) { }
        private void ProcessByCEO(ExpenseRequest request) { }
    }
}
