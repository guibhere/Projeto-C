public class FilmeInputPostDTO {
     public string Titulo { get; set; }
     public long DiretorID { get; set; }

     public FilmeInputPostDTO(string titulo,long id){
          Titulo = titulo;
          DiretorID = id;
     }
     
}