using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickuUpObject : MonoBehaviour
{
    private Transform player;

    public float pickUpDistance;

    public bool itemIsPicked;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        itemIsPicked = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        pickUpDistance = Vector3.Distance(player.position, transform.position);

        if ( pickUpDistance <= 2 )
        {
            if( itemIsPicked == false && Input.GetKeyDown(KeyCode.E))
            {
                itemIsPicked = true;
                Destroy(gameObject);


            }
        }
    }
}
