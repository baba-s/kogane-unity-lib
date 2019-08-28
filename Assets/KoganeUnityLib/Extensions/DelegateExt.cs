using System;
using System.Reflection;

namespace KoganeUnityLib
{
	public static class DelegateExt
	{
		public static int GetLength<T>( string name )
		{
			return GetLength( typeof( T ), name );
		}

		public static int GetLength( this Type self, string name )
		{
			var attrs =
				BindingFlags.GetField	|
				BindingFlags.Static		|
				BindingFlags.NonPublic	|
				BindingFlags.Public
			;
			var field = self.GetField( name, attrs );
			if ( field == null )
			{
				throw new ArgumentException( $"name is invalid parameter: {name}" );
			}
			var d = field.GetValue( null ) as Delegate;
			if ( d == null ) return 0;
			var list = d.GetInvocationList();
			if ( list == null ) return 0;
			var length = list.Length;
			return length;
		}
	}
}