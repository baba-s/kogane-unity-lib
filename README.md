# KoganeUnityLib

「KoganeUnityLib」は便利な拡張メソッドがセットになった簡易ライブラリです  

# 開発環境

- Unity 2017.3.0f3

# 導入方法

1. 下記のページにアクセスして「KoganeUnityLib.unitypackage」をダウンロードします  
https://github.com/baba-s/kogane-unity-lib/blob/master/KoganeUnityLib.unitypackage?raw=true
2. ダウンロードした「KoganeUnityLib.unitypackage」を Unity プロジェクトにインポートします 

# 拡張メソッド

※更新中

## ActionExt

```cs
private void Hoge( Action callback )
{
    callback.Call(); // Action を実行。null なら無視
}
```

## DictionaryExt

```cs
private void Hoge( Dictionary<int, string> dict )
{
    string str = "";

    // 指定されたキーに紐付く値を返す。キーが存在しない場合はデフォルト値を返す
    str = dict.GetOrDefault( 25 );
    str = dict.GetOrDefault( 25, "ピカチュウ" );

    str = dict.ElementAtRandom(); // ランダムに要素を返す

    var hashtable = dict.ToHashtable(); // Hashtable に変換
}
```

## EnumExt

```cs
private void Hoge( JobType type )
{
    // 指定されたフラグを含む場合 true
    if ( type.HasFlag( JobType.SOLDIER | JobType.SORCERER ) ) { }
}
```

## FloatExt

```cs
private void Hoge( float value )
{
    if ( value.SafeEquals( 25.5f, 0.001f ) ) { } // しきい値を考慮して等しい場合 true
    if ( value.IsValidated() ) { } // 値が正常なら true

    var result = value.GetValueOrDefault( 10.0f ); // 値が不正ならデフォルト値を返す
}
```

## FuncExt

```cs
private void Hoge( Func<bool> callback )
{
    
    if ( callback.Call() ) { } // Func を実行。null なら無視
    if ( callback.All() ) { } // Func に登録されているすべてのデリゲートが true を返す場合 true
    if ( callback.Any() ) { } // Func に登録されているいずれかのデリゲートが true を返す場合 true
}
```

## GenericExt

```cs
private void Hoge( int value )
{
    if ( value.ContainsAny( 5, 10, 15 ) ) { } // 指定されたいずれかの項目に等しいなら true
}
```

## IDisposableExt

```cs
private void Hoge( IDisposable value )
{
    // Dispose を実行。null なら無視
    value.DisposeIfNotNull();
}
```

## IEnumerableExt

