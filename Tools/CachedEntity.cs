#nullable enable
using CounterStrikeSharp.API.Core;

namespace Template.Tools
{
	/// <summary>
	/// Can be used to cache an entity and automatically update it when it becomes invalid.
	/// </summary>
	/// <typeparam name="T">The entity type</typeparam>
	public class CachedEntity<T> where T: CEntityInstance
	{
		private T? _value;
		private readonly Func<T?> _valueFactory;

		public CachedEntity(Func<T> valueFactory)
		{
			_valueFactory = valueFactory;
			_value = _valueFactory();
		}

		private bool IsValid => _value != null && _value.IsValid;

		public T? Value
		{
			get
			{
				if (IsValid == false)
				{
					_value = _valueFactory();
				}

				return _value;
			}
		}
	}
}
