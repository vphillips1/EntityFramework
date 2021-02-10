using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockAssessment6Practice.DALModels;
using MockAssessment6Practice.Models;
using MockAssessment6Practice.Services;

namespace MockAssessment6Practice.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRetireDbContext _employeeDbContext;

        public EmployeeController(EmployeeRetireDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        


        public IActionResult Employee()
        {
            return View();
        }

        public IActionResult EmployeeResult(EmployeeViewModel model)
        {

            var employee = new EmployeeDAL();
            employee.FirstName = model.Employees.FirstName;
            employee.Age = model.Employees.Age;
            employee.Salary = model.Employees.Salary;

            _employeeDbContext.Employees.Add(employee);
            _employeeDbContext.SaveChanges();


            var employeeList = _employeeDbContext.Employees
                .Select(employeeDAL => new EmployeeCurrent() {Id=employeeDAL.Id, FirstName = employeeDAL.FirstName, Age = employeeDAL.Age, Salary = employeeDAL.Salary })
                .ToList();

            var viewModel = new EmployeeResultViewModel();
            viewModel.Employees = employeeList;

            return View(viewModel);
        }  
        
        public IActionResult ReturnAllEmployeeResult()
        {

           
            var employeeList = _employeeDbContext.Employees
                .Select(employeeDAL => new EmployeeCurrent() {Id=employeeDAL.Id, FirstName = employeeDAL.FirstName, Age = employeeDAL.Age, Salary = employeeDAL.Salary })
                .ToList();

            var viewModel = new EmployeeResultViewModel();
            viewModel.Employees = employeeList;

            return View("EmployeeResult", viewModel);
        }
        public IActionResult RetirementInfo(int Id)

        {
            var employee = GetEmployeeWhereIdIsFirstOrDefault(Id);

            var model = new RetirementInfoViewModel();
            
            model.Id = Id;
           
                model.Benefits = employee.Salary * 60 / 100;

            if(employee.Age > 60)
            {

                model.CanRetire = true;
            }

            else
            {

                model.CanRetire = false;
            }
            return View(model);


            
        }

        private EmployeeCurrent GetEmployeeWhereIdIsFirstOrDefault(int id)
        {
            EmployeeDAL employeeDAL = _employeeDbContext.Employees
                .Where(employee => employee.Id == id)
                .FirstOrDefault();

            var employee = new EmployeeCurrent();
            employee.FirstName = employeeDAL.FirstName;
            employee.Age = employeeDAL.Age;
            employee.Salary = employeeDAL.Salary;
            return employee;
        }


    }
}
