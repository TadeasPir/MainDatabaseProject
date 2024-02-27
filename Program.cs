using DatabaseProjectPV.classes;

namespace DatabaseProjectPV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
             
                MachineConsole myConsole = new MachineConsole();
                myConsole.Start();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);  }
         
        }
    }
} 