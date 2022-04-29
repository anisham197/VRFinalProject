using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FoodPrefab : MonoBehaviour
{
    Vector3 initialPosition;
    Quaternion initialRotation;
    float threshold = 0.01f;
    public FoodPrefab food;
    bool hasMoved;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.position;
        initialRotation = this.transform.rotation;
        hasMoved = false;

        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().mass = 1;
        this.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
    }

    // Update is called once per frame
    void Update()
    {
        // get current position
        Vector3 currentPosition = this.transform.position;
        Vector3 diffVector = currentPosition - initialPosition;

        if (diffVector.sqrMagnitude > threshold && !hasMoved)
        {
            FoodPrefab newFood = Instantiate<FoodPrefab>(food, initialPosition, initialRotation);
            newFood.gameObject.name = food.gameObject.name;
            hasMoved = true;
        }
    }
}
