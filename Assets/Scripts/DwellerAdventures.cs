using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwellerAdventures : MonoBehaviour
{
    //this is for the leaf/bridge puzzle
    [SerializeField] GameObject leafBridge;
    [SerializeField] GameObject chasmBlocking;
    [SerializeField] Color32 hasLeafColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noLeafColor = new Color32 (1, 1, 1, 1);
    // leaf disappears when picked up
    [SerializeField] float destroyDelay = 0.1f;
    
    bool hasLeaf;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //leaf bridge turned off
        leafBridge.SetActive(false);
        //chasm blocking is turned on
        chasmBlocking.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Oof");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //when leaf is picked up, car changes color and leaf disappears
        if (other.tag == "Leaf" && !hasLeaf)
        {
            Debug.Log("Leaf picked up");
            hasLeaf = true;
            spriteRenderer.color = hasLeafColor;
            Destroy(other.gameObject, destroyDelay);
        }

        //with leaf, getting close to gateway enables leafBridge render and disables the chasmBlocking so car can pass
        if (other.tag == "Chasm1Gateway" && hasLeaf)
        {
            Debug.Log("Bridge created");
            hasLeaf = false;
            spriteRenderer.color = noLeafColor;
            leafBridge.SetActive(true);
            chasmBlocking.SetActive(false);
        }

        //getting near top of CaveEntrance repositions car
        if (other.tag == "Entrance")
        {
            gameObject.transform.position = new Vector3(34, 31.55f, 0);
            gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }
}
