using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using Galvanic.Service.Interface;
using Omu.ValueInjecter;
using Galvanic.UI.ViewModel;
using Galvanic.UI.Helper;
using System.Data;



namespace Galvanic.UI.Controllers
{
    public class HomeController : Controller
    {
        private IOrderService _orderService;
        private IUserService _userService;        

        public HomeController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;            
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var users = _userService.GetAll();

            IEnumerable<UserViewModel> model = new List<UserViewModel>();            
            model = users.Select(c => new UserViewModel().InjectFrom(c)).Cast<UserViewModel>();

            //UserViewModel userViewModel = new UserViewModel();
            //userViewModel.InjectFrom(users.FirstOrDefault());            

            return View(model);
            
        }
        
        public ActionResult DynamicGridData(GridSettings gridData)
        {    
            //get data from user and map with value injecter to view model
            IQueryable<UserViewModel> userViewModel = _userService.GetAll().AsQueryable().Select(c => new UserViewModel().InjectFrom(c)).Cast<UserViewModel>();

            if (gridData.IsSearch)
            {
                if (gridData.Where.groupOp == "AND")
                    foreach (var rule in gridData.Where.rules)
                        userViewModel = userViewModel.Where<UserViewModel>(
                            rule.field, rule.data, 
                            (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op));

                else
                {
                    var temp = new List<UserViewModel>().AsQueryable();
                    foreach (var rule in gridData.Where.rules)
                    {
                        var t = userViewModel.Where<UserViewModel>(
                            rule.field, rule.data,
                            (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op));
                        temp = temp.Concat<UserViewModel>(t);      
                    }

                    userViewModel = temp.Distinct<UserViewModel>();
                }

                userViewModel = userViewModel.OrderBy<UserViewModel>(gridData.SortColumn, gridData.SortOrder);                
            }

            int pageIndex = Convert.ToInt32(gridData.PageIndex) - 1;
            int pageSize = gridData.PageSize;            
            int totalRecords = userViewModel.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var jsonData = new
            {
                total = totalPages,
                page = pageIndex,
                records = totalRecords,
                rows = (from model in userViewModel
                        select new
                        {
                            i = model.UserId,
                            cell = new string[] { model.UserId.ToString(), model.UserName, model.Email}
                        }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        public ActionResult About()
        {
            return View();
        }
    }
}
