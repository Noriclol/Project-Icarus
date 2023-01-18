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

        private InputAction KEYBOARD_Q;

        private InputAction KEYBOARD_E;

        private InputAction KEYBOARD_I;

        private InputAction KEYBOARD_SPACEBAR;

        private InputAction KEYBOARD_TAB;

        private InputAction KEYBOARD_ESCAPE;




        private InputAction ShipTurn;
        private InputAction shipAcc;


        // region  Components - END





        // region  EventActions - BEGIN

        public static event Action<Vector2> Move = delegate { };

        public static event Action Jump = delegate { };

        public static event Action Interact = delegate { };

        public static event Action<float> TurnShip = delegate { };  
        
        public static event Action AccelerateShip = delegate { };
    // region  EventActions - END
    
    
    
    
    
    
    // region  Events - BEGIN
    
    private void EVENT_PLAYER_MOVEMENT(InputAction.CallbackContext ctx) => Move.Invoke(KEYBOARD_WASD.ReadValue<Vector2>());

    private void EVENT_PLAYER_JUMP(InputAction.CallbackContext ctx) => Jump.Invoke();
    private void EVENT_PLAYER_INTERACT(InputAction.CallbackContext ctx) => Interact.Invoke();


    private void EVENT_SHIP_TURN(InputAction.CallbackContext ctx) => TurnShip.Invoke(ctx.ReadValue<float>());
    
    private void EVENT_SHIP_ACC(InputAction.CallbackContext ctx) => AccelerateShip.Invoke();
    
    
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


        ShipTurn = input.Ship.Rudder;
        shipAcc = input.Ship.Sails;
        
        ShipTurn.Enable();
        shipAcc.Enable();

        ShipTurn.performed += EVENT_SHIP_TURN;
        ShipTurn.canceled += EVENT_SHIP_TURN;
        shipAcc.performed += EVENT_SHIP_ACC;
        shipAcc.canceled += EVENT_SHIP_ACC;



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
        
        
        
        ShipTurn = input.Ship.Rudder;
        shipAcc = input.Ship.Sails;
        
        ShipTurn.performed -= EVENT_SHIP_TURN;
        ShipTurn.canceled -= EVENT_SHIP_TURN;
        shipAcc.performed -= EVENT_SHIP_ACC;
        shipAcc.canceled -= EVENT_SHIP_ACC;
        
        
    }

    
    
    
    
    
    // region  Core - END

}
