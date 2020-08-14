using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JobTracker.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace JobTracker.Pages.Job
{
    public class IndexModel : PageModel
    {
        public readonly JobDbContext db;
        public IndexModel(JobDbContext db)
        {
            this.db = db;
        }



        public IEnumerable<Model.Job> Jobs { get; set; }
        public async Task OnGet()
        {
            Jobs = await db.Job.ToListAsync();
        }
        public async Task OnPost()
        {
            Jobs = await db.Job.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            db.Job.Attach(new Model.Job { Id = id }).State = EntityState.Deleted;

            await db.SaveChangesAsync();

            return RedirectToPage();

        }

        public IActionResult OnPostPartial()
        {
            IEnumerable<Model.Job> jobs = db.Job.ToList();
            return Partial("_Test1", jobs );
        }

        public async Task<JsonResult> OnPostRequest1()
        {
            List<Model.Job> jobs = await db.Job.ToListAsync();

            return new JsonResult(jobs);
        }
    }
}
