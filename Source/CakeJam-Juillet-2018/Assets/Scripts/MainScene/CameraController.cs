using UnityEngine;

public class CameraController : MonoBehaviour {

	public void setPosition(Vector3 pos)
    {
        pos.z = -10;
        transform.position = pos;
    }

    public void setPosition(GameObject obj)
    {
        Vector3 pos = obj.transform.position;
        pos.z = -10;
        transform.position = pos;
    }
}
