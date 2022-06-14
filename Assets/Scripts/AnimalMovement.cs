using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    private int vitesse;
    private Vector3 newPosition;
    private Vector3 direction;
    private Quaternion toRotation;
    private float lerpPosition;
    private float vitesseDeRotation;
    private Quaternion rotationDeDepart;
    public float invokeDelta;

    // Start is called before the first frame update
    void Awake()
    {
       vitesse = 10;
       vitesseDeRotation = 3;
       newPosition = Vector3.zero;
       InvokeRepeating("RandomPosition", 0.0f,invokeDelta);

    }
    void RandomPosition(){
        newPosition = new Vector3(Random.Range(-50,50),Random.Range(1,50),Random.Range(-50,50));
        direction = Vector3.Normalize(newPosition - transform.position);
        toRotation = Quaternion.LookRotation(direction, Vector3.up);
        lerpPosition = 0;
        rotationDeDepart = transform.rotation;

        //Debug.Log(newPosition);
    }

    // Update is called once per frame
    void FixedUpdate(){
        lerpPosition += vitesseDeRotation * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(rotationDeDepart, toRotation, lerpPosition);

   // transform.LookAt(newPosition, Vector3.up);
    transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime*vitesse);



    }
}
