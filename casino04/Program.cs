/******************************************************************************
António Marcelo Marques
IEFP-PI04 Programação em C#

Tarefa 3 - Casino - v4 - Jogador tenta adivinhar número (1-6) apostando 1€ 
Exercício usando aleatórios, ciclos e 'if'
Só corre no Visual Studio
A interação do utilizador não está a ser validada, pelo que podem acontecer coisas terríveis
*******************************************************************************/
using System;

public class Casino
{
    // parâmetros de configuração do Casino
    const double reservaCasino = 1_000d;  // capital inicial do casino para pagar prémios
    const double fatorPremio = 5;   // se acertar o jogador recebe o que apostou multiplicado por este fator 
    const double reservaJogador = 10d; // capital inicial do jogador ao entrar em jogo
    const int maxJogadas = 10;          // número máximo de apostas por jogo
    const int minSorte = 1, maxSorte = 6;   // define o intervalo de números em jogo: 1 a 6 neste caso 
    const double minValorAposta = 1d, maxValorAposta = 5d;  // define o intervalo de valores de cada aposta - o maxValorAposta ainda não está a ser usado porque ã aposta é fixa
    static int[,] leds = {     // array bidimensional a definir o grafismo dos algarismos do dado
            { 19, 1, 2, 3, 0, 4, 0, 3, 4, 0, 2, 4, 0, 1, 4, 0, 4, 1, 2, 3 },   // 0 [20, 20] [desenho,carater]
            { 19, 1, 1, 1, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7, 7, 7 },
            { 12, 2, 1, 2, 2, 2, 2, 2, 0, 1, 2, 3, 4, 0, 0, 0, 0, 0, 0, 0 },   // 1
            { 12, 1, 2, 2, 3, 4, 5, 6, 7, 7, 7, 7, 7, 0, 0, 0, 0, 0, 0, 0 },
            { 14, 1, 2, 3, 0, 4, 4, 3, 2, 1, 0, 1, 2, 3, 4, 0, 0, 0, 0, 0 },   // 2
            { 14, 1, 1, 1, 2, 2, 3, 4, 5, 6, 7, 7, 7, 7, 7, 0, 0, 0, 0, 0 },
            { 14, 0, 1, 2, 3, 4, 3, 2, 3, 4, 0, 4, 1, 2, 3, 0, 0, 0, 0, 0 },   // 3
            { 14, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 6, 7, 7, 7, 0, 0, 0, 0, 0 },
            { 14, 3, 2, 3, 1, 3, 0, 3, 0, 1, 2, 3, 4, 3, 3, 0, 0, 0, 0, 0 },   // 4
            { 14, 1, 2, 2, 3, 3, 4, 4, 5, 5, 5, 5, 5, 6, 7, 0, 0, 0, 0, 0 },
            { 17, 0, 1, 2, 3, 4, 0, 0, 1, 2, 3, 4, 4, 4, 0, 1, 2, 3, 0, 0 },   // 5
            { 17, 1, 1, 1, 1, 1, 2, 3, 3, 3, 3, 4, 5, 6, 7, 7, 7, 7, 0, 0 },
            { 15, 2, 3, 1, 0, 0, 1, 2, 3, 0, 4, 0, 4, 1, 2, 3, 0, 0, 0, 0 },   // 6
            { 15, 1, 1, 2, 3, 4, 4, 4, 4, 5, 5, 6, 6, 7, 7, 7, 0, 0, 0, 0 },
            { 11, 0, 1, 2, 3, 4, 4, 3, 2, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },   // 7
            { 11, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 17, 1, 2, 3, 0, 4, 0, 4, 1, 2, 3, 0, 4, 0, 4, 1, 2, 3, 0, 0 },   // 8
            { 17, 1, 1, 1, 2, 2, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 7, 7, 0, 0 },
            { 15, 1, 2, 3, 0, 4, 0, 4, 1, 2, 3, 4, 4, 3, 1, 2, 0, 0, 0, 0 },   // 9
            { 15, 1, 1, 1, 2, 2, 3, 3, 4, 4, 4, 4, 5, 6, 7, 7, 0, 0, 0, 0 }
        };
    static Random rnd = new Random();  // inicia o objeto gerador de aleatórios

    static int mostraNumero(int min, int max)  // função que gera e mostra o número sorteado
    {
        int num = 0, rotacoes = 80;  // num vai conter o número sorteado que a função devolve; rotacoes são as voltas do dado
        int linha = 6, coluna = 85;  // canto superior esquerdo do painel que mostra o número. Podem passar a parâmetros da função
        // desenha o quadro da saída do número
        Console.BackgroundColor = ConsoleColor.Yellow;   // cor do quadro
        Console.SetCursorPosition(coluna - 4, linha - 2);   // método da Consola para posicionar o cursor de escrita
        Console.Write("             ");                 // topo do painel
        for (int i = 1; i < 12; i++)                    // lados do painel
        {
            Console.SetCursorPosition(coluna - 4, linha - 2 + i);
            Console.Write(" ");
            Console.SetCursorPosition(coluna - 4 + 12, linha - 2 + i);
            Console.Write(" ");
        }
        Console.SetCursorPosition(coluna - 4, linha - 2 + 12);   // base do painel
        Console.Write("             ");
        // Lança o dado
        for (int j = 0; j <= rotacoes; j++)   // controla o número de rotações do dado
        {
            num = rnd.Next(min, max);         // gera número aleatório
            int cont = leds[num * 2, 0];
            Console.BackgroundColor = j == rotacoes ? ConsoleColor.Red : ConsoleColor.White;  // o último número é vermelho
            for (int i = 1; i <= cont; i++)     // desenha o número aleatório saído
            {
                Console.SetCursorPosition(coluna + leds[num * 2, i], linha + leds[num * 2 + 1, i]);
                Console.Write(" ");
            }
            Thread.Sleep(10 + j * j / 50);       // pausa quadrática crescente para 'animação'
            Console.BackgroundColor = ConsoleColor.Black;  // muda cor de fundo para 'apagar'
            if (j < rotacoes)    // apaga todos os números menos o último
            {
                for (int i = 1; i <= cont; i++)   // apaga número escrito antes
                {
                    Console.SetCursorPosition(coluna + leds[num * 2, i], linha + leds[num * 2 + 1, i]);
                    Console.Write(" ");
                }
            }
            Thread.Sleep(10);    // pequena pausa para se perceber que o número é renovado
        }
        return num;  // retorna o número sorteado
    }


