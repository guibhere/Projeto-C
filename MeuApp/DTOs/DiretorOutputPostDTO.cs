using System.Collections.Generic;
public class DiretorOutputPostDTO {
    public long Id { get; set; }
    public string Nome { get; set; }

    public ICollection<Filme> filmes {get;set;}

    public DiretorOutputPostDTO(Diretor diretor) {
        Id = diretor.Id;
        Nome = diretor.Nome;
        filmes = diretor.Filmes;
    }
}