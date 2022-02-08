public class Filme
{
    public Filme(string titulo)
    {
        Titulo = titulo;
    }
    public Filme(string titulo, long id)
    {
        Titulo = titulo;
        DiretorId = id;
    }


    public long Id { get; set; }
    public string Titulo { get; set; }
    public string Ano { get; set; }
    public string Genero { get; set; }
    public long DiretorId { get; set; }
    public Diretor Diretor { get; set; }

}