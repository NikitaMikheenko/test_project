using Common;
using DataAccess;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class WorkersService
    {
        private readonly WorkersContext workersContext = new WorkersContext();

        private readonly CompaniesContext companiesContext = new CompaniesContext();

        public List<Worker> GetWorkersList()
        {
            return workersContext.GetWorkersList();
        }

        public WorkerFormModel CreateWorker()
        {
            return new WorkerFormModel()
            {
                Worker = new Worker()
                {
                    Id = workersContext.CreateWorker()
                },
                Companies = companiesContext.GetCompaniesList() ?? throw new Exception("Companies not found!")
            };
        }

        public WorkerFormModel GetWorkerById(int? id)
        {
            if (id == null)
            {
                throw new Exception("Invalid id!");
            }

            return new WorkerFormModel()
            {
                Worker = workersContext.GetWorkerById((int)id),
                Companies = companiesContext.GetCompaniesList(),
            };
        }

        public void SaveWorker(WorkerFormModel model)
        {
            model.Worker.Company = new Company()
            {
                Id = model.CompanyId
            };

            /*if (model.Worker.MiddleName == null)
            {
                model.Worker.MiddleName = "NULL";
            }*/

            workersContext.SaveWorker(model.Worker);
        }

        public void DeleteWorker(int? id)
        {
            if (id == null)
            {
                throw new Exception("Invalid id!");
            }

            workersContext.DeleteWorker((int)id);
        }
    }
}
