using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField]
    public float countdown = 2f;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0f){
            FindObjectOfType<obstacleDestroyer>().Explode(transform.position);
            Destroy(gameObject);
        }
    }
}
