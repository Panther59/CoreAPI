using System;
using System.Collections.Generic;
using System.Text;

namespace Herald.Contracts
{
	public interface IExceptionTransformer
	{
		object TransformException(Exception ex);
	}
}
