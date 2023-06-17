using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndDamage : MonoBehaviour
{

    [SerializeField]
    GameObject sword;
    public void StartDealDamage()
    {
        sword.GetComponentInChildren<DamageDealer>().StartDealDamage();
    }

    public void EndDealDamage()
    {
        sword.GetComponentInChildren<DamageDealer>().EndDealDamage();
    }
}
