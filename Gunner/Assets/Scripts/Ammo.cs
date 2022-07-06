using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ammo : MonoBehaviour
{
    public Player player;
    public TMP_Text AmmoCount;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Capsule").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.Ammo > 0)
        {
            AmmoCount.text = ("Ammo: " + player.Ammo);
        }
        else
        {
            AmmoCount.text = ("Reloading");
        }
        
    }
}
