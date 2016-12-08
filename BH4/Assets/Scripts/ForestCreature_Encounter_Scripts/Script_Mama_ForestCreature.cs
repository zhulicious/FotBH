using System.Collections.Generic;
using UnityEngine;


public class Script_Mama_ForestCreature : MonoBehaviour {

    public GameObject playerRef;
    public GameObject enemyRef;
    public ActivateMonster activateMonsterTriggerRef;
    public EnemyBehaviour enemyBehaviourRef;
    public AudioManager _audioManager;

    [SerializeField]
    public List<GameObject> safeZones;


    public void PlayerStatus(bool safe)
    {
        enemyRef.GetComponent<EnemyBehaviour>().IsPlayerSafe = safe;
        _AudioManager.IsTuvaSafe = safe;
    }
    public void GoMonster()
    {
        EnemyBehaviourRef.Action();
        _AudioManager.FCActive = true;

        
    }

    public EnemyBehaviour EnemyBehaviourRef { get { return enemyBehaviourRef; } set { enemyBehaviourRef = value; } }
    public AudioManager _AudioManager {get{return _audioManager;} set{_audioManager = value;}}

}
