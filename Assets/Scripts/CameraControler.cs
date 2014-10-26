using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour
{
    public GameObject player;
    public float distanceInfront;
    public float distanceBehind;
    public float height;
    public string nameOfTarget;


    // Use this for initialization
    void Start()
    {
        if (!player)
        {
            player = GameObject.Find(nameOfTarget);
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (!player)
        {
            player = GameObject.Find(nameOfTarget);
        }

        transform.position = player.transform.position + (Vector3.up * height) - (player.transform.forward * distanceBehind);
        transform.LookAt(player.transform.position + player.transform.forward * 10);


    }
}
