// using System;
// using NUnit.Framework;
//
// namespace Server.Tests
// {
//     public class DbRequestTests
//     {
//         private DataBase Db;
//         [SetUp]
//         public void InitDb()
//         {
//             Db = new DataBase();
//         }
//         
//         [TestCase("SELECT * FROM clients WHERE client_id = 1")]
//         [Test]
//         public void MakeRequest(string reqString)
//         {
//             var res = Db.MakeRequest(reqString);
//             Console.WriteLine(res);
//             Assert.Pass();
//         }
//     }
// }