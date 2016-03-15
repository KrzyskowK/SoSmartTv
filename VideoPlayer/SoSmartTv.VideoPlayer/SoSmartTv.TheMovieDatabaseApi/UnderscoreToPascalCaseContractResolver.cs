using System.Text;
using Newtonsoft.Json.Serialization;

namespace SoSmartTv.TheMovieDatabaseApi
{
	public class UnderscoreToPascalCaseContractResolver : DefaultContractResolver
	{
		protected override string ResolvePropertyName(string propertyName)
		{
			var builder = new StringBuilder();
			foreach (var c in propertyName)
			{
				if (char.IsUpper(c))
					builder.Append('_');
				builder.Append(char.ToLower(c));
			}
			if (char.IsUpper(propertyName, 0))
				builder.Remove(0, 1);
			return base.ResolvePropertyName(builder.ToString());
		}
	}
}