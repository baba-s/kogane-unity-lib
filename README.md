# KoganeUnityLib

「KoganeUnityLib」は便利な拡張メソッドがセットになった簡易ライブラリです  

![](https://img.shields.io/badge/Unity-2018.4%2B-red.svg)
![](https://img.shields.io/badge/.NET-4.x-orange.svg)
[![](https://img.shields.io/github/license/baba-s/kogane-unity-lib.svg)](https://github.com/baba-s/kogane-unity-lib/blob/master/LICENSE.md)

# インストール

```json
"com.baba_s.kogane_unity_lib": "https://github.com/baba-s/kogane-unity-lib.git",
```

manifest.json に上記の記述を追加します  

# 拡張メソッド

## ActionExt

```cs
private void Hoge( Action callback )
{
    callback.Call(); // Action を実行。null なら無視
}
```

## ArrayExt

```cs
private void Hoge( string[] array )
{
    var str = string.Empty;
    int index = -1;

    var collection = array.AsReadOnly();

    array.Clear();

    str = array.Find( c => c == "ピカチュウ" );
    str = array.FindLast( c => c == "ピカチュウ" );
    str = array.First();
    str = array.Last();
    str = array.ElementAtRandom();

    index = array.FindIndex( c => c == "ピカチュウ" );
    index = array.FindLastIndex( c => c == "ピカチュウ" );
    index = array.IndexOf( "ピカチュウ" );
    index = array.LastIndexOf( "ピカチュウ" );

    array = array.FindAll( c => c == "ピカチュウ" );
    array = array.Reverse();
    array = array.Shuffle();
    
    if ( array.Exists( c => c == "ピカチュウ" ) ) { }
    if ( array.TrueForAll( c => c == "ピカチュウ" ) ) { }

    array.ForEach( c => { } );
    array.Sort( c => c );
    array.SortDescending( c => c );
}
```

## BoolExt

```cs
private void Hoge( bool value )
{
    var result = value.ToByte(); // byte 型に変換
}
```

## ByteExt

```cs
private void Hoge( byte value )
{
    var result = value.ToBool(); // bool 型に変換

    Debug.Log( value.ZeroFill( 4 ) ); // 123.ZeroFill( 4 ) → 01234
}
```

## ColorExt

```cs
private void Hoge( Color color )
{
    Debug.Log( color.EncodeColor() ); // Color.red.EncodeColor() → FF0000

    int num = color.ToInt(); // 16 進数の数値に変換
}
```

## ComponentExt

```cs
private void Hoge( Component com )
{
    if ( com.HasBeenDestroyed() ) { } // オブジェクトが破棄済みなら true
    if ( com.HasComponent<Rigidbody>() ) { } // コンポーネントがアタッチされていれば true
    if ( com.HasParent() ) { } // 親が存在する場合 true
    if ( com.HasChild() ) { } // 子が存在する場合 true
    if ( com.HasMissingScript() ) { } // 不正なコンポーネントがアタッチされていれば true

    Rigidbody rigidbody = null;
    rigidbody = com.GetOrAddComponent<Rigidbody>(); // コンポーネントを取得もしくはアタッチ
    rigidbody = com.AddComponent<Rigidbody>(); // コンポーネントをアタッチ

    var children = com.GetChildren(); // 子オブジェクトをすべて取得

    // 自分自身を除く指定されたコンポーネントをすべて取得
    Rigidbody[] rigidbodys = null;
    rigidbodys = com.GetComponentsInChildrenWithoutSelf<Rigidbody>();

    com.RemoveComponent<Rigidbody>(); // コンポーネントを削除
    com.RemoveComponents<Rigidbody>(); // コンポーネントをすべて削除
    com.RemoveComponentImmediate<Rigidbody>(); // コンポーネントを削除（エディタ用）
    com.RemoveComponentsImmediate<Rigidbody>(); // コンポーネントをすべて削除（エディタ用）

    com.SetActive( true ); // ゲームオブジェクトのアクティブ設定
    com.SetParent( cube ); // 親を設定
    com.LookAt( cube ); // 向きを変更

    GameObject go = null;

    go = com.FindDeep( "Cube" ); // 深い階層までゲームオブジェクトを検索
    go = com.GetParent(); // 親を取得
    go = com.GetRoot(); // ルートオブジェクトを取得

    var t = com.GetChild( 0 ); // 子を取得

    int layer = com.GetLayer(); // レイヤーを取得
    com.SetLayer( 0 ); // レイヤーを設定
    com.SetLayerRecursively( 0 ); // レイヤーを設定（子も対象）

    var vec = Vector3.zero;
    var x = 0f;
    var y = 0f;
    var z = 0f;

    // transform.position を操作
    com.ResetPosition();
    vec = com.GetPosition();
    x = com.GetPositionX();
    y = com.GetPositionY();
    z = com.GetPositionZ();
    com.SetPositionX( 1 );
    com.SetPositionY( 2 );
    com.SetPositionZ( 3 );
    com.SetPosition( 1, 2, 3 );
    com.SetPosition( new Vector2( 1, 2 ) );
    com.SetPosition( new Vector3( 1, 2, 3 ) );
    com.AddPositionX( 1 );
    com.AddPositionY( 2 );
    com.AddPositionZ( 3 );
    com.AddPosition( 1, 2 );
    com.AddPosition( 1, 2, 3 );
    com.AddPosition( new Vector2( 1, 2 ) );
    com.AddPosition( new Vector3( 1, 2, 3 ) );

    // transform.localPositon を操作
    com.ResetLocalPosition();
    vec = com.GetLocalPosition();
    x = com.GetLocalPositionX();
    y = com.GetLocalPositionY();
    z = com.GetLocalPositionZ();
    com.SetLocalPositionX( 1 );
    com.SetLocalPositionY( 2 );
    com.SetLocalPositionZ( 3 );
    com.SetLocalPosition( 1, 2, 3 );
    com.SetLocalPosition( new Vector2( 1, 2 ) );
    com.SetLocalPosition( new Vector3( 1, 2, 3 ) );
    com.AddLocalPositionX( 1 );
    com.AddLocalPositionY( 2 );
    com.AddLocalPositionZ( 3 );
    com.AddLocalPosition( 1, 2 );
    com.AddLocalPosition( 1, 2, 3 );
    com.AddLocalPosition( new Vector2( 1, 2 ) );
    com.AddLocalPosition( new Vector3( 1, 2, 3 ) );

    // transform.localScale を操作
    com.ResetLocalScale();
    vec = com.GetLocalScale();
    x = com.GetLocalScaleX();
    y = com.GetLocalScaleY();
    z = com.GetLocalScaleZ();
    com.SetLocalScaleX( 1 );
    com.SetLocalScaleY( 2 );
    com.SetLocalScaleZ( 3 );
    com.SetLocalScale( 1, 2, 3 );
    com.SetLocalScale( new Vector2( 1, 2 ) );
    com.SetLocalScale( new Vector3( 1, 2, 3 ) );
    com.AddLocalScaleX( 1 );
    com.AddLocalScaleY( 2 );
    com.AddLocalScaleZ( 3 );
    com.AddLocalScale( 1, 2 );
    com.AddLocalScale( 1, 2, 3 );
    com.AddLocalScale( new Vector2( 1, 2 ) );
    com.AddLocalScale( new Vector3( 1, 2, 3 ) );

    // transform.eulerAngles を操作
    com.ResetEulerAngles();
    vec = com.GetEulerAngles();
    x = com.GetEulerAngleX();
    y = com.GetEulerAngleY();
    z = com.GetEulerAngleZ();
    com.SetEulerAngleX( 1 );
    com.SetEulerAngleY( 2 );
    com.SetEulerAngleZ( 3 );
    com.SetEulerAngles( 1, 2, 3 );
    com.SetEulerAngles( new Vector2( 1, 2 ) );
    com.SetEulerAngles( new Vector3( 1, 2, 3 ) );
    com.AddEulerAngleX( 1 );
    com.AddEulerAngleY( 2 );
    com.AddEulerAngleZ( 3 );

    // transform.localEulerAngles を操作
    com.ResetLocalEulerAngles();
    vec = com.GetLocalEulerAngles();
    x = com.GetLocalEulerAngleX();
    y = com.GetLocalEulerAngleY();
    z = com.GetLocalEulerAngleZ();
    com.SetLocalEulerAngleX( 1 );
    com.SetLocalEulerAngleY( 2 );
    com.SetLocalEulerAngleZ( 3 );
    com.SetLocalEulerAngles( 1, 2, 3 );
    com.SetLocalEulerAngles( new Vector2( 1, 2 ) );
    com.SetLocalEulerAngles( new Vector3( 1, 2, 3 ) );
    com.AddLocalEulerAngleX( 1 );
    com.AddLocalEulerAngleY( 2 );
    com.AddLocalEulerAngleZ( 3 );
}
```

## DateTimeExt

```cs
private void Hoge( DateTime dt )
{
    Debug.Log( dt.ToPattern() ); // yyyy/MM/dd HH:mm:ss
    Debug.Log( dt.ToShortDatePattern() ); // yyyy/MM/dd
    Debug.Log( dt.ToLongDatePattern() ); // yyyy年M月d日
    Debug.Log( dt.ToFullDateTimePattern() ); // yyyy年M月d日 HH:mm:ss
    Debug.Log( dt.ToMiddleDateTimePattern() ); // MM/dd HH:mm
    Debug.Log( dt.ToShortTimePattern() ); // HH:mm
    Debug.Log( dt.ToLongTimePattern() ); // HH:mm:ss
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

## GameObjectExt

```cs
private void Hoge( GameObject com )
{
    if ( com.HasComponent<Rigidbody>() ) { } // コンポーネントがアタッチされていれば true
    if ( com.HasParent() ) { } // 親が存在する場合 true
    if ( com.HasChild() ) { } // 子が存在する場合 true
    if ( com.HasMissingScript() ) { } // 不正なコンポーネントがアタッチされていれば true

    var rigidbody = com.GetOrAddComponent<Rigidbody>(); // コンポーネントを取得もしくはアタッチ
    var children = com.GetChildren(); // 子オブジェクトをすべて取得

    // 自分自身を除く指定されたコンポーネントをすべて取得
    var rigidbodys = com.GetComponentsInChildrenWithoutSelf<Rigidbody>();

    com.RemoveComponent<Rigidbody>(); // コンポーネントを削除
    com.RemoveComponents<Rigidbody>(); // コンポーネントをすべて削除
    com.RemoveComponentImmediate<Rigidbody>(); // コンポーネントを削除（エディタ用）

    com.SetParent( cube ); // 親を設定
    com.LookAt( cube ); // 向きを変更

    GameObject go = null;

    go = com.FindDeep( "Cube" ); // 深い階層までゲームオブジェクトを検索
    go = com.GetParent(); // 親を取得
    go = com.GetRoot(); // ルートオブジェクトを取得

    var t = com.GetChild( 0 ); // 子を取得

    int layer = com.GetLayer(); // レイヤーを取得
    com.SetLayer( 0 ); // レイヤーを設定
    com.SetLayerRecursively( 0 ); // レイヤーを設定（子も対象）

    var vec = Vector3.zero;
    var x = 0f;
    var y = 0f;
    var z = 0f;

    // transform.position を操作
    com.ResetPosition();
    vec = com.GetPosition();
    x = com.GetPositionX();
    y = com.GetPositionY();
    z = com.GetPositionZ();
    com.SetPositionX( 1 );
    com.SetPositionY( 2 );
    com.SetPositionZ( 3 );
    com.SetPosition( 1, 2, 3 );
    com.SetPosition( new Vector2( 1, 2 ) );
    com.SetPosition( new Vector3( 1, 2, 3 ) );
    com.AddPositionX( 1 );
    com.AddPositionY( 2 );
    com.AddPositionZ( 3 );
    com.AddPosition( 1, 2 );
    com.AddPosition( 1, 2, 3 );
    com.AddPosition( new Vector2( 1, 2 ) );
    com.AddPosition( new Vector3( 1, 2, 3 ) );

    // transform.localPositon を操作
    com.ResetLocalPosition();
    vec = com.GetLocalPosition();
    x = com.GetLocalPositionX();
    y = com.GetLocalPositionY();
    z = com.GetLocalPositionZ();
    com.SetLocalPositionX( 1 );
    com.SetLocalPositionY( 2 );
    com.SetLocalPositionZ( 3 );
    com.SetLocalPosition( 1, 2, 3 );
    com.SetLocalPosition( new Vector2( 1, 2 ) );
    com.SetLocalPosition( new Vector3( 1, 2, 3 ) );
    com.AddLocalPositionX( 1 );
    com.AddLocalPositionY( 2 );
    com.AddLocalPositionZ( 3 );
    com.AddLocalPosition( 1, 2 );
    com.AddLocalPosition( 1, 2, 3 );
    com.AddLocalPosition( new Vector2( 1, 2 ) );
    com.AddLocalPosition( new Vector3( 1, 2, 3 ) );

    // transform.localScale を操作
    com.ResetLocalScale();
    vec = com.GetLocalScale();
    x = com.GetLocalScaleX();
    y = com.GetLocalScaleY();
    z = com.GetLocalScaleZ();
    com.SetLocalScaleX( 1 );
    com.SetLocalScaleY( 2 );
    com.SetLocalScaleZ( 3 );
    com.SetLocalScale( 1, 2, 3 );
    com.SetLocalScale( new Vector2( 1, 2 ) );
    com.SetLocalScale( new Vector3( 1, 2, 3 ) );
    com.AddLocalScaleX( 1 );
    com.AddLocalScaleY( 2 );
    com.AddLocalScaleZ( 3 );
    com.AddLocalScale( 1, 2 );
    com.AddLocalScale( 1, 2, 3 );
    com.AddLocalScale( new Vector2( 1, 2 ) );
    com.AddLocalScale( new Vector3( 1, 2, 3 ) );

    // transform.eulerAngles を操作
    com.ResetEulerAngles();
    vec = com.GetEulerAngles();
    x = com.GetEulerAngleX();
    y = com.GetEulerAngleY();
    z = com.GetEulerAngleZ();
    com.SetEulerAngleX( 1 );
    com.SetEulerAngleY( 2 );
    com.SetEulerAngleZ( 3 );
    com.SetEulerAngles( 1, 2, 3 );
    com.SetEulerAngles( new Vector2( 1, 2 ) );
    com.SetEulerAngles( new Vector3( 1, 2, 3 ) );
    com.AddEulerAngleX( 1 );
    com.AddEulerAngleY( 2 );
    com.AddEulerAngleZ( 3 );

    // transform.localEulerAngles を操作
    com.ResetLocalEulerAngles();
    vec = com.GetLocalEulerAngles();
    x = com.GetLocalEulerAngleX();
    y = com.GetLocalEulerAngleY();
    z = com.GetLocalEulerAngleZ();
    com.SetLocalEulerAngleX( 1 );
    com.SetLocalEulerAngleY( 2 );
    com.SetLocalEulerAngleZ( 3 );
    com.SetLocalEulerAngles( 1, 2, 3 );
    com.SetLocalEulerAngles( new Vector2( 1, 2 ) );
    com.SetLocalEulerAngles( new Vector3( 1, 2, 3 ) );
    com.AddLocalEulerAngleX( 1 );
    com.AddLocalEulerAngleY( 2 );
    com.AddLocalEulerAngleZ( 3 );
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
    result = list.FindNearestMoreLess( 25, c => c.id ); // 見つからなかったら例外
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
    num = list.NearestMoreLess( 25, c => c.id ); // 見つからなかったら例外
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
```

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

# 便利クラス

## CoroutineUtils

```cs
CoroutineUtils.CallWaitForCondition( () => IsOn, () => { } ); // 条件を満たしたらデリゲートを実行
CoroutineUtils.CallWaitForEndOfFrame( () => { } ); // 1 フレーム後にデリゲートを実行
CoroutineUtils.CallWaitForSeconds( 1f, () => { } ); // 指定秒後にデリゲートを実行
CoroutineUtils.StartCoroutine( Hoge() ); // 指定されたコルーチンを実行
```

## MultiDictionary

```cs
var m = new MultiDictionary<string, string>();

m.Add( "ほのお", "ヒトカゲ" );
m.Add( "ほのお", "リザード" );
m.Add( "ほのお", "リザードン" );
m.Add( "でんき", "ピカチュウ", "ライチュウ" );

m.Remove( "でんき", "ライチュウ" );
m.Remove( "ほのお" );

m.Clear();

if ( m.Contains( "でんき", "ピカチュウ" ) )
{
}

if ( m.ContainsKey( "でんき" ) )
{
}

foreach ( var pair in m )
{
    foreach ( var n in pair.Value )
    {
        Debug.Log( pair.Key + ": " + n );
    }
}

foreach ( var key in m.Keys )
{
    Debug.Log( key );
}

foreach ( var value in m.Values )
{
    foreach ( var n in value )
    {
        Debug.Log( n );
    }
}

Debug.Log( m.Count );
```

## MultiTask

```cs
var task = new MultiTask();

task.Add( onEnded =>
{
    Debug.Log( "1" );
    onEnded();
} );

task.Add( onEnded =>
{
    Debug.Log( "2" );
    onEnded();
} );

task.Add( onEnded =>
{
    Debug.Log( "3" );
    onEnded();
} );

task.Play( () =>
{
    Debug.Log( "completed" );
} );
```

## SingleTask

```cs
var task = new SingleTask();

task.Add( onEnded =>
{
    Debug.Log( "1" );
    onEnded();
} );

task.Add( onEnded =>
{
    Debug.Log( "2" );
    onEnded();
} );

task.Add( onEnded =>
{
    Debug.Log( "3" );
    onEnded();
} );

task.Play( () =>
{
    Debug.Log( "completed" );
} );
```

## ColorUtils

```cs
Debug.Log( ColorUtils.DecimalToHex( 1234) ); // 1234.DecimalToHex() → 0004D2

color = ColorUtils.ToARGB( 0xFFFF8000 ); // RGBA(1.000, 0.502, 0.000, 1.000)
color = ColorUtils.ToRGBA( 0xFF8000FF ); // RGBA(1.000, 0.502, 0.000, 1.000)
color = ColorUtils.ToRGB( 0xFF8000 ); // RGBA(1.000, 0.502, 0.000, 1.000)
```

## DebugUtils

```cs
// DEBUG_LOG が定義されている場合にのみ出力
DebugUtils.Log( "ピカチュウ" );
DebugUtils.LogFormat( "{0}", "ピカチュウ" );
DebugUtils.Warning( "ピカチュウ" );
DebugUtils.WarningFormat( "{0}", "ピカチュウ" );
DebugUtils.Error( "ピカチュウ" );
DebugUtils.ErrorFormat( "{0}", "ピカチュウ" );
```

## EnumerableUtils

```cs
// var list = Enumerable.Range( 0, 10 );
var list = EnumerableUtils.Range( 10 );
```

## EnumUtils

```cs
PARAM_TYPE type = 0;

type = EnumUtils.RandomAt( PARAM_TYPE.FIRE, PARAM_TYPE.AQUA ); // ランダムに返す
type = EnumUtils.Random<PARAM_TYPE>(); // ランダムに返す
type = EnumUtils.Parse<PARAM_TYPE>( "FIRE" ); // 文字列を列挙型に変換

int length = EnumUtils.GetLength<PARAM_TYPE>(); // 列挙型の要素数を取得
var list = EnumUtils.GetValues<PARAM_TYPE>(); // 列挙型の要素をすべて取得

if ( EnumUtils.IsEnum<PARAM_TYPE>( "FIRE" ) ) { } // 文字列を列挙型に変換できるなら true
```

## GameObjectUtils

```cs
if ( GameObjectUtils.Exists( "Cube" ) ) { } // 指定した名前のオブジェクトが存在する場合 true
```

## RandomUtils

```cs
Debug.Log( RandomUtils.Value ); // 0.0 から 1.0 の浮動小数点数をランダムに返す
Debug.Log( RandomUtils.BoolValue ); // true か false を返す
Debug.Log( RandomUtils.Flag ); // 1 か 0 を返す
Debug.Log( RandomUtils.Range( 10 ) ); // 0 から max - 1 を返す
```

## StringUtils

```cs
// string.Format よりも GC Alloc が発生しない
Debug.Log( StringUtils.Format( "{0}/{1}", 5, 25) );

// string.Join で IEnumerable<T> を指定できる
Debug.Log( StringUtils.Join( "\n", texts ) );

// 文字が全角なら true
if ( StringUtils.IsChar2Byte( 'A' ) ) { }
```
