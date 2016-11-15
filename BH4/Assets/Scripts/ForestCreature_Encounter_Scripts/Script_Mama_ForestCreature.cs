using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class Script_Mama_ForestCreature : MonoBehaviour {

	public GameObject playerRef;
	public GameObject enemyRef;
	public ActivateMonster activateMonsterTriggerRef;
	public EnemyBehaviour enemyBehaviourRef;

	[SerializeField]
	public List<GameObject> safeZones;


	public void PlayerStatus(bool safe)
	{
		enemyRef.GetComponent<EnemyBehaviour>().IsPlayerSafe = safe;
	}
	public void GoMonster()
	{
		EnemyBehaviourRef.Action();
	}

	public EnemyBehaviour EnemyBehaviourRef {get{return enemyBehaviourRef;} set{enemyBehaviourRef = value;}}

}
