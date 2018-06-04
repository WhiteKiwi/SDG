using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Utility : MonoBehaviour {
	public Text chat;
	public List<string> chats = new List<string>();

	public delegate void OnStopHandler();
	public event OnStopHandler OnStop;

	private int currentIndex = 0;
	private bool isStopped = true;

	private IEnumerator Coroutine;

	private void Start() {
		// TextCoroutine을 시작한다
		Coroutine = TextCoroutine(0.05f);
		StartCoroutine(Coroutine);

		// 타치 코르텐을 시작 하무니다
		IEnumerator touch = GetTouchCoroutine();
		StartCoroutine(touch);
	}

	// 탁스트 출력 하무니다
	public IEnumerator TextCoroutine(float waitTime = 0.5f) {
		// 안멈췄 스므니당
		isStopped = false;

		// 텍스트 없스므니다
		chat.text = "";

		for (int i = 0; i < chats[currentIndex].Length; i++) {
			yield return new WaitForSeconds(waitTime);
			chat.text += chats[currentIndex][i];
		}
		isStopped = true;

		if (OnStop != null)
			OnStop();
	}

	public IEnumerator GetTouchCoroutine() {
		while (true) {
			//if (Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Began) {
			if (Input.GetMouseButtonDown(0) && !isStopped) {
				StopCoroutine(Coroutine);
				isStopped = true;
				chat.text = chats[currentIndex];

				if (OnStop != null)
					OnStop();
			} else if (Input.GetMouseButtonDown(0) && isStopped) {
				if (currentIndex < chats.Count - 1)
					currentIndex++;
				else
					yield break;

				Coroutine = TextCoroutine(0.05f);
				StartCoroutine(Coroutine);
			}
			yield return null;
		}
	}
}
