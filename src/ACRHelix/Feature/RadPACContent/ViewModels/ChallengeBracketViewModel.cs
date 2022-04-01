
using System;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using System.Web.Mvc;
using System.Collections.Generic;
using ACRHelix.Feature.RadPACContent.Services.Entities;
using ACRHelix.Feature.RadPACContent.Models;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class ChallengeBracketViewModel
    {
        private IEnumerable<IChapter> _chapters = new List<IChapter>();
        private IEnumerable<IBracketStage> _stages = new List<IBracketStage>();
        public ID Id { get; set; }
        public IEnumerable<IChapter> Chapters
        {
            get { return _chapters; }
            set { _chapters = value; }
        }

        public IEnumerable<IBracketStage> Stages
        {
            get { return _stages; }
            set { _stages = value; }
        }

        public string Division { get; set; }
        public IEnumerable<string> Divisions { get; set; }

        public IEnumerable<SelectListItem> DivisionSelectList { get; set; }

    }
}