using Cohortis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cohortis.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public readonly List<BuildViewModel> Build;

        public PlayerViewModel()
        { }

        public PlayerViewModel(PlayerModel source)
        {
            Id = source.Id;
            Name = source.Name;
            Build = (from BuildModel i in source.Build select new BuildViewModel(i)).ToList();
        }
    }
}
