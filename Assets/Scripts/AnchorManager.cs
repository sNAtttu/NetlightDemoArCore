using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject anchoredGameobject;


    private Anchor createdAnchor;
    // Use this for initialization
    void Start()
    {

    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(3);
        var playerTransform = FindObjectOfType<ARCoreSession>().transform;
        Vector3 playerLocation = new Vector3(playerTransform.position.x, playerTransform.transform.position.y, playerTransform.transform.position.z + 2);
        Pose anchoredObjectPose = new Pose(playerLocation, prefab.transform.rotation);
        createdAnchor = Session.CreateWorldAnchor(anchoredObjectPose);
        anchoredGameobject = Instantiate(prefab, createdAnchor.transform.position, createdAnchor.transform.rotation);
    }

}
