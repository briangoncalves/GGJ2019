using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour {
    
    public Text SelectedCharacterUI; //UI Text Object

    public PlayerSelect pl;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        SelectedCharacterUI.text = pl.player.ToString();

    }
}
