using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityAtoms.BaseAtoms;
using UnityEditor.Rendering;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    private Vector2Variable movement = null;
    [SerializeField]
    private FloatVariable speed;
    private Rigidbody2D rb;
    [SerializeField]
    private BoolVariable faceRight;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement.ObserveChange().Subscribe(pos =>
        {
            rb.velocity = movement.Value * speed.Value;
            if(pos.x>0){
                faceRight.SetValue(true);
            }
            if(pos.x<0){
            
                faceRight.SetValue(false);
            }
        })
        .AddTo(this);
    }
}
