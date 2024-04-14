using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public HeroKnight heroK;
    public float RollForce = 7;
    public bool canRoll;
    public float RollCoolDown = 0.2f ;
    
    public void start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        heroK = GetComponent<HeroKnight>();
        canRoll = true;
    }
    
    public void Update()
    {
        if (Input.GetKeyDown("Space") && canRoll)
        {
            Rolling();
        }
    }
    
    public void Rolling()
    {
        rb2d.AddForce(rb2d.velocity * RollForce, ForceMode2D.Impulse);
        canRoll = false;
        StartCoroutine(RollCD());
    }
    public IEnumerator RollCD()
    {
        yield return new WaitForSeconds(RollCoolDown);
        canRoll = true;
    }
}
