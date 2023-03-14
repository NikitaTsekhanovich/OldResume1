using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Server
{
    public class Client
    {
        public int Id;
        public ClientName ClientName { get; }
        public PassportData PassportData { get; }
        public Car Car { get; }
        public List<Operation> Operations { get; }
        public string Serialized => JsonSerializer.Serialize(this);
        
        public Client(int id, ClientName name, PassportData passport, Car car, List<Operation> operations)
        {
            Id = id;
            ClientName = name;
            PassportData = passport;
            Car = car;
            Operations = operations;
        }
    }

    public class ClientName
    {
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }

        public ClientName(string name, string surname, string patronymic)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
    }

    public class PassportData
    {
        public int Id;
        public string PassportId { get; }
        public string Registration { get; }

        public PassportData(int id, string pass_id, string registration)
        {
            Id = id;
            PassportId = pass_id;
            Registration = registration;
        }
    }

    public class Car
    {
        public int Id { get; }
        public string RegistrationNumber{ get; }
        public string Model { get; }
        public string Color{ get; }

        public Car(int id, string registrationNumber, string model, string color)
        {
            Id = id;
            RegistrationNumber = registrationNumber;
            Model = model;
            Color = color;
        }
    }

    public class Operation
    {
        public string Id{ get; }
        public string Name{ get; }
        public string Price{ get; }
        public string Status { get; }
        public string Comment{ get; }

        public Operation(string id, string name, string price, string status, string comment)
        {
            Id = id;
            Name = name;
            Price = price;
            Status = status;
            Comment = comment;
        }
    }
}