using CsvHelper;
using CsvLeituraEscrita;
using System.Globalization;

Console.WriteLine("Lendo CSV");

var path = @"C:\Users\ana_a\Documents\";
var result = new List<NovosDados>();

using (var reader = new StreamReader($"{path}arquivo.csv", System.Text.Encoding.Latin1))
{
    using(var csvLeitor = new CsvReader(reader, new CultureInfo("pt-BR", true)))
    {
        var records = csvLeitor.GetRecords<DadosCsv>();

        foreach(var item in records)
        {
            result.Add(new NovosDados
            {
                Id = item.Id,
                Nome = item.Nome,
                Resultado = Convert.ToInt32(item.Id) % 2 == 0 ? "Par" : "Ímpar"
            });
        }
    }
}

Console.WriteLine("Gravando CSV");

using (var writer = new StreamWriter($"{path}novo_arquivo.csv", false, System.Text.Encoding.UTF8))
{
    using (var csvGravador = new CsvWriter(writer, new CultureInfo("pt-BR", true)))
    {
        csvGravador.WriteRecords(result);
    }
}
