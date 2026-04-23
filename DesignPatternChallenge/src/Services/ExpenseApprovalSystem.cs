using System;
using DesignPatternChallenge.Models;

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

            // Problema 1: Lógica condicional aninhada e complexa
            if (request.Amount <= 100)
            {
                // Supervisor pode aprovar
                Console.WriteLine("[Supervisor] Analisando pedido...");

                if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount))
                {
                    Console.WriteLine($"✅ [Supervisor] Despesa de R$ {request.Amount:N2} APROVADA");
                    RegisterApproval("Supervisor", request);
                }
                else
                {
                    Console.WriteLine($"❌ [Supervisor] Despesa REJEITADA - Documentação inválida");
                }
            }
            else if (request.Amount <= 500)
            {
                // Gerente pode aprovar
                Console.WriteLine("[Supervisor] Valor acima do meu limite, encaminhando...");
                Console.WriteLine("[Gerente] Analisando pedido...");

                if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount) &&
                    CheckPolicy(request))
                {
                    Console.WriteLine($"✅ [Gerente] Despesa de R$ {request.Amount:N2} APROVADA");
                    RegisterApproval("Gerente", request);
                }
                else
                {
                    Console.WriteLine($"❌ [Gerente] Despesa REJEITADA");
                }
            }
            else if (request.Amount <= 5000)
            {
                // Diretor pode aprovar
                Console.WriteLine("[Supervisor] Valor acima do meu limite, encaminhando...");
                Console.WriteLine("[Gerente] Valor acima do meu limite, encaminhando...");
                Console.WriteLine("[Diretor] Analisando pedido...");

                if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount) &&
                    CheckPolicy(request) && CheckStrategicAlignment(request))
                {
                    Console.WriteLine($"✅ [Diretor] Despesa de R$ {request.Amount:N2} APROVADA");
                    RegisterApproval("Diretor", request);
                }
                else
                {
                    Console.WriteLine($"❌ [Diretor] Despesa REJEITADA");
                }
            }
            else
            {
                // CEO deve aprovar
                Console.WriteLine("[Supervisor] Valor acima do meu limite, encaminhando...");
                Console.WriteLine("[Gerente] Valor acima do meu limite, encaminhando...");
                Console.WriteLine("[Diretor] Valor acima do meu limite, encaminhando...");
                Console.WriteLine("[CEO] Analisando pedido...");

                if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount) &&
                    CheckPolicy(request) && CheckStrategicAlignment(request) && CheckBoardApproval(request))
                {
                    Console.WriteLine($"✅ [CEO] Despesa de R$ {request.Amount:N2} APROVADA");
                    RegisterApproval("CEO", request);
                }
                else
                {
                    Console.WriteLine($"❌ [CEO] Despesa REJEITADA");
                }
            }

            // Problema 2: Adicionar novo nível de aprovação requer modificar toda esta estrutura
            // Problema 3: Lógica de encaminhamento está duplicada
            // Problema 4: Não é fácil mudar a ordem ou pular níveis
        }

        private bool ValidateReceipt(ExpenseRequest request)
        {
            Console.WriteLine("  → Validando nota fiscal...");
            return true; // Simulação
        }

        private bool CheckBudget(string department, decimal amount)
        {
            Console.WriteLine($"  → Verificando orçamento do departamento {department}...");
            return true; // Simulação
        }

        private bool CheckPolicy(ExpenseRequest request)
        {
            Console.WriteLine("  → Verificando conformidade com política...");
            return true; // Simulação
        }

        private bool CheckStrategicAlignment(ExpenseRequest request)
        {
            Console.WriteLine("  → Verificando alinhamento estratégico...");
            return true; // Simulação
        }

        private bool CheckBoardApproval(ExpenseRequest request)
        {
            Console.WriteLine("  → Verificando aprovação do conselho...");
            return true; // Simulação
        }

        private void RegisterApproval(string approver, ExpenseRequest request)
        {
            Console.WriteLine($"  → Registrando aprovação por {approver}...");
        }
    }
}
