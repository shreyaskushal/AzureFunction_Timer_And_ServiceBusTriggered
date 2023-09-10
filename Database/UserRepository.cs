using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProcessUserData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessUserData.Database
{
    public class UserRepository : IUserRepository
	{
		private readonly MyDbContext _dbContext;
		public UserRepository(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<UserData> GetUserDetails(DateTime lastExecutionTime)
		{
			return _dbContext.userData.FromSqlRaw("EXEC GetUserDetailsByLastExecutionTime @LastExecutionTime", new SqlParameter("@LastExecutionTime", lastExecutionTime)).ToList();
			
		}
	}

	public interface IUserRepository
	{
		List<UserData> GetUserDetails(DateTime lastExecutionTime);
	}

}
