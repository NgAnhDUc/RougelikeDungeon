using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    [SerializeField] protected List<Transform> itemsCollision;

    private void Awake()
    {
        this.itemsCollision = new List<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Weapon") return;
        if (collision.transform.parent != null) return;
        this.itemsCollision.Add(collision.transform);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Weapon") return;
        if (collision.transform.parent != null) return;
        this.itemsCollision.Remove(collision.transform);
    }
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.F)) return;
        if (itemsCollision.Count == 0) return;
        Transform item = itemsCollision[0];
        

        item.rotation = transform.GetChild(0).rotation; 
        item.SetParent(transform.GetChild(0));
        transform.GetChild(0).position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
        item.position = transform.GetChild(0).position;
        item.GetComponent<SpriteRenderer>().sortingLayerName = "Weapon";
    }
}
