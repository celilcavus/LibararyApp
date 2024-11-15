using Dapper;
using LibararyApp.Models;
using LibararyApps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibararyApps.Controllers
{
    public class BooksController : Controller
    {
        private readonly DatabaseInfo database = new();
        private void GetAuthors()
        {
            var values = database.Connection().Query<Authors>("SELECT * FROM AUTHORS").Where(y => y.ISACTIVE = true).Select(x => new SelectListItem
            {
                Value = x.ID + "",
                Text = string.Concat(x.NAME, " ", x.LASTNAME),
            }).ToList();


            ViewBag.Authors = values;

        }
        [HttpGet]
        public IActionResult Index()
        {
            GetAuthors();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Books books)
        {
            GetAuthors();

            database.Connection().Execute(@$"INSERT INTO BOOKS (NAME, PAGE, CREATEDDATE, UPDATEDDATE, ISACTIVE, AUTHORSID) VALUES 
            (
            '{books.NAME}',
             {books.PAGE},
            '{books.CREATEDDATE.ToString("yyyy-MM-dd")}',
            '{books.UPDATEDDATE.ToString("yyyy-MM-dd")}',
            '{books.ISACTIVE}',
             {books.AUTHORSID})");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = database.Connection().Query<BooksAndAuthors>("SELECT * FROM BOOKANDAUTHORSVIEW").ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            GetAuthors();
            var values = database.Connection().QueryFirst<Books>($"SELECT * FROM BOOKS WHERE ID = {id}");
            return View(values);
        }
        [HttpPost]
        public IActionResult Update(Books book)
        {
            database.Connection().Execute(@$"UPDATE [BOOKS]
               SET [NAME] ='{book.NAME}'
                  ,[PAGE] = '{book.PAGE}'
                  ,[UPDATEDDATE] = '{DateTime.Now.ToString("yyyy-MM-dd")}'
                  ,[ISACTIVE] = '{book.ISACTIVE}'
                  ,[AUTHORSID] = '{book.AUTHORSID}'
             WHERE ID = '{book.ID}'");
            return RedirectToAction(nameof(GetList));
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            database.Connection().Execute($"DELETE FROM BOOKS WHERE ID ={id}");
            return RedirectToAction(nameof(GetList));
        }

    }
}
