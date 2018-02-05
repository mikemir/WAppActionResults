using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WAppActionResults.Utils.ActionResults
{
    public class ImageWatemarkResult : ActionResult
    {
        public ImageWatemarkResult(string imagepath, string text)
        {

        }
        public override void ExecuteResult(ControllerContext context)
        {
            var image = new WebImage("~/Content/Images/test.jpg").AddTextWatermark(
                text: "Hola mundo",     
                fontSize: 20,
                fontColor: "white",
                horizontalAlign: "center",
                opacity: 80);

            image.Write();
        }
    }
}