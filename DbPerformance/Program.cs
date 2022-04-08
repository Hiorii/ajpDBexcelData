// See https://aka.ms/new-console-template for more information

using DbPerformance;
using DbPerformance.Services;

Console.WriteLine("Time measurements start");

var data= FileService.ReadExcelFileData(@"C:\Users\Admin\Desktop\AJP\Semestr 2\Czerwiec\Lab1\kody.csv");

// PerformanceService.ManyConnectionSingleData(data);
// PerformanceService.OneConnectionAllData(data);
//PerformanceService.BulkCopy(data);
PerformanceService.EntityFrameworkOneByOne(data);
// PerformanceService.EntityFrameworkAddAllAtOnce(data);
//PerformanceService.EntityFrameworkAddByPackageSize(data);
Console.WriteLine("Time measurements stop");
