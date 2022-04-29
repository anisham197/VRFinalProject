using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeOrder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject dish = collision.gameObject;
        int[] orderDocket;
        int orderDocketIndex;

        if (GameManager.S.inLevel0) {
            orderDocket = GameManager.S.orderDocketLevel0;
            orderDocketIndex = GameManager.S.orderDocketIndexLevel0;
        } 
        else if (GameManager.S.inLevel1) {
            orderDocket = GameManager.S.orderDocketLevel1;
            orderDocketIndex = GameManager.S.orderDocketIndexLevel1;
        }
        else {
            orderDocket = new int[0];
            orderDocketIndex = 0;
        }

        if (dish.name.Equals("Donut") && orderDocket[orderDocketIndex] == 0)
        {
            dishServed(dish);
        }

        if (dish.name.Equals("Muffin") && orderDocket[orderDocketIndex] == 1)
        {
            dishServed(dish);
        }

        if (dish.name.Equals("HotDog") && orderDocket[orderDocketIndex] == 2)
        {
            dishServed(dish);
        }

        if (dish.name.Equals("Omelette") && orderDocket[orderDocketIndex] == 3)
        {
            dishServed(dish);
        }
    }

    void dishServed(GameObject dish) {
        // Game logic for dish served
        if (GameManager.S.inLevel0) {
            GameManager.S.orderDocketIndexLevel0++;
            GameManager.S.completedOrdersLevel0++;
        } 
        if (GameManager.S.inLevel1) {
            GameManager.S.orderDocketIndexLevel1++;
            GameManager.S.completedOrdersLevel1++;
        }

        Destroy(dish); 
    }
}
