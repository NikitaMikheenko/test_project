using BusinessLogic;
using Common;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TestTask.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly CompaniesService companiesService = new CompaniesService();

        // Display companies list
        public ActionResult GetCompaniesList(string errorMessage)
        {
            ViewBag.Title = "Companies list";

            ViewBag.ErrorMessage = errorMessage;

            List<Company> model;

            try
            {
                model = companiesService.GetCompaniesList();
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }

            return View(model);
        }

        // Display company add form
        [HttpGet]
        public ActionResult AddCompany()
        {
            ViewBag.Title = "Add company";

            Company model;

            try
            {
                model = companiesService.CreateCompany();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("GetCompaniesList", new { errorMessage = ex.Message });
            }

            return View(model);
        }

        //Save new company
        [HttpPost]
        public ActionResult AddCompany(Company model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                companiesService.SaveCompany(model);
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("GetCompaniesList", new { errorMessage = ex.Message });
            }

            return RedirectToAction("GetCompaniesList");
        }

        //Display company edit form
        [HttpGet]
        public ActionResult EditCompany(int? id)
        {
            ViewBag.Title = "Edit company";

            Company model;

            try
            {
                model = companiesService.GetCompanyById(id);
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("GetCompaniesList", new { errorMessage = ex.Message });
            }

            return View(model);
        }

        //Save company changes
        [HttpPost]
        public ActionResult EditCompany(Company model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                companiesService.SaveCompany(model);
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("GetCompaniesList", new { errorMessage = ex.Message });
            }

            return RedirectToAction("GetCompaniesList");
        }

        //Delete company
        [HttpGet]
        public ActionResult DeleteCompany(int? id)
        {
            try
            {
                companiesService.DeleteCompany(id);
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("GetCompaniesList", new { errorMessage = ex.Message });
            }

            return RedirectToAction("GetCompaniesList");
        }
    }
}