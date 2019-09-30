using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KoganeUnityLib
{
	/// <summary>
	/// Component 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class ComponentExt
	{
		/// <summary>
		/// アクティブかどうかを設定します
		/// </summary>
		public static void SetActiveIfNotNull( this Component self, bool isActive )
		{
			if ( self == null ) return;
			self.SetActive( isActive );
		}

		/// <summary>
		/// <para>指定されたコンポーネントが削除済みかどうかを返します</para>
		/// <para>MissingReferenceException を防ぐために使用します</para>
		/// </summary>
		public static bool HasBeenDestroyed( this Component self )
		{
			return self == null || self.gameObject == null;
		}

		/// <summary>
		/// コンポーネントを取得します。コンポーネントがアタッチされていない場合は追加してから取得します
		/// </summary>
		public static T GetOrAddComponent<T>( this Component self ) where T : Component
		{
			return self.GetComponent<T>() ?? self.gameObject.AddComponent<T>();
		}

		/// <summary>
		/// コンポーネントを追加します
		/// </summary>
		public static T AddComponent<T>( this Component self ) where T : Component
		{
			return self.gameObject.AddComponent<T>();
		}

		/// <summary>
		/// すべての子オブジェクトを返します
		/// </summary>
		public static GameObject[] GetChildren( this Component self, bool includeInactive = false )
		{
			return self
				.GetComponentsInChildren<Transform>( includeInactive )
				.Where( c => c != self.transform )
				.Select( c => c.gameObject )
				.ToArray()
			;
		}

		/// <summary>
		/// 自分自身を含まない GetComponentsInChildren 関数を実行します
		/// </summary>
		public static T[] GetComponentsInChildrenWithoutSelf<T>( this Component self ) where T : Component
		{
			return self.GetComponentsInChildren<T>()
				.Where( c => self.gameObject != c.gameObject )
				.ToArray()
			;
		}

		/// <summary>
		/// コンポーネントを削除します
		/// </summary>
		public static void RemoveComponent<T>( this Component self ) where T : Component
		{
			GameObject.Destroy( self.GetComponent<T>() );
		}

		/// <summary>
		/// コンポーネントをすべて削除します
		/// </summary>
		public static void RemoveComponents<T>( this Component self ) where T : Component
		{
			foreach ( Component component in self.GetComponents<T>() )
			{
				GameObject.Destroy( component );
			}
		}

		/// <summary>
		/// コンポーネントを即座に削除します
		/// </summary>
		public static void RemoveComponentImmediate<T>( this Component self ) where T : Component
		{
			GameObject.DestroyImmediate( self.GetComponent<T>() );
		}

		/// <summary>
		/// コンポーネントをすべて即座に削除します
		/// </summary>
		public static void RemoveComponentsImmediate<T>( this Component self ) where T : Component
		{
			foreach ( Component component in self.GetComponents<T>() )
			{
				GameObject.DestroyImmediate( component );
			}
		}

		/// <summary>
		/// 指定されたコンポーネントを持っているかどうかを返します
		/// </summary>
		public static bool HasComponent<T>( this Component self ) where T : Component
		{
			return self.GetComponent<T>() != null;
		}

		/// <summary>
		/// アクティブかどうかを設定します
		/// </summary>
		public static void SetActive( this Component self, bool value )
		{
			self.gameObject.SetActive( value );
		}

		/// <summary>
		/// 子オブジェクトを名前で検索します
		/// </summary>
		public static Transform Find( this Component self, string name )
		{
			return self.transform.Find( name );
		}

		/// <summary>
		/// 子オブジェクトを名前で検索して GameObject 型で取得します
		/// </summary>
		public static GameObject FindGameObject( this Component self, string name )
		{
			var result = self.transform.Find( name );
			return result != null ? result.gameObject : null;
		}

		/// <summary>
		/// 深い階層まで子オブジェクトを名前で検索して GameObject 型で取得します
		/// </summary>
		public static GameObject FindDeep( this Component self, string name, bool includeInactive = false )
		{
			var children = self.GetComponentsInChildren<Transform>( includeInactive );
			foreach ( var transform in children )
			{
				if ( transform.name == name )
				{
					return transform.gameObject;
				}
			}
			return null;
		}

		/// <summary>
		/// 位置を(0, 0, 0)にリセットします
		/// </summary>
		public static void ResetPosition( this Component self )
		{
			self.transform.position = Vector3.zero;
		}

		/// <summary>
		/// 位置を返します
		/// </summary>
		public static Vector3 GetPosition( this Component self )
		{
			return self.transform.position;
		}

		/// <summary>
		/// X 座標を返します
		/// </summary>
		public static float GetPositionX( this Component self )
		{
			return self.transform.position.x;
		}

		/// <summary>
		/// Y 座標を返します
		/// </summary>
		public static float GetPositionY( this Component self )
		{
			return self.transform.position.y;
		}

		/// <summary>
		/// Z 座標を返します
		/// </summary>
		public static float GetPositionZ( this Component self )
		{
			return self.transform.position.z;
		}

		/// <summary>
		/// X 座標を設定します
		/// </summary>
		public static void SetPositionX( this Component self, float x )
		{
			self.transform.position = new Vector3
			(
				x,
				self.transform.position.y,
				self.transform.position.z
			);
		}

		/// <summary>
		/// Y 座標を設定します
		/// </summary>
		public static void SetPositionY( this Component self, float y )
		{
			self.transform.position = new Vector3
			(
				self.transform.position.x,
				y,
				self.transform.position.z
			);
		}

		/// <summary>
		/// Z 座標を設定します
		/// </summary>
		public static void SetPositionZ( this Component self, float z )
		{
			self.transform.position = new Vector3
			(
				self.transform.position.x,
				self.transform.position.y,
				z
			);
		}

		/// <summary>
		/// Vector3 型で位置を設定します
		/// </summary>
		public static void SetPosition( this Component self, Vector3 v )
		{
			self.transform.position = v;
		}

		/// <summary>
		/// Vector2 型で位置を設定します
		/// </summary>
		public static void SetPosition( this Component self, Vector2 v )
		{
			self.transform.position = new Vector3
			(
				v.x,
				v.y,
				self.transform.position.z
			);
		}

		/// <summary>
		/// 位置を設定します
		/// </summary>
		public static void SetPosition( this Component self, float x, float y )
		{
			self.transform.position = new Vector3
			(
				x,
				y,
				self.transform.position.z
			);
		}

		/// <summary>
		/// 位置を設定します
		/// </summary>
		public static void SetPosition( this Component self, float x, float y, float z )
		{
			self.transform.position = new Vector3
			(
				x,
				y,
				z
			);
		}

		/// <summary>
		/// X 座標に加算します
		/// </summary>
		public static void AddPositionX( this Component self, float x )
		{
			self.transform.position = new Vector3
			(
				self.transform.position.x + x,
				self.transform.position.y,
				self.transform.position.z
			);
		}

		/// <summary>
		/// Y 座標に加算します
		/// </summary>
		public static void AddPositionY( this Component self, float y )
		{
			self.transform.position = new Vector3
			(
				self.transform.position.x,
				self.transform.position.y + y,
				self.transform.position.z
			);
		}

		/// <summary>
		/// Z 座標に加算します
		/// </summary>
		public static void AddPositionZ( this Component self, float z )
		{
			self.transform.position = new Vector3
			(
				self.transform.position.x,
				self.transform.position.y,
				self.transform.position.z + z
			);
		}

		/// <summary>
		/// Vector3 型で位置を加算します
		/// </summary>
		public static void AddPosition( this Component self, Vector3 v )
		{
			self.transform.position += v;
		}

		/// <summary>
		/// Vector2 型で位置を加算します
		/// </summary>
		public static void AddPosition( this Component self, Vector2 v )
		{
			self.transform.position = new Vector3
			(
				self.transform.position.x + v.x,
				self.transform.position.y + v.y,
				self.transform.position.z
			);
		}

		/// <summary>
		/// 位置を加算します
		/// </summary>
		public static void AddPosition( this Component self, float x, float y )
		{
			self.transform.position = new Vector3
			(
				self.transform.position.x + x,
				self.transform.position.y + y,
				self.transform.position.z
			);
		}

		/// <summary>
		/// 位置を加算します
		/// </summary>
		public static void AddPosition( this Component self, float x, float y, float z )
		{
			self.transform.position = new Vector3
			(
				self.transform.position.x + x,
				self.transform.position.y + y,
				self.transform.position.z + z
			);
		}

		/// <summary>
		/// ローカル座標を(0, 0, 0)にリセットします
		/// </summary>
		public static void ResetLocalPosition( this Component self )
		{
			self.transform.localPosition = Vector3.zero;
		}

		/// <summary>
		/// ローカル座標を返します
		/// </summary>
		public static Vector3 GetLocalPosition( this Component self )
		{
			return self.transform.localPosition;
		}

		/// <summary>
		/// ローカル座標系の X 座標を返します
		/// </summary>
		public static float GetLocalPositionX( this Component self )
		{
			return self.transform.localPosition.x;
		}

		/// <summary>
		/// ローカル座標系の Y 座標を返します
		/// </summary>
		public static float GetLocalPositionY( this Component self )
		{
			return self.transform.localPosition.y;
		}

		/// <summary>
		/// ローカル座標系の Z 座標を返します
		/// </summary>
		public static float GetLocalPositionZ( this Component self )
		{
			return self.transform.localPosition.z;
		}

		/// <summary>
		/// ローカル座標系のX座標を設定します
		/// </summary>
		public static void SetLocalPositionX( this Component self, float x )
		{
			self.transform.localPosition = new Vector3
			(
				x,
				self.transform.localPosition.y,
				self.transform.localPosition.z
			);
		}

		/// <summary>
		/// ローカル座標系のX座標を設定します
		/// </summary>
		public static void SetLocalPositionXIfNotNull( this Component self, float x )
		{
			if ( self == null ) return;
			self.SetLocalPositionX( x );
		}

		/// <summary>
		/// ローカル座標系のY座標を設定します
		/// </summary>
		public static void SetLocalPositionY( this Component self, float y )
		{
			self.transform.localPosition = new Vector3
			(
				self.transform.localPosition.x,
				y,
				self.transform.localPosition.z
			);
		}

		/// <summary>
		/// ローカル座標系のZ座標を設定します
		/// </summary>
		public static void SetLocalPositionZ( this Component self, float z )
		{
			self.transform.localPosition = new Vector3
			(
				self.transform.localPosition.x,
				self.transform.localPosition.y,
				z
			);
		}

		/// <summary>
		/// Vector3 型でローカル座標を設定します
		/// </summary>
		public static void SetLocalPosition( this Component self, Vector3 v )
		{
			self.transform.localPosition = v;
		}

		/// <summary>
		/// Vector2 型でローカル座標を設定します
		/// </summary>
		public static void SetLocalPosition( this Component self, Vector2 v )
		{
			self.transform.localPosition = new Vector3
			(
				v.x,
				v.y,
				self.transform.localPosition.z
			);
		}

		/// <summary>
		/// ローカル座標を設定します
		/// </summary>
		public static void SetLocalPosition( this Component self, float x, float y )
		{
			self.transform.localPosition = new Vector3
			(
				x,
				y,
				self.transform.localPosition.z
			);
		}

		/// <summary>
		/// ローカル座標を設定します
		/// </summary>
		public static void SetLocalPosition( this Component self, float x, float y, float z )
		{
			self.transform.localPosition = new Vector3
			(
				x,
				y,
				z
			);
		}

		/// <summary>
		/// ローカルのX座標に加算します
		/// </summary>
		public static void AddLocalPositionX( this Component self, float x )
		{
			self.transform.localPosition = new Vector3
			(
				self.transform.localPosition.x + x,
				self.transform.localPosition.y,
				self.transform.localPosition.z
			);
		}

		/// <summary>
		/// ローカルのY座標に加算します
		/// </summary>
		public static void AddLocalPositionY( this Component self, float y )
		{
			self.transform.localPosition = new Vector3
			(
				self.transform.localPosition.x,
				self.transform.localPosition.y + y,
				self.transform.localPosition.z
			);
		}

		/// <summary>
		/// ローカルのZ座標に加算します
		/// </summary>
		public static void AddLocalPositionZ( this Component self, float z )
		{
			self.transform.localPosition = new Vector3
			(
				self.transform.localPosition.x,
				self.transform.localPosition.y,
				self.transform.localPosition.z + z
			);
		}

		/// <summary>
		/// Vector3 型でローカル座標を加算します
		/// </summary>
		public static void AddLocalPosition( this Component self, Vector3 v )
		{
			self.transform.localPosition += v;
		}

		/// <summary>
		/// Vector2 型でローカル座標を加算します
		/// </summary>
		public static void AddLocalPosition( this Component self, Vector2 v )
		{
			self.transform.localPosition = new Vector3
			(
				self.transform.localPosition.x + v.x,
				self.transform.localPosition.y + v.y,
				self.transform.localPosition.z
			);
		}

		/// <summary>
		/// ローカル座標を加算します
		/// </summary>
		public static void AddLocalPosition( this Component self, float x, float y )
		{
			self.transform.localPosition = new Vector3
			(
				self.transform.localPosition.x + x,
				self.transform.localPosition.y + y,
				self.transform.localPosition.z
			);
		}

		/// <summary>
		/// ローカル座標を加算します
		/// </summary>
		public static void AddLocalPosition( this Component self, float x, float y, float z )
		{
			self.transform.localPosition = new Vector3
			(
				self.transform.localPosition.x + x,
				self.transform.localPosition.y + y,
				self.transform.localPosition.z + z
			);
		}

		/// <summary>
		/// ローカル座標系のスケーリング値を(1, 1, 1)にリセットします
		/// </summary>
		public static void ResetLocalScale( this Component self )
		{
			self.transform.localScale = Vector3.one;
		}

		/// <summary>
		/// ローカル座標系のスケーリング値を返します
		/// </summary>
		public static Vector3 GetLocalScale( this Component self )
		{
			return self.transform.localScale;
		}

		/// <summary>
		/// X 軸方向のローカル座標系のスケーリング値を返します
		/// </summary>
		public static float GetLocalScaleX( this Component self )
		{
			return self.transform.localScale.x;
		}

		/// <summary>
		/// Y 軸方向のローカル座標系のスケーリング値を返します
		/// </summary>
		public static float GetLocalScaleY( this Component self )
		{
			return self.transform.localScale.y;
		}

		/// <summary>
		/// Z 軸方向のローカル座標系のスケーリング値を返します
		/// </summary>
		public static float GetLocalScaleZ( this Component self )
		{
			return self.transform.localScale.z;
		}

		/// <summary>
		/// X 軸方向のローカル座標系のスケーリング値を設定します
		/// </summary>
		public static void SetLocalScaleX( this Component self, float x )
		{
			self.transform.localScale = new Vector3
			(
				x,
				self.transform.localScale.y,
				self.transform.localScale.z
			);
		}

		/// <summary>
		/// Y 軸方向のローカル座標系のスケーリング値を設定します
		/// </summary>
		public static void SetLocalScaleY( this Component self, float y )
		{
			self.transform.localScale = new Vector3
			(
				self.transform.localScale.x,
				y,
				self.transform.localScale.z
			);
		}

		/// <summary>
		/// Z 軸方向のローカル座標系のスケーリング値を設定します
		/// </summary>
		public static void SetLocalScaleZ( this Component self, float z )
		{
			self.transform.localScale = new Vector3
			(
				self.transform.localScale.x,
				self.transform.localScale.y,
				z
			);
		}

		/// <summary>
		/// Vector3 型でローカル座標系のスケーリング値を設定します
		/// </summary>
		public static void SetLocalScale( this Component self, Vector3 v )
		{
			self.transform.localScale = v;
		}

		/// <summary>
		/// Vector2 型でローカル座標系のスケーリング値を設定します
		/// </summary>
		public static void SetLocalScale( this Component self, Vector2 v )
		{
			self.transform.localScale = new Vector3
			(
				v.x,
				v.y,
				self.transform.localScale.z
			);
		}

		/// <summary>
		/// ローカル座標系のスケーリング値を設定します
		/// </summary>
		public static void SetLocalScale( this Component self, float x, float y )
		{
			self.transform.localScale = new Vector3
			(
				x,
				y,
				self.transform.localScale.z
			);
		}

		/// <summary>
		/// ローカル座標系のスケーリング値を設定します
		/// </summary>
		public static void SetLocalScale( this Component self, float x, float y, float z )
		{
			self.transform.localScale = new Vector3
			(
				x,
				y,
				z
			);
		}

		/// <summary>
		/// X 軸方向のローカル座標系のスケーリング値を加算します
		/// </summary>
		public static void AddLocalScaleX( this Component self, float x )
		{
			self.transform.localScale = new Vector3
			(
				self.transform.localScale.x + x,
				self.transform.localScale.y,
				self.transform.localScale.z
			);
		}

		/// <summary>
		/// Y 軸方向のローカル座標系のスケーリング値を加算します
		/// </summary>
		public static void AddLocalScaleY( this Component self, float y )
		{
			self.transform.localScale = new Vector3
			(
				self.transform.localScale.x,
				self.transform.localScale.y + y,
				self.transform.localScale.z
			);
		}

		/// <summary>
		/// Z 軸方向のローカル座標系のスケーリング値を加算します
		/// </summary>
		public static void AddLocalScaleZ( this Component self, float z )
		{
			self.transform.localScale = new Vector3
			(
				self.transform.localScale.x,
				self.transform.localScale.y,
				self.transform.localScale.z + z
			);
		}

		/// <summary>
		/// Vector3 型でローカル座標系のスケーリング値を加算します
		/// </summary>
		public static void AddLocalScale( this Component self, Vector3 v )
		{
			self.transform.localScale += v;
		}

		/// <summary>
		/// Vector2 型でローカル座標系のスケーリング値を加算します
		/// </summary>
		public static void AddLocalScale( this Component self, Vector2 v )
		{
			self.transform.localScale = new Vector3
			(
				self.transform.localScale.x + v.x,
				self.transform.localScale.y + v.y,
				self.transform.localScale.z
			);
		}

		/// <summary>
		/// ローカル座標系のスケーリング値を加算します
		/// </summary>
		public static void AddLocalScale( this Component self, float x, float y )
		{
			self.transform.localScale = new Vector3
			(
				self.transform.localScale.x + x,
				self.transform.localScale.y + y,
				self.transform.localScale.z
			);
		}

		/// <summary>
		/// ローカル座標系のスケーリング値を加算します
		/// </summary>
		public static void AddLocalScale( this Component self, float x, float y, float z )
		{
			self.transform.localScale = new Vector3
			(
				self.transform.localScale.x + x,
				self.transform.localScale.y + y,
				self.transform.localScale.z + z
			);
		}

		/// <summary>
		/// 回転角を(0, 0, 0)にリセットします
		/// </summary>
		public static void ResetEulerAngles( this Component self )
		{
			self.transform.eulerAngles = Vector3.zero;
		}

		/// <summary>
		/// 回転角を返します
		/// </summary>
		public static Vector3 GetEulerAngles( this Component self )
		{
			return self.transform.eulerAngles;
		}

		/// <summary>
		/// X 軸方向の回転角を返します
		/// </summary>
		public static float GetEulerAngleX( this Component self )
		{
			return self.transform.eulerAngles.x;
		}

		/// <summary>
		/// Y 軸方向の回転角を返します
		/// </summary>
		public static float GetEulerAngleY( this Component self )
		{
			return self.transform.eulerAngles.y;
		}

		/// <summary>
		/// Z 軸方向の回転角を返します
		/// </summary>
		public static float GetEulerAngleZ( this Component self )
		{
			return self.transform.eulerAngles.z;
		}

		/// <summary>
		/// 回転角を設定します
		/// </summary>
		public static void SetEulerAngles( this Component self, Vector3 v )
		{
			self.transform.eulerAngles = v;
		}

		/// <summary>
		/// X 軸方向の回転角を設定します
		/// </summary>
		public static void SetEulerAngleX( this Component self, float x )
		{
			self.transform.eulerAngles = new Vector3
			(
				x,
				self.transform.eulerAngles.y,
				self.transform.eulerAngles.z
			);
		}

		/// <summary>
		/// Y 軸方向の回転角を設定します
		/// </summary>
		public static void SetEulerAngleY( this Component self, float y )
		{
			self.transform.eulerAngles = new Vector3
			(
				self.transform.eulerAngles.x,
				y,
				self.transform.eulerAngles.z
			);
		}

		/// <summary>
		/// Z 軸方向の回転角を設定します
		/// </summary>
		public static void SetEulerAngleZ( this Component self, float z )
		{
			self.transform.eulerAngles = new Vector3
			(
				self.transform.eulerAngles.x,
				self.transform.eulerAngles.y,
				z
			);
		}

		/// <summary>
		/// X 軸方向の回転角を加算します
		/// </summary>
		public static void AddEulerAngleX( this Component self, float x )
		{
			self.transform.Rotate( x, 0, 0, Space.World );
		}

		/// <summary>
		/// Y 軸方向の回転角を加算します
		/// </summary>
		public static void AddEulerAngleY( this Component self, float y )
		{
			self.transform.Rotate( 0, y, 0, Space.World );
		}

		/// <summary>
		/// Z 軸方向の回転角を加算します
		/// </summary>
		public static void AddEulerAngleZ( this Component self, float z )
		{
			self.transform.Rotate( 0, 0, z, Space.World );
		}

		/// <summary>
		/// ローカルの回転角を(0, 0, 0)にリセットします
		/// </summary>
		public static void ResetLocalEulerAngles( this Component self )
		{
			self.transform.localEulerAngles = Vector3.zero;
		}

		/// <summary>
		/// ローカルの回転角を返します
		/// </summary>
		public static Vector3 GetLocalEulerAngles( this Component self )
		{
			return self.transform.localEulerAngles;
		}

		/// <summary>
		/// ローカルの X 軸方向の回転角を返します
		/// </summary>
		public static float GetLocalEulerAngleX( this Component self )
		{
			return self.transform.localEulerAngles.x;
		}

		/// <summary>
		/// ローカルの Y 軸方向の回転角を返します
		/// </summary>
		public static float GetLocalEulerAngleY( this Component self )
		{
			return self.transform.localEulerAngles.y;
		}

		/// <summary>
		/// ローカルの Z 軸方向の回転角を返します
		/// </summary>
		public static float GetLocalEulerAngleZ( this Component self )
		{
			return self.transform.localEulerAngles.z;
		}

		/// <summary>
		/// ローカルの回転角を設定します
		/// </summary>
		public static void SetLocalEulerAngles( this Component self, Vector3 v )
		{
			self.transform.localEulerAngles = v;
		}

		/// <summary>
		/// ローカルの X 軸方向の回転角を設定します
		/// </summary>
		public static void SetLocalEulerAngleX( this Component self, float x )
		{
			self.transform.localEulerAngles = new Vector3
			(
				x,
				self.transform.localEulerAngles.y,
				self.transform.localEulerAngles.z
			);
		}

		/// <summary>
		/// ローカルの Y 軸方向の回転角を設定します
		/// </summary>
		public static void SetLocalEulerAngleY( this Component self, float y )
		{
			self.transform.localEulerAngles = new Vector3
			(
				self.transform.localEulerAngles.x,
				y,
				self.transform.localEulerAngles.z
			);
		}

		/// <summary>
		/// ローカルの Z 軸方向の回転角を設定します
		/// </summary>
		public static void SetLocalEulerAngleZ( this Component self, float z )
		{
			self.transform.localEulerAngles = new Vector3
			(
				self.transform.localEulerAngles.x,
				self.transform.localEulerAngles.y,
				z
			);
		}

		/// <summary>
		/// ローカルの X 軸方向の回転角を加算します
		/// </summary>
		public static void AddLocalEulerAngleX( this Component self, float x )
		{
			self.transform.Rotate( x, 0, 0, Space.Self );
		}

		/// <summary>
		/// ローカルの Y 軸方向の回転角を加算します
		/// </summary>
		public static void AddLocalEulerAngleY( this Component self, float y )
		{
			self.transform.Rotate( 0, y, 0, Space.Self );
		}

		/// <summary>
		/// ローカルの X 軸方向の回転角を加算します
		/// </summary>
		public static void AddLocalEulerAngleZ( this Component self, float z )
		{
			self.transform.Rotate( 0, 0, z, Space.Self );
		}

		/// <summary>
		/// 親オブジェクトが存在するかどうかを返します
		/// </summary>
		public static bool HasParent( this Component self )
		{
			return self.transform.parent != null;
		}

		/// <summary>
		/// 親オブジェクトを設定します
		/// </summary>
		public static void SetParent( this Component self, Component parent )
		{
			self.transform.SetParent( parent != null ? parent.transform : null );
		}

		/// <summary>
		/// 親オブジェクトを設定します
		/// </summary>
		public static void SetParent( this Component self, Component parent, bool worldPositionStays )
		{
			self.transform.SetParent( parent != null ? parent.transform : null, worldPositionStays );
		}

		/// <summary>
		/// 親オブジェクトを設定します
		/// </summary>
		public static void SetParent( this Component self, GameObject parent )
		{
			self.transform.SetParent( parent != null ? parent.transform : null );
		}

		/// <summary>
		/// 親オブジェクトを設定します
		/// </summary>
		public static void SetParent( this Component self, GameObject parent, bool worldPositionStays )
		{
			self.transform.SetParent( parent != null ? parent.transform : null, worldPositionStays );
		}

		/// <summary>
		/// ローカル座標を維持して親オブジェクトを設定します
		/// </summary>
		public static void SafeSetParent( this Component self, Component parent )
		{
			SafeSetParent( self, parent.gameObject );
		}

		/// <summary>
		/// ローカル座標を維持して親オブジェクトを設定します
		/// </summary>
		public static void SafeSetParent( this Component self, GameObject parent )
		{
			var t = self.transform;
			var localPosition = t.localPosition;
			var localRotation = t.localRotation;
			var localScale = t.localScale;
			t.parent = parent.transform;
			t.localPosition = localPosition;
			t.localRotation = localRotation;
			t.localScale = localScale;
			self.gameObject.layer = parent.layer;
		}

		/// <summary>
		/// 向きを変更します
		/// </summary>
		public static void LookAt( this Component self, GameObject target )
		{
			self.transform.LookAt( target.transform );
		}

		/// <summary>
		/// 向きを変更します
		/// </summary>
		public static void LookAt( this Component self, Transform target )
		{
			self.transform.LookAt( target );
		}

		/// <summary>
		/// 向きを変更します
		/// </summary>
		public static void LookAt( this Component self, Vector3 worldPosition )
		{
			self.transform.LookAt( worldPosition );
		}

		/// <summary>
		/// 向きを変更します
		/// </summary>
		public static void LookAt( this Component self, GameObject target, Vector3 worldUp )
		{
			self.transform.LookAt( target.transform, worldUp );
		}

		/// <summary>
		/// 向きを変更します
		/// </summary>
		public static void LookAt( this Component self, Transform target, Vector3 worldUp )
		{
			self.transform.LookAt( target, worldUp );
		}

		/// <summary>
		/// 向きを変更します
		/// </summary>
		public static void LookAt( this Component self, Vector3 worldPosition, Vector3 worldUp )
		{
			self.transform.LookAt( worldPosition, worldUp );
		}

		/// <summary>
		/// 子オブジェクトが存在するかどうかを返します
		/// </summary>
		public static bool HasChild( this Component self )
		{
			return 0 < self.transform.childCount;
		}

		/// <summary>
		/// 指定されたインデックスの子オブジェクトを返します
		/// </summary>
		public static Transform GetChild( this Component self, int index )
		{
			return self.transform.GetChild( index );
		}

		/// <summary>
		/// 親オブジェクトを返します
		/// </summary>
		public static Transform GetParent( this Component self )
		{
			return self.transform.parent;
		}

		/// <summary>
		/// ルートとなるオブジェクトを返します
		/// </summary>
		public static GameObject GetRoot( this Component self )
		{
			var root = self.transform.root;
			return root != null ? root.gameObject : null;
		}

		/// <summary>
		/// レイヤーを取得します
		/// </summary>
		public static int GetLayer( this Component self )
		{
			return self.gameObject.layer;
		}

		/// <summary>
		/// レイヤーを設定します
		/// </summary>
		public static void SetLayer( this Component self, int layer )
		{
			self.gameObject.layer = layer;
		}

		/// <summary>
		/// レイヤー名を使用してレイヤーを設定します
		/// </summary>
		public static void SetLayer( this Component self, string layerName )
		{
			self.gameObject.layer = LayerMask.NameToLayer( layerName );
		}

		/// <summary>
		/// 自分自身を含めたすべての子オブジェクトのレイヤーを設定します
		/// </summary>
		public static void SetLayerRecursively( this Component self, int layer )
		{
			self.gameObject.layer = layer;

			foreach ( Transform n in self.gameObject.transform )
			{
				SetLayerRecursively( n, layer );
			}
		}

		/// <summary>
		/// 自分自身を含めたすべての子オブジェクトのレイヤーを設定します
		/// </summary>
		public static void SetLayerRecursively( this Component self, string layerName )
		{
			self.SetLayerRecursively( LayerMask.NameToLayer( layerName ) );
		}

		/// <summary>
		/// グローバル座標系における X 軸方向のスケーリング値を返します
		/// </summary>
		public static float GetGlobalScaleX( this Component self )
		{
			var t = self.transform;
			var x = 1f;
			while ( t != null )
			{
				x *= t.localScale.x;
				t = t.parent;
			}
			return x;
		}

		/// <summary>
		/// グローバル座標系における Y 軸方向のスケーリング値を返します
		/// </summary>
		public static float GetGlobalScaleY( this Component self )
		{
			var t = self.transform;
			var y = 1f;
			while ( t != null )
			{
				y *= t.localScale.y;
				t = t.parent;
			}
			return y;
		}

		/// <summary>
		/// グローバル座標系における Z 軸方向のスケーリング値を返します
		/// </summary>
		public static float GetGlobalScaleZ( this Component self )
		{
			var t = self.transform;
			var z = 1f;
			while ( t != null )
			{
				z *= t.localScale.z;
				t = t.parent;
			}
			return z;
		}

		/// <summary>
		/// グローバル座標系におけるスケーリング値を返します
		/// </summary>
		public static Vector3 GetGlobalScale( this Component self )
		{
			var t = self.transform;
			var scale = Vector3.one;
			while ( t != null )
			{
				scale.x *= t.localScale.x;
				scale.y *= t.localScale.y;
				scale.z *= t.localScale.z;
				t = t.parent;
			}
			return scale;
		}

		/// <summary>
		/// コンポーネントのインターフェースを取得して返します
		/// </summary>
		public static T GetComponentInterface<T>( this Component self ) where T : class
		{
			foreach ( var n in self.GetComponents<Component>() )
			{
				var component = n as T;
				if ( component != null )
				{
					return component;
				}
			}
			return null;
		}

		/// <summary>
		/// コンポーネントのインターフェースを複数取得して返します
		/// </summary>
		public static T[] GetComponentInterfaces<T>( this Component self ) where T : class
		{
			var result = new List<T>();
			foreach ( var n in self.GetComponents<Component>() )
			{
				var component = n as T;
				if ( component != null )
				{
					result.Add( component );
				}
			}
			return result.ToArray();
		}

		/// <summary>
		/// 子のコンポーネントのインターフェースを取得して返します
		/// </summary>
		public static T GetComponentInterfaceInChildren<T>( this Component self ) where T : class
		{
			return self.GetComponentInterfaceInChildren<T>( false );
		}

		/// <summary>
		/// 子のコンポーネントのインターフェースを取得して返します
		/// </summary>
		public static T GetComponentInterfaceInChildren<T>( this Component self, bool includeInactive ) where T : class
		{
			foreach ( var n in self.GetComponentsInChildren<Component>( includeInactive ) )
			{
				var component = n as T;
				if ( component != null )
				{
					return component;
				}
			}
			return null;
		}

		/// <summary>
		/// 子のコンポーネントのインターフェースを複数取得して返します
		/// </summary>
		public static T[] GetComponentInterfacesInChildren<T>( this Component self ) where T : class
		{
			return self.GetComponentInterfacesInChildren<T>( false );
		}

		/// <summary>
		/// 子のコンポーネントのインターフェースを複数取得して返します
		/// </summary>
		public static T[] GetComponentInterfacesInChildren<T>( this Component self, bool includeInactive ) where T : class
		{
			var result = new List<T>();
			foreach ( var n in self.GetComponentsInChildren<Component>( includeInactive ) )
			{
				var component = n as T;
				if ( component != null )
				{
					result.Add( component );
				}
			}
			return result.ToArray();
		}

		/// <summary>
		/// 無効なコンポーネントがアタッチされている場合 true を返します
		/// </summary>
		public static bool HasMissingScript( this Component self )
		{
			return self
				.GetComponents<Component>()
				.Any( c => c == null )
			;
		}

		/// <summary>
		/// 指定されたアクティブと逆の状態にしてから指定されたアクティブになります
		/// </summary>
		public static void ToggleActive( this Component self, bool isActive )
		{
			self.SetActive( !isActive );
			self.SetActive( isActive );
		}

		/// <summary>
		/// すべての親オブジェクトを返します
		/// </summary>
		public static IEnumerable<Transform> GetAllParent( this Component self )
		{
			for ( var parent = self.transform.parent; null != parent; parent = parent.parent )
			{
				yield return parent;
			}
		}

		/// <summary>
		/// ルートパスを返します
		/// </summary>
		public static string GetRootPath( this Component self )
		{
			var gameObject = self.gameObject;
			var path       = gameObject.name;
			var parent     = gameObject.transform.parent;

			while ( parent != null )
			{
				path   = parent.name + "/" + path;
				parent = parent.parent;
			}

			return path;
		}

		/// <summary>
		/// グローバル座標を返します
		/// </summary>
		public static Vector3 GetGlobalPosition( this Component self )
		{
			var result = Vector3.zero;
			while ( self != null )
			{
				var t = self.transform;
				result += t.localPosition;
				self = t.parent;
			}
			return result;
		}

		/// <summary>
		/// ローカル座標系の位置を四捨五入します
		/// </summary>
		public static void RoundLocalPosition( this Component self )
		{
			var v = self.transform.localPosition;
			v.x = Mathf.Round( v.x );
			v.y = Mathf.Round( v.y );
			v.z = Mathf.Round( v.z );
			self.transform.localPosition = v;
		}

		/// <summary>
		/// ローカル座標系の回転角を四捨五入します
		/// </summary>
		public static void RoundLocalEulerAngles( this Component self )
		{
			var v = self.transform.localEulerAngles;
			v.x = Mathf.Round( v.x );
			v.y = Mathf.Round( v.y );
			v.z = Mathf.Round( v.z );
			self.transform.localEulerAngles = v;
		}

		/// <summary>
		/// ローカル座標系のスケーリング値を四捨五入します
		/// </summary>
		public static void RoundLocalScale( this Component self )
		{
			var v = self.transform.localScale;
			v.x = Mathf.Round( v.x );
			v.y = Mathf.Round( v.y );
			v.z = Mathf.Round( v.z );
			self.transform.localScale = v;
		}

		/// <summary>
		/// ローカル座標系の位置、回転角、スケーリング値を四捨五入します
		/// </summary>
		public static void Round( this Component self )
		{
			self.RoundLocalPosition();
			self.RoundLocalEulerAngles();
			self.RoundLocalScale();
		}
	}
}