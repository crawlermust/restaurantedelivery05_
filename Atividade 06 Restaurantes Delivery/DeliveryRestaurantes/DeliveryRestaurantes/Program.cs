using System;
using System.Collections.Generic;

namespace DeliveryRestaurantes
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantesRegiao regLondrina = new RestaurantesRegiao("Londrina");

            Restaurante r1 = new Restaurante("Hot Tapioca", "Praça da Sé", "33237889");
            Produto p1 = new Produto("Crepioca com Frango", "Massa de tapioca com ovo e recheio de frango", 15f);
            Produto p2 = new Produto("Crepioca Doce", "Massa de tapioca com ovo e recheio de chocolate e creme de amendoin", 12.50f);
            r1.cardapio.adicionarProduto(p1);
            r1.cardapio.adicionarProduto(p2);
            regLondrina.adicionarRestaurante(r1);

            Restaurante r2 = new Restaurante("AçaíFreeze", "Avenida JK", "332445656");
            Produto p3 = new Produto("Açaí ao pote", "500g", 12f);
            Produto p4 = new Produto("Açaí com frutas", "Açaí acompanho com 5 variedades de frutas", 15.50f);
            r2.cardapio.adicionarProduto(p3);
            r2.cardapio.adicionarProduto(p4);
            regLondrina.adicionarRestaurante(r2);

            regLondrina.removerRestaurante(r1);
            regLondrina.mostrarRestaurantes();
            r2.mostrarCardapio();

            RestaurantesRegiao regMaringa = new RestaurantesRegiao("Cambé");
            Restaurante r3 = new Restaurante("Marmitaria do João", "Av Leste Oeste", "4434433245");
            Produto p5 = new Produto("Marmita média", "Arroz com feijão 2 carnes", 13.50f);
            Produto p6 = new Produto("Sobrmesa Sortida", "Torta de morango, ou bolo de fubá", 6.50f);
            r3.cardapio.adicionarProduto(p5);
            r3.cardapio.adicionarProduto(p6);
            regMaringa.adicionarRestaurante(r3);

            r3.removerProduto(p6);

            regMaringa.mostrarRestaurantes();
            r3.mostrarCardapio();

            Pedido pedido1 = new Pedido("Renato");
            pedido1.adicionarProduto(p1);
            pedido1.adicionarProduto(p2);
            pedido1.entregar();
            pedido1.mostrarPedido();
            r3.adicionarPedido(pedido1);
            r3.criarPedido("Fernando", new Produto[]{p5});
            r2.criarPedido("Sasuke", new Produto[] { p3, p4 });
            r2.criarPedido("Naruto", new Produto[] { p3 });
            r2.criarPedido("Goku", new Produto[] { p4 });
            r3.mostrarPedidos(Restaurante.TipoPedido.NaoEntregue);
            r3.mostrarPedidos(Restaurante.TipoPedido.Entregue);
            r3.mostrarPedidos(Restaurante.TipoPedido.Todos);
            r2.mostrarPedidos(Restaurante.TipoPedido.NaoEntregue);
            r2.mostrarPedidos(Restaurante.TipoPedido.Entregue);
            r2.mostrarPedidos(Restaurante.TipoPedido.Todos);
        }
    }
}
