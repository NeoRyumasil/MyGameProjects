using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAttack : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    [SerializeField] private float Speed;
    [SerializeField] private float Parameter;

    private float Distance;
  
    void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;
      
        if (Distance < Parameter )
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Parameter);
    }
}
