using System;

namespace Cadastro_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

                Console.WriteLine("Obrigado por utilizar nossos serviços.");
                Console.WriteLine();
            }
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Difite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine("Tem certeza que deseja excluir a série: ");
            Console.WriteLine(serie + "?");
            Console.WriteLine("Digite 1 para confirmar ou 2 para cancelar: ");
            int opcao = int.Parse(Console.ReadLine());

            if(opcao == 1){
                repositorio.Exclui(indiceSerie);
            }
            else{
                Console.WriteLine("Operacao de exclusão cancelada pelo Usuário!");
            }
            
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Serie atualizaSerie = PegarInfoSerie(indiceSerie);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void InserirSerie()
        {
           Serie novaSerie = PegarInfoSerie(repositorio.proximoId());   
            
            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if( lista.Count == 0)
            {
                Console.WriteLine("Nenenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Cadastro de Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desajada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        
        private static Serie PegarInfoSerie(int id)
        {
             foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descriçã da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: id,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

            return novaSerie;
        
        }
    }

    
}
