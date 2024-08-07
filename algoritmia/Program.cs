namespace Algoritmia
{
    internal class Program
    {
//        static void Main(string[] args)
//        {
//        Console.WriteLine("Hello, World!");
        static void Espera(string msg)
        {
            char letra;
            Console.WriteLine(msg + ": ");
            letra = Console.ReadKey().KeyChar;
        }  // Espera

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  a - Paridade de um número");
            Console.WriteLine("  b - Somar valores");
            Console.WriteLine("  c - Fatorial de um número");
            Console.WriteLine("  d - Tabuada");
            Console.WriteLine("  e - Maior valor");
            Console.WriteLine("  f - Laranjas em saldo");
            Console.WriteLine("  g - Peso ideal");
            Console.WriteLine("  h - Equipa vencedora");
            Console.WriteLine("  i - Requerer reforma");
            Console.WriteLine("  j - O triângulo");
            Console.WriteLine("  k - Fatorial recursivo");
            Console.WriteLine("  s - Sair do programa");
        }  // Menu

        static int EscolheOpcao(string legenda)
        {
            char letra;
            int codLetra = 115;
            Console.WriteLine();
            while (codLetra < 0 || codLetra > 13)
            {
                Console.Write(legenda + ": ");
                // letra = Console.ReadLine();
                letra = Console.ReadKey().KeyChar;
                codLetra = (int)letra;
                if (codLetra > 65 && codLetra < 91)
                    codLetra -= 64;
                else if (codLetra > 96 && codLetra < 123)
                {
                    if (codLetra == 115)
                        codLetra = 0;
                    else codLetra -= 96;
                }
            }
            Console.WriteLine();
            return codLetra;
        }  // EscolheOpcao

        static void Paridade()
        {     // opçao a
            int numero;
            numero = 0;
            Console.Write("Escreva um número: ");
            numero = Convert.ToInt32(Console.ReadLine());
            if (numero == 0)
                Console.WriteLine("O número é zero");
            else if (numero % 2 == 0)
                Console.WriteLine("O número " + numero + " é par.");
            else
                Console.WriteLine("O número " + numero + " é ímpar.");
            Espera("Tecle para continuar");
        }  // Paridade

        static void SomarValores()
        {  // opcao b
            double valor, total = 0;
            int contador = 1;
            bool continuar = true;
            while (continuar)
            {
                Console.Write("Valor " + contador++ + ": ");
                valor = Convert.ToDouble(Console.ReadLine());
                total += valor;
                continuar = !(valor == 0);
            }
            contador -= 2;
            if (contador > 0)
            {
                Console.WriteLine("Total de " + contador + " valores igual a " + total);
                Console.WriteLine("Média igual a " + total / contador);
            }
            Espera("Tecle para continuar");
        }   // somarValores

        static void FatorialSimples()
        {
            double resultado = 1; // fatorial de 0 ou 1 é 1
            int num, contador, limite = 100;
            Console.Write("Número para calcular fatorial (0 a " + limite + "): ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num >= 0 && num <= limite)
            {
                contador = num;
                while (contador > 1)
                    resultado *= contador--;
                Console.WriteLine("O fatorial de " + num + " é " + resultado);
            }
            else
                Console.WriteLine("Número inválido");
            Espera("Tecle para continuar");
        }   // FatorialSimples

        static void Tabuada()
        {
            double resultado, operador, operando = 1;
            // int operadori, operandoi;
            Console.Write("Número operando (1 a 10) ");
            operando = Convert.ToDouble(Console.ReadLine());
            int operacao = 120;
            char operaChar = 'x';
            Console.Write("Operação ( X, +, -, /, %) ");
            operaChar = Console.ReadKey().KeyChar;
            Console.WriteLine();
            operacao = (int)operaChar;
            for (operador = 1; operador < 11; operador++)
            {
                switch (operacao)
                {
                    case 120:
                        resultado = operando * operador;
                        break;
                    case 43:
                        resultado = operando + operador;
                        break;
                    case 45:
                        resultado = operando - operador;
                        break;
                    case 47:
                        resultado = operando / operador;
                        break;
                    case 37:
                        // operandoi = (int) operando;
                        // operadori = (int) operador;
                        // resultado = operandoi % operadori;
                        resultado = (int)operando % (int)operador;
                        break;
                    default:
                        resultado = 0;
                        break;
                }
                Console.WriteLine(" " + operando + " " + operaChar + " " + operador + " = " + resultado);
            }
            Espera("Tecle para continuar");
        }      // Tabuada

        static void MaiorValor()
        {
            double valor, maiorVal, menorVal;
            int contador = 1;
            Console.Write("Valor " + contador + ": ");
            valor = Convert.ToDouble(Console.ReadLine());
            maiorVal = menorVal = valor;
            while (valor != 0)
            {
                contador++;
                Console.Write("Valor " + contador + ": ");
                valor = Convert.ToDouble(Console.ReadLine());
                if (valor != 0)
                {
                    if (valor > maiorVal)
                        maiorVal = valor;
                    else if (valor < menorVal)
                        menorVal = valor;
                }
                else
                    contador--;
            }
            if (contador > 1)
            {
                Console.WriteLine("O maior valor é " + maiorVal);
                Console.WriteLine("e o menor valor é " + menorVal);
            }
            else
                Console.WriteLine("Sem valores inseridos");
            Espera("Tecle para continuar");
        }     // MaiorValor

        static void Laranjas()
        {
            int qtLaranjas;
            double aPagar;
            Console.Write("Quantas laranjas quer? ");
            qtLaranjas = Convert.ToInt32(Console.ReadLine());
            if (qtLaranjas > 0)
            {
                if (qtLaranjas < 12)
                    aPagar = qtLaranjas * 0.3;
                else
                    aPagar = qtLaranjas * 0.5;
                Console.WriteLine("O valor a pagar é " + aPagar + "€");
            }
            else
                Console.WriteLine("Volte sempre!");
            Espera("Tecle para continuar");
        }    // Laranjas

        static void PesoIdeal()
        {
            // string nome = "", sexo = "M";
            string nome, sexo;
            double altura, pIdeal;
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            Console.Write("Sexo (M/F): ");
            sexo = Console.ReadLine();
            Console.Write("Altura: ");
            altura = Convert.ToDouble(Console.ReadLine());
            if (altura > 2 && altura < 200)
                altura /= 100;
            if (sexo == "F" || sexo == "f")
                pIdeal = (altura * 62.1) - 44.7;
            else
                pIdeal = (altura * 72.7) - 58;
            Console.WriteLine("O peso ideal de " + nome + " é " + pIdeal);
            Espera("Tecle para continuar");
        }     // PesoIdeal

        static void EquipaVencedora()
        {
            string[] equipa = new string[2];
            int indice;
            int[] pontos = new int[2];
            for (indice = 0; indice < 2; indice++)
            {
                Console.Write("Nome da equipa " + (indice + 1) + ": ");
                equipa[indice] = Console.ReadLine();
                Console.Write("Pontos da equipa " + equipa[indice] + ": ");
                pontos[indice] = Convert.ToInt32(Console.ReadLine());
            }
            if (pontos[0] > pontos[1])
                Console.WriteLine("A equipa vencedora é: " + equipa[0]);
            else if (pontos[0] < pontos[1])
                Console.WriteLine("A equipa vencedora é: " + equipa[1]);
            else
                Console.WriteLine("As equipas " + equipa[0] + " e " + equipa[1] + " empataram");
            Espera("Tecle para continuar");
        }       // EquipaVencedora

        static void Reforma()
        {
            string codigoEmpregado;
            int anoNascimento, anoIngresso, anoAtual = 2023, idade, tempoTrabalho;
            Console.Write("Código do empregado: ");
            codigoEmpregado = Console.ReadLine();
            Console.Write("Ano de nascimento do empregado: ");
            anoNascimento = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ano de entrada na empresa: ");
            anoIngresso = Convert.ToInt32(Console.ReadLine());
            idade = anoAtual - anoNascimento;
            tempoTrabalho = anoAtual - anoIngresso;
            if (idade >= 65 || tempoTrabalho >= 30)
                Console.WriteLine("Requerer aposentadoria");
            else if (idade >= 60 && tempoTrabalho >= 25)
                Console.WriteLine("Requerer aposentadoria");
            else
                Console.WriteLine("Não requerer");
            Espera("Tecle para continuar");
        }      // Reforma

        static void Triangulo()
        {
            double[] lados = new double[3];
            bool sair, certo;
            int indice = 0;
            sair = certo = false;
            while (!certo)
            {  // valida o triângulo e termina o procedimento com valor 0 na entrada
                Console.Write("Lado " + (indice + 1) + " do triângulo: ");
                lados[indice] = Convert.ToDouble(Console.ReadLine());
                if (lados[indice] > 0)
                    if (indice < 2)
                        indice++;
                    else if (lados[0] >= lados[1] + lados[2] || lados[1] >= lados[0] + lados[2] || lados[2] >= lados[0] + lados[1])
                    {
                        Console.WriteLine("Erro nos dados");
                        Console.WriteLine("Não é um triângulo. Repita.");
                        indice = 0;
                    }
                    else
                        certo = true;
                else
                {
                    sair = true;
                    certo = true;
                }
            }
            if (sair)
                Console.WriteLine("Xau");
            else if (lados[0] == lados[1] && lados[0] == lados[2] && lados[1] == lados[2])
                Console.WriteLine("O triângulo é equilátero");
            else if (lados[0] != lados[1] && lados[0] != lados[2] && lados[1] != lados[2])
                Console.WriteLine("O triângulo é escaleno");
            else
                Console.WriteLine("O triângulo é isósceles");
            Espera("Tecle para continuar");
        }      // Triangulo
        static double Fatorial(int num)
        {
            if (num < 2)
                return 1;
            else
                return num * Fatorial(--num);
        }     // Fatorial

        static void FatorialRecursivo()
        {   // opção K
            double resultado = 1; // fatorial de 0 ou 1 é 1
            int num, limite = 100;
            Console.Write("Número para calcular fatorial (0 a " + limite + "): ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num >= 0 && num <= limite)
            {
                resultado = Fatorial(num);
                Console.WriteLine("O fatorial de " + num + " é " + resultado);
            }
            else
                Console.WriteLine("Número inválido");
            Espera("Tecle para continuar");
        }  // FatorialRecursivo

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // int x = 10;
            // Console.WriteLine("x " + Convert.ToString(x) + " x");
            int opcao = 1;
            while (opcao != 0)
            {
                Program.Menu();
                opcao = EscolheOpcao("Digite a opção");
                Console.WriteLine(opcao);
                // opcao = 0;
                switch (opcao)
                {
                    case 0:          // opção S
                        Console.WriteLine("---  Xau  ---");
                        break;
                    case 1:          // opção A
                                        // somaNumeros();
                        Paridade();
                        break;
                    case 2:          // opção B
                        SomarValores();
                        break;
                    case 3:          // opção C
                        FatorialSimples();
                        break;
                    case 4:          // opção D
                        Tabuada();
                        break;
                    case 5:          // opção E
                        MaiorValor();
                        break;
                    case 6:          // opção F
                        Laranjas();
                        break;
                    case 7:          // opção G
                        PesoIdeal();
                        break;
                    case 8:          // opção H
                        EquipaVencedora();
                        break;
                    case 9:          // opção I
                        Reforma();
                        break;
                    case 10:          // opção J
                        Triangulo();
                        break;
                    case 11:          // opção K
                        FatorialRecursivo();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }

    
    }
}