using System;
using System.Collections;
using System.Collections.Generic;
using EzySlice;
using UnityEngine;

public class Cut : MonoBehaviour
{
    private Material _material;
    private GameObject _cutGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pumpkin"))
        {
            _material = other.GetComponent<MeshRenderer>().material;
            _cutGameObject = other.gameObject;
        }

        if (_cutGameObject != null)
        {
            SlicedHull Cutted = Cutting(_cutGameObject, _material);
            GameObject _cutUpper = Cutted.CreateUpperHull(_cutGameObject, _material);
            GameObject _cutLower = Cutted.CreateLowerHull(_cutGameObject, _material);
            
            _cutUpper.AddComponent<MeshCollider>().convex = true;
            _cutUpper.AddComponent<Rigidbody>();
            _cutUpper.layer = LayerMask.NameToLayer("Pumpkin");
            
            _cutLower.AddComponent<MeshCollider>().convex = true;
            _cutLower.AddComponent<Rigidbody>();
            _cutLower.layer = LayerMask.NameToLayer("Pumpkin");

            _cutUpper.transform.position = _cutGameObject.transform.position;
            _cutLower.transform.position = _cutGameObject.transform.position + new Vector3(0.1f,0.1f,0.1f);
            
            _cutUpper.transform.localScale = new Vector3(2,2,2);
            _cutLower.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
            
            Destroy(_cutGameObject);
        }
    }

    public SlicedHull Cutting(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }
    
}
