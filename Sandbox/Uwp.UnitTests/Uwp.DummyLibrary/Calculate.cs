using System;

namespace Uwp.DummyLibrary
{
	public interface ICounter
	{
		void Init();
		bool IsInitiated();
		void Add(int a);
		int GetStatus();
	}

	public class Counter : ICounter
	{
		private int? _count;

		public void Init()
		{
			_count = 0;
		}

		public bool IsInitiated()
		{
			return _count != null;
		}
		
		public void Add(int a)
		{
			if (_count == null)
				throw new InvalidOperationException("You have to call Init() first.");
			_count += a;
		}

		public int GetStatus()
		{
			if (_count == null)
				throw new InvalidOperationException("You have to call Init() first.");
			return (int)_count;
		}
	}
}