```cs
private void Hoge( IEnumerable<CharaData> list )
{
    CharaData result = null;
    int num = 0;

    // foreach
    list.ForEach( c => { } );
    list.ForEach( ( val, index ) => { } );

    if ( list.IsEmpty() ) { } // シーケンスが空なら true
    if ( list.IsNullOrEmpty() ) { } // シーケンスが null か空なら true
    if ( list.IsNotNullOrEmpty() ) { } // シーケンスが null でも空でもないなら true
    if ( list.SequenceEqual( list2, c => c.id ) ) { } // 指定されたシーケンスと等しい場合 true

    list = list.Pager( 10, 5 ); // list.Skip( 10 * 5 ).Take( 5 )
    list = list.DefaultIfNull(); // シーケンスが null なら空のシーケンスを返す
    list = list.NotNull(); // list.Where( c => c != null )
    list = list.WhereNot( c => c.id == 25 ); // 指定された条件を満たさない要素を返す
    list = list.StartWith( new [] { new CharaData() } ); // シーケンスの先頭に挿入
    list = list.Concat( list2, list3, list4 ); // シーケンスを連結
    list = list.Concat( new CharaData() ); // シーケンスを連結
    list = list.Distinct( c => c.id ); // 重複削除

    var chunk = list.Chunks( 10 ); // シーケンスを分割

    // 目的の値に最も近い値を持つ要素を返す
    result = list.FindNearest( 25, c => c.id ); // 見つからなかったら例外
    result = list.FindNearestOrDefault( 25, c => c.id ); // 見つからなかったらデフォルト値を返す

    // 目的の値に最も近く、目的の値より大きい値を持つ要素を返す
    result = list.FindNearestMoreThan( 25, c => c.id ); // 見つからなかったら例外
    result = list.FindNearestMoreThanOrDefault( 25, c => c.id ); // 見つからなかったらデフォルト値を返す

    // 目的の値に最も近く、目的の値以上の値を持つ要素を返す
    result = list.FindNearestOrMore( 25, c => c.id ); // 見つからなかったら例外
    result = list.FindNearestOrMoreOrDefault( 25, c => c.id ); // 見つからなかったらデフォルト値を返す

    // 目的の値に最も近く、目的の値以下の値を持つ要素を返す
    result = list.FindNearestOrLess( 25, c => c.id ); // 見つからなかったら例外
    result = list.FindNearestOrLessOrDefault( 25, c => c.id ); // 見つからなかったらデフォルト値を返す

    // 目的の値に最も近く、目的の値より小さい値を持つ要素を返す
    result = list.FindNearestMoreLess( 25, c => c.id ); // 
    result = list.FindNearestMoreLessOrDefault( 25, c => c.id ); // 見つからなかったらデフォルト値を返す

    // 目的の値に最も近い値を持つ値を返す
    num = list.Nearest( 25, c => c.id ); // 見つからなかったら例外
    num = list.NearestOrDefault( 25, c => c.id ); // 見つからなかったらデフォルト値を返す

    // 目的の値に最も近く、目的の値より大きい値を持つ値を返す
    num = list.NearestMoreThan( 25, c => c.id ); // 見つからなかったら例外
    num = list.NearestMoreThanOrDefault( 25, c => c.id ); // 見つからなかったらデフォルト値を返す

    // 目的の値に最も近く、目的の値以上の値を返す
    num = list.NearestOrMore( 25, c => c.id ); // 見つからなかったら例外
    num = list.NearestOrMoreOrDefault( 25, c => c.id ); // 見つからなかったらデフォルト値を返す

    // 目的の値に最も近く、目的の値以下の値を返す
    num = list.NearestOrLess( 25, c => c.id ); // 見つからなかったら例外
    num = list.NearestOrLessOrDefault( 25, c => c.id ); // 見つからなかったらデフォルト値を返す

    // 目的の値に最も近く、目的の値より小さい値を持つ値を返す
    num = list.NearestMoreLess( 25, c => c.id ); // 
    num = list.NearestMoreLessOrDefault( 25, c => c.id ); // 見つからなかったらデフォルト値を返す
}
```

## IListExt

```cs
private void Hoge( IList<CharaData> list )
{
    // foreach
    list.ForEach( c => { } );
    list.ForEach( ( val, index ) => { } );
    list.ForEachReverse( c => { } );
    list.ForEachReverse( ( val, index ) => { } );

    // 検索
    result = list.Find( c => c.name == "ピカチュウ" ) );
    result = list.FindLast( c => c.name == "ピカチュウ" ) );
    result = list.FindIndex( c => c.name == "ピカチュウ" ) );
    result = list.FindLastIndex( c => c.name == "ピカチュウ" ) );
    
    result = list.ElementAtRandom(); // 要素をランダムに返す
    result = list.ElementAtOrDefault( 25 ); // 要素を取得。範囲外ならデフォルト値を返す
    result = list.Dequeue(); // 先頭の要素を返してリストから削除

    result = list.FindMin( c => c.id ); // 最小値を持つ要素を返す
    result = list.FindMax( c => c.id ); // 最大値を持つ要素を返す

    if ( list.IsDefinedAt( 25 ) ) { } // 指定されたインデックスが範囲内なら true
}
```

## IntExt

```cs
private void Hoge( int value )
{
    // 指定された回数分処理を繰り返す
    value.Times( () => { } );
    value.Times( i => { } );

    Debug.Log( value.ZeroFill( 4 ) ); // 123.ZeroFill( 4 ) → 01234
    Debug.Log( value.FixedPoint( 4 ) ); // 123.FixedPoint( 4 ) → 123.0000

    int repeat = value.Repeat( 1, 5 ) // 数値を加算。範囲を超えた分は 0 から処理

    if ( value.IsEven() ) { } // 偶数なら true
    if ( value.IsOdd() ) { } // 奇数なら true
}
```

