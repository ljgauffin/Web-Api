
public class TimeMiddleware
{
    readonly RequestDelegate next; //nos ayuda  ainvocar el middalewhare que sigue en el viclo
    public TimeMiddleware(RequestDelegate next)
    {
        this.next=next;
        
    }

    public async Task Invoke(HttpContext context){ //metodo por defecto en middlwware. El hhttpContext viene la información del request
        //primero paso al siguiente middleware y luego  hago la ejecución de la logica y la modificacion del response en la vuelta
        


        await next(context); //Se hace el llamado al siguiente request

        if(context.Request.Query.Any(p=>p.Key =="time")){ //si existe algun parametro con Key igual a time
            await context.Response.WriteAsync (DateTime.Now.ToShortTimeString()); //dentro de la respuesta del request se escirbe la hora actual por encima
        }
    }

    
}

public static class TimeMiddlewareExtension  //nos ayuda a meter el extension dentro de la configuracion del program
{
    public static IApplicationBuilder UseTimeMiddleware (this IApplicationBuilder builder) //recibimos el contexto como paramtero
    { 
        return builder.UseMiddleware<TimeMiddleware>(); //tomamos el builder usamos el middleware actual y retornamos para quw siga el proceso
    }

}