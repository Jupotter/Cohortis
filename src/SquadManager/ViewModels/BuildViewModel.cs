using SquadManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadManager.ViewModels
{
    public class BuildViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }

        public BuildViewModel()
        { }

        public BuildViewModel(BuildModel source)
        {
            Id = source.Id;
            Name = source.Name;
            Class = source.Class.ToString();
        }
    }
}
