using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuladorDeDisco.Classes
{
    public class Arquivo
    {
        public string Conteudo { get; set; } = "";

        public Arquivo(string conteudo)
        {
            Conteudo = conteudo;
        }

        public List<string> DefinirArquivosParaCriar()
        {
            var listaArquivos = new List<string>();
            string arquivoNome = string.Empty;
            var splitConteudo = Conteudo.Split(" ").ToList();

            foreach (var palavra in splitConteudo)
            {
                arquivoNome = string.Empty;
                if (palavra.Length <= 3)
                {
                    listaArquivos.Add(palavra);
                    continue;
                }

                for (int i = 0; i < palavra.Length; i++)
                {
                    if (i % 3 != 0 || i == 0)
                    {
                        arquivoNome += palavra[i];
                        continue;
                    }

                    listaArquivos.Add(arquivoNome);
                    arquivoNome = string.Empty;
                    arquivoNome += palavra[i];
                }

                listaArquivos.Add(arquivoNome);
            }

            return listaArquivos;
        }

        public void CriarArquivo(int nomeArquivo, int indiceLista)
        {
            var particao = Particao.ObterParticao();
            var raiz = particao.DiretorioRaiz;

            var listaArquivos = DefinirArquivosParaCriar();

            for (int i = 0; i <= indiceLista; i++)
            {
                if (i != indiceLista)
                    continue;

                raiz = $"{raiz}\\{nomeArquivo}.txt";
                File.Create(raiz).Close();
                Console.WriteLine($"Novo arquivo criado em: {raiz}");

                using var file = File.AppendText(raiz);
                file.WriteLine(listaArquivos[i]);
                file.Close();
            }
        }

        public void DeletarArquivo(int nomeArquivo)
        {
            var particao = Particao.ObterParticao();
            var raiz = particao.DiretorioRaiz;

            raiz = $"{raiz}\\{nomeArquivo}.txt";
            File.Delete(raiz);
        }
    }
}
