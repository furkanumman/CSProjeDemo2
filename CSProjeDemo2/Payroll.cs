using CSProjeDemo2.Entities;
using Newtonsoft.Json;

namespace CSProjeDemo2;

public static class Payroll
{
    public static void CreatePayrollManager(List<Manager> managers)
    {
        if (managers.Count == 0)
        {
            Console.WriteLine("Yönetici bulunmamaktadır");
            return;
        }

        do
        {
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].BaseSalary == 0)
                    Console.WriteLine($"{i + 1}. {managers[i].FullName}");
            }
            Console.Write("Bordro oluşturmak istediğiniz yönetici indeksini giriniz: ");
            int indexOfManager = int.Parse(Console.ReadLine()) - 1;

            Console.Write($"{managers[indexOfManager].FullName} çalışma saati: ");
            managers[indexOfManager].WorkingHours = int.Parse(Console.ReadLine());
            Console.Write("Bonus miktarı: ");
            managers[indexOfManager].Bonus = int.Parse(Console.ReadLine());
            decimal salary = managers[indexOfManager].CalculateSalary();
            decimal mainPayment = salary - managers[indexOfManager].Bonus;

            string payrollTitle = $"Maas Bordro {DateTime.Now:MMMM} {DateTime.Now.Year}";
            var payrollData = new Dictionary<string, object>
            {
                [payrollTitle] = new
                {
                    Personel_Ismi = managers[indexOfManager].FullName,
                    Calisma_Saati = managers[indexOfManager].WorkingHours,
                    Ana_Odeme = $"{mainPayment:C}",
                    Bonus = $"{managers[indexOfManager].Bonus:C}",
                    Toplam_Odeme = $"{salary:C}"
                }
            };
            string json = JsonConvert.SerializeObject(payrollData, Formatting.Indented);

            string fullname = managers[indexOfManager].FullName.Replace(" ", "_");

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var projectDirectory = baseDirectory.Split("bin");
            var path = Path.Combine(projectDirectory[0], "Results", fullname);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.Combine(path, $"{fullname}_Bordro_{Guid.NewGuid()}.json");
            File.WriteAllText(fileName, json);

            Console.WriteLine($"{managers[indexOfManager].FullName} için bordro oluşturuldu.");
            Console.WriteLine("");

            if (managers.Where(x => x.BaseSalary == 0).ToList().Count() != 0)
            {
                Console.Write("Bordro oluşturmaya devam etmek için Y, çıkış için herhangi bir tuşa basabilirsiniz. ");

                if (Console.ReadLine() != "Y")
                    break;
            }

        } while (managers.Where(x => x.BaseSalary == 0).ToList().Count() != 0);

        ManagerReport(managers);
    }

    public static void CreatePayrollOfficer(List<Officer> officers)
    {
        if (officers.Count == 0)
        {
            Console.WriteLine("Memur bulunmamaktadır");
            return;
        }

        do
        {
            for (int i = 0; i < officers.Count; i++)
            {
                if (officers[i].BaseSalary == 0)
                    Console.WriteLine($"{i + 1}. {officers[i].FullName}");
            }

            Console.Write("Bordro oluşturmak istediğiniz memur indeksini giriniz: ");
            int indexOfOfficer = int.Parse(Console.ReadLine()) - 1;

            Console.Write($"{officers[indexOfOfficer].FullName} çalışma saati: ");
            officers[indexOfOfficer].WorkingHours = int.Parse(Console.ReadLine());

            decimal salary = officers[indexOfOfficer].CalculateSalary();

            string payrollTitle = $"Maas Bordro {DateTime.Now:MMMM} {DateTime.Now.Year}";
            var payrollData = new Dictionary<string, object>
            {
                [payrollTitle] = new
                {
                    Personel_Ismi = officers[indexOfOfficer].FullName,
                    Calisma_Saati = officers[indexOfOfficer].WorkingHours,
                    Ana_Odeme = $"{officers[indexOfOfficer].BaseSalary:C}",
                    Mesai = $"{officers[indexOfOfficer].ExtraShiftPayment:C}",
                    Toplam_Odeme = $"{salary:C}"
                }
            };
            string json = JsonConvert.SerializeObject(payrollData, Formatting.Indented);

            string fullname = officers[indexOfOfficer].FullName.Replace(" ", "_");

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var projectDirectory = baseDirectory.Split("bin");
            // Results klasörünü içeren yeni bir yol oluştur
            var path = Path.Combine(projectDirectory[0], "Results", fullname);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = Path.Combine(path, $"{fullname}_Bordro_{Guid.NewGuid()}.json");
            File.WriteAllText(fileName, json);
            Console.WriteLine($"{officers[indexOfOfficer].FullName} için bordro oluşturuldu.");
            Console.WriteLine("");

            if (officers.Where(x => x.BaseSalary == 0).ToList().Count() != 0)
            {
                Console.Write("Bordro oluşturmaya devam etmek için Y, çıkış için herhangi bir tuşa basabilirsiniz. ");

                if (Console.ReadLine() != "Y")
                    break;
            }
        } while (officers.Where(x => x.BaseSalary == 0).ToList().Count() != 0);

        OfficerReport(officers);
    }

    private static void OfficerReport(List<Officer> personnels)
    {
        if (personnels != null)
        {
            foreach (var personnel in personnels)
            {
                if (personnel.WorkingHours < 150)
                {
                    Console.WriteLine($"Ad: {personnel.FullName}, Çalışma Saati: {personnel.WorkingHours}");
                }
            }
        }
    }

    private static void ManagerReport(List<Manager> personnels)
    {
        if (personnels != null)
        {
            foreach (var personnel in personnels)
            {
                if (personnel.WorkingHours < 150)
                {
                    Console.WriteLine($"Ad: {personnel.FullName}, Çalışma Saati: {personnel.WorkingHours}");
                }
            }
        }
    }


}
