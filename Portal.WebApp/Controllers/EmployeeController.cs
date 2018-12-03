using AutoMapper;
using Porta.DataAccess.Common;
using Porta.DataAccess.Domain;
using Portal.MetaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGenericPattern<Employee> iEmployeeRepository;
        public EmployeeController(IGenericPattern<Employee> employeeRepository)
        {
            this.iEmployeeRepository = employeeRepository;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var empList = Mapper.Map<List<Employee>, List<EmployeeMetaData>>(this.iEmployeeRepository.GetAll().ToList());
            return View(empList);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var emp = Mapper.Map<Employee, EmployeeMetaData>(this.iEmployeeRepository.GetById(id));
            return View(emp);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            var emp = new EmployeeMetaData();
            return View(emp);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeMetaData model)
        {
            try
            {
                // TODO: Add insert logic here
                if (this.ModelState.IsValid)
                {
                    var empMetaData = new EmployeeMetaData
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        MobileNo = model.MobileNo,
                        Email = model.Email,
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        EditStatus = 1
                    };
                    var empAddStatus = this.iEmployeeRepository.Create(Mapper.Map<EmployeeMetaData, Employee>(empMetaData));
                    if (empAddStatus > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Record not updated";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Record not updated";
                    return View(model);
                }

            }
            catch (Exception objEx)
            {
                ViewBag.ErrorMessage = objEx.Message;
                return View(model);
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = Mapper.Map<Employee, EmployeeMetaData>(this.iEmployeeRepository.GetById(id));
            return View(emp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeMetaData model)
        {
            try
            {
                // TODO: Add update logic here
                if (this.ModelState.IsValid)
                {
                    var empDetail = Mapper.Map<Employee, EmployeeMetaData>(this.iEmployeeRepository.GetById(model.EmpId));
                    model.EmpId = empDetail.EmpId;
                    model.CreatedBy = empDetail.CreatedBy;
                    model.CreatedBy = empDetail.CreatedBy;
                    model.ModifiedBy = 1;
                    model.ModifiedDate = DateTime.Now;
                    model.EditStatus = empDetail.EditStatus;
                    var empEditStatus = iEmployeeRepository.Update(Mapper.Map<EmployeeMetaData, Employee>(model));
                    if (empEditStatus > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Record not updated";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Record not updated";
                    return View(model);
                }
            }
            catch (Exception objEx)
            {
                ViewBag.ErrorMessage = objEx.Message;
                return View(model);
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
