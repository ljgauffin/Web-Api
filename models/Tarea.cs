using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;
//definicion del modelod e Tarea
public class Tarea
{
    // [Key] //indica PK
    public Guid TareaId { get; set; } //Guid genera un ID unico, al llamar esta prop igual que la case con Id al final ya lo toma como PK
    // [ForeignKey("CategoriaId")] //Data Annotation para FK
    public Guid CategoriaId { get; set; }

    // [Required]  //Data Annotation para not null
    // [MaxLength(200)] //indica el tamaño del campo
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public Prioridad PrioridadTarea { get; set; }
    public DateTime FechaCreacion { get; set; }
    public virtual Categoria Categoria { get; set; }
    // [NotMapped] //Data Annotation que le dice al ORM que NO mapee este campo (no cree columna en la db)
    public string Resumen { get; set; }
}

public enum Prioridad{
    Baja,
    Media,
    Alta
}