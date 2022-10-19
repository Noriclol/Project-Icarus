    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class InputManager
{
    
    
    // region  Components - BEGIN

    private InputMaster input;

    
    //Mouse
    private InputAction MOUSE_DELTA;
    
    private InputAction MOUSE_SCROLL;
    
    private InputAction MOUSE_BTN_L;
    
    private InputAction MOUSE_BTN_M;
    
    private InputAction MOUSE_BTN_R;
    
    
    //Keyboard
    private InputAction KEYBOARD_WASD;
    
    private InputAction KEYBOARD_Q;
    
    private InputAction KEYBOARD_E;
    
    private InputAction KEYBOARD_I;
    
    private InputAction KEYBOARD_SPACEBAR;

    private InputAction KEYBOARD_TAB;

    private InputAction KEYBOARD_ESCAPE;
    
    // region  Components - END
    
    
    
    
    
    // region  EventActions - BEGIN
    
    public event Action<Vector2> Move = delegate { };
    
    public event Action Jump = delegate {  };
    
    public event Action Interact = delegate { };
    
    
    
    // region  EventActions - END
    
    
    
    
    
    
    // region  Events - BEGIN
    
    private void EVENT_PLAYER_MOVEMENT() => Move.Invoke(KEYBOARD_WASD.ReadValue<Vector2>());

    private void EVENT_PLAYER_JUMP() => Jump.Invoke();
    private void EVENT_PLAYER_INTERACT() => Interact.Invoke();
    
    
    // region  Events - END

    
    
    
    
    
    // region  Core - BEGIN

    
    private void Awake()
    {
        if (input != null)
        {
            return;
        }
        input = new InputMaster();
    }
    
    private void OnEnable()
    {
        input.Enable();

        // KEYBOARD_WASD = input.Player.Movment;
        // KEYBOARD_SPACEBAR = input.Player.Jump;
        
        KEYBOARD_WASD.Enable();
        KEYBOARD_SPACEBAR.Enable();
        KEYBOARD_E.Enable();
        
    }

    private void OnDisable()
    {
        input.Disable();
        
    }

    // region  Core - BEGIN


}
