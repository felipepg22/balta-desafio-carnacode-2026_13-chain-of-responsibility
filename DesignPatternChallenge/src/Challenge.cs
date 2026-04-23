// DESAFIO: Sistema de Aprovação de Despesas Corporativas
// PROBLEMA: Uma empresa precisa processar pedidos de reembolso com diferentes níveis de aprovação
// baseados no valor. O código atual usa condicionais gigantes e está difícil de manter
// quando novos níveis de aprovação são adicionados

using System;
using DesignPatternChallenge.Models;
using DesignPatternChallenge.Services;

namespace DesignPatternChallenge
{
    // Contexto: Sistema de RH que processa reembolsos de despesas
    // Cada nível gerencial tem limite de aprovação diferente

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Aprovação de Despesas ===");

            var system = new ExpenseApprovalSystem();

            // Teste com diferentes valores
            var expense1 = new ExpenseRequest("João Silva", 50.00m, "Material de escritório", "TI");
            system.ProcessExpense(expense1);

            var expense2 = new ExpenseRequest("Maria Santos", 350.00m, "Curso de capacitação", "RH");
            system.ProcessExpense(expense2);

            var expense3 = new ExpenseRequest("Pedro Oliveira", 2500.00m, "Notebook", "TI");
            system.ProcessExpense(expense3);

            var expense4 = new ExpenseRequest("Ana Costa", 15000.00m, "Servidor para datacenter", "TI");
            system.ProcessExpense(expense4);

            Console.WriteLine("\n=== PROBLEMAS ===");
            Console.WriteLine("✗ Lógica condicional profundamente aninhada e complexa");
            Console.WriteLine("✗ Código duplicado para encaminhamento entre níveis");
            Console.WriteLine("✗ Adicionar novo nível requer modificar toda estrutura");
            Console.WriteLine("✗ Difícil alterar ordem ou critérios de aprovação");
            Console.WriteLine("✗ Não é possível compor diferentes cadeias dinamicamente");
            Console.WriteLine("✗ Testabilidade comprometida - difícil testar níveis isoladamente");
            Console.WriteLine("✗ Viola Single Responsibility: uma classe faz tudo");

            // Perguntas para reflexão:
            // - Como desacoplar os níveis de aprovação?
            // - Como permitir que cada nível decida se processa ou encaminha?
            // - Como facilitar adição/remoção de níveis sem modificar código existente?
            // - Como criar diferentes cadeias de aprovação dinamicamente?
        }
    }
}
