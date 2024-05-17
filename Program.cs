using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividadeVetor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalpessoas = 0;
            int nmrPrioridade = 0;
            
            string op = "0";

            string nome;
            string prioritario;
            bool bool_priori = false;

            Cliente[] clientes = new Cliente[10];

            void exibir()
            {
                int contador = 0;
                Console.WriteLine("\n\n==========Lista de clientes============\n\n");
                foreach (Cliente cli in clientes)
                {
                    if (cli != null)
                    {
                        contador++;
                        Console.WriteLine("  " + contador + "° " + cli.nome);
                    }
                }
                Console.WriteLine("\n\n=======================================");
            }

            while (op != "q")
            {
                Console.WriteLine("\n=======================================\n Deseja cadastrar um novo cliente [1]\n Deseja atender um cliente [2]\n Listar clientes na fila [3]\n Para fechar [q]\n=======================================\n");
                op = Console.ReadLine().ToLower();
                Console.WriteLine("\n=======================================");
                switch (op)
                {
                    case "1":
                       if (totalpessoas < 10)
                        {
                            Cliente cliente;
                            Console.WriteLine("\nDigite o nome do cliente");
                            nome = Console.ReadLine();
                            Console.WriteLine("\nÉ prioritario? [S/N]");
                            prioritario = Console.ReadLine().ToUpper();
                            Console.WriteLine("\n=======================================");
                            if (prioritario == "S")
                            {
                                bool_priori = true;
                                cliente = new Cliente(nome, bool_priori);
                                for (int c = totalpessoas; c > nmrPrioridade; c--)
                                {
                                    clientes[c] = clientes[c-1];
                                }
                                clientes[nmrPrioridade] = cliente;
                                nmrPrioridade++;
                            }
                            else if (prioritario == "N")
                            {
                                cliente = new Cliente(nome, bool_priori);
                                clientes[totalpessoas] = (cliente);
                            }
                            else
                            {
                                Console.WriteLine("Não há essa opção para cadastro, favor reinserir os dados");
                                break;
                            }
                            totalpessoas++;
                            exibir();
                        }
                        else
                        {
                            Console.WriteLine("\nA fila ta lotada");
                        }
                        break;

                    case "2":
                        if (totalpessoas > 0)
                        {
                            if (nmrPrioridade > 0) 
                            { 
                                nmrPrioridade--; 
                            }
                            for (int c = 0; c < 9; c++)
                            {
                                clientes[c] = clientes[c + 1];
                            }
                            clientes[totalpessoas] = null;
                            totalpessoas--;
                            Console.WriteLine("\nCliente atendido com sucesso");
                            exibir();
                        }
                        else { Console.WriteLine("\nA fila ta vazia, vai atender oq?"); }
                    break;

                    case "3":
                        exibir();
                        break;
                }
            }
        }
    }
}
