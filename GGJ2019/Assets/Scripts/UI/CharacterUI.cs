using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour {

    public GameObject Player;
    public Text SelectedCharacterUI; //UI Text Object

    private PlayerSelect pl;
	// Use this for initialization
	void Start () {
        pl = Player.GetComponent<PlayerSelect>();
	}
	
	// Update is called once per frame
	void Update () {
        SelectedCharacterUI.text = pl.player.ToString();

    }
}
