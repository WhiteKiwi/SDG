using Android.App;
using Android.OS;
using System.Collections.Specialized;
using System.IO;

namespace SDG {
	[Activity(Label = "SDG", MainLauncher = true)]
	public class MainActivity : Activity {
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);

			#region Login with Save Data
			FileInfo loginDataFile = new FileInfo(Environment.ExternalStorageDirectory.Path + "/SDG/LoginData");

			if (loginDataFile.Exists) {
				//파일 읽어오기
				string[] loginData = File.ReadAllText(Environment.ExternalStorageDirectory.Path + "/SDG/LoginData").Split(new char[] { ' ' });

				if (LoginCheck(loginData[0], loginData[1])) {
					//login 성공 -> Main 창 Load
					SetContentView(Resource.Layout.Main);
				} else {  //File 존재 & 로그인 실패
						  //login 실패 -> Login 창 Load
					SetContentView(Resource.Layout.Login);
					FindViewById<Button>(Resource.Id.loginButton).Click += LoginButton;
				}
			} else {
				//File 존재 X -> Login 창 Load
				SetContentView(Resource.Layout.Login);
				FindViewById<Button>(Resource.Id.loginButton).Click += LoginButton;
			}
			#endregion
		}

		// Check Login
		private bool LoginCheck(string id, string pw) {
			Web.UploadValues("https://student.cnsa.hs.kr/login/userLogin", new NameValueCollection() {
				{ "loginId", id },
				{ "loginPw", pw }
			});

			if (Web.LoginCheck) {
				//로그인 성공
				return true;
			} else {
				//로그인 실패
				return false;
			}
		}
	}
}

