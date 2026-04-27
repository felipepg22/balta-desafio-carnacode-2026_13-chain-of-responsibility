using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.src.Services.Approvers;

public abstract class Approver
{
    protected Approver Next;

    public Approver SetNext(Approver next)
    {
        Next = next;
        return next;
    }

    public abstract void ProcessExpense(ExpenseRequest expenseRequest);

    public abstract void RegisterApproval(ExpenseRequest expenseRequest);

    protected bool ValidateReceipt(ExpenseRequest request)
    {
        Console.WriteLine("  → Validando nota fiscal...");
        return true; // Simulação
    }

    protected bool CheckBudget(string department, decimal amount)
    {
        Console.WriteLine($"  → Verificando orçamento do departamento {department}...");
        return true; // Simulação
    }

    protected bool CheckPolicy(ExpenseRequest request)
    {
        Console.WriteLine("  → Verificando conformidade com política...");
        return true; // Simulação
    }

    protected bool CheckStrategicAlignment(ExpenseRequest request)
    {
        Console.WriteLine("  → Verificando alinhamento estratégico...");
        return true; // Simulação
    }

    protected bool CheckBoardApproval(ExpenseRequest request)
    {
        Console.WriteLine("  → Verificando aprovação do conselho...");
        return true; // Simulação
    }
}
