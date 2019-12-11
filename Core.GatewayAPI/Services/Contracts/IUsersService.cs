using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.GatewayAPI.Services.Models;

namespace Core.GatewayAPI.Services.Contracts
{
	public interface IUsersService
	{
		List<User> Users { get; }
	}
}
