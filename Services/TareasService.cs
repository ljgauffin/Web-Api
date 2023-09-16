using webapi;
using webapi.Models;


namespace webapi.Services;

public class TareasService: ITareasService
{
    TareasContext context;
    
    public TareasService(TareasContext dbContext)
    {
        context= dbContext;
        
    }
    public IEnumerable<Tarea> Get(){
        return context.Tareas;
    }

    public async Task Save(Tarea tarea){
        tarea.TareaId= Guid.NewGuid();
        tarea.FechaCreacion = DateTime.Now;
        context.Add(tarea);
        
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea){
        var tareaActual = context.Tareas.Find(id);
        
        if(tareaActual!=null){
            tareaActual.CategoriaId= tarea.CategoriaId;
            tareaActual.Titulo= tarea.Titulo;
            tareaActual.PrioridadTarea= tarea.PrioridadTarea;
            tareaActual.Descripcion= tarea.Descripcion;

            await context.SaveChangesAsync();

        }
        
    }

    public async Task Delete(Guid id){
            var tareaActual = context.Tareas.Find(id);
            
            if(tareaActual!=null){

                context.Remove(id);
                await context.SaveChangesAsync();

            }
            
        }

}

public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea Tarea);
    Task Update(Guid id, Tarea Tarea);
    Task Delete(Guid id);


}