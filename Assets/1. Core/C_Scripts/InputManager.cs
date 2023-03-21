    using System;
    using UnityEngine;
    using UnityEngine.Assertions.Must;
    using UnityEngine.InputSystem;

    public class InputManager : MonoBehaviour
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

        private InputAction KEYBOARD_AD;
        
        private InputAction KEYBOARD_WS;
                
        private InputAction KEYBOARD_Q;

        private InputAction KEYBOARD_E;

        private InputAction KEYBOARD_I;

        private InputAction KEYBOARD_SPACEBAR;

        private InputAction KEYBOARD_TAB;

        private InputAction KEYBOARD_ESCAPE;







        // region  Components - END





        // region  EventActions - BEGIN

        public static event Action<Vector2> Move = delegate { };

        public static event Action Jump = delegate { };

        public static event Action Interact = delegate { };

        public static event Action<float> TurnShip = delegate { };  
        
        public static event Action<float> AccelerateShip = delegate { };

        public static event Action<Vector2> SteerShip = delegate {  };

        public static event Action SwitchController = delegate {  };
        
    // region  EventActions - END
    
    
    
    
    
    
    // region  Events - BEGIN
    
        private void EVENT_PLAYER_MOVEMENT(InputAction.CallbackContext ctx) => Move.Invoke(KEYBOARD_WASD.ReadValue<Vector2>());
    
        private void EVENT_PLAYER_JUMP(InputAction.CallbackContext ctx)
        {
            Jump.Invoke();
            Debug.Log($"IM Jump");
        } 
        private void EVENT_PLAYER_INTERACT(InputAction.CallbackContext ctx) => Interact.Invoke();


        private void EVENT_SHIP_TURN(InputAction.CallbackContext ctx)
        {
            TurnShip.Invoke(ctx.ReadValue<float>());
            Debug.Log($"Turninging IM");
        } 
        
        private void EVENT_SHIP_ACC(InputAction.CallbackContext ctx) => AccelerateShip.Invoke(ctx.ReadValue<float>());
        
        private void EVENT_SHIP_STEER(InputAction.CallbackContext ctx) => SteerShip.Invoke(ctx.ReadValue<Vector2>());
        
        private void EVENT_GENERAL_SWITCH(InputAction.CallbackContext ctx) => SwitchController.Invoke();
    
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


        KEYBOARD_I = input.General.SwitchController;
        
        KEYBOARD_I.Enable();
        KEYBOARD_I.performed += EVENT_GENERAL_SWITCH;
        
        KEYBOARD_WASD = input.Player.Movement;
        KEYBOARD_SPACEBAR = input.Player.Jump;
        KEYBOARD_E = input.Player.Interact;
        
        KEYBOARD_WASD.Enable();
        KEYBOARD_SPACEBAR.Enable();
        KEYBOARD_E.Enable();
        
        KEYBOARD_WASD.performed += EVENT_PLAYER_MOVEMENT;
        KEYBOARD_WASD.canceled += EVENT_PLAYER_MOVEMENT;
        KEYBOARD_SPACEBAR.performed += EVENT_PLAYER_JUMP;
        KEYBOARD_E.performed += EVENT_PLAYER_INTERACT;


        KEYBOARD_AD = input.Ship.Rudder;
        KEYBOARD_WS = input.Ship.Sails;
        
        KEYBOARD_AD.Enable();
        KEYBOARD_WS.Enable();

        KEYBOARD_AD.performed += EVENT_SHIP_TURN;
        KEYBOARD_AD.canceled += EVENT_SHIP_TURN;
        KEYBOARD_WS.performed += EVENT_SHIP_ACC;
        KEYBOARD_WS.canceled += EVENT_SHIP_ACC;



    }

    private void OnDisable()
    {
        input.Disable();
        
        KEYBOARD_WASD.Disable();
        KEYBOARD_SPACEBAR.Disable();
        KEYBOARD_E.Disable();
        
        KEYBOARD_WASD.performed -= EVENT_PLAYER_MOVEMENT;
        KEYBOARD_WASD.canceled -= EVENT_PLAYER_MOVEMENT;
        KEYBOARD_SPACEBAR.performed -= EVENT_PLAYER_JUMP;
        KEYBOARD_E.performed -= EVENT_PLAYER_INTERACT;
        
        
        
        KEYBOARD_AD = input.Ship.Rudder;
        KEYBOARD_WS = input.Ship.Sails;
        
        KEYBOARD_AD.performed -= EVENT_SHIP_TURN;
        KEYBOARD_AD.canceled -= EVENT_SHIP_TURN;
        KEYBOARD_WS.performed -= EVENT_SHIP_ACC;
        KEYBOARD_WS.canceled -= EVENT_SHIP_ACC;
        
        
    } 
}
