﻿using ProcessUserData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessUserData.Iservices
{
	public interface IUserService
	{
		List<UserData> GetUserDetails();
	}
}
