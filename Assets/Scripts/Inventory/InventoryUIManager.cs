using System.Collections;
using System.Collections.Generic;
using UnityEditor;
<<<<<<< HEAD
=======
using UnityEditorInternal.Profiling.Memory.Experimental;
>>>>>>> eaa0af3 (Choose-your-Adventure)
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{

    public GameObject m_slotPrefab;
    void Start()
    {
        InventorySystem.InventoryInstance.onInventoryChange += OnUpdateInventory;
    }

    private void OnUpdateInventory()
    {

        
        foreach(Transform t in transform)
        {
            
            Destroy(t.gameObject);
        }
        DrawInventory();
    }

    public void DrawInventory()
    {
        foreach (InventoryItem item in InventorySystem.InventoryInstance.inventory)
        {
            
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);

        InventorySlot slot = obj.GetComponent<InventorySlot>();
        Debug.Log("Trying to add " + item.data.displayName.ToString());
        
        slot.Set(item);
    }
}
