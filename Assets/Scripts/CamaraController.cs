using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = player.transform.position.x + 5;
       // var y = player.transform.position.y + 5;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

    }
}
