using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KoganeUnityLib
{
	/// <summary>
	/// string 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class StringExt
	{
		/// <summary>
		/// 指定した正規表現に一致する箇所が、指定した入力文字列内に見つかるかどうかを示します
		/// </summary>
		public static bool IsMatch( this string str, string pattern )
		{
			return Regex.IsMatch( str, pattern );
		}

		/// <summary>
		/// 指定した入力文字列内で、指定した正規表現に最初に一致する箇所を検索します
		/// </summary>
		public static Match Match( this string str, string pattern )
		{
			return Regex.Match( str, pattern );
		}

		/// <summary>
		/// 指定した入力文字列内で、指定した正規表現に一致する箇所をすべて検索します
		/// </summary>
		public static MatchCollection Matches( this string str, string pattern )
		{
			return Regex.Matches( str, pattern );
		}

		/// <summary>
		/// 指定した入力文字列内で指定した正規表現に一致するすべての文字列を、指定した置換文字列に置換します
		/// </summary>
		public static string ReplaceRegex( this string str, string pattern, string replacement )
		{
			return Regex.Replace( str, pattern, replacement );
		}

		/// <summary>
		/// 指定した文字列の書式項目を指定した配列内の対応するオブジェクトの文字列形式に置換します
		/// </summary>
		public static string FormatWith( this string format, params Object[] args )
		{
			return string.Format( format, args );
		}

		/// <summary>
		/// コレクションを指定した文字で連結します
		/// </summary>
		public static string ConcatWith<T>( this IEnumerable<T> self, string separator )
		{
			var list = new List<string>();
			foreach ( var n in self )
			{
				list.Add( n.ToString() );
			}
			return string.Join( separator, list.ToArray() );
		}

		/// <summary>
		/// コレクションを指定した文字で連結します
		/// </summary>
		public static string ConcatWith( this IEnumerable self, string separator )
		{
			var list = new List<object>();
			foreach ( var n in self )
			{
				list.Add( n );
			}
			return string.Join( separator, list.Select( c => c.ToString() ).ToArray() );
		}

		/// <summary>
		/// コレクションを指定した文字で連結します
		/// </summary>
		public static string ConcatWith<T>( this IEnumerable<T> self, string separator, string format, IFormatProvider provider = null ) where T : IFormattable
		{
			return self.Select( x => x.ToString( format, provider ) ).Aggregate( ( a, b ) => a + separator + b );
		}

		/// <summary>
		/// 指定された文字列が null または Empty 文字列であるかどうかを示します
		/// </summary>
		public static bool IsNullOrEmpty( this string value )
		{
			return string.IsNullOrEmpty( value );
		}

		/// <summary>
		/// 指定された文字列が null または空であるか、空白文字だけで構成されているかどうかを返します
		/// </summary>
		public static bool IsNullOrWhiteSpace( this string value )
		{
			return value == null || value.Trim() == "";
		}

		/// <summary>
		/// 指定された文字列が null ではない、 Empty 文字列ではないかどうかを示します
		/// </summary>
		public static bool IsNotNullOrEmpty( this string self )
		{
			return !self.IsNullOrEmpty();
		}

		/// <summary>
		/// 指定された文字列が null ではない、空ではない、空白文字だけで構成されていないかどうかを返します
		/// </summary>
		public static bool IsNotNullOrWhiteSpace( this string self )
		{
			return !self.IsNullOrWhiteSpace();
		}

		/// <summary>
		/// 文字列が空の場合は string.Empty を返します
		/// </summary>
		public static string DefaultIfEmpty( this string self )
		{
			return string.IsNullOrEmpty( self ) ? string.Empty : self;
		}

		/// <summary>
		/// 文字列が空の場合は defaultValue を返します
		/// </summary>
		public static string DefaultIfEmpty( this string self, string defaultValue )
		{
			return string.IsNullOrEmpty( self ) ? defaultValue : self;
		}

		/// <summary>
		/// 文字列が空もしくは空白文字だけで構成されている場合は string.Empty を返します
		/// </summary>
		public static string DefaultIfWhiteSpace( this string self )
		{
			return IsNullOrWhiteSpace( self ) ? string.Empty : self;
		}

		/// <summary>
		/// 文字列が空もしくは空白文字だけで構成されている場合は defaultValue を返します
		/// </summary>
		public static string DefaultIfWhiteSpace( this string self, string defaultValue )
		{
			return IsNullOrWhiteSpace( self ) ? defaultValue : self;
		}

		/// <summary>
		/// 文字列を指定された長さに制限して返します
		/// </summary>
		public static string Limit( this string self, int maxLength, string suffix = null )
		{
			if ( self.Length <= maxLength ) return self;
			return string.Concat( self.Substring( 0, maxLength ).Trim(), suffix ?? string.Empty );
		}

		/// <summary>
		/// 指定された文字列の配列の要素で区切られた、この文字列の部分文字列を格納する文字列配列を返します
		/// </summary>
		public static string[] Split( this string self, char separator )
		{
			return self.Split( new[] { separator }, StringSplitOptions.None );
		}

		/// <summary>
		/// 指定された文字列の配列の要素で区切られた、この文字列の部分文字列を格納する文字列配列を返します
		/// </summary>
		public static string[] Split( this string self, char separator, StringSplitOptions options )
		{
			return self.Split( new[] { separator }, options );
		}

		/// <summary>
		/// 指定された文字列の配列の要素で区切られた、この文字列の部分文字列を格納する文字列配列を返します
		/// </summary>
		public static string[] Split( this string self, string separator )
		{
			return self.Split( new[] { separator }, StringSplitOptions.None );
		}

		/// <summary>
		/// 指定された文字列の配列の要素で区切られた、この文字列の部分文字列を格納する文字列配列を返します
		/// </summary>
		public static string[] Split( this string self, string separator, StringSplitOptions options )
		{
			return self.Split( new[] { separator }, options );
		}

		/// <summary>
		/// 指定された文字列の配列の要素で区切られた、この文字列の部分文字列を格納する文字列配列を返します
		/// </summary>
		public static string[] Split( this string self, params string[] separator )
		{
			return self.Split( separator, StringSplitOptions.None );
		}

		/// <summary>
		/// <para>指定した文字列をすべて空文字列に置換した新しい文字列を返します</para>
		/// <para>"ABCABC".ReplaceEmpty("B") → ACAC</para>
		/// </summary>
		public static string ReplaceEmpty( this string self, string oldValue )
		{
			return self.Replace( oldValue, string.Empty );
		}

		/// <summary>
		/// 先頭に指定した文字列を挿入します
		/// </summary>
		public static string AddFront( this string self, string value )
		{
			return self.Insert( 0, value );
		}

		/// <summary>
		/// 単語の先頭文字を大文字に変換します
		/// </summary>
		public static string ToTitleCase( this string self )
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase( self );
		}

		/// <summary>
		/// <para>スネークケースをアッパーキャメル(パスカル)ケースに変換します</para>
		/// <para>例) quoted_printable_encode → QuotedPrintableEncode</para>
		/// </summary>
		public static string SnakeToUpperCamel( this string self )
		{
			if ( string.IsNullOrEmpty( self ) ) return self;

			return self
				.Split( new[] { '_' }, StringSplitOptions.RemoveEmptyEntries )
				.Select( s => char.ToUpperInvariant( s[ 0 ] ) + s.Substring( 1, s.Length - 1 ) )
				.Aggregate( string.Empty, ( s1, s2 ) => s1 + s2 )
			;
		}

		/// <summary>
		/// <para>スネークケースをローワーキャメル(パスカル)ケースに変換します</para>
		/// <para>例) quoted_printable_encode → quotedPrintableEncode</para>
		/// </summary>
		public static string SnakeToLowerCamel( this string self )
		{
			if ( string.IsNullOrEmpty( self ) ) return self;

			return self.SnakeToUpperCamel().Insert( 0, char.ToLowerInvariant( self[ 0 ] ).ToString() ).Remove( 1, 1 );
		}

		/// <summary>
		/// <para>Windows 形式のファイルパスに変換します</para>
		/// <para>例) temp/doc.txt → temp\\doc.txt</para>
		/// </summary>
		public static string ToWindowsPath( this string self )
		{
			return self.Replace( "/", "\\" );
		}

		/// <summary>
		/// <para>Mac 形式のファイルパスに変換します</para>
		/// <para>例) temp\\doc.txt → temp/doc.txt</para>
		/// </summary>
		public static string ToMacPath( this string self )
		{
			return self.Replace( "\\", "/" );
		}

		/// <summary>
		/// バイト数を計算して返します
		/// </summary>
		public static int GetByteCount( this string self )
		{
			int count = 0;
			for ( int i = 0; i < self.Length; i++ )
			{
				if ( StringUtils.IsChar2Byte( self[ i ] ) )
				{
					count++;
				}
				count++;
			}
			return count;
		}

		/// <summary>
		/// インスタンスからバイト単位で部分文字列を取得します
		/// </summary>
		public static string SubstringInByte( this string self, int byteCount )
		{
			string tmp = "";
			int count = 0;
			for ( int i = 0; i < self.Length; i++ )
			{
				char c = self[ i ];
				if ( StringUtils.IsChar2Byte( c ) )
				{
					count++;
				}
				count++;
				if ( count > byteCount )
				{
					break;
				}
				tmp += c;
			}
			return tmp;
		}

		/// <summary>
		/// インスタンスからバイト単位で部分文字列を取得します。文字数が指定されたバイト数以内の場合はインスタンスをそのまま返します
		/// </summary>
		public static string SafeSubstringInByte( this string self, int byteCount )
		{
			return byteCount < self.GetByteCount() ? self.SubstringInByte( byteCount ) : self;
		}

		/// <summary>
		/// <para>指定された文字列のインスタンスの先頭および末尾から、配列で指定された文字セットをすべて削除します</para>
		/// <para>var str = "\n王国兵士\n魔法使い\n";</para>
		/// <para>str = str.Trim( "\n" ); // 王国兵士\n魔法使い</para>
		/// </summary>
		public static string Trim( this string self, params string[] trimChars )
		{
			return self.Trim( trimChars.Select( c => Convert.ToChar( c ) ).ToArray() );
		}

		/// <summary>
		/// <para>指定された文字列のインスタンスの末尾から、配列で指定された文字セットをすべて削除します</para>
		/// <para>var str = "\n王国兵士\n魔法使い\n";</para>
		/// <para>str = str.TrimEnd( "\n" ); // \n王国兵士\n魔法使い</para>
		/// </summary>
		public static string TrimEnd( this string self, params string[] trimChars )
		{
			return self.TrimEnd( trimChars.Select( c => Convert.ToChar( c ) ).ToArray() );
		}

		/// <summary>
		/// <para>指定された文字列のインスタンスの先頭から、配列で指定された文字セットをすべて削除します</para>
		/// <para>var str = "\n王国兵士\n魔法使い\n";</para>
		/// <para>str = str.TrimStart( "\n" ); // 王国兵士\n魔法使い\n</para>
		/// </summary>
		public static string TrimStart( this string self, params string[] trimChars )
		{
			return self.TrimStart( trimChars.Select( c => Convert.ToChar( c ) ).ToArray() );
		}

		/// <summary>
		/// 指定された文字列を指定された回数分繰り返し連結した文字列を生成して返します
		/// </summary>
		public static string Repeat( this string self, int repeatCount )
		{
			var builder = new StringBuilder();
			for ( int i = 0; i < repeatCount; i++ )
			{
				builder.Append( self );
			}
			return builder.ToString();
		}

		/// <summary>
		/// <para>全角と半角の違いを無視して文字列比較します</para>
		/// <para>http://d.hatena.ne.jp/tbpg/20130701/1372684055</para>
		/// </summary>
		public static bool CompareIgnoreWidthAndCase( this string self, string value )
		{
			var compareInfo = CultureInfo.CurrentCulture.CompareInfo;
			return 0 <= compareInfo.IndexOf( self, value, CompareOptions.IgnoreWidth | CompareOptions.IgnoreCase );
		}

		/// <summary>
		/// <para>指定されたいずれかの文字列を含むかどうかを返します</para>
		/// <para>var str = "ピカチュウカイリュー";</para>
		/// <para>Debug.Log( str.IncludeAny( "ピカチュウ", "カイリュー" ) ); // True</para>
		/// <para>Debug.Log( str.IncludeAny( "カイリュー", "ヤドラン" ) ); // True</para>
		/// <para>Debug.Log( str.IncludeAny( "ヤドラン", "ピジョン" ) ); // False</para>
		/// </summary>
		public static bool IncludeAny( this string self, params string[] list )
		{
			return list.Any( c => self.Contains( c ) );
		}

		/// <summary>
		/// <para>指定された文字列に拡張子を追加して返します</para>
		/// <para>既に拡張子が設定されている場合は何もしません</para>
		/// </summary>
		public static string SafeAddExtension( this string self, string extension )
		{
			if ( self.EndsWith( extension ) ) return self;
			return self + extension;
		}

		/// <summary>
		/// 改行コードを削除した文字列を返します
		/// </summary>
		public static string RemoveNewLine( this string self )
		{
			return self.ReplaceEmpty( "\n" ).ReplaceEmpty( "\r" );
		}

		/// <summary>
		/// 指定された色で文字列を装飾して返します
		/// </summary>
		public static string Coloring( this string str, string color )
		{
			return string.Format( "<color={0}>{1}</color>", color, str );
		}

		/// <summary>
		/// 赤色で文字列を装飾して返します
		/// </summary>
		public static string Red( this string str )
		{
			return str.Coloring( "red" );
		}

		/// <summary>
		/// 緑色で文字列を装飾して返します
		/// </summary>
		public static string Green( this string str )
		{
			return str.Coloring( "green" );
		}

		/// <summary>
		/// 青色で文字列を装飾して返します
		/// </summary>
		public static string Blue( this string str )
		{
			return str.Coloring( "blue" );
		}

		/// <summary>
		/// 指定されたサイズで文字列を装飾して返します
		/// </summary>
		public static string Resize( this string str, int size )
		{
			return string.Format( "<size={0}>{1}</size>", size, str );
		}

		/// <summary>
		/// 小サイズで文字列を装飾して返します
		/// </summary>
		public static string Small( this string str )
		{
			return str.Resize( 9 );
		}

		/// <summary>
		/// 中サイズで文字列を装飾して返します
		/// </summary>
		public static string Medium( this string str )
		{
			return str.Resize( 11 );
		}

		/// <summary>
		/// 大サイズで文字列を装飾して返します
		/// </summary>
		public static string Large( this string str )
		{
			return str.Resize( 16 );
		}

		/// <summary>
		/// 文字列を太字にして返します
		/// </summary>
		public static string Bold( this string str )
		{
			return string.Format( "<b>{0}</b>", str );
		}

		/// <summary>
		/// 文字列を斜体にして返します
		/// </summary>
		public static string Italic( this string str )
		{
			return string.Format( "<i>{0}</i>", str );
		}

		/// <summary>
		/// 文字列中における特定文字列の出現回数をカウントして返します
		/// </summary>
		public static int CountString( this string self, string str )
		{
			return ( self.Length - self.Replace( str, "" ).Length ) / str.Length;
		}

		/// <summary>
		/// <para>特定文字列を指定個数を残した状態まで先頭から削除して返します</para>
		/// <para>"あ\nい\nう\nえ\nお".Reduce( "\n", 2 )</para>
		/// <para>↓</para>
		/// <para>"あいう\nえ\nお"</para>
		/// </summary>
		public static string Reduce( this string self, string str, int remainCount )
		{
			while ( remainCount < self.CountString( str ) )
			{
				self = self.Remove( self.IndexOf( str ), str.Length );
			}
			return self;
		}

		/// <summary>
		/// <para>特定文字列を指定個数を残した状態まで末尾から削除して返します</para>
		/// <para>"あ\nい\nう\nえ\nお".LastReduce( "\n", 2 )</para>
		/// <para>↓</para>
		/// <para>"あ\nい\nうえお"</para>
		/// </summary>
		public static string LastReduce( this string self, string str, int remainCount )
		{
			while ( remainCount < self.CountString( str ) )
			{
				self = self.Remove( self.LastIndexOf( str ), str.Length );
			}
			return self;
		}

		/// <summary>
		/// <para>Unicode 文字列から Shift-JIS 文字列に変換して返します</para>
		/// <para>http://blog.livedoor.jp/pandora200x/archives/50087762.html</para>
		/// </summary>
		public static string ToShiftJis( this string unicodeStrings )
		{
#if UNITY_EDITOR
			var unicode = Encoding.Unicode;
			var unicodeByte = unicode.GetBytes( unicodeStrings );
			var s_jis = Encoding.GetEncoding( "shift_jis" );
			var s_jisByte = Encoding.Convert( unicode, s_jis, unicodeByte );
			var s_jisChars = new char[ s_jis.GetCharCount( s_jisByte, 0, s_jisByte.Length ) ];
			s_jis.GetChars( s_jisByte, 0, s_jisByte.Length, s_jisChars, 0 );
			return new string( s_jisChars );
#else
			return unicodeStrings;
#endif
		}

		/// <summary>
		/// 入力文字列内に含まれるエスケープされた文字を変換して返します
		/// </summary>
		public static string Unescape( this string self )
		{
			return Regex.Unescape( self );
		}

		/// <summary>
		/// 文字 (\、*、+、?、|、{、[、(、)、^、$、.、#、および空白) をエスケープコードに置き換えることにより、このような文字をエスケープして返します
		/// </summary>
		public static string Escape( this string self )
		{
			return Regex.Escape( self );
		}

		/// <summary>
		/// 文字列を指定した文字数で分割して返します
		/// </summary>
		public static string[] SubstringAtCount( this string self, int count )
		{
			var result = new List<string>();
			var length = ( int )Math.Ceiling( ( double )self.Length / count );

			for ( int i = 0; i < length; i++ )
			{
				int start = count * i;
				if ( self.Length <= start )
				{
					break;
				}
				if ( self.Length < start + count )
				{
					result.Add( self.Substring( start ) );
				}
				else
				{
					result.Add( self.Substring( start, count ) );
				}
			}

			return result.ToArray();
		}

		/// <summary>
		/// <para>指定された文字列がこのインスタンス内で最後に見つかった場合、</para>
		/// <para>その文字列を削除した新しい文字列を返します</para>
		/// </summary>
		public static string RemoveAtLast( this string self, string value )
		{
			return self.Remove( self.LastIndexOf( value ), value.Length );
		}
		
		/// <summary>
		/// 高速な StartsWith
		/// </summary>
		public static bool CustomStartsWith( this string a, string b )
		{
			int aLen = a.Length;
			int bLen = b.Length;
			int ap   = 0;
			int bp   = 0;

			while ( ap < aLen && bp < bLen && a[ ap ] == b[ bp ] )
			{
				ap++;
				bp++;
			}

			return ( bp == bLen && aLen >= bLen ) || ( ap == aLen && bLen >= aLen );
		}
		
		/// <summary>
		/// 高速な EndsWith
		/// </summary>
		public static bool CustomEndsWith( this string a, string b )
		{
			int ap = a.Length - 1;
			int bp = b.Length - 1;

			while ( ap >= 0 && bp >= 0 && a[ ap ] == b[ bp ] )
			{
				ap--;
				bp--;
			}

			return ( bp < 0 && a.Length >= b.Length ) || ( ap < 0 && b.Length >= a.Length );
		}
		
		/// <summary>
		/// 文字列がすべて小文字の場合 true を返します
		/// </summary>
		public static bool IsLower( this string self )
		{
			for ( int i = 0; i < self.Length; i++ )
			{
				if ( char.IsUpper( self[ i ] ) )
				{
					return false;
				}
			}

			return true;
		}
		
		/// <summary>
		/// 文字列がすべて大文字の場合 true を返します
		/// </summary>
		public static bool IsUpper( this string self )
		{
			for ( int i = 0; i < self.Length; i++ )
			{
				if ( char.IsLower( self[ i ] ) )
				{
					return false;
				}
			}

			return true;
		}
		
		/// <summary>
		/// 一行目だけ返します
		/// </summary>
		public static string GetFirstLine( this string self )
		{
			var separator = new [] { Environment.NewLine };

			return self
					.Split( separator, StringSplitOptions.None )
					.FirstOrDefault()
				;
		}
	}
}