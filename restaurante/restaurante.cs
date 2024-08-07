/******************************************************************************
António Marcelo Marques
IEFP-PI04 Programação em C#

Tarefa 2 - Menu de um restaurante v4 (utilização de enum)
Exercício sobre 'arrays' e 'switch'
*******************************************************************************/

using System;
class Restaurante
{
    enum Opcoes { Sair, Sopas, Pratos, Sobremesas, Bebidas, Conta, Pagamento };
    // dimensões dos 'arrays'
    const int maxMenus = 6, maxSopas = 4, maxPratos = 10, maxSobremesas = 5, maxBebidas = 7;
    const int maxMesas = 6, maxPedidos = 30;
    // menus e preços
    static readonly string[] menus = { "Sopas", "Pratos", "Sobremesas", "Bebidas", "Conta", "Pagamento" };
    static readonly string[] menuSopas = { "Sopa de Legumes", "Canja", "Caldo Verde", "Sopa de Peixe" };
    static readonly float[] precosSopas = { 2, 2, 3, 5 };
    static readonly string[] menuPratos = { "Bacalhau com batatas", "Bacalhau à Brás", "Arroz de bacalhau", "Pataniscas",
                        "Pastéis de bacalhau", "Bacalhau assado", "Bacalhau com natas", "Bacalhau à casa",
                        "Bacalhau desfiado", "Salada de Bacalhau" };
    static readonly float[] precosPratos = { 8, 9, 10, 10, 11, 12, 13, 14, 10, 11 };
    static readonly string[] menuSobremesas = { "Mousse de Chocolate", "Arroz Doce", "Gelado", "Baba de Camelo", "Profiteroles" };
    static readonly float[] precosSobremesas = { 5, 7, 6, 7, 8 };
    static readonly string[] menuBebidas = { "Água", "Sumo", "Sangria", "Cerveja", "Vinho", "Cola", "Café" };
    static readonly float[] precosBebidas = { 1, 2, 8, 3, 5, 2, 1 };

