using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class RotateToMouse : MonoBehaviour
{
    [SerializeField] protected GameObject weapon;
    [SerializeField] protected SpriteRenderer weaponSprite;

    [SerializeField] protected PhotonView photonView;
    void Awake()
    {
        photonView = GetComponent<PhotonView>();
        weaponSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (!PhotonNetwork.InRoom)
        {
            this.ObjectRotateToMouse();
        }
        if (!photonView.IsMine) return;
        this.ObjectRotateToMouse();
    }
    protected void ObjectRotateToMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 norTar = (worldPos - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        Quaternion rotation = new Quaternion();

        if (transform.position.x > worldPos.x)
        {
            weaponSprite.flipX = true;
            rotation.eulerAngles = new Vector3(0, 0, angle - 180);
        }
        else
        {
            weaponSprite.flipX = false;
            rotation.eulerAngles = new Vector3(0, 0, angle);
        }

        transform.rotation = rotation;
    }
}
