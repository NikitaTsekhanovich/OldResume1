using System;
using Excel.Domain.Services;
using Microsoft.Office.Interop.Excel;

namespace Excel.Domain.Entities.Documents
 {
     public class SaleDirect : Document
     {
         private string[] SheetsExcel { get; }
         private object[] DataSheet1 { get; }
         private object[] DataSheet2 { get; }
         private static DateTime Today { get; }

         public SaleDirect(string name, string surname, string yearBirth,
             string passId, string registration, int indexDocument)
         {
             IndexDocument = indexDocument;

             DataSheet1 = new object[] { 
                     null, 
                     null,
                     "Document", 
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
             DataSheet2 = new object[] { 
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
             Console.WriteLine("Into SaleDirect");
             foreach (var sheet in SheetsExcel)
             {
                 var worksheet = (Worksheet)sheets.get_Item(sheet);
                 if (sheet == "Данные Клиента Продавца и Авто")
                 {
                     for (var row = 1; row < DataSheet1.Length - 1; row++)
                     {
                         if (DataSheet1[row] != null) 
                             worksheet.Cells[row, 2] = DataSheet1[row];
                     }
                 }
                 else
                 {
                     for (var row = 1; row < DataSheet2.Length - 1; row++)
                     {
                         if (DataSheet1[row] != null)   
                            worksheet.Cells[row, 2] = DataSheet2[row];
                     }
                 }
             }
         }
     }
 }