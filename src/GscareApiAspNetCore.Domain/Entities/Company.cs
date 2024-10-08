﻿namespace GscareApiAspNetCore.Domain.Entities;
public class Company
{
    public long Id { get; set; }
    public string NomeDaEmpresa { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string TipoDeEscala { get; set; } = string.Empty;
    public string ValorPagoMensal { get; set; } = string.Empty;
    public string ValorDoPlantaoDaProfissional { get; set; } = string.Empty;

    // Navigation property
    public User? User { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    public ICollection<Warning> Warnings { get; set; } = new List<Warning>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<Stock> Stocks { get; set; } = new List<Stock>();


}
