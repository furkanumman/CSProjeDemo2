using CSProjeDemo2.Entities.Base;

namespace CSProjeDemo2.Entities;

public class Officer : BasePersonnel
{
    public override decimal HourlyFee { get; } = 500;
    public decimal ExtraShiftPayment { get; set; }
    public override decimal CalculateSalary()
    {
        if (WorkingHours <= 180)
            BaseSalary = WorkingHours * HourlyFee;

        else if (WorkingHours > 180)
        {
            ExtraShiftPayment = (WorkingHours - 180) * HourlyFee * 1.5m;
            BaseSalary = (180 * HourlyFee);
        }

        return BaseSalary + ExtraShiftPayment;
    }
}
