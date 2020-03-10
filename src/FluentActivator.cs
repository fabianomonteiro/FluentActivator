using System;
using System.Linq;
using System.Runtime.Serialization;

namespace FabianoMonteiro.Core.Fluents
{
	public class FluentActivator
	{
		private Type _type;

		private object[] _args;

		public FluentActivator(Type type)
		{
			_type = type;
		}

		public static FluentActivator SetType(Type type)
		{
			var result = new FluentActivator(type);

			return result;
		}

		public FluentActivator SetArgs(params object[] args)
		{
			_args = args;

			return this;
		}

		public FluentActivator OnBeforeConstructor(Action<object> callback)
		{
			_beforeConstructor = callback;

			return this;
		}

		public object CreateInstance()
		{
			var instance = FormatterServices.GetUninitializedObject(_type);

			_beforeConstructor?.Invoke(instance);

			var constructor = _type.GetConstructor(_args.Select(x => x.GetType()).ToArray());

			constructor.Invoke(instance, _args);

			return instance;
		}

		public T CreateInstance<T>()
		{
			return (T)CreateInstance();
		}

		public void CreateInstance<T>(ref T instance)
		{
			instance = CreateInstance<T>();
		}

		private event Action<object> _beforeConstructor;
	}
}
