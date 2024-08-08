/******************************************************************************
António Marcelo Marques
IEFP-PI04 Programação em C#

Tarefa 3 - Casino - v3 -Jogadores tentam adivinhar número (0-5) apostando 1€ 
Exercício usando aleatórios, ciclos e 'if'
*******************************************************************************/
using System;

namespace Casino03
{
    internal class Casino
    {
        // o casino acumula tudo o que não for para prémio e pode falir se muita gente acertar
        // cada aposta por jogador é de 1€ e o prémio é cinco vezes a aposta
        // como o jogo é anónimo os jogadores só são conhecidos pelo número de entrada (posição no array + 1)
        const int qtJogadores = 10;    // número de jogadores a tentar a sorte na jornada de jogo
        const int maxJogadas = 100;    // jogadas por jornada
        const double minAposta = 1;    // valor mínimo (e máximo por enquanto) para cada aposta
                                       // É curioso que se a proporção do prémio for maior que 5 o casino começa a perder dinheiro...
        const double proporcaoPremio = 5;  // por sugestão do problema é 5 * minAposta 
        static double saldoCasino = 1000;     // reserva inicial do casino para pagamento de prémios
        static double saldoInicialJogador = 10;  // 10 € por sugestão do problema
        static double[] saldoJogador = new double[qtJogadores];  // guarda o valor da carteira de cada jogador
        static int[] apostaJogador = new int[qtJogadores];     // guarda o número aposta do jogador em cada jogada

        static Random rnd = new Random();  // cria um objeto de class Random

        static void painel()
        {
            Console.WriteLine("\n===========     Casino     ===========");
            Console.WriteLine("\n  Jogada:          Número da Sorte: ");
            Console.WriteLine("\n\n    Jogador    Aposta      Saldo");
            for (int i = 0; i < qtJogadores; i++)
            {
                Console.WriteLine($"       {i + 1,2}");
            }
            Console.SetCursorPosition(6, 19); // coluna, linha
            Console.Write("Saldo do Casino:");
        }

        static void Main()
        {
            // atribui saldo inicial a todos os jogadores
            for (int i = 0; i < qtJogadores; i++) saldoJogador[i] = saldoInicialJogador;

            int numJogada = 0;        // contador de jogadas 
            bool continuar = true;    // pode fechar a porta do Casino
            double valorTotalApostas;  // acumula o valor apostado pelos jogadores em cada jogada
            double valorTotalPremio;   // acumula o valor pago pelo Casino em cada jogada
            int valorSorte;            // valor do dado lançado na mesa
            int jogadoresEmJogo;       // subtrai ao total de jogadores os que faliram e já não jogam (sairam da mesa)

            painel();

            while (numJogada++ < maxJogadas && continuar)
            {
                valorTotalApostas = valorTotalPremio = 0;
                jogadoresEmJogo = qtJogadores;
                // Jogadores escolhem números e apostam
                for (int i = 0; i < qtJogadores; i++)  // atribui saldo inicial a todos os jogadores
                {
                    if (saldoJogador[i] >= minAposta)   // só apostam jogadores que tenham saldo (não há fiado)
                    {
                        valorTotalApostas += minAposta;    // acumula valor da aposta para o casino
                        apostaJogador[i] = rnd.Next(6);    // jogador escolhe
                        saldoJogador[i] -= minAposta;      // subtrai saldo do jogador que aposta
                        Console.SetCursorPosition(18, i + 7);
                        Console.Write($"{apostaJogador[i]:0}         {saldoJogador[i],2}");
                    }
                    else
                    {
                        apostaJogador[i] = -1;     // jogador falido não aposta
                        jogadoresEmJogo--;         // acumula jogadores falidos
                        Console.SetCursorPosition(18, i + 7);
                        Console.Write($"          {saldoJogador[i],2}");
                    }
                }
                // para teste -> Console.WriteLine("Jogadores em jogo na jogada " + numJogada + " : " + jogadoresEmJogo);
                if (jogadoresEmJogo > 0)
                { // o jogo só continua se houver jogadores em jogo
                  // Lançamento do dado
                    valorSorte = rnd.Next(6);    // O número da sorte
                    Console.SetCursorPosition(10, 3);
                    Console.Write(numJogada);
                    Console.SetCursorPosition(36, 3);
                    Console.Write(valorSorte);

                    // Verificação dos premiados
                    for (int i = 0; i < qtJogadores; i++)
                    {
                        if (apostaJogador[i] == valorSorte)   // este jogador ganhou
                        {
                            valorTotalPremio += proporcaoPremio * minAposta;  // acumula despesa do casino na jogada
                            saldoJogador[i] += proporcaoPremio * minAposta;
                            //Console.SetCursorPosition(5, 2);
                            //Console.Write("");
                            // Console.Write("Jogada " + numJogada + " O jogador " + (i + 1) + " Acertou!!! ");
                            // Console.WriteLine(" e ficou com " + saldoJogador[i]);
                        }
                    }
                    saldoCasino += (valorTotalApostas - valorTotalPremio);
                }
                else
                {
                    Console.SetCursorPosition(10, 18);
                    Console.WriteLine("O jogo terminou. Vitória do Casino.");
                    continuar = false;
                }
                if (saldoCasino < 0)
                {
                    Console.SetCursorPosition(3, 18); // coluna, linha
                    Console.WriteLine("O Casino faliu...");
                    continuar = false;
                }
                Console.SetCursorPosition(23, 19); // coluna, linha
                Console.Write(saldoCasino + "€\n\n\n");
                Thread.Sleep(100);
            }

            //for (int i = 0; i < qtJogadores; ++i)
            //{
            //    Console.WriteLine("Saldo final do jogador " + (i + 1) + " " + saldoJogador[i] + "€");
            //}
        }
    }

}