using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;

namespace ACR.Library.ACR.Education
{
	public partial class FacultyMemberItem
	{
		public bool HasCourse(Item course)
		{
			if (Courses == null || Courses.ListItems == null)
			{
				return false;
			}
			return Courses.ListItems.Any(item => item.ID == course.ID);
		}
	}
}
