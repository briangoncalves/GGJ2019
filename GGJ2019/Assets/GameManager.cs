using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public PlayerSelect player;
    public Transform playerTransform;
   //public GameObject room0Prefab;
    public Room currentRoom;
    public GameObject[] levels;
    int index = -1;

    private void Awake()
    {
    //    currentRoom  = Instantiate(room0Prefab).GetComponent<Room>();
        playerTransform.position = currentRoom.playerStartPosition.position;
        if(currentRoom.defaultCharacter == PlayerSelect.Character.InnocentGirl)
        {
            player.SetInnocentGirl();
        }
        else
        {
            player.SetStrongMan();
        }
    }

    private void Update()
    {
    }

    public void ReloadLevel()
    {

    }

    public void LoadNextRoom()
    {
        index++;
        if (index >= levels.Length)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Room room = Instantiate(levels[index], currentRoom.NewRoomPos.position, Quaternion.identity).GetComponent<Room>();

            playerTransform.position = room.playerStartPosition.position;
            currentRoom = room;
            if (currentRoom.defaultCharacter == PlayerSelect.Character.InnocentGirl)
            {
                player.SetInnocentGirl();
            }
            else
            {
                player.SetStrongMan();
            }
        }
    }
}
