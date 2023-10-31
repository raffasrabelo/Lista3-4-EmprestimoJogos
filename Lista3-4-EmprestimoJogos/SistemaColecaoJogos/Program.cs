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
        public DateTime data;
        public string nomePessoa;
        public char emprestado;

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
        novoJogo.emprestimo.emprestado = 'N';
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
                if (jogo.emprestimo.emprestado == 'N')
                {
                    Console.WriteLine("Emprestado: N");
                }
                else
                {
                    Console.WriteLine("Emprestado: S");
                }
            }
        }
        Console.ReadLine();
        Console.Clear();
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
                    if (jogo.emprestimo.emprestado == 'N')
                    {
                        Console.WriteLine("Emprestado: N");
                    }
                    else if (jogo.emprestimo.emprestado == 'S')
                    {
                        Console.WriteLine("Emprestado: S");
                    }
                Console.WriteLine("---------------------");
            }
        }
        Console.ReadLine();
        Console.Clear();
    }

    static void emprestarJogo(List<Jogos> lista, string nomeJogo)
    {
        int qtd = lista.Count();
        string pessoa;
        for (int i = 0; i < qtd; i++)
        {

            if (lista[i].titulo.ToUpper().Equals(nomeJogo.ToUpper()))
            {
                if (lista[i].emprestimo.emprestado == 'S')
                {
                    Console.WriteLine("O Jogo já está emprestado!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Digite o nome da pessoa que está pegando o jogo emprestado: ");
                    pessoa = Console.ReadLine();
                    Jogos jogoAtualizado = lista[i];
                    jogoAtualizado.emprestimo.data = DateTime.Now;
                    jogoAtualizado.emprestimo.emprestado = 'S';
                    jogoAtualizado.emprestimo.nomePessoa = pessoa;
                    lista[i] = jogoAtualizado;
                }
            }
        }
    }

    static void devolverJogo(List<Jogos> lista, string titulo)
    {
        int qtd= lista.Count();

        for(int i = 0; i < qtd; i++)
        {
            if (lista[i].titulo.ToUpper() == titulo.ToUpper())
            {
                if (lista[i].emprestimo.emprestado == 'N')
                {
                    Console.WriteLine("O Jogo não está emprestado!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Jogos jogoAtualizado = lista[i];
                    jogoAtualizado.emprestimo.data = DateTime.MinValue;
                    jogoAtualizado.emprestimo.nomePessoa = "";
                    jogoAtualizado.emprestimo.emprestado = 'N';
                    lista[i] = jogoAtualizado;
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }

    static void jogosEmprestados(List<Jogos> lista)
    {
        int qtd= lista.Count();
        for(int i = 0; i < qtd;)
        {
            if (lista[i].emprestimo.emprestado == 'S')
            {
                Console.WriteLine($"Título: {lista[i].titulo}");
                Console.WriteLine($"Console: {lista[i].console}");
                Console.WriteLine($"Ano: {lista[i].ano}");
                Console.WriteLine($"Ranking: {lista[i].ranking}");
                Console.WriteLine($"Este jogo está emprestado para {lista[i].emprestimo.nomePessoa}");
                Console.WriteLine("------------------------------------");
            }
        }
        Console.ReadLine();
    }
    static int menu()
    {
        Console.WriteLine("1-Cadastrar jogo");
        Console.WriteLine("2-Busca pelo título");
        Console.WriteLine("3-Listar todos os jogos por console");
        Console.WriteLine("4-Empréstimo jogo");
        Console.WriteLine("5-Devolução de jogo");
        Console.WriteLine("0-Sair");
        int opc= Convert.ToInt32(Console.ReadLine());
        return opc;
    }

    static void salvarDados(List<Jogos> lista, string nomeArquivo)
    {

        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            foreach (Jogos jogo in lista)
            {
                writer.WriteLine($"{jogo.titulo},{jogo.console},{jogo.ano},{jogo.ranking},{jogo.emprestimo.data},{jogo.emprestimo.nomePessoa},{jogo.emprestimo.emprestado}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");


    }

    static void carregarDados(List<Jogos> lista, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                Jogos jogo = new Jogos
                {
                    titulo = campos[0],
                    console = campos[1],
                    ano = int.Parse(campos[2]),
                    ranking = int.Parse(campos[3]),
                    emprestimo =
                    new Emprestimo
                    {
                        data = DateTime.Parse(campos[4]),
                        nomePessoa = campos[5],
                        emprestado = char.Parse(campos[6])
                    }

                };
                lista.Add(jogo);
            }
            Console.WriteLine("Dados carregados com sucesso!");
            
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }
    static void Main()
    {
        List<Jogos>listaJogos = new List<Jogos>();
        int op;
        carregarDados(listaJogos, "dadosJogos.txt");
        do
        {
            op = menu();
            switch (op)
            {
                case 1:
                    addJogos(listaJogos);
                    break;
                case 2:
                    Console.WriteLine("Digite o nome do jogo:");
                    string nomeJogo = Console.ReadLine();
                    Console.ReadLine();
                    Console.Clear();
                    buscaPorTitulo(listaJogos, nomeJogo);
                    break;

                case 3:
                    Console.WriteLine("Digite o nome do console:");
                    string console = Console.ReadLine();
                    listarPorConsole(listaJogos, console);
                    break;
                case 4:
                    Console.WriteLine("Digite o nome do jogo:");
                    nomeJogo = Console.ReadLine();
                    emprestarJogo(listaJogos, nomeJogo);
                    break;
                case 5:
                    Console.WriteLine("Digite o nome do jogo:");
                    nomeJogo = Console.ReadLine();
                    devolverJogo(listaJogos, nomeJogo);
                    break;
                case 6:
                    jogosEmprestados(listaJogos);
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    salvarDados(listaJogos, "dadosJogos.txt");
                    break;

            }
        } while (op != 0);

    }
}

