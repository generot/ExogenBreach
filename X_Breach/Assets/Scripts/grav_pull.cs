using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class grav_pull : MonoBehaviour
{
    const float grav_const = 1.6740f, mass = 60f;

    Scene currScene;
    GameObject[] allObjs;

    List<GameObject> attractableObjs;

    void Start()
    {
        attractableObjs = new List<GameObject>();

        currScene = SceneManager.GetActiveScene();
        allObjs = currScene.GetRootGameObjects();

        for(int i = 0; i < allObjs.Length; i++)
        {
            if (allObjs[i].tag == "Moveable")
                attractableObjs.Add(allObjs[i]);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
            for (int i = 0; i < attractableObjs.Count; i++)
            {
                Vector2 distVec = attractableObjs[i].transform.position - transform.position;
                float distSq = distVec.x * distVec.x + distVec.y * distVec.y;

                if(distSq > 16f)
                    Pull(attractableObjs[i]);
            }
            
    }

    void Pull(GameObject obj)
    {
        float dist = Vector2.Distance(transform.position, obj.transform.position);
        float objMass = obj.GetComponent<MoveableObj>().mass;

        float force = grav_const * (mass - objMass) / (dist * dist);

        Vector2 dir = transform.position - obj.transform.position;
        obj.GetComponent<Rigidbody2D>().velocity = dir * force;
    }
}
