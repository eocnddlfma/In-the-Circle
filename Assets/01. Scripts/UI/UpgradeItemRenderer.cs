using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeItemRenderer : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public ItemType type; 
    
    
    public void DoItemRender(Image icon, string itemName, string itemDescription, ItemType type)
    {
        this.icon = icon;
        Name.text = itemName;
        Description.text = itemDescription;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SkillManager.Instance.UpgradeSkill(type);
        UpgradeManager.Instance.CloseCanvas();
    }
}
