using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryRestaurantes
{
    class Restaurante
    {
        public enum TipoPedido
        {
            Entregue,
            NaoEntregue,
            Todos
        }
        public string nome, endereco, cnpj;
        public Cardapio cardapio;
        public List<Pedido> pedidos;
        
        public Restaurante(string nome, string endereco, string cnpj)
        {
            this.nome = nome;
            this.endereco = endereco;
            this.cnpj = cnpj;
            this.cardapio = new Cardapio();
            this.pedidos = new List<Pedido>();
        }
        public bool aceitaPedido(List<Produto> p)
        {
            if (p.Count > 0 && p.Count <= 5) return true;
            return false;
        }
        public void mostrarCardapio()
        {
            Console.WriteLine($"=====Cardápio do restaurante {nome}=======");
            foreach(Produto p in cardapio.produtos)
            {
                Console.WriteLine($"{p.nome} {p.descricao} {p.valor}");
            }
            Console.WriteLine();
        }
        public void adicionarProduto(Produto p)
        {
            this.cardapio.adicionarProduto(p);
        }

        public void removerProduto(Produto p)
        {
            this.cardapio.removerProduto(p);
        }

        public bool adicionarPedido(Pedido p)
        {
            if (this.aceitaPedido(p.produtos))
            {
                this.pedidos.Add(p);
                return true;
            }
            return false;
        }
        public bool removerPedido(Pedido p)
        {
            return this.pedidos.Remove(p);
        }
        public bool criarPedido(string nomeCliente, Produto[] produtos)
        {
            List <Produto> listProdutos = new List<Produto>(produtos);
            Pedido p = new Pedido(nomeCliente, listProdutos);
            return this.adicionarPedido(p);
        }
        public void mostrarPedidos(TipoPedido tipo)
        {
            Console.WriteLine($"#####Pedidos do restaurante {nome}#####");
            switch (tipo)
            {
                case TipoPedido.Entregue:
                    Console.WriteLine("Pedidos entregados");
                    foreach (Pedido p in this.pedidos)
                    {
                        if (p.entregue) p.mostrarPedido();
                    }
                    break;
                case TipoPedido.NaoEntregue:
                    Console.WriteLine("Pedidos que não foram entregados");
                    foreach (Pedido p in this.pedidos)
                    {
                        if (!p.entregue) p.mostrarPedido();
                    }
                    break;
                case TipoPedido.Todos:
                    Console.WriteLine("Todos os pedidos");
                    foreach (Pedido p in this.pedidos) p.mostrarPedido();
                    break;
            }
            Console.WriteLine();
        }
    }
}
