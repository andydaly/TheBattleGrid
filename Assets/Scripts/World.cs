using UnityEngine;
using System.Collections;
using GG;

public class World : MonoBehaviour {
	public int size,numRooms,maxFails,numAI, numHealth;
	public float scale;
	
	public GameObject wall;
    public GameObject player;
    public GameObject AI1;
	public GameObject AI2;
	public GameObject Health;
	Tile[][] tiles;
	Room[] rooms;
	
	// Use this for initialization
	void Start () {
	
		GridGenerator Map = new GridGenerator(size,numRooms,maxFails,numAI, numHealth);
		tiles = Map.getTiles();
		Map.getRooms(out rooms);


		InstantiateTiles();
		
        //Ignore this was trying to build a mesh for the floor rather than have it as many little cubes
        //TODO Actually make the floor a mesh 
        /*
        Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Debug.Log (vertices[1]);
         */
	}

    void InstantiateTiles()
	{
		//Create all the tiles at the imput scale this governs the total size of the world. And every object spawned within it.

		Vector3 scale = new Vector3(this.scale,this.scale,this.scale);
		for(int i=0;i<size;i++)
		{
			for(int j=0;j<size;j++)
			{
				Vector3 pos = Vector3.zero;
                GameObject temp;
				pos.x = i * scale.x;
				pos.z = j * scale.x;
				if(tiles[i][j].type==1)
				{
					//TODO Rewrite this fuction to enable more than just walls
                    //Tanks and enemys also
                    //For now ill just add some if elses IE Make Type 2 player tank type 3 an AI Type 4 what ever
                    pos.y = pos.y+scale.y;
					temp = (GameObject)Instantiate (wall,pos,transform.rotation);
					temp.transform.localScale = scale;
					//temp.renderer.material.SetColor("_Color",Color.red);

                }else{ 
					temp = (GameObject)Instantiate (wall,pos,transform.rotation);
				    temp.transform.localScale = scale;
                }
                
                if (tiles[i][j].type == 2)
                {
                    //TODO Rewrite this fuction to enable more than just walls
                    //Tanks and enemys also
                    //For now ill just add some if elses IE Make Type 2 player tank type 3 an AI Type 4 what ever
                    pos.y = pos.y + ((scale.y));
                    temp = (GameObject)Instantiate(player, pos, transform.rotation);
                    //temp.transform.localScale = scale;
                    //temp.renderer.material.SetColor("_Color", Color.red);

                }
                if (tiles[i][j].type == 3)
                {
                    //TODO Rewrite this fuction to enable more than just walls
                    //Tanks and enemys also
                    //For now ill just add some if elses IE Make Type 2 player tank type 3 an AI Type 4 what ever
                    pos.y = pos.y + ((scale.y)/1.5f);

					int enemytype = Random.Range(1,3);
					
					// Edited by Andrew to include Different Enemies
					if (enemytype == 1)
                    	temp = (GameObject)Instantiate(AI1, pos, transform.rotation);
					else 
						temp = (GameObject)Instantiate(AI2, pos, transform.rotation);

                    //temp.transform.localScale = scale;
                    //temp.renderer.material.SetColor("_Color", Color.green);

                }
				// Edited by Andrew to include Health Pickup
				if (tiles[i][j].type == 4)
				{
					//TODO Rewrite this fuction to enable more than just walls
					//Tanks and enemys also
					//For now ill just add some if elses IE Make Type 2 player tank type 3 an AI Type 4 what ever
					pos.y = pos.y + ((scale.y)/1.5f);

					temp = (GameObject)Instantiate(Health, pos, transform.rotation);

						
					
					//temp.transform.localScale = scale;
					//temp.renderer.material.SetColor("_Color", Color.green);
					
				}
				
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
