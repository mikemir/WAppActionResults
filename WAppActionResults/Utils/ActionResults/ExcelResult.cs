using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WAppActionResults.Utils.ActionResults
{
    public class ExcelResult : ActionResult
    {
        public ExcelResult(string name, IEnumerable<object> data)
        {
            _name = name;
            _data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (_data == null | !_data.Any())
                return;

            var response = context.HttpContext.Response;
            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("content-disposition", "attachment;filename=" + _name + ".xlsx");

            using (var stream = CreateExcelFile(_name, _data))
            {
                stream.WriteTo(response.OutputStream);
            }

        }

        public IEnumerable<object> _data { get; set; }
        public string _name { get; set; }


        private MemoryStream CreateExcelFile(string name, IEnumerable<object> data)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet(name);
            var row = 1;
            var col = 1;

            var type = data.First().GetType();
            var props = type.GetProperties();

            foreach (var prop in props)
            {
                var cell = worksheet.Cell(row, col++);
                cell.Value = prop.Name;
                cell.Style.Font.Bold = true;
                cell.Style.Font.FontColor = XLColor.Blue;
            }

            foreach (var elem in data)
            {
                row++;
                col = 1;
                foreach (var prop in props)
                {
                    var cell = worksheet.Cell(row, col++);
                    cell.Value = prop.GetValue(elem, null);
                }

            }
            worksheet.Columns().AdjustToContents();

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            return memoryStream;
        }

        public static byte[] Generar(IEnumerable<object> data, string name)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet(name);
            var row = 1;
            var col = 1;

            var type = data.First().GetType();
            var props = type.GetProperties();

            foreach (var prop in props)
            {
                var cell = worksheet.Cell(row, col++);
                cell.Value = prop.Name;
                cell.Style.Font.Bold = true;
                cell.Style.Font.FontColor = XLColor.Blue;
            }

            foreach (var elem in data)
            {
                row++;
                col = 1;
                foreach (var prop in props)
                {
                    var cell = worksheet.Cell(row, col++);
                    cell.Value = prop.GetValue(elem, null);
                }

            }
            worksheet.Columns().AdjustToContents();

            MemoryStream memoryStream = new MemoryStream();
            workbook.SaveAs(memoryStream);
            return memoryStream.ToArray();
        }
    }
}