using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KoganeUnityLib
{
	/// <summary>
	/// string 型に関する汎用関数を管理するクラス
	/// </summary>
	public static class StringUtils
	{
		/// <summary>
		/// 指定された形式に基づいてオブジェクトの値を文字列に変換し、別の文字列に挿入します
		/// </summary>
		public static string Format<T1>( string format, T1 arg1 )
		{
			return string.Format
			(
				format,
				arg1.ToString()
			);
		}

		/// <summary>
		/// 指定された形式に基づいてオブジェクトの値を文字列に変換し、別の文字列に挿入します
		/// </summary>
		public static string Format<T1, T2>( string format, T1 arg1, T2 arg2 )
		{
			return string.Format
			(
				format,
				arg1.ToString(),
				arg2.ToString()
			);
		}

		/// <summary>
		/// 指定された形式に基づいてオブジェクトの値を文字列に変換し、別の文字列に挿入します
		/// </summary>
		public static string Format<T1, T2, T3>( string format, T1 arg1, T2 arg2, T3 arg3 )
		{
			return string.Format
			(
				format,
				arg1.ToString(),
				arg2.ToString(),
				arg3.ToString()
			);
		}

		/// <summary>
		/// 指定された形式に基づいてオブジェクトの値を文字列に変換し、別の文字列に挿入します
		/// </summary>
		public static string Format<T1, T2, T3, T4>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4 )
		{
			return string.Format
			(
				format,
				arg1.ToString(),
				arg2.ToString(),
				arg3.ToString(),
				arg4.ToString()
			);
		}

		/// <summary>
		/// 指定された形式に基づいてオブジェクトの値を文字列に変換し、別の文字列に挿入します
		/// </summary>
		public static string Format<T1, T2, T3, T4, T5>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5 )
		{
			return string.Format
			(
				format,
				arg1.ToString(),
				arg2.ToString(),
				arg3.ToString(),
				arg4.ToString(),
				arg5.ToString()
			);
		}

		/// <summary>
		/// 指定された形式に基づいてオブジェクトの値を文字列に変換し、別の文字列に挿入します
		/// </summary>
		public static string Format<T1, T2, T3, T4, T5, T6>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6 )
		{
			return string.Format
			(
				format,
				arg1.ToString(),
				arg2.ToString(),
				arg3.ToString(),
				arg4.ToString(),
				arg5.ToString(),
				arg6.ToString()
			);
		}

		/// <summary>
		/// 文字列配列のすべての要素を連結します。各要素の間には、指定した区切り記号が挿入されます
		/// </summary>
		public static string Join( string separator, IEnumerable<string> value )
		{
			return string.Join( separator, value.ToArray() );
		}

		/// <summary>
		/// 文字列配列の指定した要素を連結します。各要素の間には、指定した区切り記号が挿入されます
		/// </summary>
		public static string Join( string separator, IEnumerable<string> value, int startIndex, int count )
		{
			return string.Join( separator, value.ToArray(), startIndex, count );
		}

		/// <summary>
		/// 文字が全角かどうかを返します
		/// </summary>
		public static bool IsChar2Byte( char c )
		{
			// Shift_JIS: 0x0 ～ 0x80, 0xa0 , 0xa1 ～ 0xdf , 0xfd ～ 0xff
			// Unicode : 0x0 ～ 0x80, 0xf8f0, 0xff61 ～ 0xff9f, 0xf8f1 ～ 0xf8f3
			return !( ( c >= 0x0 && c < 0x81 ) || ( c == 0xf8f0 ) || ( c >= 0xff61 && c < 0xffa0 ) || ( c >= 0xf8f1 && c < 0xf8f4 ) );
		}

		/// <summary>
		/// 特定の文字で区切られた文字列の配列から、複合書式指定文字列の配列を返します
		/// </summary>
		/// <param name="separator">区切り文字</param>
		/// <param name="texts">特定の文字で区切られた文字列の配列</param>
		/// <returns>複合書式指定文字列の配列</returns>
		/// <example>
		/// var texts = new []
		/// {
		///     "Label_Start",
		///     "Label_End",
		///     "Label_Rea_Close",
		///     "Label_Rea_Start",
		///     "Label_Ten_Close",
		///     "Label_Ten_Start",
		/// };
		/// var formattableTexts = GetFormattableTexts( "_", texts );
		/// // Label_{0}
		/// // Label_Rea_{0}
		/// // Label_{0}_Close
		/// // Label_{0}_{1}
		/// // Label_{0}_Start
		/// // Label_Ten_{0}
		/// </example>
		public static string[] GetFormattableTexts( string separator, params string[] texts )
		{
			var list = new List<string>();

			for ( int i = 0; i < texts.Length - 1; i++ )
			{
				var separatedText1 = texts[ i ].Split( new[] { separator }, StringSplitOptions.None ).ToArray();

				for ( int j = i + 1; j < texts.Length; j++ )
				{
					var separatedText2 = texts[ j ].Split( new[] { separator }, StringSplitOptions.None ).ToArray();

					int argumentCount = 0;

					var builder = new StringBuilder();

					for ( int k = 0; k < Math.Min( separatedText1.Length, separatedText2.Length ); k++ )
					{
						var text1 = separatedText1[ k ];
						var text2 = separatedText2[ k ];

						if ( text1 == text2 )
						{
							builder.Append( text1 );
						}
						else
						{
							builder.AppendFormat( "{{{0}}}", argumentCount++ );
						}

						builder.Append( "_" );
					}

					builder = builder.Remove( builder.Length - 1, 1 );

					list.Add( builder.ToString() );
				}
			}

			return list.Distinct().ToArray();
		}
	}
}