namespace Restful_API.Logging
{
    public class Logging : ILogging
    {
        public void Log(string message, string? type=null)
        {
            if (type == "error")
            {
                Console.WriteLine("ERROR - " + message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}
