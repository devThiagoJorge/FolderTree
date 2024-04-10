using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmuladorDeDisco.Classes
{
    public sealed class Particao // A classe não pode ser herdada
    {

        public BitArray BitMap { get; private set; } = new BitArray(20);
        public string DiretorioRaiz { get; set; } = "";
        public Dictionary<string, List<int>> Files { get; set; }
            = new Dictionary<string, List<int>>();

        private Particao()
        {
        }

        private static Particao _instance;

        public void ListarMensagens()
        {
            foreach (var mensagem in Files.Keys.ToList())
            {
                Console.WriteLine($"- {mensagem}");
            }
        }

        public static Particao ObterParticao()
        {

            if (_instance == null)
            {
                _instance = new Particao();
                _instance.DiretorioRaiz = @"C:\dev\FolderTree\EmuladorDeDisco\TesteSistema";
            }

            return _instance;
        }

        public int IndexDisponivelParaSalvar()
        {
            for (int i = 0; i < BitMap.Length; i++)
            {
                if (!BitMap[i])
                    return i;
            }

            return -1;
        }

        public void CriarNaParticao(string conteudo)
        {
            var arquivo = new Arquivo(conteudo);
            int quantidadeDeArquivos = arquivo.DefinirArquivosParaCriar().Count;
            int indexBitMap = 0;
            int quantidadeParticoes = QuantidadeParticoes();

            for (int i = 0; i < quantidadeDeArquivos; i++)
            {
                if (i > quantidadeParticoes)
                    break;

                indexBitMap = IndexDisponivelParaSalvar();

                if (indexBitMap == -1)
                    break;

                arquivo.CriarArquivo(indexBitMap, i);
                PreencherBitMap(indexBitMap);
                PreencherDictionary(conteudo, indexBitMap);
            }
        }

        public void ApagarMensagem(string mensagem)
        {
            var recuperarParticoes = BuscarParticoesIndex(mensagem);
            var arquivo = new Arquivo(mensagem);

            foreach (var item in recuperarParticoes)
            {
                BitMap[item] = false;
                arquivo.DeletarArquivo(item);
            }
        }

        private List<int> BuscarParticoesIndex(string mensagem)
        {
            return Files.FirstOrDefault(x => x.Key == mensagem).Value.ToList();
        }

        public bool ExisteMensagem(string mensagem)
        {
            if(Files.ContainsKey(mensagem)) return true;

            return false;
        }

        private void PreencherDictionary(string conteudo, int indice)
        {
            if (!Files.ContainsKey(conteudo))
            {
                Files.Add(conteudo, new List<int> {indice});
                return;
            }

            var listaIndices = Files.Where(x => x.Key == conteudo).FirstOrDefault().Value;

            listaIndices.Add(indice);
            Files.Remove(conteudo);
            Files.Add(conteudo, listaIndices);
        }

        private void PreencherBitMap(int index)
        {
            BitMap[index] = true;
        }

        private int QuantidadeParticoes()
        {
            int quantidade = 0;
            for (int i = 0; i < BitMap.Length; i++)
            {
                if (!BitMap[i])
                    quantidade++;
            }

            return quantidade;
        }

    }
}
