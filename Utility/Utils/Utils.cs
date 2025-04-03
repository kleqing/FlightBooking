using System.ComponentModel;
using System.Reflection;

namespace Utility.Utils;

public static class Utils
{
	public static string GetDescription(this Enum value)
	{
		FieldInfo field = value.GetType().GetField(value.ToString());
		DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

		return attribute == null ? value.ToString() : attribute.Description;
	}
}