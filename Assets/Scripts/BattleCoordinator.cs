using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCoordinator : MonoBehaviour
{
    public GameObject Enemy;
	public GameObject Player;
	
	private bool isHitbyRock;
	
	// Start is called before the first frame update
    void Start()
    {
       isHitbyRock = false;
    }

    public void PlayerNormalAttack()
	{
		Enemy.GetComponent<EnemyStats>().HP = Enemy.GetComponent<EnemyStats>().HP - Player.GetComponent<PlayerStats>().ATK;
		Debug.Log(Enemy.GetComponent<EnemyStats>().HP);
	}
	
	public void EnemyNormalAttack()
	{
		if (isHitbyRock==false)
		{
			isHitbyRock = true;
			Player.GetComponent<PlayerStats>().HP = Player.GetComponent<PlayerStats>().HP - Enemy.GetComponent<EnemyStats>().ATK;
			Debug.Log(Player.GetComponent<PlayerStats>().HP);
			Invoke("ResetHitByRock", 0.1f);
		}		
	}
	
	private void ResetHitByRock()
	{
		isHitbyRock = false;
	}
}
