namespace Excel.Infrastructure
{
    public class DocumentSettings
    {
        public string SourcePath;
        public readonly string PathRootFolder;
        public readonly int[] ContractTypes;

        public DocumentSettings()
        {
            SourcePath = @"AgencyPortfolio\Агенский_Портфель_v.3.0.xlsx";
            PathRootFolder = @"D:\Agreements";
            ContractTypes = new[] { 0, 1, 2 };
        }
    }
}