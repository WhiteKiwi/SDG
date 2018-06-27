using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickyManager : MonoBehaviour {
	public Text stickyNote1;
	public Text stickyNote2;
	public Text stickyNote3;

	void Start () {
		string[][] hashtags = {
			// 1
			new string[]{ "Waterborne\nDiseases", "Water\nsanitation\nfacilities", "Water-use\nefficiency" },
			// 2
			new string[]{ "Poverty", "Hunger", "Food" },
			// 3
			new string[]{ "", "", "" },
			// 4
			new string[]{ "", "", "" },
			// 5
			new string[]{ "", "", "" },
			// 6
			new string[]{ "", "", "" },
			// 7
			new string[]{ "", "", "" },
			// 8
			new string[]{ "", "", "" }
		};

		int stage = PlayerPrefs.GetInt("Stage", 1);
		stickyNote1.text = hashtags[stage - 1][0];
		stickyNote2.text = hashtags[stage - 1][1];
		stickyNote3.text = hashtags[stage - 1][2];
	}
}
