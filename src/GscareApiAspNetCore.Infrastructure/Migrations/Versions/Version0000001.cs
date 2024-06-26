﻿using FluentMigrator;

namespace GscareApiAspNetCore.Infrastructure.Migrations.Versions;

[Migration(1, "Create initial tables and relationships, add current company to employees and patients")]
public class Version0000001 : Migration
{
    public override void Up()
    {
        // Company Table
        Create.Table("Companies")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("NomeDaEmpresa").AsString(255).NotNullable()
            .WithColumn("Cnpj").AsString(255).NotNullable()
            .WithColumn("TipoDeEscala").AsString(255).NotNullable()
            .WithColumn("ValorPagoMensal").AsString(255).NotNullable()
            .WithColumn("ValorDoPlantaoDaProfissional").AsString(255).NotNullable();

        // Employee Table
        Create.Table("Employees")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("NomeCompleto").AsString(255).NotNullable()
            .WithColumn("Cpf").AsString(255).NotNullable()
            .WithColumn("Identidade").AsString(255).NotNullable()
            .WithColumn("EnderecoComCep").AsString(255).NotNullable()
            .WithColumn("DisponibilidadeDeHorario").AsInt32().NotNullable()
            .WithColumn("FotoIdentidade").AsString(255).Nullable()
            .WithColumn("FotoCpf").AsString(255).Nullable()
            .WithColumn("FotoComprovanteResidencia").AsString(255).Nullable()
            .WithColumn("CertificadoDoCurso").AsString(255).Nullable()
            .WithColumn("Mei").AsString(255).Nullable()
            .WithColumn("NadaConsta").AsString(255).Nullable()
            .WithColumn("CurrentCompanyId").AsInt64().Nullable();

        // Patient Table
        Create.Table("Patients")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("NomeCompleto").AsString(255).NotNullable()
            .WithColumn("Idade").AsInt32().NotNullable()
            .WithColumn("Patologia").AsString(255).NotNullable()
            .WithColumn("EnderecoDeAtendimentoComCep").AsString(255).NotNullable()
            .WithColumn("NomeCompletoDoResponsavelFinanceiro").AsString(255).NotNullable()
            .WithColumn("DataDePagamento").AsString(255).NotNullable()
            .WithColumn("FormaDePagamento").AsString(255).NotNullable()
            .WithColumn("GrauDeParentesco").AsString(255).NotNullable()
            .WithColumn("Identidade").AsString(255).NotNullable()
            .WithColumn("Cpf").AsString(255).NotNullable()
            .WithColumn("Email").AsString(255).NotNullable()
            .WithColumn("Celular").AsString(255).NotNullable()
            .WithColumn("CurrentCompanyId").AsInt64().Nullable();

        // User Table
        Create.Table("Users")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Name").AsString(255).NotNullable()
            .WithColumn("Email").AsString(255).NotNullable()
            .WithColumn("Password").AsString(255).NotNullable()
            .WithColumn("UserType").AsInt32().NotNullable()
            .WithColumn("DateOfBirth").AsDateTime().NotNullable()
            .WithColumn("Gender").AsInt32().NotNullable()
            .WithColumn("Phone").AsString(255).NotNullable()
            .WithColumn("Address").AsString(255).NotNullable()
            .WithColumn("RegistrationDate").AsDateTime().NotNullable()
            .WithColumn("EmployeeId").AsInt64().Nullable()
            .WithColumn("PatientId").AsInt64().Nullable()
            .WithColumn("CompanyId").AsInt64().Nullable();

        Create.ForeignKey("FK_User_Employee")
            .FromTable("Users").ForeignColumn("EmployeeId")
            .ToTable("Employees").PrimaryColumn("Id");

        Create.ForeignKey("FK_User_Patient")
            .FromTable("Users").ForeignColumn("PatientId")
            .ToTable("Patients").PrimaryColumn("Id");

        Create.ForeignKey("FK_User_Company")
            .FromTable("Users").ForeignColumn("CompanyId")
            .ToTable("Companies").PrimaryColumn("Id");

        // DailyReport Table
        Create.Table("DailyReports")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Title").AsString(255).NotNullable()
            .WithColumn("Description").AsString(255).NotNullable()
            .WithColumn("Patient").AsString(255).NotNullable()
            .WithColumn("Employee").AsString(255).NotNullable()
            .WithColumn("Question1").AsBoolean().NotNullable()
            .WithColumn("Question2").AsBoolean().NotNullable()
            .WithColumn("Question3").AsBoolean().NotNullable()
            .WithColumn("Question4").AsBoolean().NotNullable()
            .WithColumn("Question5").AsBoolean().NotNullable();

        // Document Table
        Create.Table("Documents")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("DocumentName").AsString(255).Nullable()
            .WithColumn("DocumentImage").AsString(255).Nullable();

        // Medicament Table
        Create.Table("Medicaments")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(255).NotNullable()
            .WithColumn("Type").AsString(255).NotNullable()
            .WithColumn("Amount").AsString(255).NotNullable()
            .WithColumn("Hours").AsString(255).NotNullable()
            .WithColumn("Frequency").AsString(255).NotNullable();

        // Service Table
        Create.Table("Services")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Patient").AsString(255).NotNullable()
            .WithColumn("Employee").AsString(255).NotNullable()
            .WithColumn("InicioService").AsString(255).NotNullable()
            .WithColumn("FimService").AsString(255).NotNullable()
            .WithColumn("Descricao").AsString(255).Nullable();

        // Supply Table
        Create.Table("Supplies")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Nome").AsString(255).NotNullable()
            .WithColumn("Comentario").AsString(255).NotNullable()
            .WithColumn("Quantidade").AsString(255).NotNullable()
            .WithColumn("Data").AsString(255).NotNullable();

        // Warning Table
        Create.Table("Warnings")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Titulo").AsString(255).NotNullable()
            .WithColumn("AvisoType").AsString(255).NotNullable()
            .WithColumn("DataInicial").AsString(255).NotNullable()
            .WithColumn("DataFinal").AsString(255).NotNullable()
            .WithColumn("Mensagem").AsString(255).NotNullable();

        // Foreign key relationship for CurrentCompanyId
        Create.ForeignKey("FK_Employees_CurrentCompany")
            .FromTable("Employees").ForeignColumn("CurrentCompanyId")
            .ToTable("Companies").PrimaryColumn("Id");

        Create.ForeignKey("FK_Patients_CurrentCompany")
            .FromTable("Patients").ForeignColumn("CurrentCompanyId")
            .ToTable("Companies").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_Employees_CurrentCompany").OnTable("Employees");
        Delete.ForeignKey("FK_Patients_CurrentCompany").OnTable("Patients");

        Delete.ForeignKey("FK_User_Employee").OnTable("Users");
        Delete.ForeignKey("FK_User_Patient").OnTable("Users");
        Delete.ForeignKey("FK_User_Company").OnTable("Users");

        Delete.Table("Warnings");
        Delete.Table("Users");
        Delete.Table("Supplies");
        Delete.Table("Services");
        Delete.Table("Patients");
        Delete.Table("Medicaments");
        Delete.Table("Employees");
        Delete.Table("Documents");
        Delete.Table("DailyReports");
        Delete.Table("Companies");
    }
}
