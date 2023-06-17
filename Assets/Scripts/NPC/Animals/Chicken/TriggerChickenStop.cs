using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChickenStop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Chicken"))
        {
            // other.gameObject.GetComponent<RandomMovement>().stop = true;
            other.gameObject.GetComponent<RandomMovement>().StopChicken();
            Debug.Log(other.gameObject.name);
        }
            

    }
}
