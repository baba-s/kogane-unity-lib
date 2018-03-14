using System;

namespace KoganeUnityLib
{
	/// <summary>
	/// 選択中の値を管理するクラス
	/// </summary>
	public class Selectable<T> : IDisposable
	{
		private T m_value; // 選択中の値

		/// <summary>
		/// <para>値を取得または設定します</para>
		/// <para>値の設定後に mChanged イベントが呼び出されます</para>
		/// </summary>
		public T Value
		{
			get { return m_value; }
			set
			{
				m_value = value;
				OnChanged();
			}
		}

		/// <summary>
		/// 値が変更された時に呼び出されます
		/// </summary>
		public Action mChanged;

		/// <summary>
		/// 破棄します
		/// </summary>
		public void Dispose()
		{
			mChanged = null;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Selectable()
		{
			m_value = default( T );
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Selectable( T value )
		{
			m_value = value;
		}

		/// <summary>
		/// <para>値を設定します</para>
		/// <para>値の設定後に mChanged イベントは呼び出されません</para>
		/// </summary>
		public void SetValueWithoutCallback( T value )
		{
			m_value = value;
		}

		/// <summary>
		/// <para>値を設定します</para>
		/// <para>値が変更された場合にのみ mChanged イベントが呼び出されます</para>
		/// </summary>
		public void SetValueIfNotEqual( T value )
		{
			if ( m_value.Equals( value ) )
			{
				return;
			}
			m_value = value;
			OnChanged();
		}

		/// <summary>
		/// 値が変更された時に呼び出されます
		/// </summary>
		private void OnChanged()
		{
			mChanged.Call();
			DoOnChanged();
		}

		/// <summary>
		/// 派生クラスで値が変更された時に呼び出される処理を記述します
		/// </summary>
		protected virtual void DoOnChanged() { }
	}
}