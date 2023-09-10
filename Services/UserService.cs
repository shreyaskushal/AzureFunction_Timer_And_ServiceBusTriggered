using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProcessUserData.Database;
using ProcessUserData.Iservices;
using ProcessUserData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessUserData.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IConfiguration _config;
		private readonly ILogger<UserService> _log;

		public UserService(IConfiguration config, ILogger<UserService> log, IUserRepository userRepository)
        {
			_config = config;
			_log = log;
			_userRepository = userRepository;
        }
        public List<UserData> GetUserDetails()
		{
			try
			{
				var lastExecutionTime = _config["LastExecutionTime"];

				DateTime lastExecutionDateTime = DateTime.Parse(lastExecutionTime);

				var userDetails = _userRepository.GetUserDetails(lastExecutionDateTime);

				_config["LastExecutionTime"] = DateTime.Now.ToString();

				return userDetails;
			}
			catch (SqlException ex)
			{
				_log.LogError($"SQL Exception : {ex.Message}");	
				throw;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
