﻿using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
	const string address = "http://localhost:59202";

	// Scene Start - Start Button
	public void Press_StartButton() {
		if (PlayerPrefs.GetString("User_ID", "-1") == "-1" || PlayerPrefs.GetString("Password", "-1") == "-1") {
			SceneManager.LoadScene("Login");
		} else {
			SceneManager.LoadScene("Stage" + PlayerPrefs.GetInt("Stage", 0).ToString());
		}
	}

	// Scene Start - WebSite Button
	public void Press_WebSiteButton() {
		Application.OpenURL(address);
	}

	// Scene Login - Load Register Button
	public void Press_LoadRegisterButton() {
		SceneManager.LoadScene("Register");
	}
	
	// Scene Login - Load Register Button
	public void Press_LoadLoginButton() {
		SceneManager.LoadScene("Login");
	}

	// Scene Register - Register Button
	public void Press_RegisterButton() {
		GetText getText = gameObject.GetComponent<GetText>();

		// send login data
		WebClient web = new WebClient();
		var receiveBytes = web.UploadValues(address + "/Register.aspx", "POST", new System.Collections.Specialized.NameValueCollection {
			{ "UserID", getText.id.text },
			{ "Password", getText.pw.text },
			{ "Password2", getText.pw2.text },
			{ "Email", getText.email.text },
			{ "Name", getText.userName.text }
		});

		if (receiveBytes.Length != 0) {
			getText.alert.text = Encoding.UTF8.GetString(receiveBytes);
		} else {
			SceneManager.LoadScene("Login");
		}
	}

	// Scene Login - Login Button
	public void Press_LoginButton() {
		GetText getText = gameObject.GetComponent<GetText>();
		getText.alert.text = "Login Failed";

		// send login data
		WebClient web = new WebClient();
		var receiveBytes = web.UploadValues(address + "/Login.aspx", "POST", new System.Collections.Specialized.NameValueCollection {
			{ "UserID", getText.id.text },
			{ "Password", getText.pw.text },
		});

		if (Encoding.UTF8.GetString(receiveBytes) == "Authorized") {
			PlayerPrefs.SetString("User_ID", getText.id.text);
			PlayerPrefs.SetString("Password", getText.pw.text);
			PlayerPrefs.Save();
			getText.alert.text = "Login Success!";
			SceneManager.LoadScene("Stage" + PlayerPrefs.GetInt("Stage", 0).ToString());
		}
	}

	// Scene Stage0 - Man Button
	public void Press_ManButton() {
		// 0 : Man
		PlayerPrefs.SetInt("Sex", 0);
		PlayerPrefs.SetInt("Stage", 1);
		PlayerPrefs.Save();
		SceneManager.LoadScene("Stage1");
	}

	// Scene Stage0 - Woman Button
	public void Press_WomanButton() {
		// 1 : Woman
		PlayerPrefs.SetInt("Sex", 1);
		PlayerPrefs.SetInt("Stage", 1);
		PlayerPrefs.Save();
		SceneManager.LoadScene("Stage1");
	}

	// Scene Solution - Upload Button
	public void Press_UploadButton() {

	}

	#region TEST
	public void Press_TestButton() {
		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save();
	}
	#endregion
}
