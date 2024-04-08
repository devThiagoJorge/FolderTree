using EmuladorDeDisco.Classes;

Console.WriteLine("Escolha o diretório raiz!");
//string caminho = Console.ReadLine()!;

string caminho = @"C:\dev\FolderTree\EmuladorDeDisco\TesteSistema";
var nomePasta = caminho.Split("\\").Last();
var pasta = new Pasta(caminho, nomePasta);

MenuSistema();
int escolha = int.Parse(Console.ReadLine()!);


do
{
    switch (escolha)
    {
        case 1:
            pasta.MontarArvoreDePastas();
            escolha = -1;
            break;
        case 2:
            break;
        case 3:
            //Console.WriteLine("Informe o último nível da pasta, onde será criado");
            //string ultimoNivel = Console.ReadLine()!;

            Console.WriteLine("Informe o nome da nova pasta");
            string novaPasta = Console.ReadLine()!;
            pasta.CriarPasta(novaPasta);
            Console.WriteLine("\nInforme o conteúdo do arquivo.");
            string conteudo = Console.ReadLine()!;
            var arquivo = new Arquivo("", conteudo);
            arquivo.ManipularArquivo(pasta, novaPasta);
            escolha = -1;
            break;
        default:
            MenuSistema();
            escolha = int.Parse(Console.ReadLine()!);
            break;

    }
} while (escolha != 0);




static void MenuSistema()
{
    Console.WriteLine("----------------------------------- Menu -----------------------------------");
    Console.WriteLine(@"
*** Escolha uma opção do sistema, digite os comandos: ***
1 - Listar todos os diretórios 
3 - Adicionar um novo arquivo (irá adicionar uma nova pasta para o arquivo)
0 - P/ sair do sistema");
}