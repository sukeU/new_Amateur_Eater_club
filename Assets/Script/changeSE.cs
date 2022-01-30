using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSE : MonoBehaviour
{
	private AudioSource audioSource;

	private void Start()
	{
		// "AudioSource"コンポーネントを取得
		audioSource = gameObject.GetComponent<AudioSource>();

	}

	/// <summary>
	/// スライドバー値の変更イベント
	/// </summary>
	/// <param name="newSliderValue">スライドバーの値(自動的に引数に値が入る)</param>
	public void SoundSliderOnValueChange(float newSliderValue)
	{
		// 音楽の音量をスライドバーの値に変更
		audioSource.volume = newSliderValue;
	}
	void Update()
	{
		// 左クリックしたら、効果音を鳴らす
		if (Input.GetMouseButtonDown(0))
		{
			GetComponent<AudioSource>().Play();  // 効果音を鳴らす
		}
	}
}