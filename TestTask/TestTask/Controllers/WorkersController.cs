using BusinessLogic;
using Common;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TestTask.Controllers
{
    public class WorkersController : Controller
    {
        private readonly WorkersService workersService = new WorkersService();

        private readonly CompaniesService companiesService = new CompaniesService();

        // Display workers list
        public ActionResult GetWorkersList(string errorMessage)
        {
            ViewBag.Title = "Workers list";

            ViewBag.ErrorMessage = errorMessage;

            List<Worker> model;

            try
            {
                model = workersService.GetWorkersList();
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }

            return View(model);
        }

        // Display worker add form
        [HttpGet]
        public ActionResult AddWorker()
        {
            ViewBag.Title = "Add worker";

            WorkerFormModel model;

            try
            {
                model = workersService.CreateWorker();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("GetWorkersList", new { errorMessage = ex.Message });
            }

            return View(model);
        }

        //Save new worker
        [HttpPost]
        public ActionResult AddWorker(WorkerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Companies = companiesService.GetCompaniesList();

                return View(model);
            }

            try
            {
                workersService.SaveWorker(model);
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("GetWorkersList", new { errorMessage = ex.Message });
            }

            return RedirectToAction("GetWorkersList");
        }

        //Display worker edit form
        [HttpGet]
        public ActionResult EditWorker(int? id)
        {
            ViewBag.Title = "Edit worker";

            WorkerFormModel model;

            try
            {
                model = workersService.GetWorkerById(id);
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("GetWorkersList", new { errorMessage = ex.Message });
            }

            return View(model);
        }

        //Save worker changes
        [HttpPost]
        public ActionResult EditWorker(WorkerFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Companies = companiesService.GetCompaniesList();

                return View(model);
            }

            try
            {
                workersService.SaveWorker(model);
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("GetWorkersList", new { errorMessage = ex.Message });
            }

            return RedirectToAction("GetWorkersList");
        }

        //Delete worker
        [HttpGet]
        public ActionResult DeleteWorker(int? id)
        {
            try
            {
                workersService.DeleteWorker(id);
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("GetWorkersList", new { errorMessage = ex.Message });
            }

            return RedirectToAction("GetWorkersList");
        }
    }
}