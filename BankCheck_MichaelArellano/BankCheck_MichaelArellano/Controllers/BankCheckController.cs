using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BankingCheck_MichaelArellano.Helper;
using BankingCheck_MichaelArellano.Models;

namespace BankCheck_MichaelArellano.Controllers
{
    public class BankCheckController : Controller
    {
        private const string ResetCommand = "Reset";
        private const string IndexAction = "Index";
        
        public ActionResult Index()
        {
            return View(new BankingCheck() { CheckDate = DateTime.Today });
        }

        [HttpPost]
        public ActionResult Index(BankingCheck model, string command)
        {

            if (command == ResetCommand)
            {
                // Implement PRG
                return RedirectToAction(IndexAction);
            }

            model.IsCheckVisible = false;

            if (ModelState.IsValid)
            {
                model.AmountInWords = string.Format("{0} only", CurrencyHelper.CurrencyToWords(model.AmountInNumbers));
                model.IsCheckVisible = true;
            } 

            return View(model);
        }

    }
}
