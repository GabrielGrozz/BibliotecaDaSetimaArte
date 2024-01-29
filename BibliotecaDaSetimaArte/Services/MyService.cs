namespace BibliotecaDaSetimaArte.Services
{
    public class MyService : IMyService
    {
        public string Greeting(string name)
        {
            return $"bem vindo {name}";
        }
    }
}
