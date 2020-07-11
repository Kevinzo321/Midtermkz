using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Pri Insp War
    [SerializeField] private Transform player;
    [SerializeField] private Transform MoveThreshold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Follow Player
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
