using System;
using System.Collections.Generic;
using System.IO;
using Excel.Domain.Services;

namespace Excel.Infrastructure
{
    public static class FilesHandler 
    {
        public static bool DoCopyFile(
            string newAgencyPortfolio, 
            DocumentSettings documentSettings,
            HashSet<Document> documents)
        {
            try
            {
                File.Copy(documentSettings.SourcePath, newAgencyPortfolio);
            }
            catch (FileNotFoundException e)
            {
                ExceptionHandler.CloseProcess(documents);
                throw new AgencyPortfolioNotFoundException(e);
            }
            return true;
        }
        
        public static string GetCountFolders(DocumentSettings documentSettings)
        {
            var countFolders = "0";
            
            try
            {
                countFolders = new DirectoryInfo(documentSettings.PathRootFolder)
                    .GetDirectories().Length.ToString();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine
                ("Папка создана на диске D.\n" +
                 "Название папки: Agreements.\n" +
                 "Полный путь: D:\\Agreements.\n" +
                 "Все документы будут записываться в эту папку."
                );
            }
            return countFolders;
        }
        
        public static string GetPathFile(
            DocumentSettings documentSettings, 
            string name, 
            string surname, 
            HashSet<Document> documents,
            string countFolders)
        {
            var pathNewFolderAgencyPortfolio =
                $"{documentSettings.PathRootFolder}\\" +
                $"{countFolders}.{surname}.{name}";
            
            Directory.CreateDirectory(pathNewFolderAgencyPortfolio);
            
            var newAgencyPortfolio = @$"{pathNewFolderAgencyPortfolio}\Агенский_Портфель_{surname}_{name}.xlsx";

            if (DoCopyFile(newAgencyPortfolio, documentSettings, documents)) 
                return newAgencyPortfolio;
            return null;
        }
    }
    
    public class AgencyPortfolioNotFoundException : Exception
    {
        public AgencyPortfolioNotFoundException(Exception agencyPortfolioNotFoundException) : 
            base(@"Агенский_Портфель_v.3.0.xlsx не найден по пути AgencyPortfolio\Агенский_Портфель_v.3.0.xlsx", 
                agencyPortfolioNotFoundException) { }
    }
}