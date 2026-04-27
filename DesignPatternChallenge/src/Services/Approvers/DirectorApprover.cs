using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Services.Approvers;

public class DirectorApprover : Approver
{
    public override void ProcessExpense(ExpenseRequest expenseRequest)
    {

        if (expenseRequest.Amount <= 5000)
        {
            // Diretor pode aprovar
            Console.WriteLine("[Supervisor] Valor acima do meu limite, encaminhando...");
            Console.WriteLine("[Gerente] Valor acima do meu limite, encaminhando...");
            Console.WriteLine("[Diretor] Analisando pedido...");

            if (ValidateReceipt(expenseRequest) && CheckBudget(expenseRequest.Department, expenseRequest.Amount) &&
                CheckPolicy(expenseRequest) && CheckStrategicAlignment(expenseRequest))
            {
                Console.WriteLine($"✅ [Diretor] Despesa de R$ {expenseRequest.Amount:N2} APROVADA");
                RegisterApproval(expenseRequest);
            }
            else
            {
                Console.WriteLine($"❌ [Diretor] Despesa REJEITADA");
            }

            return;
        }

        Next.ProcessExpense(expenseRequest);
    }

    public override void RegisterApproval(ExpenseRequest expenseRequest)
    {
        Console.WriteLine($"  → Registrando aprovação por Diretor...");
    }
}
