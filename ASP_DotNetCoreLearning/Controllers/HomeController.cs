using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_DotNetCoreLearning.Models;
using System.IO;
using ExcelDataReader;
using System.Data;

namespace ASP_DotNetCoreLearning.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Reader()
        {
            string filePath = "C:\\Users\\IT228\\Documents\\git\\ASP_DotNetCoreLearning\\ASP_DotNetCoreLearning\\test.xlsx";
            //var stream = System.IO.File.ReadAllLines(filePath);
            var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read);

            // Auto-detect format, supports:
            //  - Binary Excel files (2.0-2003 format; *.xls)
            //  - OpenXml Excel files (2007 format; *.xlsx)
            var reader = ExcelReaderFactory.CreateReader(stream);

            // Choose one of either 1 or 2:

            // 1. Use the reader methods
            do
            {
                while (reader.Read())
                {
                    // reader.GetDouble(0);
                }
            } while (reader.NextResult());

            // 2. Use the AsDataSet extension method
            var result = reader.AsDataSet(
                new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = false
                    }
                }
                );
            DataTable dt = new DataTable();
            dt = result.Tables[0];
            // The result of each spreadsheet is in result.Tables


            return View();
        }
    }
}
