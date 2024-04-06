namespace EmuladorDeDisco.Classes
{
    public class Pasta
    {
        public string DiretorioRaiz { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;


        public Pasta(string diretorioRaiz, string nome)
        {
            DiretorioRaiz = diretorioRaiz;
            Nome = nome;
        }

        #region Opção 1!
        private IEnumerable<(string, string)> ObterTodasAsPastas()
        {
            Console.WriteLine($"\n\nDiretório raiz: {DiretorioRaiz}");

            return Directory.EnumerateDirectories(DiretorioRaiz, "*", SearchOption.AllDirectories)
                .Select(x => (Path.GetFileName(x),
                  Path.GetFullPath(Path.Combine(x, @"..")) // pega o diretório anterior
                    .Substring(DiretorioRaiz.Length))); // Remove o diretório raiz!
        }

        public void MontarArvoreDePastas()
        {
            var folders = ObterTodasAsPastas().ToList();
            bool passouPelasRaizes = false;
            var raizes = folders.Where(x => string.IsNullOrEmpty(x.Item2)).Select(x => x.Item1).ToList();
            string ultimaRaiz = folders.Last(x => string.IsNullOrEmpty(x.Item2)).Item1;

            foreach (var raiz in raizes)
            {
                foreach (var folder in folders)
                {

                    if (folder.Item2.Contains(raiz))
                        Console.WriteLine($"{folder.Item2.Replace("\\", " -> ")} -> {folder.Item1}");


                    if (!passouPelasRaizes && ultimaRaiz == folder.Item1)
                    {
                        Console.WriteLine($"-> {folder.Item1}");
                        passouPelasRaizes = true;
                    }

                }
            }
        }
        #endregion



        public Tuple<string, bool> BuscarSubdiretorio(string buscarSubdiretorio)
        {
            var diretorios = Directory.GetDirectories(DiretorioRaiz);

            foreach (var diretorio in diretorios)
            {
                if (diretorio == buscarSubdiretorio)
                {
                    bool encontreiDiretorio = true;
                    return new Tuple<string, bool>(diretorio, encontreiDiretorio);
                }
            }

            return new Tuple<string, bool>("", false);

        }


    }
}
