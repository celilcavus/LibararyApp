using Dapper;
using LibararyApp.Models;
using LibararyApps.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibararyApps.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly DatabaseInfo databaseInfo = new();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(Authors authors)
        {
            databaseInfo.Connection().Execute($"INSERT INTO AUTHORS (NAME, LASTNAME, MAIL, BIRTHDATE, CREATEDDATE, UPDATEDDATE, ISACTIVE) VALUES ('{authors.NAME}'," +
                $"'{authors.LASTNAME}'," +
                $"'{authors.MAIL}'," +
                $"'{authors.BIRTHDATE.ToString("yyyy-MM-dd")}'," +
                $"'{authors.CREATEDDATE.ToString("yyyy-MM-dd")}'," +
                $"'{authors.UPDATEDDATE.ToString("yyyy-MM-dd")}'," +
                $"'{authors.ISACTIVE}')");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = databaseInfo.Connection().Query<Authors>("SELECT * FROM AUTHORS").ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var findValue = databaseInfo.Connection().QueryFirst<Authors>($"SELECT * FROM AUTHORS WHERE ID = {id}");
            return View(findValue);
        }
        [HttpPost]
        public IActionResult Update(Authors authors)
        {
            var findValue = databaseInfo.Connection().Execute(@$"UPDATE [AUTHORS]
               SET [NAME] = '{authors.NAME}'
                  ,[LASTNAME] = '{authors.LASTNAME}'
                  ,[MAIL] = '{authors.MAIL}'
                  ,[BIRTHDATE] = '{authors.BIRTHDATE.ToString("yyyy-MM-dd")}'
                  ,[UPDATEDDATE] = '{DateTime.Now.ToString("yyyy-MM-dd")}'
                  ,[ISACTIVE] = '{authors.ISACTIVE}'
             WHERE ID = {authors.ID}");
            return RedirectToAction(nameof(GetList));
        }

        [HttpGet]
        public IActionResult Delete([FromRoute]int id)
        {
            var delvalue = databaseInfo.Connection().Execute($"DELETE FROM AUTHORS WHERE ID = {id}");
            return RedirectToAction(nameof(GetList));
        }
    }
}
