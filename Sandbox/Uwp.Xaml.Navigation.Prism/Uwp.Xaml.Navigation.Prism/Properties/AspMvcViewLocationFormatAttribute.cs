using System;

namespace Uwp.Xaml.Navigation.Annotations
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public sealed class AspMvcViewLocationFormatAttribute : Attribute
	{
		public AspMvcViewLocationFormatAttribute(string format)
		{
			Format = format;
		}

		public string Format { get; private set; }
	}
}