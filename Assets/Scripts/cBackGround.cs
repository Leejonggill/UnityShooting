using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBackGround : MonoBehaviour
{
    SpriteRenderer sprite;
    float offset;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();  
    }
    void Update()
    {
        offset += Time.deltaTime * 0.3f;
        sprite.material.mainTextureOffset = new Vector2(0, offset);
    }
}
