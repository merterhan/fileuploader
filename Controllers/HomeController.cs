using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upload()
        {
            HttpFileCollectionBase files = Request.Files;

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                string path = Server.MapPath("~") + "Uploads\\" + file.FileName;
                file.SaveAs(path);
            }            

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}