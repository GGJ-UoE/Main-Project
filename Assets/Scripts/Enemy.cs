using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 startpos;
    public Vector3 desPos = new Vector3(5, 0, 0);
    public float speed = 3f;
    public bool pingPong;
    [SerializeField]private Vector3 currentPos;
    public float flyInAirspeed = 5f;
    public Vector3 flyDirection = new Vector3(20, 13, 0);
    public GameObject deathPartilce;
    public GameObject flyDeathPartilce;
    bool flyinAir;
    void Start()
    {
        startpos = transform.position;
        desPos += startpos;
        currentPos = desPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (flyinAir)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + flyDirection, Time.deltaTime * flyInAirspeed);
            transform.rotation = Quaternion.Euler(Random.Range(10, 20), Random.Range(30, 50), Random.Range(0, 10));
            Destroy(gameObject, 3f);
        }
        else
        {


            if (pingPong)
            {
                if (Vector3.Distance(transform.position, desPos) <= 0.1f)
                {
                    currentPos = startpos;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);


                }
                if (Vector3.Distance(transform.position, startpos) <= 0.1f)
                {
                    currentPos = desPos;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);

                }
                transform.position = Vector3.MoveTowards(transform.position, currentPos, Time.deltaTime * speed);

                // transform.position = Vector3.MoveTowards(transform.position, startpos, Time.deltaTime * speed);
            }
            else
                transform.position = Vector3.MoveTowards(transform.position, desPos, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // explode enemy //
            if (CharacterControl.attackType == 1)
            {
                Instantiate(deathPartilce, transform.position, deathPartilce.transform.rotation);
                Destroy(gameObject);
            }
            // go in Air //
            else if(CharacterControl.attackType == 2)
            {
                gameObject.GetComponent<Collider>().enabled = false;    
                Instantiate(flyDeathPartilce, transform.position+Vector3.up*2, flyDeathPartilce.transform.rotation);
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