    public static void Main()
    {
        bool continuar = true;    // controla o ciclo while e o fim do jogo
        int numJogada = 0;        // identifica a atual jogada
        int numSorte = 0;         // guarda o número aleatório sorteado ()
        double carteiraCasino = reservaCasino;
        double carteiraJogador = reservaJogador; // coloca na carteira do jogador o valor inicial
        int escolhaJogador = 0;   // guarda o número escolhido pelo jogador para a jogada atual
        double apostaJogador = minValorAposta; // guarda o valor da aposta do jogador em cada jogada

        Console.WriteLine("================ Casino Hello World =================");  // 

        while (continuar)
        {  // se não houver outra razão acaba em maxJogadas
            numJogada++;
            // Console.Clear();    // limpa a consola - não funciona em alguns compiladores online (aliás, só o vi funcionar no 'onlinegdb.com')
            Console.SetCursorPosition(3, 2);    // Este método da Consola define a posição de escrita do próximo 'Write'
            Console.WriteLine("Jogada número " + numJogada); // Mostra a jogada atual
            Console.SetCursorPosition(3, 4);
            Console.Write("Tem " + carteiraJogador + " euros. Em que número aposta de " + minSorte + " a " + maxSorte + ": ");
            escolhaJogador = int.Parse(Console.ReadLine());
            numSorte = mostraNumero(minSorte, maxSorte);   // Lançamento do dado
            Console.SetCursorPosition(6, 6); // coluna, linha
            Console.WriteLine("Saiu o número " + numSorte);
            if (numSorte == escolhaJogador)
            {       // verifica se o jogador acertou
                double premio = apostaJogador * fatorPremio - apostaJogador;  // calcula o prémio 
                carteiraCasino -= premio;     // retira do casino o dinheiro do prémio 
                carteiraJogador += premio;    // coloca o prémio na carteira do jogador
                Console.SetCursorPosition(3, 8);
                Console.WriteLine("Parabéns, ganhou esta jogada. O seu saldo passou a " + carteiraJogador + " euros");
            }
            else    // se não ganhou é porque perdeu ...
            {
                carteiraJogador -= apostaJogador; // retira o valor da aposta da carteira do jogador
                carteiraCasino += apostaJogador; // coloca o valor da aposta na carteira do casino
                Console.SetCursorPosition(3, 8);
                Console.Write("Perdeu nesta jogada. O seu saldo passou a " + carteiraJogador);
                Console.WriteLine(carteiraJogador == 1 ? " euro\n\n" : " euros\n\n");
            }
            if (carteiraJogador < minValorAposta)
            {
                Console.SetCursorPosition(3, 10);
                Console.WriteLine("O seu crédito esgotou. Volte quando tiver mais dinheiro :P");
                Console.SetCursorPosition(3, 12);
                Console.WriteLine("O casino Hello World agradece.");
                continuar = false;
            }
            else if (numJogada < maxJogadas)
            {
                Console.SetCursorPosition(3, 10);
                Console.Write("Quer continuar a jogar? (s/n): ");
                string opcao = Console.ReadLine();
                if (opcao == "n")
                {
                    Console.WriteLine("\nEntão até uma próxima.");
                    continuar = false;
                }
                else
                {
                    for (int i = 0; i < 16; i++)   // apagador
                    {
                        Console.SetCursorPosition(3, 4 + i);
                        Console.WriteLine("                                                           ");
                    }
                }
            }
            else  // acabaram as jogadas previstas (maxJogadas)
            {
                continuar = false;
                Console.SetCursorPosition(3, 10);
                Console.WriteLine("O jogo chegou ao fim.");
                Console.SetCursorPosition(3, 11);
                Console.WriteLine("Lamentamos que ainda tenha dinheiro na carteira...");
            }
        }
        Console.SetCursorPosition(3, 14);
        double ganho = carteiraCasino - reservaCasino;

        if (ganho == 0)
        {
            Console.WriteLine("O saldo do casino manteve-se em " + carteiraCasino);
        }
        else if (ganho > 0)
        {
            Console.WriteLine("O saldo do casino é agora de " + carteiraCasino);
            Console.SetCursorPosition(3, 15);
            Console.Write("\nGraças ao seu esforço a nossa reserva subiu " + ganho);
            Console.WriteLine(ganho == 1 ? " euro\n\n" : " euros\n\n");
        }
        else
        {
            Console.WriteLine("O saldo do casino é agora de " + carteiraCasino);
            Console.SetCursorPosition(3, 15);
            Console.Write("\nGraças ao seu esforço a nossa reserva baixou " + (-ganho));
            Console.WriteLine(ganho == -1 ? " euro\n\n" : " euros\n\n");
        }
    }
}
