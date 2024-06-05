﻿using AbarroLaw.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AbarroLaw.Web.Controllers
{
    public class PracticeAreaController : Controller
    {
        private readonly IPracticeRepository practiceRepository;
        private readonly ICaseRepository caseRepository;

        public PracticeAreaController(IPracticeRepository practiceRepository, ICaseRepository caseRepository)
        {
            this.practiceRepository = practiceRepository;
            this.caseRepository = caseRepository;
        }


        //Practice Area Main ----------------------------------------
        [HttpGet]
        public async Task<IActionResult> PracticeAreaView()
        {
            var allPractices = await practiceRepository.GetAllPracticesAsyncForUser();
            if (allPractices != null && allPractices.Any())
            {
                return View(allPractices);
            }
            else
            {
                return View();
            }

        }

        //Practice Area Dynamic (based on DB) -----------------------
        public async Task<IActionResult> PracticeAreaDynamic(string practiceName)
        {
            if (string.IsNullOrEmpty(practiceName))
            {
                return BadRequest("No cases related on the practice!");
            }
            else
            {
                var casePosts = await caseRepository.GetCasePostsByPracticeNameAsync(practiceName);

                return View(casePosts);
            }
        }


        
    }
}
