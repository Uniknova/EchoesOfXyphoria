using UnityEngine;

public class UICanvasControllerInput : MonoBehaviour
{

    //[Header("Output")]
    public Player inputs;

    public void Awake()
    {
        if (DataInfo.Instance.GetPlatform() == 1) this.gameObject.SetActive(false);
    }
    public void VirtualMoveInput(Vector2 virtualMoveDirection)
    {
        if (inputs != null)
        {
            Vector3 move = new Vector3(virtualMoveDirection.x, 0, virtualMoveDirection.y);
            inputs.controller.Move(move * inputs.speed * Time.deltaTime);
        }
        //inputs.move = virtualMoveDirection;
    }

    public void VirtualLookInput(Vector2 virtualLookDirection)
    {

        float angle = Mathf.Atan2(-virtualLookDirection.y , virtualLookDirection.x) * Mathf.Rad2Deg - 90.0f;

        inputs.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
        //inputs.look = virtualLookDirection;
    }

    //public void VirtualJumpInput(bool virtualJumpState)
    //{
    //    inputs.jump = virtualJumpState;
    //}

    //public void VirtualSprintInput(bool virtualSprintState)
    //{
    //    inputs.sprint = virtualSprintState;
    //}

    //public void VirtualSwitchInput(bool virtualSwitchState)
    //{
    //    inputs.switchMode = virtualSwitchState;
    //}
}