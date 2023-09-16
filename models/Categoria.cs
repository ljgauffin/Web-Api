using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Categoria
{
    // [Key]
    private Guid categoriaId;
    public Guid CategoriaId
    {
        get { return categoriaId; }
        set { categoriaId = value; }
    }

    // [Required]
    // [MaxLength(150)]
    private string nombre;
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    private string descripcion;
    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }
    public int Peso { get; set; }
    [JsonIgnore] //sirve para que al momento de cargar las Categorias no traiga al mismo tiempo las tareas
    public virtual ICollection<Tarea> Tareas { get; set; }
    
    
    
}