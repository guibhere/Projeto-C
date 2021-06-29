public class FilmeOutputGetIdDTO{
    public long Id { get; set; }
    public string Titulo { get; set; }       
    public string Diretor { get; set; }
    
    public  FilmeOutputGetIdDTO(long id, string titulo, string diretor) {
        Id = id;
        Titulo = titulo;
        Diretor = diretor;
    }
}