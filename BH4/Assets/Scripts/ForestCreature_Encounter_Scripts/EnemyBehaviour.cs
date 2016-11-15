using UnityEngine;
using System.Collections.Generic;

public enum EnemyMode {Relaxed = 0, Turning = 1, Search = 2, SeeingPlayer = 3}

public class EnemyBehaviour : MonoBehaviour { //This script is the AI for the tree monster. The idea is to use a switch with four cases. 

	public Script_Mama_ForestCreature gamePlayRef; // This is the mother script that has all the scripts thats needed to make this part of the game work.
	public GameObject friendlyOldMan; // This is the NPC that carries a lantern and will extinguish the flame when the mosnter is about to search for the player (case 2).

	private EnemyMode currentMode;
	private bool isPlayerSafe; //Scripts can access this variable with the property variable IsPlayerSafe.


	private List<Color> enemyLook; //This is meant to be a list of animations.

	private SpriteRenderer myColor;

	public Color color_Relaxed; // These variables are temporary. They are meant to be animations.
	public Color color_Turning;
	public Color color_Search;
	public Color color_SeeingPlayer;

	public float relaxedTime; // These floats are the times every case is active.
	public float turningTime;
	public float searchTime;

	private EnemyMode nextMode;

	void Start () {
		currentMode = EnemyMode.Relaxed;

		enemyLook = new List<Color> ();

		enemyLook.Add (color_Relaxed);
		enemyLook.Add (color_Turning);
		enemyLook.Add (color_Search);
		enemyLook.Add (color_SeeingPlayer);

		myColor = GetComponent<SpriteRenderer>();
		myColor.color = enemyLook [0];
	}
	
	// Update is called once per frame
	void Update () {

		if (currentMode == EnemyMode.Search && !IsPlayerSafe) 
		{
			nextMode = EnemyMode.SeeingPlayer;
			Action ();
		}
	}



	public void Action()
	{

		switch(nextMode)
		{
		case EnemyMode.Relaxed: //Monstret is not looking for the player. It is safe for the player to move outside of safezones.
			Debug.Log ("Case 0");
			currentMode = EnemyMode.Relaxed;
			ChangeColor ((int)EnemyMode.Relaxed);
			nextMode = EnemyMode.Turning;
			Invoke ("Action", relaxedTime);
			break;
		case EnemyMode.Turning: //Friendly Old Man turns off a lantern inorder to warn the player that the monster is soon searching for you.		
			Debug.Log ("Case 1");
			currentMode = EnemyMode.Turning;
			nextMode = EnemyMode.Search;
			ChangeColor ((int)EnemyMode.Turning);
			Invoke ("Action", turningTime);
			break;
		case EnemyMode.Search: //Monster is searching for player, if player is not inside a safezone the monster will see the player.
			Debug.Log ("Case 2");
			currentMode = EnemyMode.Search;
			nextMode = EnemyMode.Relaxed;
			ChangeColor ((int)EnemyMode.Search);
			Invoke ("Action", searchTime);
			break;
		case EnemyMode.SeeingPlayer: //This case is when the monster sees the player.
			Debug.Log ("Case 3");
			ChangeColor ((int)EnemyMode.SeeingPlayer);
			break;
		}
	}
	private void ChangeColor(int c)
	{
		Color newColor = enemyLook[c];
		myColor.color = newColor;
	} // This is temporary and will be replaced with changing animation.
		
	public bool IsPlayerSafe {get {return isPlayerSafe;} set {isPlayerSafe = value;}}

}
