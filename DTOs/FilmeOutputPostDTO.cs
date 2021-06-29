public class FilmeOutputPostDTO {
    public long Id { get; set; }
    public string Titulo { get; set; }       
    public long DiretorID { get; set; }
    
    public FilmeOutputPostDTO(long id, string titulo, long diretorid) {
        Id = id;
        Titulo = titulo;
        DiretorID = diretorid;
    }
}