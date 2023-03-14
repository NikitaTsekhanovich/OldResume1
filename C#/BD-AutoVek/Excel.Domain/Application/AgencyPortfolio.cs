using System;
using System.Collections.Generic;
using Excel.Domain.Entities;
using Excel.Domain.Entities.Documents;
using Excel.Domain.Services;

namespace Excel.Infrastructure
{
    public class AgencyPortfolio : Client
    {
        private readonly HashSet<Document> _documents = new HashSet<Document>();
        private readonly DocumentSettings _documentSettings = new DocumentSettings();

        public AgencyPortfolio(string name, string surname, string yearBirth,
            string passId, string registration) : 
            base(name, surname, yearBirth, passId, registration)
        {
            // _documents.Add(new SaleDirect(name, surname, yearBirth, passId, registration, indexDocument:0));
            _documents.Add(new TradeIN(name, surname, yearBirth, passId, registration, indexDocument:1));
            _documents.Add(new Result(name, surname, yearBirth, passId, registration, indexDocument:2));
        }

        public void CreateAgencyPortfolio(int typeContract)
        {
            try
            { 
                var countFolders = FilesHandler.GetCountFolders(_documentSettings);
                var newAgencyPortfolio = FilesHandler.GetPathFile
                    (_documentSettings, Name, Surname, _documents, countFolders);

                if (_documentSettings.ContractTypes.Length != _documents.Count)
                { throw new DocumentLossException() } 
                CreateDocument(typeContract, newAgencyPortfolio);
            }
            catch (DocumentLossException e)
            {
                ExceptionHandler.CloseProcess(_documents);
                throw;
            }
        }

        private void CreateDocument(int typeContract, string newAgencyPortfolio)
        {
            foreach (var document in _documents)
            {
                if (document.IndexDocument == typeContract)
                    document.DoWorkDocument(newAgencyPortfolio);
                else
                    document.Dispose();
            }
        }
    }

    internal class DocumentLossException : Exception
    {
        private string exc = @"Ожидалось количество документов " $"{_documentSettings.ContractTypes.Length}, было получено {_documents.Count}");
        public DocumentLossException(Exception documentLossException) :
            base("Нарушена целостность HashSet<Document> _documents",
                documentLossException) { }
    }
}