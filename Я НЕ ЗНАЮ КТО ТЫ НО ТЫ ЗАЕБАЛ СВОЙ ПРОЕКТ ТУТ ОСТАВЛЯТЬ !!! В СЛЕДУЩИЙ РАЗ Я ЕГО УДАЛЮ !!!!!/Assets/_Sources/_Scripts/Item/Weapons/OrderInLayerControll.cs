using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayerControll : MonoBehaviour
{
    public void OrderInLayerChanger(GameObject player, GameObject weapon)
    {
        if (player != null && weapon != null)
        {
            SpriteRenderer firstRenderer = weapon.GetComponent<SpriteRenderer>();
            SpriteRenderer secondRenderer = player.GetComponent<SpriteRenderer>();

            if (firstRenderer != null && secondRenderer != null)
            {
                firstRenderer.sortingOrder = secondRenderer.sortingOrder + 1;
            }
            else
            {
                Debug.LogError("One of the objects does not have a SpriteRenderer component.");
            }
        }
        else
        {
            Debug.LogError("FirstObject or SecondObject is not assigned.");
        }
    }
}
