using SquadManager.Models;
using SquadManager.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadManager.API
{
    [Route("api/v1/[controller]/")]
    public class BuildController : Controller
    {
        private readonly IBuildRepository repository;

        public BuildController(IBuildRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<BuildViewModel> GetAll()
        {
            return repository.AllBuilds.Select(i => new BuildViewModel(i));
        }

        [HttpGet("{id:int}", Name = "GetBuildByIdRoute")]
        public IActionResult GetbyId(int id)
        {
            var item = repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(new BuildViewModel(item));
        }

        [HttpPost("{id:int}", Name = "UpdateBuildByIdRoute")]
        public IActionResult UpdatebyId(int id, [FromBody] BuildModel item)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(400);
            }
            else
            {
                repository.TryUpdate(item);
                return new ObjectResult(new BuildViewModel(item));
            }
        }
    }
}
