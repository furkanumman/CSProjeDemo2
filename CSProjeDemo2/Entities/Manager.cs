using CSProjeDemo2.Entities.Base;

namespace CSProjeDemo2.Entities;

public class Manager : BasePersonnel
{
    public decimal Bonus { get; set; }
  
    public override decimal HourlyFee => 500;

    public override decimal CalculateSalary()
    {
        BaseSalary = WorkingHours * HourlyFee;
        return Bonus + BaseSalary;
    }
}
