using Player;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Interectable : MonoBehaviour
{
    private Inventory _inventory;
    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ItemHandler item))
        {
            if (_inventory.AddItem(item.GetItem(), item.GetCount()))
            {
                Destroy(item.gameObject);
            }
            else
            {
                if (item) item.SetCount(_inventory.GetLastRemations());
            }
        }
    }
}
