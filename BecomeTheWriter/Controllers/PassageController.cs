using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BecomeTheWriter.Models;

namespace BecomeTheWriter.Controllers
{
    public class PassageController : Controller
    {
        // GET: Passage
        public ActionResult All()
        {
            return View(GeneratePassage());
        }

        public ActionResult CreatePassage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePassage(Passage passage)
        {
            const string passagesPattern = "passage-";
            var passagesKey = Request.Form.AllKeys.Where(x => x.Contains(passagesPattern));
            foreach (var passageKey in passagesKey)
            {
                int id = int.Parse(passageKey.Substring(passagesPattern.Length));
                passage.After.Add(GeneratePassage().First(x=>x.Id == id));
            }
            return View(passage);
        }

        public JsonResult GetAllPassage()
        {
            var passagesTextAndId = GeneratePassage().Select(x => new { id = x.Id, text = x.Text });
            return new JsonResult
            {
                Data = passagesTextAndId,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        private List<Passage> GeneratePassage()
        {
            var result = new List<Passage>();

            result.Add(new Passage(1, "Я супер мен и это моя история. Она началась..."));

            result.Add(new Passage(2, "Я домохозяйка и это моя история. Она началась..."));

            result.Add(new Passage(3, "Я обычное комнатное растение и это моя история. Она началась..."));

            return result;
        }
    }
}