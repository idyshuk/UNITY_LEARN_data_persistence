using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public UnityEvent<int> onDestroyed;
    
    public int PointValue;
    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");

    void Start()
    {
        var renderer = GetComponentInChildren<Renderer>();

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        switch (PointValue)
        {
            case 1 :
                block.SetColor(BaseColor, Color.green);
                break;
            case 2:
                block.SetColor(BaseColor, Color.yellow);
                break;
            case 5:
                block.SetColor(BaseColor, Color.blue);
                break;
            default:
                block.SetColor(BaseColor, Color.red);
                break;
        }
        renderer.SetPropertyBlock(block);
    }

    private void OnCollisionEnter(Collision other)
    {
        onDestroyed.Invoke(PointValue);
        
        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }
}
