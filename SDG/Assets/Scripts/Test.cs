using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	private void Start() {
		Debug.Log(PlayerPrefs.GetInt("Sex", 0) == 0 ? "Maaaaaaan" : "Giiiiiiiiiiirl");
		IEnumerator teeeeeeest = TeeeeeeeeeeeeestCoroutine("원 배이배 배 배이베");
		StartCoroutine(teeeeeeest);
	}

	private IEnumerator TeeeeeeeeeeeeestCoroutine(string text) {
		for (int i = 0; i < text.Length; i++) {
			if (text[i] != ' ') {
				yield return new WaitForSeconds(0.5f);
				Debug.Log(text.Substring(0, i + 1));
			}
		}
	}
}
