using MediaData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetaMedia.Controllers
{
    public class WorksController : Controller
    {

        private readonly DataDBContext _context;

        public WorksController(DataDBContext context)
        {
            _context = context;
        }

        // GET: WorksController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WorksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorksController/Create
        [HttpPost]
        // [ValidateAntiForgeryToken] 
        [HttpPost]
        public ActionResult Create(Work work)
        {
            if (ModelState.IsValid)
            {
                _context.Works.Add(work);
                _context.SaveChanges();

                // Redirigez vers une autre action après la sauvegarde
                return RedirectToAction("Index"); // Changez "Index" par la vue appropriée
            }

            return View(work);
        }


        // GET: WorksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
