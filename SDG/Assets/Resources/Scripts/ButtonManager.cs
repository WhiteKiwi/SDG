using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
	// Scene Main - Start Button
	public void Press_StartButton() {
		int stage = PlayerPrefs.GetInt("Stage", 1);

		if (stage == 1) {
			PlayerPrefs.SetInt("Stage", 1);
			PlayerPrefs.Save();
			SceneManager.LoadScene("Stage" + stage.ToString());
		}
	}
}
