using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeart : MonoBehaviour
{
    public GameObject heart;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void DestroyChest()
    {
        Instantiate(heart, new Vector3( this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity);
        anim.SetTrigger("Destruir");
        Destroy(this.gameObject, 0.2f);
    }
}
