using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace StudentRegistrationSystem.Data
{
    public static class DbInitializer
    {
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
        public static void Initialize(ApplicationDbContext context)
        {
            // Ensure database is created and all tables exist
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            // Log database creation
            Console.WriteLine("Database created successfully.");

            // Seed users if none exist
            if (!context.Users.Any())
            {
                var users = new User[]
                {
                    new User
                    {
                        Username = "admin",
                        Password = HashPassword("admin123"),
                        Email = "admin@example.com",
                        IsAdmin = true
                    },
                    new User
                    {
                        Username = "usuario",
                        Password = HashPassword("usuario123"),
                        Email = "usuario@example.com",
                        IsAdmin = false
                    }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            // Seed courses if none exist
            if (!context.Courses.Any())
            {
                var courses = new Course[]
                {
                    new Course
                    {
                        Name = "Ingeniería Informática",
                        Description = "Carrera de ingeniería enfocada en el desarrollo de software y sistemas informáticos.",
                        Credits = 8,
                        IsActive = true
                    },
                    new Course
                    {
                        Name = "Arquitectura",
                        Description = "Carrera profesional enfocada en el diseño y construcción de edificios y espacios urbanos.",
                        Credits = 9,
                        IsActive = true
                    },
                    new Course
                    {
                        Name = "Medicina",
                        Description = "Carrera profesional dedicada al estudio, diagnóstico y tratamiento de enfermedades.",
                        Credits = 10,
                        IsActive = true
                    },
                    new Course
                    {
                        Name = "Derecho",
                        Description = "Carrera profesional enfocada en el estudio y aplicación de las leyes y normativas.",
                        Credits = 7,
                        IsActive = true
                    },
                    new Course
                    {
                        Name = "Psicología",
                        Description = "Carrera dedicada al estudio del comportamiento humano y procesos mentales.",
                        Credits = 8,
                        IsActive = true
                    },
                    new Course
                    {
                        Name = "Economía",
                        Description = "Carrera enfocada en el estudio de la producción, distribución y consumo de bienes y servicios.",
                        Credits = 7,
                        IsActive = true
                    }
                };

                context.Courses.AddRange(courses);
                context.SaveChanges();
            }
            
            // Check if there are any students
            if (context.Students.Any())
            {
                return; // Students have been seeded
            }

            // Seed data
            var students = new Student[]
            {
                new Student
                {
                    Nombre = "Ana García Martínez",
                    Edad = 19,
                    Curso = "Ingeniería Informática",
                    Promedio = 8.7M
                },
                new Student
                {
                    Nombre = "Carlos Rodríguez López",
                    Edad = 21,
                    Curso = "Arquitectura",
                    Promedio = 7.9M
                },
                new Student
                {
                    Nombre = "María Fernández Sánchez",
                    Edad = 20,
                    Curso = "Medicina",
                    Promedio = 9.2M
                },
                new Student
                {
                    Nombre = "Juan Pérez Gómez",
                    Edad = 22,
                    Curso = "Derecho",
                    Promedio = 8.1M
                },
                new Student
                {
                    Nombre = "Laura Díaz Ruiz",
                    Edad = 18,
                    Curso = "Psicología",
                    Promedio = 8.5M
                },
                new Student
                {
                    Nombre = "Miguel Torres Vega",
                    Edad = 23,
                    Curso = "Economía",
                    Promedio = 7.6M
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();
            
            // Nota: Ya no necesitamos asignar cursos a estudiantes mediante CourseId
            // Los estudiantes están relacionados con los cursos mediante el campo Curso (string)
        }
    }
}
