using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    private Transform player;

    public float pickUpDistance ;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    public void OnHandlePickupItem()
    {
        InventorySystem.InventoryInstance.Add(referenceItem);
        /*Debug.Log(referenceItem.name);*/
        Destroy(gameObject);
    }

    private void Update()
    {
        pickUpDistance = Vector3.Distance(player.position, transform.position);

        if(pickUpDistance <= 2)
        {
            if(Input.GetKeyDown(KeyCode.F)) 
            {
                
                OnHandlePickupItem();
                
            }
        }
    }
}
