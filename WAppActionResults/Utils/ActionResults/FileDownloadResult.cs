using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WAppActionResults.Utils.ActionResults
{
    public class FileDownloadResult : ActionResult
    {
        private byte[] _data;
        private string _name;

        public FileDownloadResult(byte[] data, string name)
        {
            _data = data;
            _name = name;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("content-disposition", "attachment;filename=" + _name + ".xlsx");
            var ms = new MemoryStream(_data);
            ms.WriteTo(response.OutputStream);
            ms.Close();
        }
    }
}