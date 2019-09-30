using System.Text;
using UnityEngine.UI;

namespace KoganeUnityLib
{
	/// <summary>
	/// Text 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class TextExt
	{
		/// <summary>
		/// テキストを設定します
		/// </summary>
	    public static void SetText( this Text self, string format, params object[] args )
	    {
	        self.text = string.Format( format, args );
	    }

	    /// <summary>
	    /// テキストを設定します
	    /// </summary>
	    public static void SetText( this Text self, string          text    ) { self.text = text;                   }
	    public static void SetText( this Text self, int             value   ) { self.SetText( value .ToString() );  }
	    public static void SetText( this Text self, ushort          value   ) { self.SetText( value .ToString() );  }
	    public static void SetText( this Text self, uint            value   ) { self.SetText( value .ToString() );  }
	    public static void SetText( this Text self, ulong           value   ) { self.SetText( value .ToString() );  }
	    public static void SetText( this Text self, long            value   ) { self.SetText( value .ToString() );  }
	    public static void SetText( this Text self, byte            value   ) { self.SetText( value .ToString() );  }
	    public static void SetText( this Text self, StringBuilder   sb      ) { self.SetText( sb    .ToString() );  }
	    public static void SetText( this Text self, StringAppender  sa      ) { self.SetText( sa    .ToString() );  }
	}
}