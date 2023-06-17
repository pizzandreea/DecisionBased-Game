using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    [SerializeField]
    private Image m_icon;

    [SerializeField]
    private TextMeshProUGUI m_label;

    [SerializeField]
    private GameObject m_stackObj;

    [SerializeField]
    private TextMeshProUGUI m_stackLabel;

    public void Set (InventoryItem item)
    {
        Debug.Log(item.data.icon.ToString());
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;

        if(item.stackSize < 1)
        {
            m_stackObj.SetActive(false);
            return;
        }
        m_stackLabel.text = item.stackSize.ToString();
    }
}
