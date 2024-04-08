using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuladorDeDisco.Classes
{
    public class Arquivo
    {
        public string Nome { get; set; } = "";
        public string Conteudo { get; set; } = "";
        public Pasta Pasta { get; set; }

        public Arquivo(string nome, string conteudo)
        {
            Nome = nome;
            Conteudo = conteudo;
        }

        public void ManipularArquivo(Pasta pasta, string novaPasta)
        {
            var novaRaiz = $"{pasta.DiretorioRaiz}\\{novaPasta}";
            CriarArquivo(novaRaiz);
        }

        private List<string> DefinirArquivosParaCriar(List<string> listaPalavras)
        {
            var listaArquivos = new List<string>();
            string newPalavra = string.Empty;
            foreach (var palavra in listaPalavras)
            {
                newPalavra = string.Empty;
                if (palavra.Length <= 3)
                {
                    listaArquivos.Add(palavra);
                    continue;
                }

                for (int i = 0; i < palavra.Length; i++)
                {
                    if (i % 3 != 0 || i == 0)
                    {
                        newPalavra += palavra[i];
                        continue;
                    }

                    if (i == palavra.Length - 1)
                    {
                        newPalavra += palavra[i];
                        continue;
                    }

                    listaArquivos.Add(newPalavra);
                    newPalavra = string.Empty;
                    newPalavra += palavra[i];
                }

                listaArquivos.Add(newPalavra); ;
            }

            return listaArquivos;
        }

        private void CriarArquivo(string raiz)
        {
            var splitConteudo = Conteudo.Split(" ").ToList();
            var listaArquivos = DefinirArquivosParaCriar(splitConteudo);


            string newRaiz = string.Empty;
            foreach (var arquivo in listaArquivos)
            {
                newRaiz = $"{raiz}\\{arquivo}.txt";

                File.Create(newRaiz).Close();
                Console.WriteLine($"Novo arquivo criado em: {newRaiz}");

                using var file = File.AppendText(newRaiz);
                file.WriteLine(arquivo);
                file.Close();
                newRaiz = string.Empty;
            }
        }
    }
}