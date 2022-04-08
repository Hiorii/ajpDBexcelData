using System.Data.Common;
using System.Data.SqlClient;
using DbPerformance.EntityFramework;
using DbPerformance.Models;
using Microsoft.EntityFrameworkCore;

namespace DbPerformance.Services;

public static class DbServices
{
    public static string conn = @"Data Source=DESKTOP-HR9D125; Integrated Security= true";

    public static void AddSingleRow(ExcelDataModel excelDataModel)
    {
        using SqlConnection connection = new SqlConnection(conn);
        connection.Open();
        var cmd = new SqlCommand(
            "INSERT INTO ajp_lab.dbo.Kody_Pocztowe (KOD_POCZTOWY, ADRES, MIEJSCOWOSC, WOJEWODZTWO, POWIAT) VALUES (@KodPocztowy, @Adres, @Miejscowosc, @Wojewodztwo, @Powiat)");
        cmd.Parameters.AddWithValue("@KodPocztowy", excelDataModel.KodPocztowy);
        cmd.Parameters.AddWithValue("Adres", excelDataModel.Adres);
        cmd.Parameters.AddWithValue("Miejscowosc", excelDataModel.Miejscowosc);
        cmd.Parameters.AddWithValue("Wojewodztwo", excelDataModel.Wojewodztwo);
        cmd.Parameters.AddWithValue("Powiat", excelDataModel.Powiat);

        cmd.Connection = connection;
        cmd.ExecuteNonQuery();
        connection.Close();
    }

    public static void AddSingleRow(ExcelDataModel excelDataModel, SqlConnection connection)
    {
        var cmd = new SqlCommand(
            "INSERT INTO ajp_lab.dbo.Kody_Pocztowe (KOD_POCZTOWY, ADRES, MIEJSCOWOSC, WOJEWODZTWO, POWIAT) VALUES (@KodPocztowy, @Adres, @Miejscowosc, @Wojewodztwo, @Powiat)");
        cmd.Parameters.AddWithValue("@KodPocztowy", excelDataModel.KodPocztowy);
        cmd.Parameters.AddWithValue("Adres", excelDataModel.Adres);
        cmd.Parameters.AddWithValue("Miejscowosc", excelDataModel.Miejscowosc);
        cmd.Parameters.AddWithValue("Wojewodztwo", excelDataModel.Wojewodztwo);
        cmd.Parameters.AddWithValue("Powiat", excelDataModel.Powiat);

        cmd.Connection = connection;
        cmd.ExecuteNonQuery();
    }

    public static void BulkCopy(DbDataReader rows)
    {
        using SqlConnection connection = new SqlConnection(conn);
        connection.Open();
        using (System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(connection))
        {
            bulkCopy.DestinationTableName = "ajp_lab.dbo.Kody_Pocztowe";
            bulkCopy.WriteToServer(rows);
        }

        connection.Close();
    }
    
    public static void AdSingleEntityFramework(ExcelDataModel excelDataModel)
    {
        using var context = new EfDbContext();
        context.Kody.Add(excelDataModel);
        context.SaveChanges();
    }
    
    public static void AddFullDataEntityFramework(List<ExcelDataModel> models)
    {
        using var context = new EfDbContext();
        foreach (var model in models)
        {
            context.Kody.Add(model);    
        }
        context.SaveChanges();
    }
    
    public static void AddOnePackageEntityFramework(List<ExcelDataModel> models)
    {
        using var context = new EfDbContext();
        for (var index = 0; index < models.Count; index++)
        {
            var model = models[index];
            context.Kody.Add(model);
            if (index % 1000 == 0) context.SaveChanges();
        }
        context.SaveChanges();
    }
}