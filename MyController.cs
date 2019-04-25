using UnityEngine;

public class MyController : MonoBehaviour {

    public float player_speed = 0.5f;
    public float gravity = 9.8f;

    private CharacterController mController;

    // Start is called before the first frame update
    private void Start() {
        mController = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update() {
        // moving player
        Vector3 moveX = Input.GetAxisRaw("Horizontal") * Vector3.right * player_speed;
        Vector3 moveZ = Input.GetAxisRaw("Vertical") * Vector3.forward * player_speed;
        Vector3 move = transform.TransformDirection(moveX + moveZ);

        move.y -= gravity * Time.deltaTime;
        mController.Move(move);
    }
}
