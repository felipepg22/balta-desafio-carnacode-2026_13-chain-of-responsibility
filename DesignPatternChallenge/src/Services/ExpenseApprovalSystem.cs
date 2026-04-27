using System;
using DesignPatternChallenge.Models;
using DesignPatternChallenge.src.Services.Approvers;

namespace DesignPatternChallenge.Services
{
    // Problema: Classe monolítica com lógica condicional complexa
    public class ExpenseApprovalSystem
    {
        public void ProcessExpense(ExpenseRequest request)
        {
            Console.WriteLine($"\n=== Processando Despesa ===");
            Console.WriteLine($"Funcionário: {request.EmployeeName}");
            Console.WriteLine($"Valor: R$ {request.Amount:N2}");
            Console.WriteLine($"Propósito: {request.Purpose}");
            Console.WriteLine($"Departamento: {request.Department}\n");

            var supervisor = new SupervisorApprover();
            var manager = new ManagerApprover();
            var director = new DirectorApprover();
            var ceo = new CEOApprover();

            supervisor.SetNext(manager);
            manager.SetNext(director);
            director.SetNext(ceo);

            supervisor.ProcessExpense(request);
        }
    }
}
