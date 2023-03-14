using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Server
{
    public class MySqlContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public MySqlContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder opBuilder)
        {
            opBuilder.UseMySql(
                @"server=localhost;database=avtovek;uid=root;password=0000;",
                new MySqlServerVersion(new Version(8, 0, 30))
            );
        }
    }
    
    public class MySqlRepository : IRepository
    {
        public void Add(Client client)
        {
            using (var context = new MySqlContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }
        
        public List<Client> FindAll()
        {
            List<Client> clients;
            
            using (var context = new MySqlContext())
            {
                clients = context.Clients.ToList();
            }

            return clients;
        }

        public Client Read(int id)
        {
            Client client;
            
            using (var context = new MySqlContext())
            {
                client = context.Clients.First(cl => cl.Id == id);
            }

            return client;
        }

        public bool ExistById(int id)
        {
            Client client;
            
            using (var context = new MySqlContext())
            {
                client = context.Clients.First(cl => cl.Id == id);
            }

            return client != null;
        }

        public void DeleteById(int id)
        {
            using (var context = new MySqlContext())
            {
                var client = context.Clients.First(cl => cl.Id == id);
                context.Clients.Remove(client);
            }
        }

        public void ReWriteById(int id, Client client)
        {
            using (var context = new MySqlContext())
            {
                var oldClient = context.Clients.First(cl => cl.Id == id);
                context.Clients.Remove(oldClient);
                context.Clients.Add(client);
            }
        }
    }
}