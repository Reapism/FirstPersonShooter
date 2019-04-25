using UnityEngine;

public class Target : MonoBehaviour {

    public bool enableSpin = true;
    public bool enableHMotion = false;
    public bool enableUPMotion = false;
    public float move_speed = 1.0f;
    public float rotate_speed = 100.0f;

    // Start is called before the first frame update
    private void Start() {

    }

    // Update is called once per frame
    private void Update() {
        this.gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotate_speed * (enableSpin ? 1.0f : 0.0f));
        this.gameObject.transform.Translate(Vector3.up * move_speed
            * Mathf.Cos(Time.timeSinceLevelLoad) * (enableUPMotion ? 1.0f : 0.0f));

        this.gameObject.transform.Translate(Vector3.forward * move_speed
            * Mathf.Cos(Time.timeSinceLevelLoad) * (enableHMotion ? 1.0f : 0.0f));
    }
}
