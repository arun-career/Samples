using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumberSequencesGenerator.Web.Controllers
{
    using NumberSequencesGenerator.Business.Interfaces.GeneratorService;
    public class NumberSequenceGeneratorController : Controller
    {
        private INumberSequencesGeneratorService nsGeneratorService;

        public NumberSequenceGeneratorController()
        {
            
        }

        public NumberSequenceGeneratorController(INumberSequencesGeneratorService nsGeneratorService)
        {
            this.nsGeneratorService = nsGeneratorService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Heading = NumberSequencesGenerator.Web.Properties.Settings.Default.Heading;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            return View("InputNumber");
            
            //RedirectToAction("InputNumber");
        }

        [HttpGet]
        public ActionResult InputNumber()
        {
            ViewBag.InputHeading = NumberSequencesGenerator.Web.Properties.Settings.Default.InputHeading;
            return View();
        }

        [HttpPost]
        public void InputNumber(FormCollection collection)
        {
            var nsgService = new Business.NumberSequencesGeneratorService();
            ViewBag.UpperLimit = collection["UpperLimit"];
            //return View("ViewResult");
            
            RedirectToAction("ViewResult");
        }

        [HttpGet]
        public ActionResult ViewResult()
        {
            var upperLimit = ViewBag.UpperLimit;
            var resultDcit = nsGeneratorService.GenerateSequence(10);

            ViewBag.Heading = NumberSequencesGenerator.Web.Properties.Settings.Default.ResultHeading;
            ViewBag.ResultDictionary = resultDcit;
            return View();
        }
    }
}