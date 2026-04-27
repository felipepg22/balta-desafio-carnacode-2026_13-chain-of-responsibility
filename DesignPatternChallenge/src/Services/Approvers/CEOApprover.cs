using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Services.Approvers;

public class CEOApprover : Approver
{
    public override void ProcessExpense(ExpenseRequest expenseRequest)
    {
        Console.WriteLine("[Supervisor] Valor acima do meu limite, encaminhando...");
        Console.WriteLine("[Gerente] Valor acima do meu limite, encaminhando...");
        Console.WriteLine("[Diretor] Valor acima do meu limite, encaminhando...");
        Console.WriteLine("[CEO] Analisando pedido...");

        if (ValidateReceipt(expenseRequest) && CheckBudget(expenseRequest.Department, expenseRequest.Amount) &&
            CheckPolicy(expenseRequest) && CheckStrategicAlignment(expenseRequest) && CheckBoardApproval(expenseRequest))
        {
            Console.WriteLine($"✅ [CEO] Despesa de R$ {expenseRequest.Amount:N2} APROVADA");
            RegisterApproval(expenseRequest);
        }
        else
        {
            Console.WriteLine($"❌ [CEO] Despesa REJEITADA");
        }
    }

    public override void RegisterApproval(ExpenseRequest expenseRequest)
    {
        Console.WriteLine($"  → Registrando aprovação por CEO...");
    }
}
