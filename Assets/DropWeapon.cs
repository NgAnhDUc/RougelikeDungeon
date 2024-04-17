using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWeapon : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Transform itemDrop = transform.GetChild(0);
            Vector3 newpos = new Vector3(itemDrop.position.x + 0.2f, itemDrop.position.y - 0.2f, itemDrop.position.z);
            itemDrop.SetParent(null);
            itemDrop.position = Vector3.MoveTowards(itemDrop.position, newpos, 3);
            itemDrop.GetComponent<SpriteRenderer>().sortingLayerName = "SolidObject";
        }
    }
}
