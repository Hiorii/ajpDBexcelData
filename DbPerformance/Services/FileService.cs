using DbPerformance.Models;

namespace DbPerformance.Services;

public static class FileService
{
    public static List<ExcelDataModel> ReadExcelFileData(string path)
    {
        var lines = File.ReadAllLines(path);
        return (from line in lines.Where((t, index) => index != 0)
            select line.Split(';')
            into columns
            let x = columns[0].Trim()
            select new ExcelDataModel(columns[0].Trim(), columns[1].Trim(), columns[2].Trim(), columns[3].Trim(),
                columns[4].Trim())).ToList();
    }
}