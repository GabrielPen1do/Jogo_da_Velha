using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_da_Velha
{
    internal class Program
    {

        static bool VerificarVitoria(char[,] tabuleiro, char jogador)
        {
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                if (tabuleiro[i, 0] == jogador && tabuleiro[i, 1] == jogador && tabuleiro[i, 2] == jogador)
                {
                    return true;
                }
            }

            for (int j = 0; j < tabuleiro.GetLength(0); j++)
            {
                if (tabuleiro[0, j] == jogador && tabuleiro[1, j] == jogador && tabuleiro[2, j] == jogador)
                {
                    return true;
                }
            }

            if (tabuleiro[0, 0] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 2] == jogador)
            {
                return true;
            }

            if (tabuleiro[0, 2] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 0] == jogador)
            {
                return true;
            }

            return false;
        }


        static void ImprimirTabuleiro(char[,] tabuleiro)
        {
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    Console.Write($"[{tabuleiro[i, j]}] ");
                }
                Console.WriteLine();
            }
        }
        static void InicializarTabuleiro(char[,] tabuleiro)
        {
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {

                    tabuleiro[i, j] = '*';
                    Console.Write($"[{tabuleiro[i, j]}]" + " ");

                }
                Console.WriteLine();
            }
        }

        static void Jogada(char[,] tabuleiro, char jogador)
        {

            int linha, coluna;

            Console.WriteLine("Jogador 1");

            do
            {
                Console.WriteLine("Insira a linha que você deseja preencher");
                linha = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("Insira a coluna que você deseja preencher");
                coluna = int.Parse(Console.ReadLine()) - 1;

            } while (tabuleiro[linha, coluna] != '*');

            tabuleiro[linha, coluna] = jogador;

        }



        static void Main(string[] args)
        {

            int linhas = 3, colunas = 3;
            char jogador1 = 'X';
            char jogador2 = 'O';
            bool acabou = false;
            int rodadas = 1;
            char[,] tabuleiro = new char[linhas, colunas];

            InicializarTabuleiro(tabuleiro);

            do
            {
                Jogada(tabuleiro, jogador1);
                ImprimirTabuleiro(tabuleiro);
                if (VerificarVitoria(tabuleiro, jogador1))
                {
                    Console.WriteLine($"O jogador {jogador1} venceu");
                    acabou = true;
                }
                else
                {
                    rodadas++;

                    if (rodadas == 10)
                    {
                        Console.WriteLine("O jogo terminou empatado");
                        acabou = true;
                    }
                    else
                    {
                        Jogada(tabuleiro, jogador2);
                        ImprimirTabuleiro(tabuleiro);
                        if (VerificarVitoria(tabuleiro, jogador2))
                        {
                            Console.WriteLine($"O jogador {jogador2} venceu");
                            acabou = true;
                        }

                        rodadas++;
                    }
                }

            } while (!acabou);

            Console.ReadKey();
        }
    }
}
