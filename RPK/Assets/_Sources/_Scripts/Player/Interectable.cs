using Player;
using UnityEngine;

public class Interectable : MonoBehaviour
{
    [SerializeField] private CellInventory cell;
    [SerializeField] private Item item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMove player))
        {
            cell.AddItem(item, item.addCount);
        }
    }
}
