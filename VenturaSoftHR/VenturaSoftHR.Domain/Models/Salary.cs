using VenturaSoftHR.Common.Exceptions;
using VenturaSoftHR.Domain.Specifications;

namespace VenturaSoftHR.Domain.Models
{
    public class Salary
    {
        public decimal Value { get; set; }

        public Salary(decimal salary) => Value = salary;
    }
}