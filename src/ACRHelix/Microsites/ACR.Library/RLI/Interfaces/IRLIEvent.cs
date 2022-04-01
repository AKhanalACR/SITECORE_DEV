using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.RLI.Taxonomy;

namespace ACR.Library.RLI.Interfaces
{
	public interface IRLIEvent
	{
		DateTime EventStartDate { get; }
		String EventShortDescription { get; }
		String EventShortDescriptionFull { get; }
		String EventBody { get; }
		String EventTitle { get; }
		String EventUrl { get; }
		String EventUrlTarget { get; }
		String ItemUrl { get; }
		DateTime EventEndDate { get; }
		String EventDuration { get; }
		String EventTimezone { get; }
		List<DayOfWeekItem> LectureDaysOfWeek { get; }
	}
}