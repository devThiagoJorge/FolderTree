using EmuladorDeDisco.Classes;
using System.IO;

var particao = Particao.ObterParticao();
string mensagem = "";

MenuSistema();
int escolha = int.Parse(Console.ReadLine()!);

do
{
    switch (escolha)
    {
        case 1:
            Console.WriteLine("\nLista de mensagens salvas:");
            particao.ListarMensagens();
            escolha = -1;
            break;

        case 2:
            Console.WriteLine("Digite a mensagem:");
            mensagem = Console.ReadLine()!;

            if (particao.IndexDisponivelParaSalvar() == -1)
            {
                Console.WriteLine("A particão já foi completamente preenchida.");
                Environment.Exit(0);
            }
            particao.CriarNaParticao(mensagem);
            escolha = -1;
            break;

        case 3:
            Console.WriteLine("Mensagem para apagar:");
            mensagem = Console.ReadLine()!;

            var existeMensagem = particao.ExisteMensagem(mensagem);

            if (existeMensagem)
            {
                particao.ApagarMensagem(mensagem);
            }

            Console.WriteLine($"Mensagem: {mensagem} não existe");
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
    Console.WriteLine("\n\n----------------------------------- Menu -----------------------------------");
    Console.WriteLine(@"
*** Escolha uma opção do sistema, digite os comandos: ***
1 - Listar todas as mensagens 
2 - Adicionar uma nova mensagem
3 - Apagar mensagem
0 - P/ sair do sistema");
}






