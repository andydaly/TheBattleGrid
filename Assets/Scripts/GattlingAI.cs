using UnityEngine;
using System.Collections;

public class GattlingAI : MonoBehaviour {

	// Gattling AI script
	// Author Andrew Daly
	// Must be attached to Gattling enemy perfab
	

	public GameObject BulletPrefab;
	public float bulletspeed = 100.0f;
	public float CoolDown = 3.0f;
	public float Speed = 2f;
	
	
	private Transform player; 
	private PlayerHealth playerHealth; 
	private EnemyView Sight;
	private Transform SpawnPoint1, SpawnPoint2, SpawnPoint3, SpawnPoint4;
	private SphereCollider SCollider;
	private float DamageTime = 0.0f;
	private EnemyHealth enemyHealth;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerHealth = player.GetComponent<PlayerHealth>();
		Sight = transform.FindChild("View").GetComponent<EnemyView>();
		enemyHealth = GetComponent<EnemyHealth>();

		SpawnPoint1 = transform.FindChild("Spawn1");
		SpawnPoint2 = transform.FindChild("Spawn2");
		SpawnPoint3 = transform.FindChild("Spawn3");
		SpawnPoint4 = transform.FindChild("Spawn4");

		SCollider = transform.FindChild("View").GetComponent<SphereCollider>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Sight.EnemySighted && playerHealth.Health > 0f)
		{
			if (DamageTime <= 0)
			{

				GameObject Bullet1 = (GameObject)Instantiate(BulletPrefab, SpawnPoint1.position, transform.rotation); 
				Bullet1.rigidbody.AddForce(transform.forward * bulletspeed, ForceMode.Impulse);

				GameObject Bullet2 = (GameObject)Instantiate(BulletPrefab, SpawnPoint2.position, transform.rotation); 
				Bullet2.rigidbody.AddForce(transform.forward * bulletspeed, ForceMode.Impulse);

				GameObject Bullet3 = (GameObject)Instantiate(BulletPrefab, SpawnPoint3.position, transform.rotation); 
				Bullet3.rigidbody.AddForce(transform.forward * bulletspeed, ForceMode.Impulse);
				
				GameObject Bullet4 = (GameObject)Instantiate(BulletPrefab, SpawnPoint4.position, transform.rotation); 
				Bullet4.rigidbody.AddForce(transform.forward * bulletspeed, ForceMode.Impulse);
				

				DamageTime += CoolDown;



			}

			transform.position += transform.forward * Speed * Time.deltaTime;

			
		}
		
		if(DamageTime > 0)
			DamageTime -= Time.deltaTime;
		else if (DamageTime <= 0)
			DamageTime = 0;
	}


	void OnCollisionEnter(Collision collision) {
		
		if (collision.gameObject.tag == "PLaser")
		{
			enemyHealth.TakeDamage(30);
			
		}
	}

}