## ListExt

```cs
private void Hoge( List<string> list )
{
    list.AddRange( "フシギダネ", "フシギソウ", "フシギバナ" ); // 指定されたコレクションを末尾に追加
    list.Set( "フシギダネ", "フシギソウ", "フシギバナ" ); // 指定されたコレクションで上書き
    list.Sort( c => c ) // 指定された要素でソート
    list.SortDescending( c => c ) // 指定された要素で逆順にソート
    list.Shuffle(); // 要素をランダムに並べ替え
    list.Remove( c => c.Contains( "ピ" ) ); // 指定された条件を満たす要素を削除
    list.InsertFirst( "ヒトカゲ" ); // 指定された要素を先頭に挿入
    list.RemoveSince( 3 ); // 指定された数になるまで末尾から要素を削除
}
```

## MulticastDelegateExt

```cs
private void Hoge( Action callback )
{
    // デリゲートの登録数を返す
    int length1 = callback.GetLength();
    int length2 = callback.GetLengthIfNotNull();

    if ( callback.IsNullOrEmpty() ) { } // デリゲートが登録されている場合 true
    if ( callback.IsNotNullOrEmpty() ) { } // デリゲートが登録されていない場合 true
}
```

## ObjectExt

```cs
private void Hoge( object obj )
{
    Debug.Log( obj.FormatWithComma() ); // 数値を 3 桁区切りの文字列に変換
}
```

## RectExt

```cs
private void Hoge( Rect rect )
{
    // ずらす
    rect = rect.Shift( new Vector2( 1, 2 ) );
    rect = rect.Shift( 1, 2 );
}
```

## StringBuilderExt

```cs
private void Hoge( StringBuilder sb )
{
    sb.AppendLine( "{0}/{1}", 5, 25 ); // AppendLine で書式指定可能
}
```

## StringExt

```cs
private void Hoge( string str )
{
    // 正規表現
    if ( str.IsMatch( ".*" ) ) { } // パターンマッチする場合 true
    var match = str.Match( ".*" ); // パターンマッチした箇所の情報を返す
    var matchCollection = str.Matches( ".*" ); // パターンマッチした箇所の情報をすべて返す
    var replaced = str.ReplaceRegex( ".*", "$1" ); // 置換

    Debug.Log( str.FormatWith( 25, "ピカチュウ" ) ) // string.Format の拡張メソッド版
    Debug.Log( texts.ConcatWith( "\n" ) ); // string.Join の拡張メソッド版

    if ( str.IsNullOrEmpty() ) { } // null もしくは空文字列なら true
    if ( str.IsNotNullOrEmpty() ) { } // null でも空文字列でもないなら true 
    if ( str.IsNullOrWhiteSpace() ) { } // null もしくは空文字列もしくは空白文字のみなら true
    if ( str.IsNotNullOrWhiteSpace() ) { } // null でも空文字列でも空白文字のみでもないなら true

    // 文字列が null もしくは空文字列ならデフォルト値を返す
    Debug.Log( str.DefaultIfEmpty( "ピカチュウ" ) );
    Debug.Log( str.DefaultIfWhiteSpace( "ピカチュウ" ) );

    var list = str.Split( "\n" ); // 指定された区切り文字で分割して返す

    Debug.Log( str.Limit( 5 ) ); // 指定された長さに制限した文字列を返す
    Debug.Log( str.ReplaceEmpty( "ピカチュウ" ) ); // 指定された文字列を削除
    Debug.Log( str.AddFront( "ピカチュウ" ) ); // 先頭に文字列を挿入
    Debug.Log( str.ToTitleCase() ) // 先頭文字を大文字に変換

    // スネークケースの文字列をキャメルケースに変換
    Debug.Log( str.SnakeToUpperCamel() ); // quoted_printable_encode → QuotedPrintableEncode
    Debug.Log( str.SnakeToLowerCamel() ); // quoted_printable_encode → quotedPrintableEncode

    Debug.Log( str.ToWindowsPath() ); // temp/doc.txt → temp\\doc.txt
    Debug.Log( str.ToMacPath() ); // temp\\doc.txt → temp/doc.txt

    int byteCount = str.GetByteCount(); // バイト数を返す
    Debug.Log( str.SubstringInByte( 5 ) ); // 指定されたバイト単位で部分文字列を返す

    Debug.Log( str.Trim( "\n" ) ); // \n王国兵士\n魔法使い\n → 王国兵士\n魔法使い
    Debug.Log( str.TrimEnd( "\n" ) ); // \n王国兵士\n魔法使い\n → \n王国兵士\n魔法使い
    Debug.Log( str.TrimStart( "\n" ) ); // \n王国兵士\n魔法使い\n → 王国兵士\n魔法使い\n

    Debug.Log( str.Repeat( 5 ) ); // 指定された回数分繰り返し連結した文字列を返す
    Debug.Log( str.RemoveNewLine() ); // 改行コードを削除

    if ( str.CompareIgnoreWidthAndCase( "ABC") ) { } // 全角半角を無視して比較

    if ( str.IncludeAny(  "ピカチュウ", "カイリュー" ) ) // いずれかの文字列を含む場合 true

    Debug.Log( str.Coloring( "ff0000" ) ); // <color={0}>str</color>
    Debug.Log( str.Red() ); // <color=red>str</color>
    Debug.Log( str.Green() ); // <color=green>str</color>
    Debug.Log( str.Blue() ); // <color=blue>str</color>
    Debug.Log( str.Resize( 16 ) ); // <size={0}>str</size>
    Debug.Log( str.Small() ); // <size=9>str</size>
    Debug.Log( str.Medium() ); // <size=11>str</size>
    Debug.Log( str.Large() ); // <size=16>str</size>
    Debug.Log( str.Bold() ); // <b>str</b>
    Debug.Log( str.Italic() ); // <i>str</i>

    int count = str.CountString( "ピ" ); // 指定された文字列の出現回数を返す

    Debug.Log( str.Reduce( "\n", 2 ) ); // あ\nい\nう\nえ\nお → あいう\nえ\nお
    Debug.Log( str.LastReduce( "\n", 2 ) ); // あ\nい\nう\nえ\nお → あ\nい\nうえお

    Debug.Log( str.ToShiftJis() ); // Unicode から Shift-JIS に変換
}
```

