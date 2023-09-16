using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace webapi;

//Es necesario crear una clase que ehereda dde DBcontext para hacer a relacion entre los modelos y las tablas
public class TareasContext: DbContext
{
    
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) : base(options)
    {
        
    }
    //fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder){

        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria(){CategoriaId=Guid.Parse("b3a3096e-4274-4799-a843-380868d4831c"), Nombre= "Actividades pendientes", Peso=20});
        categoriasInit.Add(new Categoria(){CategoriaId=Guid.Parse("b3a3096e-4274-4799-a843-380868d4832c"), Nombre= "Actividades personales", Peso=50});
        categoriasInit.Add(new Categoria(){CategoriaId=Guid.Parse("b3a3096e-4274-4799-a843-380868d4833c"), Nombre= "Actividades del Hogar", Peso=20});

        modelBuilder.Entity<Categoria>(categoria=>{
            categoria.ToTable("Categoria");
            categoria.HasKey(p=>p.CategoriaId);
            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=>p.Descripcion).IsRequired(false);
            categoria.Property(p=>p.Peso);
            categoria.HasData(categoriasInit);

        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea(){TareaId=Guid.Parse("b3a3096e-4274-4799-a843-380868d4834c"),CategoriaId=Guid.Parse("b3a3096e-4274-4799-a843-380868d4831c"), Titulo= "Hacer tarea", FechaCreacion= DateTime.Now, PrioridadTarea=Prioridad.Media});
        tareasInit.Add(new Tarea(){TareaId=Guid.Parse("b3a3096e-4274-4799-a843-380868d4835c"),CategoriaId=Guid.Parse("b3a3096e-4274-4799-a843-380868d4832c"), Titulo= "Ir al gym", FechaCreacion= DateTime.Now, PrioridadTarea=Prioridad.Baja});
        tareasInit.Add(new Tarea(){TareaId=Guid.Parse("b3a3096e-4274-4799-a843-380868d4836c"),CategoriaId=Guid.Parse("b3a3096e-4274-4799-a843-380868d4833c"), Titulo= "Limpiar", FechaCreacion= DateTime.Now, PrioridadTarea=Prioridad.Alta});


        modelBuilder.Entity<Tarea>(tarea=>{
            tarea.ToTable("Tarea");
            tarea.HasKey(p=>p.TareaId);

            tarea.HasOne(p=>p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaId);
            tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=>p.Descripcion).IsRequired(false);
            tarea.Property(p=>p.FechaCreacion);
            //no agrego Tarea.Resumen porque no quiero mapearla
            tarea.Ignore(p=>p.Resumen);
            tarea.HasData(tareasInit);

        });
    }

}