    static void Main()
    {

        int[,] pedidosMenu = new int[maxMesas, maxPedidos]; // guarda a opcao de Menu na forma (mesa, opcao)
        int[,] pedidosServico = new int[maxMesas, maxPedidos]; // guarda a opcao de subMenu (mesa, subOpcao)
        int[,] quantidadeServico = new int[maxMesas, maxPedidos]; // guarda a quantidade do serviço pedido (mesa, quantidade)

        bool continuar = true;  // controla a saída da aplicação
        int[] numPedidosMesa = new int[maxMesas];
        for (int i = 0; i < maxMesas; i++) numPedidosMesa[i] = -1;  // inicia pedidos de mesa a -1 

        while (continuar)   // continua até ser escolhida uma opção de saída do programa
        {
            //int opcao = 0;    // carrega a opção do menu
            Opcoes opcao = Opcoes.Sair;
            int subOpcao = 0;  // carrega a opção do submenu
            int numMesa = 0;  // carega a mesa a que o serviço está associado
            Console.Write("\nMesas com serviço iniciado: ");
            for (int i = 1; i <= maxMesas; i++)
                if (numPedidosMesa[i - 1] >= 0) Console.Write($"{i} ");
            Console.Write($"\n====> Escolha a mesa a servir (1 a {maxMesas}): ");
            // O número de mesa 'numMesa' vai ser usado como índice de um array
            // como é um número com significado para o operador, no uso como índice é subtraído de uma unidade
            // o mesmo acontece com outros índices aqui utilizados
            numMesa = int.Parse(Console.ReadLine());     // escolhe a mesa do próximo serviço
            Console.Clear();  // limpa a consola e posiciona o cursor no canto superior esquerdo
            if (numMesa == 0) break;   // sair à bruta
            Console.WriteLine($"Serviço para a mesa {numMesa}");
            for (int i = 0; i < maxMenus; i++)
                Console.WriteLine($"{i + 1} - {menus[i]}");
            Console.WriteLine("0 - Sair da aplicação - 0");
            // opcao = int.Parse(Console.ReadLine());  // escolhe o serviço a executar
            opcao = (Opcoes)int.Parse(Console.ReadLine());
            int quantidade = 1;
            switch (opcao)
            {
                case Opcoes.Sair:         //  o operador escolheu sair da aplicação 
                    Console.WriteLine("-- Xau --");
                    continuar = false;
                    break;
                case Opcoes.Sopas:  // Escolher Sopas  
                    Console.WriteLine($"Serviço para a mesa {numMesa}");
                    for (int i = 0; i < maxSopas; i++)
                        Console.WriteLine($"{i + 1} - {menuSopas[i],-20} {precosSopas[i]:0.00}€");
                    Console.WriteLine("0 - Voltar ao Menu");
                    subOpcao = int.Parse(Console.ReadLine());
                    if (subOpcao > 0)
                    {
                        Console.WriteLine($"Quantidade de {menuSopas[subOpcao - 1]}?");
                        quantidade = int.Parse(Console.ReadLine());
                        if (quantidade > 0)
                        {
                            quantidadeServico[numMesa - 1, ++numPedidosMesa[numMesa - 1]] = quantidade;
                            pedidosMenu[numMesa - 1, numPedidosMesa[numMesa - 1]] = (int)opcao - 1;
                            pedidosServico[numMesa - 1, numPedidosMesa[numMesa - 1]] = subOpcao - 1;
                        } // 'if' quantidade
                    } // 'if' subopcao
                    break;
                case Opcoes.Pratos: // Pratos
                    Console.WriteLine($"Serviço para a mesa {numMesa}");
                    for (int i = 0; i < maxPratos; i++)
                        Console.WriteLine($"{i + 1} - {menuPratos[i],-20} {precosPratos[i]:0.00}€");
                    Console.WriteLine("0 - Voltar ao Menu");
                    subOpcao = int.Parse(Console.ReadLine());
                    if (subOpcao > 0)
                    {
                        Console.WriteLine($"Quantidade de {menuPratos[subOpcao - 1]}?");
                        quantidade = int.Parse(Console.ReadLine());
                        if (quantidade > 0)
                        {
                            quantidadeServico[numMesa - 1, ++numPedidosMesa[numMesa - 1]] = quantidade;
                            pedidosMenu[numMesa - 1, numPedidosMesa[numMesa - 1]] = (int)opcao - 1;
                            pedidosServico[numMesa - 1, numPedidosMesa[numMesa - 1]] = subOpcao - 1;
                        } // 'if' quantidade
                    } // 'if' subopcao
                    break;
                case Opcoes.Sobremesas:  // Sobremesas
                    Console.WriteLine($"Serviço para a mesa {numMesa}");
                    for (int i = 0; i < maxSobremesas; i++)
                        Console.WriteLine($"{i + 1} - {menuSobremesas[i],-20} {precosSobremesas[i]:0.00}€");
                    Console.WriteLine("0 - Voltar ao Menu - 0");
                    subOpcao = int.Parse(Console.ReadLine());
                    if (subOpcao > 0)
                    {
                        Console.WriteLine($"Quantidade de {menuSobremesas[subOpcao - 1]}?");
                        quantidade = int.Parse(Console.ReadLine());
                        if (quantidade > 0)
                        {
                            quantidadeServico[numMesa - 1, ++numPedidosMesa[numMesa - 1]] = quantidade;
                            pedidosMenu[numMesa - 1, numPedidosMesa[numMesa - 1]] = (int)opcao - 1;
                            pedidosServico[numMesa - 1, numPedidosMesa[numMesa - 1]] = subOpcao - 1;
                        } // 'if' quantidade
                    } // 'if' subopcao
                    break;
                case Opcoes.Bebidas:  // Bebidas
                    for (int i = 0; i < maxBebidas; i++)
                        Console.WriteLine($"{i + 1} - {menuBebidas[i],-20} {precosBebidas[i]:0.00}€");
                    Console.WriteLine("0 - Voltar ao Menu - 0");
                    subOpcao = int.Parse(Console.ReadLine());
                    if (subOpcao > 0)
                    {
                        Console.WriteLine($"Quantidade de {menuBebidas[subOpcao - 1]}?");
                        quantidade = int.Parse(Console.ReadLine());
                        if (quantidade > 0)
                        {
                            quantidadeServico[numMesa - 1, ++numPedidosMesa[numMesa - 1]] = quantidade;
                            pedidosMenu[numMesa - 1, numPedidosMesa[numMesa - 1]] = (int)opcao - 1;
                            pedidosServico[numMesa - 1, numPedidosMesa[numMesa - 1]] = subOpcao - 1;
                        } // 'if' quantidade
                    } // 'if' subopcao
                    break;
                case Opcoes.Conta:  // Conta e pagamento
                case Opcoes.Pagamento:
                    if (numPedidosMesa[numMesa - 1] < 0)  // mesa sem serviço não tem conta
                        Console.WriteLine($"Mesa {numMesa} não tem serviço iniciado");
                    else
                    {
                        Console.WriteLine("========== Conta ==========");
                        Console.WriteLine($"========== Mesa {numMesa} =========");
                        float total = 0;
                        for (int i = 0; i <= numPedidosMesa[numMesa - 1]; i++)
                        {
                            switch (pedidosMenu[numMesa - 1, i] + 1)
                            {
                                case 1:  // consumo de sopas
                                    Console.WriteLine($"{quantidadeServico[numMesa - 1, i]} {menuSopas[pedidosServico[numMesa - 1, i]],-20} {precosSopas[pedidosServico[numMesa - 1, i]]:0.00}€");
                                    total += quantidadeServico[numMesa - 1, i] * precosSopas[pedidosServico[numMesa - 1, i]];
                                    break;
                                case 2:  // consumo de pratos
                                    Console.WriteLine($"{quantidadeServico[numMesa - 1, i]} {menuPratos[pedidosServico[numMesa - 1, i]],-20} {precosPratos[pedidosServico[numMesa - 1, i]]:0.00}€");
                                    total += quantidadeServico[numMesa - 1, i] * precosPratos[pedidosServico[numMesa - 1, i]];
                                    break;
                                case 3:  // consumo de sobremesas
                                    Console.WriteLine($"{quantidadeServico[numMesa - 1, i]} {menuSobremesas[pedidosServico[numMesa - 1, i]],-20} {precosSobremesas[pedidosServico[numMesa - 1, i]]:0.00}€");
                                    total += quantidadeServico[numMesa - 1, i] * precosSobremesas[pedidosServico[numMesa - 1, i]];
                                    break;
                                case 4:  // consumo de bebidas
                                    Console.WriteLine($"{quantidadeServico[numMesa - 1, i]} {menuBebidas[pedidosServico[numMesa - 1, i]],-20} {precosBebidas[pedidosServico[numMesa - 1, i]]:0.00}€");
                                    total += quantidadeServico[numMesa - 1, i] * precosBebidas[pedidosServico[numMesa - 1, i]];
                                    break;
                                default:
                                    break;
                            }  // Consulta o valor a pagar nma determinada mesa em qualquer momento 
                        }  // 'for' de Conta e Pagamento
                        Console.WriteLine($"Valor a pagar: {total:0.00}€");
                        if ((int)opcao == 6)  // pagamento
                        {
                            Console.Write("O cliente merece desconto (s/n)? ");
                            string cliBom = Console.ReadLine();
                            if (cliBom == "s")
                            {
                                total *= 0.9f;   // aplica desconto de 10%
                            }
                            Console.WriteLine($"Valor a pagar: {total:0.00}€");
                            // limpar a mesa - o contador de pedidos é anulado e não é necessário limpar 'arrays'
                            numPedidosMesa[numMesa - 1] = -1;
                        } // if pagamento
                    }
                    break;
                default:
                    Console.WriteLine("Opção errada!");
                    break;
            } // switch menu
        } // while
    }
}