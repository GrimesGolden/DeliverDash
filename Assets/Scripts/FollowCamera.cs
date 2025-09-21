using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    void LateUpdate()
    {
        // The Vector3 is a magic number here, we realize that, but it's okay. 
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
        //transform.position.z = -10; 
        // This doesn't work, because Vector3's are structs, and so .z is just a read only field of that.
        // We have to modify the entire vector and then set it with the = operator. 
    }
}   
