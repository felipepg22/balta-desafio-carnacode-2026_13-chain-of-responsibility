using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Services.Approvers;

public class SupervisorApprover : Approver
{
    public override void ProcessExpense(ExpenseRequest expenseRequest)
    {
        if (expenseRequest.Amount <= 100)
        {
            Console.WriteLine("[Supervisor] Analisando pedido...");

            if (ValidateReceipt(expenseRequest) && CheckBudget(expenseRequest.Department, expenseRequest.Amount))
            {
                Console.WriteLine($"✅ [Supervisor] Despesa de R$ {expenseRequest.Amount:N2} APROVADA");
                RegisterApproval(expenseRequest);
            }
            else
            {
                Console.WriteLine($"❌ [Supervisor] Despesa REJEITADA - Documentação inválida");
            }

            return;
        }

        Next.ProcessExpense(expenseRequest);
    }

    public override void RegisterApproval(ExpenseRequest expenseRequest)
    {
        Console.WriteLine($"  → Registrando aprovação por Supervisor...");
    }
}
