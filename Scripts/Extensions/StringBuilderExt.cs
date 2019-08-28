using System.Text;

namespace KoganeUnityLib
{
	/// <summary>
	/// StringBuilder 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class StringBuilderExt
	{
		/// <summary>
		/// 指定した文字列のコピーと既定の行終端記号を、現在の StringBuilder オブジェクトの末尾に追加します
		/// </summary>
		///
		public static StringBuilder AppendLine( this StringBuilder self, string format, object arg0 )
		{
			return self.AppendFormat( format, arg0 ).AppendLine();
		}

		/// <summary>
		/// 指定した文字列のコピーと既定の行終端記号を、現在の StringBuilder オブジェクトの末尾に追加します
		/// </summary>
		///
		public static StringBuilder AppendLine( this StringBuilder self, string format, params object[] args )
		{
			return self.AppendFormat( format, args ).AppendLine();
		}

		/// <summary>
		/// 指定した文字列のコピーと既定の行終端記号を、現在の StringBuilder オブジェクトの末尾に追加します
		/// </summary>
		///
		public static StringBuilder AppendLine( this StringBuilder self, string format, object arg0, object arg1 )
		{
			return self.AppendFormat( format, arg0, arg1 ).AppendLine();
		}

		/// <summary>
		/// 指定した文字列のコピーと既定の行終端記号を、現在の StringBuilder オブジェクトの末尾に追加します
		/// </summary>
		///
		public static StringBuilder AppendLine( this StringBuilder self, string format, object arg0, object arg1, object arg2 )
		{
			return self.AppendFormat( format, arg0, arg1, arg2 ).AppendLine();
		}
	}
}