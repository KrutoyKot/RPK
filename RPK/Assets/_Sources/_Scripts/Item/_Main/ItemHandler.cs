using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemHandler : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField, Range(1, 64)] private int count;

    private void Start()
    {
        if(item == null)
        {
            Debug.LogWarning($"Item Destroy: {gameObject.name}");
            Kill();
            return;
        }

        GetComponent<Collider2D>().isTrigger = true;
        GetComponentInChildren<SpriteRenderer>().sprite = item.Sprite;
    }
    public Item GetItem()
    {
        return item;
    }
    public int GetCount()
    {
        return count;
    }    
    public void Kill() => Destroy(gameObject);
}
