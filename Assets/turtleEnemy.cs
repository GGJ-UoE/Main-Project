using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleEnemy : MonoBehaviour
{
    public Animator anim;
    public float flyInAirspeed = 5f;
    public Vector3 flyDirection = new Vector3(20, 13, 0);
    public GameObject deathPartilce;
    public GameObject flyDeathPartilce;
    bool flyinAir;
    private CharacterControl player;
    void Start()
    {
        player = FindObjectOfType<CharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,player.transform.position)<=15f)
        {
            anim.SetInteger("state", 1);
        }
        if (flyinAir)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + flyDirection, Time.deltaTime * flyInAirspeed);
            transform.rotation = Quaternion.Euler(Random.Range(10, 20), Random.Range(30, 50), Random.Range(0, 10));
            Destroy(gameObject, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(CharacterControl.attackType);
            // explode enemy //
            if (CharacterControl.attackType == 1)
            {
                // player gonna fucked
                //Instantiate(deathPartilce, transform.position, deathPartilce.transform.rotation);
                //Destroy(gameObject);
            }
            // go in Air //
            else if (CharacterControl.attackType == 2)
            {
                gameObject.GetComponent<Collider>().enabled = false;
                Instantiate(flyDeathPartilce, transform.position + Vector3.up * 2, flyDeathPartilce.transform.rotation);
                flyinAir = true;

            }
            else if (CharacterControl.attackType == 0)
            {
                // player will die //
                other.gameObject.GetComponent<CharacterControl>().die();
            }
            CharacterControl.attackType = 0;
        }
    }
}
