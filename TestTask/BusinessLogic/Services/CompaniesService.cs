using Common;
using DataAccess;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class CompaniesService
    {
        private readonly CompaniesContext companiesContent = new CompaniesContext();

        public List<Company> GetCompaniesList()
        {
            return companiesContent.GetCompaniesList();
        }

        public Company CreateCompany()
        {
            return new Company()
            {
                Id = companiesContent.CreateCompany()
            };
        }

        public Company GetCompanyById(int? id)
        {
            if (id == null)
            {
                throw new Exception("Invalid id!");
            }

            return companiesContent.GetCompanyById((int)id);
        }

        public void SaveCompany(Company model)
        {
            companiesContent.SaveCompany(model);
        }

        public void DeleteCompany(int? id)
        {
            if (id == null)
            {
                throw new Exception("Invalid id!");
            }

            companiesContent.DeleteCompany((int)id);
        }
    }
}
