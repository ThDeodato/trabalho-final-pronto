using System;

namespace trab_final
{
    // Definindo a classe para uma receita
    class Receita
    {
        public string Nome { get; set; }
        public string[] IngredientesNomes { get; set; }
        public double[] IngredientesQuantidades { get; set; }
        public string Dificuldade { get; set; }
        public int TempoPreparacao { get; set; }
    }

    class Program
    {
        static Receita[] receitas = new Receita[100]; // Tamanho máximo de 100 receitas
        static int numReceitas = 0;

        static void Main()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n=== Gerenciador de Receitas ===");
                Console.WriteLine("1. Adicionar Receita");
                Console.WriteLine("2. Editar Receita");
                Console.WriteLine("3. Excluir Receita");
                Console.WriteLine("4. Visualizar Todas as Receitas");
                Console.WriteLine("5. Visualizar por Dificuldade");
                Console.WriteLine("6. Visualizar por Tempo de Preparação");
                Console.WriteLine("7. Sair");
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
                            VisualizarTodasAsReceitas();
                            break;
                        case 5:
                            VisualizarPorDificuldade();
                            break;
                        case 6:
                            VisualizarPorTempoDePreparacao();
                            break;
                        case 7:
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

            Console.Write("Nome da Receita: ");
            novaReceita.Nome = Console.ReadLine();

            Console.Write("Dificuldade: ");
            novaReceita.Dificuldade = Console.ReadLine();

            Console.Write("Tempo de Preparação (minutos): ");
            if (int.TryParse(Console.ReadLine(), out int tempoPreparacao))
            {
                novaReceita.TempoPreparacao = tempoPreparacao;
            }
            else
            {
                Console.WriteLine("Tempo de Preparação inválido. Certifique-se de inserir um número inteiro.");
                return;
            }

            Console.Write("Quantidade de Ingredientes: ");
            if (int.TryParse(Console.ReadLine(), out int numIngredientes))
            {
                novaReceita.IngredientesNomes = new string[numIngredientes];
                novaReceita.IngredientesQuantidades = new double[numIngredientes];

                for (int i = 0; i < numIngredientes; i++)
                {
                    Console.Write($"Nome do Ingrediente {i + 1}: ");
                    novaReceita.IngredientesNomes[i] = Console.ReadLine();

                    Console.Write($"Quantidade do Ingrediente {i + 1}: ");
                    if (double.TryParse(Console.ReadLine(), out double quantidade))
                    {
                        novaReceita.IngredientesQuantidades[i] = quantidade;
                    }
                    else
                    {
                        Console.WriteLine("Quantidade inválida. Certifique-se de inserir um número válido.");
                        return;
                    }
                }

                receitas[numReceitas++] = novaReceita;
                Console.WriteLine("Receita adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("Quantidade de Ingredientes inválida. Certifique-se de inserir um número inteiro.");
                return;
            }
        }

        static void EditarReceita()
        {
            Console.WriteLine("\n=== Editar Receita ===");
            Console.Write("Digite o nome da receita que deseja editar: ");
            string nomeReceita = Console.ReadLine();

            for (int i = 0; i < numReceitas; i++)
            {
                if (receitas[i].Nome == nomeReceita)
                {
                    Console.Write("Novo nome da Receita: ");
                    receitas[i].Nome = Console.ReadLine();

                    Console.Write("Dificuldade: ");
                    receitas[i].Dificuldade = Console.ReadLine();

                    Console.Write("Tempo de Preparação (minutos): ");
                    if (int.TryParse(Console.ReadLine(), out int tempoPreparacao))
                    {
                        receitas[i].TempoPreparacao = tempoPreparacao;
                    }
                    else
                    {
                        Console.WriteLine("Tempo de Preparação inválido. Certifique-se de inserir um número inteiro.");
                        return;
                    }

                    Console.Write("Quantidade de Ingredientes: ");
                    if (int.TryParse(Console.ReadLine(), out int numIngredientes))
                    {
                        receitas[i].IngredientesNomes = new string[numIngredientes];
                        receitas[i].IngredientesQuantidades = new double[numIngredientes];

                        for (int j = 0; j < numIngredientes; j++)
                        {
                            Console.Write($"Nome do Ingrediente {j + 1}: ");
                            receitas[i].IngredientesNomes[j] = Console.ReadLine();

                            Console.Write($"Quantidade do Ingrediente {j + 1}: ");
                            if (double.TryParse(Console.ReadLine(), out double quantidade))
                            {
                                receitas[i].IngredientesQuantidades[j] = quantidade;
                            }
                            else
                            {
                                Console.WriteLine("Quantidade inválida. Certifique-se de inserir um número válido.");
                                return;
                            }
                        }

                        Console.WriteLine("Receita editada com sucesso!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Quantidade de Ingredientes inválida. Certifique-se de inserir um número inteiro.");
                        return;
                    }
                }
            }

            Console.WriteLine("Receita não encontrada.");
        }

