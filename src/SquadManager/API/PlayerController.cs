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
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository repository;

        public PlayerController(IPlayerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<PlayerViewModel> GetAll()
        {
            return repository.AllPlayers.Select(i => new PlayerViewModel(i)) ;
        }

        [HttpGet("{id:int}", Name = "GetPlayerByIdRoute")]
        public IActionResult GetbyId(int id)
        {
            var item = repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(new PlayerViewModel(item));
        }

        [HttpGet("{id:int}/build", Name = "GetPlayerBuildRoute")]
        public IActionResult GetBuild(int id)
        {
            var item = repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(from BuildModel i in item.Build select new BuildViewModel(i));
        }

        [HttpGet("{id:int}/present")]
        public IActionResult GetPresence(int id)
        {
            var item = repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item.Present.ToDictionary(s => s.Key.ToString(), s => s.Value));
        }

        [HttpGet("{id:int}/present/{day}")]
        public IActionResult GetPresence(int id, string day)
        {
            var item = repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            DayOfWeek key;
            try
            {
                key = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day, ignoreCase: true);
            }
            catch
            {
                return HttpBadRequest();
            }

            return new ObjectResult(item.Present[key]);
        }
        
        [HttpPost("{id:int}/present/{day}")]
        public IActionResult SetPresence(int id, string day, [FromBody] bool value)
        {
            var item = repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            DayOfWeek key;
            try
            {
                key = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day, ignoreCase: true);
            }
            catch
            {
                return HttpBadRequest();
            }

            item.Present[key] = value;

            return new ObjectResult(item.Present[key]);
        }

        [HttpGet("{id:int}/present/today")]
        public IActionResult GetPresenceToday(int id)
        {
            var today = DateTime.Now;
            var item = repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item.Present[today.DayOfWeek]);
        }

        [HttpPost("{id:int}/present/today")]
        public IActionResult SetPresenceToday(int id, [FromBody] bool value)
        {
            var today = DateTime.Now;
            var item = repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            item.Present[today.DayOfWeek] = value;

            return new ObjectResult(item.Present[today.DayOfWeek]);
        }


        [HttpGet("{id:int}/present/tomorrow")]
        public IActionResult GetPresenceTomorrow(int id)
        {
            var day = DateTime.Now;
            day.AddDays(1);
            var item = repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item.Present[day.DayOfWeek]);
        }

        [HttpPost("{id:int}/present/tomorrow")]
        public IActionResult SetPresenceTomorrow(int id, [FromBody] bool value)
        {
            var day = DateTime.Now;
            day.AddDays(1);
            var item = repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            
            item.Present[day.DayOfWeek] = value;

            return new ObjectResult(item.Present[day.DayOfWeek]);
        }

        [HttpPost]
        public void CreatePlayerModel([FromBody] PlayerModel item)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {

                repository.Add(item);

                string url = Url.RouteUrl("GetPlayerByIdRoute", new { id = item.Id },
                    Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            if (!repository.TryDelete(id))
            {
                return HttpNotFound();
            }
            return new HttpStatusCodeResult(204); // 201 No Content
        }
    }
}
