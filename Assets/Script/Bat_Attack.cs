using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Attack : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float AttackSpeed;
    [SerializeField] private float Parameter;

    private float BatDistance;

    // Update is called once per frame
    void Update()
    {
        BatDistance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;

        if (BatDistance < Parameter)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, AttackSpeed * Time.deltaTime);
        }
    }
}
