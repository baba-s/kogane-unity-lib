namespace KoganeUnityLib
{
	/// <summary>
	/// Random クラスに関する汎用関数を管理するクラス
	/// </summary>
	public static class RandomUtils
	{
		/// <summary>
		/// 0.0 から 1.0 の浮動小数点数をランダムに返します
		/// </summary>
		public static float Value { get { return UnityEngine.Random.value; } }

		/// <summary>
		/// true か false の真偽値をランダムに返します
		/// </summary>
		public static bool BoolValue { get { return UnityEngine.Random.Range( 0, 2 ) == 0; } }

		/// <summary>
		/// 1 か 0 の真偽値をランダムに返します
		/// </summary>
		public static byte Flag { get { return BoolValue.ToByte(); } }

		/// <summary>
		/// 指定された配列の中からランダムに値を返します
		/// </summary>
		public static T Random<T>( params T[] values )
		{
			return values[ UnityEngine.Random.Range( 0, values.Length ) ];
		}

		/// <summary>
		/// 0 から max - 1 の間の整数をランダムに返します
		/// </summary>
		public static int Range( int max )
		{
			return UnityEngine.Random.Range( 0, max );
		}

		/// <summary>
		/// 0 から max - 1 の間の整数をランダムに返します
		/// </summary>
		public static byte RangeByte( byte max )
		{
			return ( byte )UnityEngine.Random.Range( 0, max );
		}

		/// <summary>
		/// 0 から max - 1 の間の整数をランダムに返します
		/// </summary>
		public static ushort RangeUshort( uint max )
		{
			return ( ushort )UnityEngine.Random.Range( 0, ( int )max );
		}

		/// <summary>
		/// 0 から max - 1 の間の整数をランダムに返します
		/// </summary>
		public static uint RangeUint( uint max )
		{
			return ( uint )UnityEngine.Random.Range( 0, ( int )max );
		}

		/// <summary>
		/// 0 から max - 1 の間の整数をランダムに返します
		/// </summary>
		public static ulong RangeUlong( ulong max )
		{
			return ( ulong )UnityEngine.Random.Range( 0, ( int )max );
		}

		/// <summary>
		/// min から max - 1 の間の整数をランダムに返します
		/// </summary>
		public static int Range( int min, int max )
		{
			return UnityEngine.Random.Range( min, max );
		}

		/// <summary>
		/// min から max の間の浮動小数点数をランダムに返します
		/// </summary>
		public static float Range( float min, float max )
		{
			return UnityEngine.Random.Range( min, max );
		}
	}
}