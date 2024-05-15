using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividadeVetor
{
    internal class Cliente
    {
        public string nome;
        bool prioritario;
        public Cliente(string nome, bool prioritario)
        {
            this.nome = nome;
            this.prioritario = prioritario;
        }
    }
}

