
using System;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using System.Web.Mvc;
using System.Collections.Generic;
using ACRHelix.Feature.RadPACContent.Services.Entities;
using ACRHelix.Feature.RadPACContent.Models;
using System.Linq;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class EventTilesViewModel
    {
        private IEnumerable<IEventTile> _tiles = new List<IEventTile>();
        private List<string> _tags = new List<string>();
        public ID Id { get; set; } 
        public string Title { get; set; }

        public int TilesDisplayNumber { get; set; }

        public Link Link { get; set; }

        public IEnumerable<IEventTile> Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        public IEnumerable<string>Tags
        {
            get
            {
                foreach(var tile in Tiles)
                {
                    if(tile.Tags != null)
                    {
                        foreach(var tag in tile.Tags)
                        {
                            _tags.Add(tag.Name);
                        }                       
                    }
                }
                return _tags.Distinct().OrderByDescending(x => x).ToList();
            }

        }
    }
}