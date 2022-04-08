using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using DbPerformance.Models;

namespace DbPerformance.Services;

public static class PerformanceService
{
    public static void ManyConnectionSingleData(List<ExcelDataModel> rows)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        foreach (var row in rows)
        {
            DbServices.AddSingleRow(row);
        }

        stopwatch.Stop();
        
        TimeSpan t = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", 
            t.Hours, 
            t.Minutes, 
            t.Seconds, 
            t.Milliseconds);
            
        Console.WriteLine("Czas wykonania ManyConnectionSingleData to:" + answer);
        Console.ReadLine();
    }

    public static void OneConnectionAllData(List<ExcelDataModel> rows)
    {
        var stopwatch = new Stopwatch();

        using SqlConnection connection = new SqlConnection(DbServices.conn);
        connection.Open();
        stopwatch.Start();
        foreach (var row in rows)
        {
            DbServices.AddSingleRow(row, connection);
        }

        connection.Close();
        stopwatch.Stop();
        
        TimeSpan t = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", 
            t.Hours, 
            t.Minutes, 
            t.Seconds, 
            t.Milliseconds);
            
        Console.WriteLine("Czas wykonania OneConnectionAllData to:" + answer);
        Console.ReadLine();
    }

    public static void BulkCopy(List<ExcelDataModel> rows)
    {
        var stopwatch = new Stopwatch();
        
        var dt = ConverService.ToDataTable(rows);
        var dataReader = new DataTableReader(dt);
        
        stopwatch.Start();
        DbServices.BulkCopy(dataReader);


        stopwatch.Stop();
        
        TimeSpan t = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", 
            t.Hours, 
            t.Minutes, 
            t.Seconds, 
            t.Milliseconds);
            
        Console.WriteLine("Czas wykonania BulkCopy to:" + answer);
        Console.ReadLine();
    }
    
    public static void EntityFrameworkOneByOne(List<ExcelDataModel> rows)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        foreach (var row in rows)
        {
            DbServices.AdSingleEntityFramework(row);
        }
        stopwatch.Stop();
        
        TimeSpan t = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", 
            t.Hours, 
            t.Minutes, 
            t.Seconds, 
            t.Milliseconds);
            
        Console.WriteLine("Czas wykonania EntityFrameworkOneByOne to:" + answer);
        Console.ReadLine();
    }
    
    public static void EntityFrameworkAddAllAtOnce(List<ExcelDataModel> rows)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        DbServices.AddFullDataEntityFramework(rows);
        stopwatch.Stop();
        
        TimeSpan t = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", 
            t.Hours, 
            t.Minutes, 
            t.Seconds, 
            t.Milliseconds);
            
        Console.WriteLine("Czas wykonania EntityFrameworkAddAllAtOnce to:" + answer);
        Console.ReadLine();
    }
    
    public static void EntityFrameworkAddByPackageSize(List<ExcelDataModel> rows)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        DbServices.AddOnePackageEntityFramework(rows);
        stopwatch.Stop();
        
        TimeSpan t = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", 
            t.Hours, 
            t.Minutes, 
            t.Seconds, 
            t.Milliseconds);
            
        Console.WriteLine("Czas wykonania EntityFrameworkAddByPackageSize to:" + answer);
        Console.ReadLine();
    }
}