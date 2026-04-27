using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Services.Approvers;

public class ManagerApprover : Approver
{
    public override void ProcessExpense(ExpenseRequest expenseRequest)
    {
        if (expenseRequest.Amount <= 500)
        {
            // Gerente pode aprovar
            Console.WriteLine("[Supervisor] Valor acima do meu limite, encaminhando...");
            Console.WriteLine("[Gerente] Analisando pedido...");

            if (ValidateReceipt(expenseRequest) && CheckBudget(expenseRequest.Department, expenseRequest.Amount) &&
                CheckPolicy(expenseRequest))
            {
                Console.WriteLine($"✅ [Gerente] Despesa de R$ {expenseRequest.Amount:N2} APROVADA");
                RegisterApproval(expenseRequest);
            }
            else
            {
                Console.WriteLine($"❌ [Gerente] Despesa REJEITADA");
            }

            return;
        }

        Next.ProcessExpense(expenseRequest);
    }

    public override void RegisterApproval(ExpenseRequest expenseRequest)
    {
        Console.WriteLine($"  → Registrando aprovação por Gerente...");
    }
}
