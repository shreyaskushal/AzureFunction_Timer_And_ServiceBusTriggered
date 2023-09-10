using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessUserData.Models
{
	public class MessageData
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string UserEmail { get; set; }
		public string DataValue { get; set; }
	}
}