        static void ExcluirReceita()
        {
            Console.WriteLine("\n=== Excluir Receita ===");
            Console.Write("Digite o nome da receita que deseja excluir: ");
            string nomeReceita = Console.ReadLine();

            for (int i = 0; i < numReceitas; i++)
            {
                if (receitas[i].Nome == nomeReceita)
                {
                    for (int j = i; j < numReceitas - 1; j++)
                    {
                        receitas[j] = receitas[j + 1];
                    }

                    numReceitas--;
                    Console.WriteLine("Receita excluída com sucesso!");
                    return;
                }
            }

            Console.WriteLine("Receita não encontrada.");
        }

        static void VisualizarTodasAsReceitas()
        {
            Console.WriteLine("\n=== Lista de Todas as Receitas ===");
            for (int i = 0; i < numReceitas; i++)
            {
                Console.WriteLine($"Nome: {receitas[i].Nome}");
                Console.WriteLine($"Dificuldade: {receitas[i].Dificuldade}");
                Console.WriteLine($"Tempo de Preparação: {receitas[i].TempoPreparacao} minutos");
                Console.WriteLine("Ingredientes:");
                for (int j = 0; j < receitas[i].IngredientesNomes.Length; j++)
                {
                    Console.WriteLine($"- {receitas[i].IngredientesNomes[j]}: {receitas[i].IngredientesQuantidades[j]}");
                }
                Console.WriteLine();
            }
        }

        static void VisualizarPorDificuldade()
        {
            Console.WriteLine("\n=== Lista de Receitas por Dificuldade ===");
            Console.Write("Digite a dificuldade desejada: ");
            string dificuldade = Console.ReadLine();

            for (int i = 0; i < numReceitas; i++)
            {
                if (receitas[i].Dificuldade == dificuldade)
                {
                    Console.WriteLine($"Nome: {receitas[i].Nome}");
                    Console.WriteLine($"Dificuldade: {receitas[i].Dificuldade}");
                    Console.WriteLine($"Tempo de Preparação: {receitas[i].TempoPreparacao} minutos");
                    Console.WriteLine("Ingredientes:");
                    for (int j = 0; j < receitas[i].IngredientesNomes.Length; j++)
                    {
                        Console.WriteLine($"- {receitas[i].IngredientesNomes[j]}: {receitas[i].IngredientesQuantidades[j]}");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void VisualizarPorTempoDePreparacao()
        {
            Console.WriteLine("\n=== Lista de Receitas por Tempo de Preparação ===");
            Console.Write("Digite o tempo de preparação máximo desejado (minutos): ");
            if (int.TryParse(Console.ReadLine(), out int tempoMaximo))
            {
                for (int i = 0; i < numReceitas; i++)
                {
                    if (receitas[i].TempoPreparacao <= tempoMaximo)
                    {
                        Console.WriteLine($"Nome: {receitas[i].Nome}");
                        Console.WriteLine($"Dificuldade: {receitas[i].Dificuldade}");
                        Console.WriteLine($"Tempo de Preparação: {receitas[i].TempoPreparacao} minutos");
                        Console.WriteLine("Ingredientes:");
                        for (int j = 0; j < receitas[i].IngredientesNomes.Length; j++)
                        {
                            Console.WriteLine($"- {receitas[i].IngredientesNomes[j]}: {receitas[i].IngredientesQuantidades[j]}");
                        }
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Tempo de preparação inválido. Certifique-se de inserir um número inteiro.");
            }
        }
    }
}
