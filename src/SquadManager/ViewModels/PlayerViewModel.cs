﻿using SquadManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadManager.ViewModels
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public readonly List<BuildViewModel> Build;
        public readonly Dictionary<string, bool> Present;

        public PlayerViewModel()
        { }

        public PlayerViewModel(PlayerModel source)
        {
            Id = source.Id;
            Name = source.Name;
            Build = (from BuildModel i in source.Build select new BuildViewModel(i)).ToList();
            Present = source.Present.ToDictionary(s => s.Key.ToString(), s => s.Value);
        }
    }
}
