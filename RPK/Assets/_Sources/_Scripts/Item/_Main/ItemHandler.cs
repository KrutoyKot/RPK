using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private Item item;

    private void Start()
    {
        if(item == null)
        {
            Debug.LogWarning($"Item Destroy: {gameObject.name}");
            Kill();
            return;
        }

        GetComponentInChildren<SpriteRenderer>().sprite = item.Sprite;
    }
    public Item GetItem()
    {
        return item;
    }
    public void Kill() => Destroy(gameObject);
}
