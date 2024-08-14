using EmployerManagment.Domain.Entities;
using EmployerManagment.Domain.Services;
using EmployerManagment.Infrastructure.Helper;
using System.Text.Json;

namespace EmployerManagment.Infrastructure.Add
{
    /// <summary>
    /// Imitation of DB sql - JSON
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public EmployeeRepository()
        {
            if (!File.Exists(FileDBHelper.GetFullPathDBFile()))
                File.Create(FileDBHelper.GetFullPathDBFile());
        }

        public async Task<long> AddNewEmployee(Employee employee)
        {
            try
            {
                IList<Employee> tableEmployee = new List<Employee>();
                using (Stream stream = FileDBHelper.GetStreamDBFile())
                {
                    tableEmployee = await JsonSerializer.DeserializeAsync<List<Employee>>(stream) ?? new List<Employee>();
                }

                long id = 1;
                if (tableEmployee.Count > 0)
                    id = tableEmployee.Last().Id + 1;

                if (tableEmployee.Any(f => f.FirstName == employee.FirstName && f.LastName == employee.LastName))
                    throw new ArgumentNullException($"User of {employee.FirstName} {employee.LastName} exist in DB!");

                employee.SetId(id);
                tableEmployee.Add(employee);
                SaveInDB(tableEmployee);
                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SaveInDB(object obj)
        {
            semaphore.Wait();
            try
            {
                string json = JsonSerializer.Serialize<object>(obj);
                File.WriteAllText(FileDBHelper.GetFullPathDBFile(), json);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
