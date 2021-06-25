using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic.Core;
using PaymentOrderApp.PaymentOrderReference;

namespace PaymentOrderApp.Controllers

{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return (View());
        }

        public ActionResult GetPaymentList()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            PaymentOrderServiceClient obj = new PaymentOrderServiceClient();

            var paymentOrderList = obj.GetPaymentOrder().ToList();

            int totalrows = paymentOrderList.Count;
    
            //Search
            if (!string.IsNullOrEmpty(searchValue)) //filter
            {
                paymentOrderList = paymentOrderList.Where(x => x.RemitterName.ToLower().Contains(searchValue.ToLower())
                || x.RecepientName.ToString().Contains(searchValue.ToLower())|| x.RouteId.ToString().Contains(searchValue.ToLower())).ToList();
            }


            int totalrowsafterfiltering = paymentOrderList.Count;
            //Sorting
            var queryable = paymentOrderList.AsQueryable();
             paymentOrderList = queryable.OrderBy(sortColumnName + " " + sortDirection).ToList();

            //Paging
            paymentOrderList = paymentOrderList.Skip(start).Take(length).ToList();


            return Json(new { data = paymentOrderList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);


        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(PaymentOrderDTO paymentOrder)
        {
            PaymentOrderServiceClient obj = new PaymentOrderServiceClient();
            if (ModelState.IsValid)
            {

                obj.Add(paymentOrder);
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            PaymentOrderServiceClient obj = new PaymentOrderServiceClient();
            var model = obj.Get(Id);
            if (model == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(model);
        }
        public ActionResult Delete(int Id)
        {
            PaymentOrderServiceClient obj = new PaymentOrderServiceClient();
            var modelDelete = obj.Get(Id);
            if (modelDelete == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(modelDelete);
        }
        [HttpPost]
        public ActionResult Delete(PaymentOrderDTO paymentOrder)
        {
            PaymentOrderServiceClient obj = new PaymentOrderServiceClient();
            obj.Remove(paymentOrder);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            PaymentOrderServiceClient obj = new PaymentOrderServiceClient();
            var modelEdit = obj.Get(Id);
            if (modelEdit == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(modelEdit);
        }
        [HttpPost]
        public ActionResult Edit(PaymentOrderDTO paymentOrder)
        {
            PaymentOrderServiceClient obj = new PaymentOrderServiceClient();
            obj.Update(paymentOrder);
            return RedirectToAction("Details", new { id = paymentOrder.Id });
        }

        public ActionResult NotFound()
        {

            return View();
        }
    }
}