using Microsoft.EntityFrameworkCore;
using System;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while (true)
            {
            }
        }

    }

    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer("Data Source=DESKTOP-BL1CI2M;Initial Catalog=HelpRequestDB;Integrated Security=True");
        }
    }
}
