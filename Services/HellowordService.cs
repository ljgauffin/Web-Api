public interface IHelloWorldService
{
    string GetHelloWord();
}

public class HellowordService : IHelloWorldService
{
    public string GetHelloWord(){
        return "hello word";
    }
    
}

