using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform CameraPosition;
    public Transform NewRoomPos;
    public Transform playerStartPosition;
    public GameObject[] prefabs;
    Transform cam;
    public static Room activeRoom;
    bool cameraMove = true;
    public string levelconfig = "";

    // Start is called before the first frame update
    void Start()
    {
        var level = levelconfig.Split(';');
        int prefabIndex = 0;
        for (int i = 0; i < level.Length; i++)
        {
            if(Int32.TryParse(level[i], out prefabIndex))
            {

            }
        }

        if ( activeRoom != null)
        {
            Destroy(activeRoom.gameObject);
        }
        activeRoom = this;
        cam = FindObjectOfType<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMove)
        {
            cam.position  = Vector3.Slerp(cam.position, CameraPosition.position, Time.deltaTime * 3.0f);
            cameraMove = Vector3.Distance(cam.position, CameraPosition.position) > 0.1f;
        }
    }
}
