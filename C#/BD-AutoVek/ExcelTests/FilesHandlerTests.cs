using NUnit.Framework;
using System.IO;
using Excel.Infrastructure;

namespace Excel.Tests
{
    [TestFixture]
    public class FilesHandlerTests
    {
        private DocumentSettings _documentSettings;
        [SetUp]
        public void SetUp()
        {
            _documentSettings = new DocumentSettings();
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(pathFile, true);
        }
        
        [Test]
        public void FilesHandler_TestMissingFolder()
        {
            var pathFile = $"{_documentSettings.PathRootFolder} + .test";
            Directory.CreateDirectory(pathFile);
            var countFolders = FilesHandler.GetCountFolders(_documentSettings);
            Assert.AreEqual(countFolders, "0");
        }

        [Test]
        public void FilesHandler_DoCopyFile()
        {
            const string name = "Misha";
            const string surname = "Olegovich";
        
            var countFolders = FilesHandler.GetCountFolders(_documentSettings);
            
            _documentSettings.SourcePath = 
                @"C:\Users\honor\source\repos\BD-Autovek-\" + 
                @"BD-Autovek-\AgencyPortfolio\Агенский_Портфель_v.3.0.xlsx";
            
            var pathNewFolderAgencyPortfolio =
                $"{_documentSettings.PathRootFolder}\\" +
                $"{countFolders}.{surname}.{name}.Test";
            
            Directory.CreateDirectory(pathNewFolderAgencyPortfolio);
            
            var newAgencyPortfolio = @$"{pathNewFolderAgencyPortfolio}\Агенский_Портфель_{surname}_{name}.xlsx";
            
            var copyFolder = FilesHandler.DoCopyFile(
                newAgencyPortfolio,
                _documentSettings,
                null);
            
            Assert.AreEqual(copyFolder, true);
            var existFile = Directory.Exists($"{pathNewFolderAgencyPortfolio}");
            Assert.AreEqual(existFile, true);
            Directory.Delete(pathNewFolderAgencyPortfolio, true);
        }
    }
}