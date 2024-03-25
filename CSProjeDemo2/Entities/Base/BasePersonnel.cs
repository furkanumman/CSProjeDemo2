using System.Reflection.Metadata.Ecma335;

namespace CSProjeDemo2.Entities.Base
{
    public abstract class BasePersonnel
    {
        public string FullName { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int WorkingHours { get; set; }

        public abstract decimal HourlyFee { get;  }

        public decimal BaseSalary { get; set; }
        public abstract decimal CalculateSalary();
        
    }
}
