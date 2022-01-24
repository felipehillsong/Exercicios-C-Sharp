namespace Exercicios
{
    public class Partido
    {
        public string NomePartido { get; set; }
        public int NumeroPartido { get; set; }        
        public enum PartidoPolitico
        {
            PSDB = 45,
            PT = 13,
            PSOL = 50,
            PSL = 17 
        };
        
    }
}