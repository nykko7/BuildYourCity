using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi : MonoBehaviour
{
    
    
    public IEnumerator MoveTo(Transform mover, Vector3 destination, float speed) {
    // This looks unsafe, but Unity uses
    // en epsilon when comparing vectors.
        //float x = 0f;
        while(mover.position != destination) {
            mover.position = Vector3.MoveTowards(
                mover.position,
                destination,
                speed * Time.deltaTime);
            //x += 0.35f;
            // mover.rotation = Quaternion.Euler(0,0,1);
            yield return null;
            // Wait a frame and move again.         
        }
        
    }

    

}
