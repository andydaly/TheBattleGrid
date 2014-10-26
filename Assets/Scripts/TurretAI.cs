using UnityEngine;
using System.Collections;

public class TurretAI : MonoBehaviour {


	// Turret Ai script
	// Author Andrew Daly
	// Must be attached to Turret Prefab
	




	public GameObject BulletPrefab;
	public float bulletspeed = 100.0f;
	public float CoolDown = 1.0f;



	private Transform player; 
	private PlayerHealth playerHealth; 
	private EnemyView Sight;
	private Transform SpawnPoint;

	private float DamageTime = 0.0f;
	private EnemyHealth enemyHealth;


	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerHealth = player.GetComponent<PlayerHealth>();
		Sight = transform.FindChild("View").GetComponent<EnemyView>();
		SpawnPoint = transform.FindChild("Spawn");
		enemyHealth = GetComponent<EnemyHealth>();





	}
	
	// Update is called once per frame
	void Update () {
	



		if (Sight.EnemySighted && playerHealth.Health > 0f)
		{
			if (DamageTime <= 0)
			{
				GameObject Bullet = (GameObject)Instantiate(BulletPrefab, SpawnPoint.position, transform.rotation); 
				Bullet.rigidbody.AddForce(transform.forward * bulletspeed, ForceMode.Impulse);
				DamageTime += CoolDown;

			}

		}

		if(DamageTime > 0)
			DamageTime -= Time.deltaTime;
		else if (DamageTime <= 0)
			DamageTime = 0;

	}

	void OnCollisionEnter(Collision collision) {
		
		if (collision.gameObject.tag == "PLaser")
		{
			enemyHealth.TakeDamage(20);
			
		}
	}

}
