using System;

namespace Excel.Domain.Entities
{
    public class Client
    {
        protected int Identifier { get; }
        protected string Name { get; set; }
        protected string Surname { get; set; }
        protected string YearBirth { get; set; }
        protected string PassportId { get; set; }
        protected string Registration { get; set; }

        protected Client(string name, string surname, string yearBirth,
            string passId, string registration)
        {
            Name = name;
            Surname = surname;
            YearBirth = yearBirth;
            PassportId = passId;
            Registration = registration;
        }

        public void PutData()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Surname);
            Console.WriteLine(YearBirth);
            Console.WriteLine(PassportId);
            Console.WriteLine(Registration);
        }

        public void GetData()
        {
            
        }
    }
}