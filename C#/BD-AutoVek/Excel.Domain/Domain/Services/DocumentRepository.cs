using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace Excel.Domain.Services
{
    public abstract class Document : IDisposable
    {
        private Workbook _workbook;
        private Sheets _sheets;
        private readonly Application _excel;
        public int IndexDocument;

        protected Document() 
        {
            // _excel = new Application();
        }
        
        public void DoWorkDocument(string newAgencyPortfolio)
        {
            Open(newAgencyPortfolio);
            WriteTo(_sheets);
            Save();
            Dispose();
        }

        private void Open(string newAgencyPortfolio)
        {
            try { _excel.DisplayAlerts = false; }
            catch (NullReferenceException e) { throw new NullExcelException(e); }
            // catch (NullReferenceException) { _excel = new Application(); }
            _workbook = _excel.Workbooks.Open(newAgencyPortfolio);
            _sheets = _workbook.Worksheets;
        }

        protected abstract void WriteTo(Sheets sheets);

        private void Save()
        {
            _workbook.Save();
        }

        public void Dispose()
        {
            Console.WriteLine("Delete proc");
            
            try
            {
                GetWindowThreadProcessId((IntPtr)_excel.Hwnd, out var processId);
                Process.GetProcessById((int)processId).Kill();
            }
            catch (NullReferenceException e) { throw new NullExcelException(e); }
            // catch (NullReferenceException) { _excel = new Application(); }
        }
        
        [DllImport("user32")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    }

    internal class NullExcelException : Exception
    {
        public NullExcelException(Exception nullReferenceException) : 
            base("_excel is null", nullReferenceException) { }
    }
}