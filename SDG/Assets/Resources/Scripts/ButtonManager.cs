using System;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
	const string address = "http://outofwell.com";

	int classification = -1;
	// 0 : Political
	// TODO: Classification

	#region Scene Start
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
	#endregion

	#region Scene Login, Register
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

		// NULL check
		if (string.IsNullOrEmpty(getText.id.text)) {
			getText.alert.text = "ID is empty.";
		} else if (string.IsNullOrEmpty(getText.pw.text)) {
			getText.alert.text = "Password is empty.";
		} else if (string.IsNullOrEmpty(getText.pw2.text)) {
			getText.alert.text = "Password Check is empty.";
		} else if (string.IsNullOrEmpty(getText.email.text)) {
			getText.alert.text = "Name is empty.";
		} else if (string.IsNullOrEmpty(getText.userName.text)) {
			getText.alert.text = "Email is empty.";
		} else {
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
				string error = Encoding.UTF8.GetString(receiveBytes);
				if (error == "2-ID") {
					getText.alert.text = "ID is already in use.";
					getText.IDCheck.sprite = getText.Check_No;
					getText.PasswordCheck.sprite = getText.Check;
					getText.EmailCheck.sprite = getText.Check;
				} else if (error == "2-PW") {
					getText.alert.text = "Passwords do not match.";
					getText.IDCheck.sprite = getText.Check;
					getText.PasswordCheck.sprite = getText.Check_No;
					getText.EmailCheck.sprite = getText.Check;
				} else if (error == "2-Email") {
					getText.alert.text = "It is not Email";
					getText.IDCheck.sprite = getText.Check;
					getText.PasswordCheck.sprite = getText.Check;
					getText.EmailCheck.sprite = getText.Check_No;
				} else {
					getText.IDCheck.sprite = getText.Check_Ok;
					getText.PasswordCheck.sprite = getText.Check_Ok;
					getText.EmailCheck.sprite = getText.Check_Ok;
					getText.alert.text = error;
				}
			} else {
				SceneManager.LoadScene("Login");
			}
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
			getText.alert.color = Color.blue;
			getText.alert.text = "Login Success!";
			SceneManager.LoadScene("Stage" + PlayerPrefs.GetInt("Stage", 0).ToString());
		}
	}
	#endregion

	#region Scene Stage0
	// Scene Stage0 - Man Button
	public void Press_ManButton() {
		GetStage0 getStage0 = gameObject.GetComponent<GetStage0>();
		// 0 : Man
		PlayerPrefs.SetInt("Sex", 0);
		PlayerPrefs.Save();

		getStage0.BoyButtonText.color = new Color(157 / 256f, 195 / 256f, 230 / 256f);
		getStage0.GirlButtonText.color = new Color(0f, 0f, 0f, 0.8f);
		getStage0.ConfirmButton.image.color = new Color(157 / 256f, 195 / 256f, 230 / 256f);
	}

	// Scene Stage0 - Woman Button
	public void Press_WomanButton() {
		GetStage0 getStage0 = gameObject.GetComponent<GetStage0>();
		// 1 : Woman
		PlayerPrefs.SetInt("Sex", 1);
		PlayerPrefs.Save();

		getStage0.BoyButtonText.color = new Color(0f, 0f, 0f, 0.8f);
		getStage0.GirlButtonText.color = new Color(255 / 256f, 168 / 256f, 201 / 256f);
		getStage0.ConfirmButton.image.color = new Color(255 / 256f, 168 / 256f, 201 / 256f);
	}

	// Scene Stage0 - Confirm Button
	public void Press_ConfirmButton() {
		if (PlayerPrefs.GetInt("Sex", -1) != -1) {
			PlayerPrefs.SetInt("Stage", 1);
			PlayerPrefs.Save();
			SceneManager.LoadScene("Stage1");
		}
	}
	#endregion

	#region Scene Solutions
	// Scene Solution - Upload Button
	public void Press_UploadButton() {
		GetSolution getSolution = gameObject.GetComponent<GetSolution>();
		if (classification != -1 && !string.IsNullOrEmpty(getSolution.title.text.Trim()) && !string.IsNullOrEmpty(getSolution.content.text.Trim())) {

			// send login data1,l
			CookieAwareWebClient web = new CookieAwareWebClient();
			string id = PlayerPrefs.GetString("User_ID", "-1");
			string pw = PlayerPrefs.GetString("Password", "-1");
			var receiveBytes = web.UploadValues(address + "/Login.aspx", "POST", new System.Collections.Specialized.NameValueCollection {
				{ "UserID",  id },
				{ "Password", pw },
			});

			string redata = Encoding.UTF8.GetString(receiveBytes);
			if (redata == "Authorized") {
				web.UploadValues(address + "/Upload.aspx", "POST", new System.Collections.Specialized.NameValueCollection {
					{ "Title", getSolution.title.text },
					{ "Content", getSolution.content.text },
					{ "Classification", classification.ToString() },
					{ "Stage", PlayerPrefs.GetInt("Stage", 0).ToString() },
				});

				PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage", 0) + 1);
				PlayerPrefs.Save();
				SceneManager.LoadScene("Stage" + PlayerPrefs.GetInt("Stage", 0).ToString());
			}
		}
	}

	// Scene HashTag - Load Solution
	public void Press_LoadSolutionButton() {
		Application.OpenURL("https://google.com");
		SceneManager.LoadScene("Solution");
	}

	#region Classification Buttons
	// Scene Solution - Classidication Buttons
	public void Press_EconomyButton() {
		GetSolution getSolution = gameObject.GetComponent<GetSolution>();
		getSolution.classificationButton0.GetComponentInChildren<Text>().color = new Color(58 / 256f, 103 / 256f, 184 / 256f);
		getSolution.classificationButton1.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton2.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton3.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton4.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);

		// 0: Economy
		classification = 0;
	}
	public void Press_SaTButton() {
		GetSolution getSolution = gameObject.GetComponent<GetSolution>();
		getSolution.classificationButton0.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton1.GetComponentInChildren<Text>().color = new Color(58 / 256f, 103 / 256f, 184 / 256f);
		getSolution.classificationButton2.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton3.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton4.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		
		// 1: Science and Technology
		classification = 1;
	}
	public void Press_LawButton() {
		GetSolution getSolution = gameObject.GetComponent<GetSolution>();
		getSolution.classificationButton0.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton1.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton2.GetComponentInChildren<Text>().color = new Color(58 / 256f, 103 / 256f, 184 / 256f);
		getSolution.classificationButton3.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton4.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);

		// 2: Law
		classification = 2;
	}
	public void Press_SocietyButton() {
		GetSolution getSolution = gameObject.GetComponent<GetSolution>();
		getSolution.classificationButton0.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton1.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton2.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton3.GetComponentInChildren<Text>().color = new Color(58 / 256f, 103 / 256f, 184 / 256f);
		getSolution.classificationButton4.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);

		// 3: Society
		classification = 3;
	}
	public void Press_PoliticButton() {
		GetSolution getSolution = gameObject.GetComponent<GetSolution>();
		getSolution.classificationButton0.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton1.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton2.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton3.GetComponentInChildren<Text>().color = new Color(50 / 256f, 50 / 256f, 50 / 256f);
		getSolution.classificationButton4.GetComponentInChildren<Text>().color = new Color(58 / 256f, 103 / 256f, 184 / 256f);

		// 4: Politic
		classification = 4;
	}
	#endregion
	#endregion

	#region TEST
	public void Press_TestButton() {
		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save();
	}
	#endregion

	public class CookieAwareWebClient : WebClient {
		public CookieContainer CookieContainer {
			get; set;
		}
		public Uri Uri {
			get; set;
		}

		//기본 생성자
		public CookieAwareWebClient() : this(new CookieContainer()) { }

		//CookieContainer를 매개변수로 받는 생성자
		public CookieAwareWebClient(CookieContainer cookies) {
			this.CookieContainer = cookies;
		}

		//Uri, Cookie를 매개변수로 받는 생성자
		public CookieAwareWebClient(Uri uri, Cookie cookie) : this(new CookieContainer()) {
			this.CookieContainer.Add(uri, cookie);
		}

		protected override WebRequest GetWebRequest(Uri address) {
			//WebRequest 생성
			WebRequest request = base.GetWebRequest(address);

			//패킷 속성 설정
			if (request is HttpWebRequest) {
				//패킷 Cookie 쿠키 설정
				(request as HttpWebRequest).CookieContainer = this.CookieContainer;
				//Connect: Kepp-Alive 
				(request as HttpWebRequest).KeepAlive = true;
			}

			//HttpWebRequest.AutomaticDecompression 속성 설정 
			HttpWebRequest httpRequest = (HttpWebRequest)request;
			httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

			//https 인증서 설정
			//httpRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

			return httpRequest;
		}

		protected override WebResponse GetWebResponse(WebRequest request) {
			//WebResponse 생성
			WebResponse response = base.GetWebResponse(request);
			string setCookieHeader = response.Headers[HttpResponseHeader.SetCookie];

			if (setCookieHeader != null) {
				//'='을 기준으로 받아온 Cookie 정보 Split
				string[] cookieHeader = setCookieHeader.Split("=;".ToCharArray(), 3);

				//cookieHeader[0]: Cookie ID		cookieHeader[1]: Cookie Data
				Cookie cookie = new Cookie(cookieHeader[0], cookieHeader[1]);

				//받아온 Cookie 설정
				this.CookieContainer.Add(response.ResponseUri, cookie);
			}

			return response;
		}

		//CookieAwareWebClient Cookie 추가
		public void AddCookie(Uri uri, Cookie cookie) {
			this.CookieContainer.Add(uri, cookie);
		}
	}
}