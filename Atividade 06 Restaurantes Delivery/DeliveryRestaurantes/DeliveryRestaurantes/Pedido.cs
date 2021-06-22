using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryRestaurantes
{
    class Pedido
    {
        public string nomeCliente;
        public List<Produto> produtos;
        public bool entregue;

        public Pedido(string nomeCliente)
        {
            this.nomeCliente = nomeCliente;
            this.produtos = new List<Produto>();
            this.entregue = false;
        }

        public Pedido(string nomeCliente, List<Produto> produtos)
        {
            this.nomeCliente = nomeCliente;
            this.produtos = produtos;
            this.entregue = false;
        }

        public void mostrarPedido()
        {
            Console.WriteLine($"*****Pedido do cliente {this.nomeCliente}*****");
            foreach(Produto p in this.produtos)
            {
                Console.WriteLine(p.nome);
            }
            if (this.entregue) Console.WriteLine("Pedido entregue");
            else Console.WriteLine("Pedido ainda não entregue");
            Console.WriteLine($"Valor total: {this.calcularValor()}");
            Console.WriteLine();
        }
        public void adicionarProduto(Produto p)
        {
            produtos.Add(p);
        }
        public bool removerProduto(Produto p)
        {
            return produtos.Remove(p);
        }

        public void entregar()
        {
            this.entregue = true;
        }

        private float calcularValor()
        {
            float total = 0;
            foreach(Produto p in this.produtos)
            {
                total += p.valor;
            }
            return total;
        }

    }
}
