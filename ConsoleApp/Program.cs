using CSProjeDemo2;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var projectDirectory = baseDirectory.Split("bin");
            var path = Path.Combine(projectDirectory[0], "personnel.json");
            Console.WriteLine(path);

            var managers = ReadDocument.GetManagerList(path);
            var officers = ReadDocument.GetOfficerList(path);

            Console.WriteLine("-- Yöneticileri listelemek için -> 1 \n" +
                  "-- Memurları listelemek için --> 2 ");

            bool isNumber = int.TryParse(Console.ReadLine(), out int input);

            if (!isNumber || input > 2 || input < 1)
            {
                Console.WriteLine("Hatalı değer girişi yaptınız.");
            }

            switch (input)
            {
                case 1:
                    Console.WriteLine(" ### Yöneticiler ### ");
                    Payroll.CreatePayrollManager(managers);
                    break;
                case 2:
                    Console.WriteLine(" ### Memurlar ### ");
                    Payroll.CreatePayrollOfficer(officers);
                    break;
            }
        }
    }
}
