using Microsoft.EntityFrameworkCore;
public class AplicationDbContext : DbContext
{
public DbSet<Filme> Filmes {get;set;}
public DbSet<Diretor> Diretores{get;set;}

public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options){}


}