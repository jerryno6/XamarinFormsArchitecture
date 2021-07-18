using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsArchitecture.Shared.Core.Model;

namespace XamarinFormsArchitecture.Shared.Core.Interfaces.Repositories
{
	public interface IGreetRepository
	{
		Task<Greet> Greet(); 
	}
}
