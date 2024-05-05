using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int ATK;
	public int HP;
	public float RockSpeed;
	
	// Start is called before the first frame update
    void Start()
    {
        ATK = 1;
		HP = 10000;
		RockSpeed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
