﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class JoinRoomManager : MonoBehaviour {

	public void loadRoomList()
	{
		SceneManager.LoadSceneAsync("RoomList");
	}
}