using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private Transform stand;
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private float yOffSet;
    [SerializeField] private float zOffSet;


    private void Update()
    {
        FollowObject(objectToFollow);
    }

    private void FollowObject(Transform target)
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y + yOffSet, target.position.z + zOffSet);
        stand.position = targetPos;

        transform.position = Vector3.Lerp(transform.position, stand.position, Time.deltaTime * 2f);
    }
}
