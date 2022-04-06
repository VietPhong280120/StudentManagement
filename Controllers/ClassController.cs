using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    

    public class ClassController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult GetData(DataTableParam dataTableParam)
        {

            ClassTableData classes = new ClassTableData();

            classes.Draw = dataTableParam.Draw;
            classes.RecordsTotal = _context.Classes.Count();
            classes.RecordsFiltered = classes.RecordsTotal;
            var searchString = dataTableParam.Search.Value;
            var classQuery = _context.Classes.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                classQuery = classQuery.Where(x => x.ClassName.Contains(searchString));
            }
            var sort = dataTableParam.Order.FirstOrDefault();
            if (sort != null)
            {
                if (sort.Dir == "asc")
                {
                    switch (sort.Column)
                    {
                        case 1:
                            classQuery = classQuery.OrderBy(x => x.ClassName);
                            break;
                        case 2:
                            classQuery = classQuery.OrderBy(x => x.Amount);
                            break;                       
                    }
                }
                else
                {
                    switch (sort.Column)
                    {
                        case 1:
                            classQuery = classQuery.OrderByDescending(x => x.ClassName);
                            break;
                        case 2:
                            classQuery = classQuery.OrderByDescending(x => x.Amount);
                            break;
                    }
                }

            }
            classes.Data = classQuery.Skip(dataTableParam.Start).Take(dataTableParam.Length).Select(s => new ClassViewModel()
            {
                Id = s.Id,
                ClassName = s.ClassName,
                Description = s.Description,
                Amount = s.Amount,

            }).ToList();
            return Json(classes);
        }
        [HttpGet]
       public IActionResult Create()
        {
            return View();
        }
        
       [HttpPost]
       public async Task<IActionResult> Create(ClassViewModel classes)
        {   
            if(ModelState.IsValid)
            {
                
                IList<ClassStudent> classStudents = new List<ClassStudent>();
                foreach (int studentId in classes.StudentIds)
                {
                    classStudents.Add(new ClassStudent {StudentId=studentId, ClassId = classes.Id });
                }
                var MyClass = new Class()
                {
                    Id=classes.Id,
                    ClassName=classes.ClassName,
                    Amount=classes.Amount,
                    Description=classes.Description,
                    ClassStudents = classStudents
                };
                _context.Classes.Add(MyClass);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }    
            return View(classes);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var data = await _context.Classes.Include(x=>x.ClassStudents).FirstOrDefaultAsync(x=>x.Id==Id);

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ClassViewModel model)
        {
           
            var data = _context.Classes.Include(x=>x.ClassStudents).Where(x=>x.Id==model.Id).FirstOrDefault();

            _context.RemoveRange(data.ClassStudents);
            await _context.SaveChangesAsync();
            IList<ClassStudent> classStudents = new List<ClassStudent>();
            if (model.StudentIds != null)
            {
                foreach (int studentId in model.StudentIds)
                {
                    classStudents.Add(new ClassStudent { StudentId = studentId, ClassId = model.Id });
                }
            }
                if (data != null)
                {
                    data.ClassName = model.ClassName;
                    data.Description = model.Description;
                    data.Amount = model.Amount;
                    data.ClassStudents = classStudents;
                    await _context.SaveChangesAsync();
                } 
            return RedirectToAction("Index"); ;
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Class data = _context.Classes.Find(id);
            return View(data);
        }  
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if(ModelState.IsValid)
            {
                
                Class data = await _context.Classes.FindAsync(id);
                _context.Classes.Remove(data);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult GetStudent()
        {
            var data = new SelectList(_context.Students.ToList(),"Id","Name");
            return View(data);
        }
        [HttpPost]
        public IActionResult GetStudentsForSelection()
        {

            var data = _context.Students.Select(x => new SelectionViewModel()
            {
                Id = x.Id,
                Text = x.Name,
            }).ToList();
            return Json(data);
        }
      
    }
}
