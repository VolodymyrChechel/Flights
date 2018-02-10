using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Airline.Common.Enums;
using Airline.Common.StaticData;
using Airline.WEB.Validators;

namespace Airline.WEB.Models
{
    public class ShowCrewModel
    {
        public int Id { get; set; }
        public int CrewCompositionId { get; set; }
        public string WorkersDescription{ get; set; }

    }
}