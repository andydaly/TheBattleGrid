using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GG{
	
	public class Tile
	{
		//Type of tile and its location in space
		/// <summary>
		///
		/// Type 0 wall
		/// Type 1 Room
        /// Type 2 Player
        /// Type 3 AI
		/// More types likely to come
		///
		/// </summary>
		public int type; 

		
		/// <summary>
		/// The location in 2d Space.
		/// </summary>
		public Vector2 location;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="GG.Tile"/> class.
		/// </summary>
		/// <param name='x'>
		/// X.
		/// </param>
		/// <param name='y'>
		/// Y.
		/// </param>
		/// <param name='type'>
		/// Type.
		/// </param>
		public Tile(int x, int y, int type)
		{
			location.x = x;
			location.y = y;
			this.type = type;			
		}
	}
		
	public class Room
	{
	//TODO Fix This Class.
		public Tile[] roomTiles;
		public int connected = 0;
	}
	
	
	public class GridGenerator{
		
		private Tile[][] tiles;
		private Room[] rooms;
		private int size;
		private int numRooms;
		private int maxFails;
		private int count =0;
		
		public GridGenerator(int size,int numRooms,int maxFails,int numAI, int numHealth)
		{
			this.size = size;
			this.numRooms = numRooms;
			this.maxFails = maxFails;
			initializeGrid();
			createRooms(numRooms);
            
            int aicount = 0;
            while (aicount < numAI)
            {
                if (placeAI()) { aicount++;}
            }

			int healthcount = 0;
			while (healthcount < numHealth)
			{
				if (placeHealth()) { healthcount++;}
			}
			


            bool placed = false;
            while(placed != true)
            {
                placed = placePlayer();
            }

			createPaths();
						
		}
		
		void initializeGrid()
		{
			tiles = new Tile[size][];
			for(int i=0;i<size;i++)
			{
				tiles[i] = new Tile[size];
				
				for(int j=0;j<size;j++)
				{
					tiles[i][j] = new Tile(i,j,0);

				}
				
			}			
			rooms = new Room[numRooms];
			
		}
		void createRooms(int numRooms)
		{			
			int fails = 0;
			while(count < numRooms)
			{
				if(placeRoom(count))
				{
					count++;
				}else{
					fails++;
					if (fails > maxFails)
					{
						break;
					}
				}
			}	
		}
		
		bool placeRoom(int roomIndex)
		{
			//Position and Size of the room to be created
			int posX, posY, roomX, roomY;
			bool valid = true;
		
			//find a location for a room.
			posX = Random.Range (1, (size-1));
			posY = Random.Range (1, (size-1));		

			//Set Room size
			roomX = Random.Range (2, 6);
			roomY = Random.Range (2, 6);
						
			//check to see if Location is valid. by adding the room size to the position to make sure it wont be larger than the array-1
			if (((posX+roomX) < (size-1))&&((posY+roomY)<(size-1)))
			{	
						
				for (int i=-1; i<(roomX+1); i++) {
					for (int j=-1; j<(roomY+1); j++) {
			
						//this must be lower than size - 1 or index out of range error.
																
						if (tiles[(posX + i)][(posY + j)].type == 1) 
						{
							Debug.Log ("Room pressent invalid ");
							return false;
						}
						
					}			
				}
			}
			else
			{				
				Debug.Log ("Location invalid ");
				return false;	
			}
			
			//If Vaild Delete the cubes from the room array and create a new room object
			if (valid) 
			{
				//int tileCount=0;
				
				for(int i=0; i<roomX; i++)
				{
					for (int j=0; j<roomY; j++) 
					{
						tiles[(posX+i)][(posY+j)].type=1;
												
					}			
				}
				return(true);
			}
			
			Debug.Log("Thats Not Right Error 1 Failed to place room");
			return(false);
			
		}

        bool placeAI()
        {

            //Position where to place tank
            int posX, posY;
            bool valid = true;

            //find a location for a room.
            posX = Random.Range(1, (size - 1));
            posY = Random.Range(1, (size - 1));

            if (tiles[(posX)][(posY)].type == 1)
            {
                Debug.Log("Room pressent invalid ");
                return false;
            }

            //If Vaild Delete the cubes from the room array and set the tile type
            if (valid)
            {
                tiles[posX][posY].type = 3;
                return (true);
            }

            Debug.Log("Thats Not Right Error 1 Failed to place room");
            return (false);

        }


		bool placeHealth()
		{
			
			//Position where to place tank
			int posX, posY;
			bool valid = true;
			
			//find a location for a room.
			posX = Random.Range(1, (size - 1));
			posY = Random.Range(1, (size - 1));
			
			if (tiles[(posX)][(posY)].type == 1)
			{
				Debug.Log("Room pressent invalid ");
				return false;
			}
			
			//If Vaild Delete the cubes from the room array and set the tile type
			if (valid)
			{
				tiles[posX][posY].type = 4;
				return (true);
			}
			
			Debug.Log("Thats Not Right Error 1 Failed to place room");
			return (false);
			
		}




        bool placePlayer(){

            //Position where to place tank
            int posX, posY;
            bool valid = true;

            //find a location for a room.
            posX = Random.Range(1, (size - 1));
            posY = Random.Range(1, (size - 1));
           
            if (tiles[(posX)][(posY)].type == 1)
            {
                Debug.Log("Room pressent invalid ");
                return false;
            }

            //If Vaild Delete the cubes from the room array and set the tile type
            if(valid)
            {                          
                tiles[posX][posY].type = 2;
                return (true);
            }

            Debug.Log("Thats Not Right Error 1 Failed to place room");
            return (false);

        }

		/// <summary>
		/// Creates the paths.
		/// </summary>
		void createPaths()
		{

			
			/*
			for (int i=0;i<count;i++){
				if (rooms[i].connected==0)
				{	
					///TODO
					//Find near room, start pathing
					//Need Lists 
					//Use Shortest List
				}
			}*/
		}
		
		void createPath(Room start,Room end)
		{
			//Get list of Tiles around starting room.
			List<Tile> tiles = new List<Tile>();
			foreach (Tile t in start.roomTiles)
			{
				tiles.Add(t);
			}
			
			foreach(Tile t in tiles)
			{
				//Get the nort south east and west tile that does not exist in this set already
				//add is not null
				//North

			
			}
			
			
		}
		/// <summary>
		/// Gets the tiles.
		/// </summary>
		/// <returns>
		/// The tiles.
		/// </returns>
		public Tile[][] getTiles()
		{
			return(tiles);
		}
		/// <summary>
		/// Gets the rooms.
		/// </summary>
		/// <param name='x'>
		/// X.
		/// </param>
		public void getRooms(out Room[] x)
		{
			x = rooms;
		}
		
		public Tile[][] Dijkstra()
		{
			Tile[][] x = tiles;
			return(x);
		}
		
	}
}