## StringParseExt

```cs
private void Hoge( string str )
{
    // 文字列と次の型の変換に関する拡張メソッド
    // sbyte, byte, char, short, ushort, int, uint, long, ulong
    // float, double, decimal, DateTime, bool, enum

    int i1 = str.ToInt(); // int に変換
    int? i2 = str.ToIntOrNull(); // int に変換。変換できない場合は null を返す
    int i3 = str.ToIntOrDefault(); // int に変換。変換できない場合はデフォルト値を返す
    int i4 = str.ToIntOrDefault( 25 ); // int に変換。変換できない場合はデフォルト値を返す
    if ( str.IsInt() ) { } // int に変換できる場合 true
}

## TimeSpanExt

```cs
private void Hoge( TimeSpan ts )
{
    // DateTime 型に変換
    var dateTime = ts.ToDateTime();

    Debug.Log( ts.ToPattern() ); // yyyy/MM/dd HH:mm:ss
    Debug.Log( ts.ToShortDatePattern() ); // yyyy/MM/dd
    Debug.Log( ts.ToLongDatePattern() ); // yyyy年M月d日
    Debug.Log( ts.ToFullDateTimePattern() ); // yyyy年M月d日 HH:mm:ss
    Debug.Log( ts.ToMiddleDateTimePattern() ); // MM/dd HH:mm
    Debug.Log( ts.ToShortTimePattern() ); // HH:mm
    Debug.Log( ts.ToLongTimePattern() ); // HH:mm:ss
}
```

## UintExt

```cs
private void Hoge( uint value )
{
    // 指定された回数分処理を繰り返す
    value.Times( () => { } );
    value.Times( i => { } );

    Debug.Log( value.ZeroFill( 4 ) ); // 123.ZeroFill( 4 ) → 01234
}
```

## Vector3Ext

```cs
private void Hoge( Vector3 v )
{
    if ( v.IsUniform() ) { } // x, y, z の値が等しい場合 true
}
```

## WWWExt

```cs
private void Hoge( WWW www )
{
    if ( www.IsError() ) { }

    if ( www.IsNotError() ) { }
}
```