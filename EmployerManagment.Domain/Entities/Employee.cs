using EmployerManagment.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Domain.Entities
{
    public class Employee
    {
        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ContactInfo ContactInfo { get; private set; }
        public Position Position { get; private set; }
        public DateTime HireDate { get; private set; }

        //public List<PositionChangeEvent> PositionHistory { get; private set; } = new List<PositionChangeEvent>();

        public static Employee Create(long id, string firstName, string lastName, ContactInfo contactInfo, Position position)
        {
            var employee = new Employee
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                ContactInfo = contactInfo,
                Position = position,
                HireDate = DateTime.UtcNow
            };

            DomainEvents.Raise(new EmployeeCreated(employee.Id, employee.FirstName, employee.LastName));

            return employee;
        }
        public void ChangePosition(Position newPosition)
        {
            PositionHistory.Add(new PositionChangeEvent(Position, newPosition, DateTime.UtcNow));
            Position = newPosition;
        }


    }
}
