using System.Collections.Generic;
using Excel.Domain.Services;

namespace Excel.Infrastructure
{
    public static class ExceptionHandler
    {
        public static void CloseProcess(HashSet<Document> documents)
        {
            foreach (var document in documents)
                document.Dispose();
        }
    }
}