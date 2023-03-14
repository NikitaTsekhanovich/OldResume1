using System;
using Excel.Domain.Services;
using Microsoft.Office.Interop.Excel;

namespace Excel.Domain.Entities.Documents
{
    public class TradeIN : Document
    {
        private string[] Data { get; }
        private string SheetExcel { get; }
        private int MaxRow { get; }

        public TradeIN(string name, string surname, string yearBirth,
            string passId, string registration, int indexDocument)
        {
            IndexDocument = indexDocument;
            
            Data = new[] { "123" };
            SheetExcel = "Данные Клиента Продавца и Авто"; 
            MaxRow = 45;
        }

        protected override void WriteTo(Sheets sheets)
        {
            Console.WriteLine("Into TradeIN");
            
            var worksheet = (Worksheet)sheets.get_Item(SheetExcel);
            for (var row = 1; row <= MaxRow; row++)
            {
                if (row != 32)
                    worksheet.Cells[row, 2] = Data[0];
            }
        }
        //public продажа/покупка по прямой договор: до 29 заполняется и заполняются данные продажи до 19 и печать 3 экз
        // прием по прямому и ставим на комиссию: ДКП прямой полностью, ДКП прямой прием (при комиссии) (м б с комис может без)
        // закрывашки: закрывашки
        // трейд ин с пробегом: ДКП прямой, данные продажи,
    }
}
