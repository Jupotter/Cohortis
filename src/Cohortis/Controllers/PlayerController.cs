﻿using Cohortis.Models;
using Cohortis.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.OData;

namespace Cohortis.Controllers
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

        [HttpGet("{id:int}", Name = "GetByIdRoute")]
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

                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id },
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
