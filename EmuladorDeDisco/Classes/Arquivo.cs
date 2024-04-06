using System;
using System.Collections.Generic;
using System.Data;
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

        public void ManipularArquivo(Pasta pasta)
        {
            CriarArquivo(pasta.DiretorioRaiz);
        }

        private void CriarArquivo(string raiz)
        {
            var splitConteudo = Conteudo.Split(" ");
            int contarArquivo = 0;

            File.Create(raiz);
            foreach (var palavras in splitConteudo)
            {
                for (int i = 0; i < palavras.Length; i++)
                {
                    if (i < 3) {
                        
                    }
                }
            }
        }
    }
}
