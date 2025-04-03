using System.ComponentModel;

namespace Utility.Utils;

public class Constant
{
	public enum UserErrorType
	{
		[Description("Created Failed!")]
		CreateFailed = 0,

		[Description("Create Success!")]
		CreateSuccess = 1,
		
		[Description("Update Failed!")]
		UpdateFailed = 2,
		
		[Description("Update Success!")]
		UpdateSuccess = 3
	}
}