using Microsoft.AspNetCore.Mvc;
using Todo.Data;

namespace Todo.Controllers
{
    public class TodoController : Controller
    {
        private readonly Todoservice _todoservice;

        public TodoController(Todoservice todoservice)
        {
            _todoservice = todoservice;
        }

        public IActionResult Index()
        {
            var todo = _todoservice.FindAll();
            return View(todo);
        }
        [HttpPost]
        public IActionResult Create(string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                _todoservice.CreateItem(description);

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult clear()
        {
            _todoservice.clear();
            return RedirectToAction("Index");   
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            _todoservice.Remove(id);

             return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult MarkDone(int id) 
        {
            var todos = _todoservice.FindById(id);
            if(todos != null)
            {
                todos.Done = true;
            }
            return RedirectToAction("Index");
    }
        [HttpPost]
        public IActionResult MarkUnDone(int id)
        {
            var todos = _todoservice.FindById(id);
            if (todos != null)
            {
                todos.Done = false;
            }
            return RedirectToAction("Index");
        }

    }
}
