using UnityEngine;
public class Billboard : MonoBehaviour {
    void LateUpdate() {
        if (Camera.main)
            transform.LookAt(Camera.main.transform);
    }
}
