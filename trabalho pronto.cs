using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho_final
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        // Definindo a classe para um ingrediente
        class Ingrediente
        {
            public string Nome { get; set; }
            public double Quantidade { get; set; }
        }

        // Definindo a classe para uma receita
        class Receita
        {
            public string Nome { get; set; }
            public List<Ingrediente> Ingredientes { get; set; }
        }

        static List<Receita> receitas = new List<Receita>();

        static void Main()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n=== Gerenciador de Receitas ===");
                Console.WriteLine("1. Adicionar Receita");
                Console.WriteLine("2. Editar Receita");
                Console.WriteLine("3. Excluir Receita");
                Console.WriteLine("4. Visualizar Receitas");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                int opcao;
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            AdicionarReceita();
                            break;
                        case 2:
                            EditarReceita();
                            break;
                        case 3:
                            ExcluirReceita();
                            break;
                        case 4:
                            VisualizarReceitas();
                            break;
                        case 5:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
            }
        }

        static void AdicionarReceita()
        {
            Console.WriteLine("\n=== Adicionar Receita ===");
            Receita novaReceita = new Receita();
            novaReceita.Ingredientes = new List<Ingrediente>();

            Console.Write("Nome da Receita: ");
            novaReceita.Nome = Console.ReadLine();

            bool adicionarOutroIngrediente = true;
            while (adicionarOutroIngrediente)
            {
                Ingrediente novoIngrediente = new Ingrediente();

                Console.Write("Nome do Ingrediente: ");
                novoIngrediente.Nome = Console.ReadLine();

                Console.Write("Quantidade do Ingrediente: ");
                novoIngrediente.Quantidade = Convert.ToDouble(Console.ReadLine());

                novaReceita.Ingredientes.Add(novoIngrediente);

                Console.Write("Deseja adicionar outro ingrediente? (s/n): ");
                adicionarOutroIngrediente = Console.ReadLine().ToLower() == "s";
            }

            receitas.Add(novaReceita);
            Console.WriteLine("Receita adicionada com sucesso!");
        }

        static void EditarReceita()
        {
            Console.WriteLine("\n=== Editar Receita ===");
            Console.Write("Digite o nome da receita que deseja editar: ");
            string nomeReceita = Console.ReadLine();

            Receita receitaParaEditar = receitas.Find(r => r.Nome == nomeReceita);

            if (receitaParaEditar != null)
            {
                Console.Write("Novo nome da Receita: ");
                receitaParaEditar.Nome = Console.ReadLine();

                receitaParaEditar.Ingredientes.Clear();
                bool adicionarOutroIngrediente = true;
                while (adicionarOutroIngrediente)
                {
                    Ingrediente novoIngrediente = new Ingrediente();

                    Console.Write("Nome do Ingrediente: ");
                    novoIngrediente.Nome = Console.ReadLine();

                    Console.Write("Quantidade do Ingrediente: ");
                    novoIngrediente.Quantidade = Convert.ToDouble(Console.ReadLine());

                    receitaParaEditar.Ingredientes.Add(novoIngrediente);

                    Console.Write("Deseja adicionar outro ingrediente? (s/n): ");
                    adicionarOutroIngrediente = Console.ReadLine().ToLower() == "s";
                }

                Console.WriteLine("Receita editada com sucesso!");
            }
            else
            {
                Console.WriteLine("Receita não encontrada.");
            }
        }

        static void ExcluirReceita()
        {
            Console.WriteLine("\n=== Excluir Receita ===");
            Console.Write("Digite o nome da receita que deseja excluir: ");
            string nomeReceita = Console.ReadLine();

            Receita receitaParaExcluir = receitas.Find(r => r.Nome == nomeReceita);

            if (receitaParaExcluir != null)
            {
                receitas.Remove(receitaParaExcluir);
                Console.WriteLine("Receita excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Receita não encontrada.");
            }
        }

        static void VisualizarReceitas()
        {
            Console.WriteLine("\n=== Lista de Receitas ===");
            foreach (var receita in receitas)
            {
                Console.WriteLine($"Nome: {receita.Nome}");
                Console.WriteLine("Ingredientes:");
                foreach (var ingrediente in receita.Ingredientes)
                {
                    Console.WriteLine($"- {ingrediente.Nome}: {ingrediente.Quantidade}");
                }
            }
        }
    }

}