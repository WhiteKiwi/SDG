using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour {
	public void Press_TeeeeeeeeeestButton() {
		PlayerPrefs.SetInt("Sex", -1);
	}

	// Scene Main - Start Button
	public void Press_StartButton() {
		if (PlayerPrefs.GetInt("Sex", -1) == -1)
			SceneManager.LoadScene("ChooseSex");
		else {
			int stage = PlayerPrefs.GetInt("Stage", 1);
			if (stage == 1) {
				PlayerPrefs.SetInt("Stage", 1);
				PlayerPrefs.Save();
			}
			SceneManager.LoadScene("Stage" + stage.ToString());
		}
	}

	// Scene ChooseSex - choose boy
	public void Press_BoyButton() {
		GetText getText = gameObject.GetComponent<GetText>();
		if (!string.IsNullOrEmpty(getText.nickName.text)) {
			// Save Nickname
			PlayerPrefs.SetString("Name", getText.nickName.text);

			// 0 : Boy
			PlayerPrefs.SetInt("Sex", 0);
			PlayerPrefs.Save();
			SceneManager.LoadScene("Stage1");
		} else {
			getText.alert.text = "원배!";
		}
	}

	// Scene ChooseSex - choose girl
	public void Press_GirlButton() {
		GetText getText = gameObject.GetComponent<GetText>();
		if (!string.IsNullOrEmpty(getText.nickName.text)) {
			// Save Nickname
			PlayerPrefs.SetString("Name", getText.nickName.text);

			// 1 : Girl
			PlayerPrefs.SetInt("Sex", 1);
			PlayerPrefs.Save();
			SceneManager.LoadScene("Stage1");
		} else {
			getText.alert.text = "이뻠배!";
		}
	}
}
