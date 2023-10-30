﻿using System.ComponentModel;

class Program
{
    struct Jogos
    {
        public string titulo;
        public string console;
        public int ano;
        public int ranking;
        public Emprestimo emprestimo;

    }

     struct Emprestimo
    {
        public DateOnly data;
        public string nomePessoa;
        public bool emprestado;

    }

    static void addJogos(List<Jogos>lista)
    {
        Jogos novoJogo = new Jogos();
        Console.WriteLine("Digite o título do jogo: ");
        novoJogo.titulo = Console.ReadLine();
        Console.WriteLine("Digite o console compatível: ");
        novoJogo.console = Console.ReadLine();
        Console.WriteLine("Digite o ano de lançamento: ");
        novoJogo.ano = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite o digite a posição dele no seu ranking pessoal: ");
        novoJogo.ranking = Convert.ToInt32(Console.ReadLine());
        novoJogo.emprestimo.emprestado = false;
        lista.Add(novoJogo);
    }

    static void buscaPorTitulo(List<Jogos>lista, string nome)
    {
        foreach (Jogos jogo in lista)
        {
            if (jogo.titulo.ToUpper().Equals(nome.ToUpper()))
            {
                Console.WriteLine($"Título: {jogo.titulo}");
                Console.WriteLine($"Console: {jogo.console}");
                Console.WriteLine($"Ano: {jogo.ano}");
                Console.WriteLine($"Ranking: {jogo.ranking}");
                if (jogo.emprestimo.emprestado == false)
                {
                    Console.WriteLine("Emprestado: N");
                }
                else
                {
                    Console.WriteLine("Emprestado: S");
                }
            }
        }
    }

    static void listarPorConsole(List<Jogos> lista, string console)
    {
        Console.WriteLine($"***Lista de Jogos do {console}***");
        foreach (Jogos jogo in lista)
        {
            if (jogo.console.ToUpper().Equals(console.ToUpper()))
            {
                    Console.WriteLine($"Título: {jogo.titulo}");
                    Console.WriteLine($"Console: {jogo.console}");
                    Console.WriteLine($"Ano: {jogo.ano}");
                    Console.WriteLine($"Ranking: {jogo.ranking}");
                    if (jogo.emprestimo.emprestado == false)
                    {
                        Console.WriteLine("Emprestado: N");
                    }
                    else
                    {
                        Console.WriteLine("Emprestado: S");
                    }
            }
        }
    }

    static void emprestarJogo(List<Jogos> lista, string nomeJogo)
    {
        Console.WriteLine("Digite o nome da pessoa que está pegando o jogo emprestado: "); 
        foreach (Jogos jogo in lista) 
        {
            int v = 0;

            if (jogo.titulo.ToUpper().Equals(nomeJogo.ToUpper()) && (v ==0)){
                lista.emprestimo.emprestado = true;
                jogo.emprestimo.nomePessoa = Console.ReadLine();
            }
                
        }
    }

    static void Main()
    {

    }
}

