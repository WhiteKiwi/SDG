using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	public GameObject dialogueMan;
	public GameObject dialogueWoman;

	void Start() {
		if (PlayerPrefs.GetInt("Sex", 0) == 0) {
			dialogueWoman.SetActive(false);
		} else {
			dialogueMan.SetActive(false);
		}
	}
}
