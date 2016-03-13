using System;

namespace Uwp.Xaml.Navigation.Annotations
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public sealed class AspMvcMasterLocationFormatAttribute : Attribute
	{
		public AspMvcMasterLocationFormatAttribute(string format)
		{
			Format = format;
		}

		public string Format { get; private set; }
	}
}