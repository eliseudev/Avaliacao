using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Customer.Banco;

public class MeuContexto<T> : DbContext where T : class
{
    public MeuContexto(DbContextOptions<MeuContexto<T>> options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=tcp:NETCORE-BOOK\\SQLEXPRESS,1433;Initial Catalog=TesteDb;User ID=sa;Password='jesuscristo';trusted_connection=false;Persist Security Info=False;Encrypt=False")
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    public void Adicionar(T obj)
    {
        Set<T>().Add(obj);
        SaveChanges();
    }

    public void Atualizar(T obj)
    {
        Set<T>().Update(obj);
        SaveChanges();
    }

    public List<T> Listar(int page, int size)
    {
        var query = Set<T>().AsQueryable();

        if (typeof(T) == typeof(Cliente))
        {
           query = query.Include( x => (x as Cliente)!.Enderecos );
        }
        return query.ToList().Skip((page - 1) * size).Take(size).ToList();
    }
    
    public T? Find(int id)
    {
        IQueryable<T?> query = Set<T>().AsQueryable();
        if (typeof(T) == typeof(Cliente))
        {
            query = query.Include( x => (x as Cliente)!.Enderecos );
            query = query.Where( x => (x as Cliente).Id == id  );
        }
        return query.FirstOrDefault();
    }
}