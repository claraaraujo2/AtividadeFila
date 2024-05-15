using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividadeVetor
{
    internal class Program
    {
        static Cliente[] clientes = new Cliente[10];
        private static void exibir()
        {
            Console.WriteLine("\n\n");
            foreach (Cliente cli in clientes)
            {
                if (cli != null)
                {
                    Console.WriteLine(cli.nome);
                }
            }
            Console.WriteLine("\n\n");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            int i = 0;
            int nmrPrioridade = 0;
            string op = "0";

            while (true)
            {
                Console.WriteLine("\n=======================================\n Deseja cadastrar um novo cliente [1]\n Deseja atender um cliente [2]\n Listar clientes na fila [3]\n Para fechar [q]\n=======================================\n");
                op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                       if (i < 10)
                        {
                            string nome;
                            string prioritario;
                            bool bool_priori = false;
                            Cliente cliente;

                            Console.WriteLine("\nDigite o nome do cliente");
                            nome = Console.ReadLine();
                            Console.WriteLine("\nÉ prioritario? [S/N]");
                            prioritario = Console.ReadLine().ToUpper();

                            if (prioritario == "S")
                            {
                                bool_priori = true;
                                cliente = new Cliente(nome, bool_priori);
                                for (int c = i+1; c > nmrPrioridade; c--)
                                {
                                    clientes[c] = clientes[c-1];
                                }
                                clientes[nmrPrioridade] = cliente;
                                nmrPrioridade++;
                            }
                            else if (prioritario == "N")
                            {
                                cliente = new Cliente(nome, bool_priori);
                                clientes[i] = (cliente);
                            }
                            i++;
                            exibir();
                        }
                        else
                        {
                            Console.WriteLine("\nA fila ta lotada");
                        }
                        break;

                    case "2":
                        if (i > 0)
                        {
                            if (nmrPrioridade > 0) { nmrPrioridade--; }

                            for (int c = 0; c < 9; c++)
                            {
                                clientes[c] = clientes[c + 1];
                            }
                            clientes[i] = null;
                            i--;

                            Console.WriteLine("\nCliente atendido com sucesso");


                            Console.WriteLine("\n\n");
                            foreach (Cliente cli in clientes)
                            {
                                if (cli != null)
                                {
                                    Console.WriteLine(cli.nome);
                                }
                            }
                            Console.WriteLine("\n\n");
                            exibir();
                            Console.ReadKey();
                        }
                        else { Console.WriteLine("\nA fila ta vazia, vai atender oq?"); }
                    break;

                    case "3":
                        exibir();
                        break;
                    case "q":

                        break;
                }
                
            }
        }
    }
}
