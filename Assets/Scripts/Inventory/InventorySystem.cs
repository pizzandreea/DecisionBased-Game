using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySystem : MonoBehaviour
{
    public static InventorySystem InventoryInstance { get; private set; }
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    
    public List<InventoryItem> inventory; /* { get; private set; }*/

    public delegate void OnInventoryChangeEvent();
    public event OnInventoryChangeEvent onInventoryChange;



    private void Awake()
    {
        if(InventoryInstance != null && InventoryInstance != this) { 
            Destroy(InventoryInstance);
            
        }
        else
        {
            InventoryInstance = this;
        }

        inventory = new List<InventoryItem>();

        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        


        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
            onInventoryChange?.Invoke();
        }
        else
        {
            
            
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
                
            m_itemDictionary.Add(referenceData, newItem);
            onInventoryChange?.Invoke();
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        onInventoryChange?.Invoke();
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
    }
}
