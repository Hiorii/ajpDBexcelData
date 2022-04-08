using System.ComponentModel.DataAnnotations.Schema;

namespace DbPerformance.Models;

[Table("Kody_Pocztowe")]
public class ExcelDataModel
{
    [Column("KOD_POCZTOWY")]
    public string KodPocztowy { get; set; }

    [Column("ADRES")]
    public string Adres { get; set; }

    [Column("MIEJSCOWOSC")]
    public string Miejscowosc { get; set; }

    [Column("WOJEWODZTWO")]
    public string Wojewodztwo { get; set; }

    [Column("POWIAT")]
    public string Powiat { get; set; }

    public ExcelDataModel(string kodPocztowy, string adres, string miejscowosc, string wojewodztwo, string powiat)
    {
        KodPocztowy = kodPocztowy;
        Adres = adres;
        Miejscowosc = miejscowosc;
        Wojewodztwo = wojewodztwo;
        Powiat = powiat;
    }
}