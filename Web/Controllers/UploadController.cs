using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F;
using F.Web.Models;

namespace Web.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Print(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var dto = Helper.LoadFromStream(file.InputStream);

                using (var db = new ApplicationDbContext())
                {
                    var row = new DbApplyRequest
                    {
                        FullName = dto.FullName,
                        Age = dto.Age,
                        Filled = dto.Filled,
                    };

                    /*row.WayPoints = new Collection<DbWayPoint>();

                    foreach (var wpDto in dto.WayPoints)
                    {
                        row.WayPoints.Add(new DbWayPoint
                        {
                            Address = wpDto.Address,
                            Type = (Models.WayPointType)(int)wpDto.Type
                        });
                    }*/

                    db.ApplyRequests.Add(row);
                    db.SaveChanges();
                }
                return View(dto);
            }
            return RedirectToAction("Index");
        }
    }
}