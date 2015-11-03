using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Cohortis.ViewModels;
using Microsoft.AspNet.Mvc;

namespace Cohortis.Controllers
{
    [Route("api/[controller]")]
    public class ProcessesController : Controller
    {
        [HttpGet]
        public IEnumerable<ProcessInfoViewModel> Get()
        {
            var processList = Process.GetProcesses().OrderBy(p => p.ProcessName).ToList();
            return processList.Select(p => new ProcessInfoViewModel() {Name = p.ProcessName});
        }
    }
}
