using System;

namespace EmployeeEqualityConsoleApp
{
    // Define the Employee class
    public class Employee
    {
        // Properties for the Employee class
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Overload the == operator to compare Employee objects by their Id
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // Check for nulls to avoid exceptions
            if (ReferenceEquals(emp1, null) && ReferenceEquals(emp2, null))
                return true;
            if (ReferenceEquals(emp1, null) || ReferenceEquals(emp2, null))
                return false;

            return emp1.Id == emp2.Id;
        }

        // Overload the != operator as a pair to ==
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // Override Equals method to ensure correct comparison
        public override bool Equals(object obj)
        {
            var other = obj as Employee;
            if (other == null)
                return false;

            return this.Id == other.Id;
        }

        // Override GetHashCode when Equals is overridden
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create first Employee object and set properties
            Employee emp1 = new Employee()
            {
                Id = 101,
                FirstName = "Alice",
                LastName = "Johnson"
            };

            // Create second Employee object and set properties
            Employee emp2 = new Employee()
            {
                Id = 102,
                FirstName = "Bob",
                LastName = "Smith"
            };

            // Compare the two employees using overloaded == operator
            if (emp1 == emp2)
            {
                Console.WriteLine("Employees are equal (same ID).");
            }
            else
            {
                Console.WriteLine("Employees are not equal (different IDs).");
            }

            // Keep console open
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
