using System;
using Excel.Domain.Services;
using Microsoft.Office.Interop.Excel;

namespace Excel.Domain.Entities.Documents
{
    public class Result : Document
    {
        private string[] SheetsExcel { get; }
        private object[] DataSheet1 { get; }
        private object[] DataSheet2 { get; }
        private static DateTime Today { get; }

        public Result(string name, string surname, string yearBirth,
            string passId, string registration, int indexDocument)
        {
            IndexDocument = indexDocument;
            
            DataSheet1 = new object[]
            {
                null,
                null,
                "Result",
                passId,
                Today,
                null,
                name + " " + surname,
                name + " " + surname,
                yearBirth,
                yearBirth,
                null,
                registration,
                registration,
                registration,
                registration,
                registration,
                89123,
                registration,
                null,
                12223
            };
            DataSheet2 = new object[]
            {
                null,
                null,
                "Екатеринбург",
                Today,
                null,
                name + " " + surname,
                name + " " + surname,
                yearBirth,
                registration
            };
            SheetsExcel = new[] {"Данные Клиента Продавца и Авто","Данные Продажи"};
    }

        protected override void WriteTo(Sheets sheets)
        {
            Console.WriteLine("Into Result");

            try
            {
                foreach (var sheet in SheetsExcel)
                {
                    var worksheet = (Worksheet)sheets.Item[sheet];
                    if (sheet == "Данные Клиента Продавца и Авто")
                    {
                        try
                        { 
                            for (var row = 1; row < DataSheet1.Length - 1; row++)
                            {
                                if (DataSheet1[row] != null) 
                                    worksheet.Cells[row, 2] = DataSheet1[row];
                            } 
                        }
                        catch (NullReferenceException e) { throw new NullDataException(e); }
                    }
                    else
                    {
                        try
                        {
                            for (var row = 1; row < DataSheet2.Length - 1; row++)
                            {
                                if (DataSheet2[row] != null)
                                    worksheet.Cells[row, 2] = DataSheet2[row];
                            }
                        }
                        catch (NullReferenceException e) { throw new NullDataException(e); }
                    }
                }
            }
            catch (NullReferenceException e) { throw new NullSheetException(e); }
        }
    }

    internal class NullDataException : Exception
    {
        public NullDataException(Exception nullDataException) :
            base("Документ не может быть заполнен, так как значение данных пустое", 
                nullDataException) { }
    }
    
    internal class NullSheetException : Exception
    {
        public NullSheetException(Exception nullSheetException) :
            base("Документ не может быть заполнен, так как нет значения листов excel", 
                nullSheetException) { }
    }
}