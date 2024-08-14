using EmployerManagment.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
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

        public Employee(long id, string firstName, string lastName, ContactInfo contactInfo, Position position, DateTime hireDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ContactInfo = contactInfo;
            Position = position;
            HireDate = hireDate;
        }

        public static Employee Create(long id, string firstName, string lastName, ContactInfo contactInfo, Position position)
        {
            var employee = new Employee(id, firstName, lastName, contactInfo, position, DateTime.UtcNow);

            //DomainEvents.Raise(new EmployeeCreated(employee.Id, employee.FirstName, employee.LastName));

            return employee;
        }

        public void SetId(long id) 
        {
            if (id < 1)
                throw new SecurityException("Cannot set id less than 1!");

            this.Id = id;
        }
        public void ChangePosition(Position newPosition)
        {
            //PositionHistory.Add(new PositionChangeEvent(Position, newPosition, DateTime.UtcNow));
            //Position = newPosition;
        }


    }
}
