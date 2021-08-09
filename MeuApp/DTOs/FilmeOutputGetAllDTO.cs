public class FilmeOutputGetAllDTO
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public string Ano { get; set; }

    public FilmeOutputGetAllDTO(long id, string titulo, string ano)
    {
        Id = id;
        Titulo = titulo;
        Ano = ano;
    }
}