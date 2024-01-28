using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingCar : MonoBehaviour
{
    float speed;
    public Vector3 direction = new Vector3(-1, 0, 0);

    private void Start()
    {
        speed = Random.Range(7, 10);
        StartCoroutine(dei());
    }
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.isOver = true;
            GameManager.instance.gameOver(deathEffectType.stars);
            other.gameObject.GetComponent<CharacterControl>().die();

        }
        if (other.gameObject.tag == "end")
        {
            carspawner.spawnCount--;
            Destroy(gameObject);
        }
    }
    IEnumerator dei()
    {
        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);
    }
}
