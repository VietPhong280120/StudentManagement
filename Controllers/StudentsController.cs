using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class StudentsController : Controller
    {

        private readonly ApplicationDbContext _context;
        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetData(DataTableParam studentDataTableParam)
        {       
            StudentTableData students = new StudentTableData();

            students.Draw = studentDataTableParam.Draw;
            students.RecordsTotal = _context.Students.Count();
            students.RecordsFiltered = students.RecordsTotal;
            var searchString = studentDataTableParam.Search.Value;
            var studentQuery = _context.Students.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                studentQuery = studentQuery.Where(x=>x.Name.Contains(searchString)||x.Address.Contains(searchString));
            }
            var sort = studentDataTableParam.Order.FirstOrDefault();
            if (sort!=null)
            {
                if (sort.Dir == "asc")
                {
                    switch (sort.Column) {
                        case 1:
                            studentQuery = studentQuery.OrderBy(x => x.DateofBirth);
                            break;
                        case 2 :
                        studentQuery = studentQuery.OrderBy(x => x.PhoneNumber);
                            break;
                        case 3 :
                            studentQuery = studentQuery.OrderBy(x => x.Address);
                            break;
                        default:
                            studentQuery = studentQuery.OrderBy(x => x.Name);
                            break;
                    }
                }
                else
                {
                    switch (sort.Column)
                    {                     
                        case 1:
                            studentQuery = studentQuery.OrderByDescending(x => x.DateofBirth);
                            break;
                        case 2:
                            studentQuery = studentQuery.OrderByDescending(x => x.PhoneNumber);
                            break;
                        case 3:
                            studentQuery = studentQuery.OrderByDescending(x => x.Address);
                            break;
                        default:
                            studentQuery = studentQuery.OrderByDescending(x => x.Name);
                            break;
                    }            
                }

            }
            students.Data = studentQuery.Skip(studentDataTableParam.Start)
                .Take(studentDataTableParam.Length)
                .Select(s => new StudentViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PhoneNumber = s.PhoneNumber,
                    Address = s.Address,
                    DateofBirth = s.DateofBirth,
                    Classes = s.ClassStudents.Select(x => new ClassViewModel()
                    {
                        ClassName = x.Class.ClassName,
                        Id = x.ClassId
                    }).ToList()
                }).ToList();
            return Json(students);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _context.Students.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel model)
        {
            var data = _context.Students.Where(x => x.Id == model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Name = model.Name;
                data.DateofBirth = model.DateofBirth;
                data.PhoneNumber = model.PhoneNumber;
                data.Address = model.Address;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            Student student = _context.Students.Find(id);
            if (student == null)
            {
                return ViewBag();
            }
            return View(student);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Student student = _context.Students.Find(id);
            if (student == null)
            {
                return ViewBag();
            }
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Student student = _context.Students.Find(id);
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("Index");
        }


    }
}
