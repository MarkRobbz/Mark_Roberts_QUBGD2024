using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Vector3 randomVector3;
    
    void Start()
    {
       RandomCubeTransform();
        //transform.position = new Vector3(3, 4, 1);
        //transform.localScale = Vector3.one * 1.3f;
        
        //Material material = Renderer.material;
        
        //material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        transform.Rotate(randomVector3.x * Time.deltaTime, 0.0f,0.0f);
        
    }

    void RandomCubeTransform()
    {
        randomVector3 = new Vector3(Random.Range(1.0f, 4.0f), Random.Range(1.0f, 4.0f), Random.Range(1.0f, 4.0f));
        transform.localScale = Vector3.one * Random.Range(1.0f,4.0f);
        Material material = Renderer.material;
        material.color = new Color(randomVector3.x, randomVector3.y, randomVector3.z);
    }
}
