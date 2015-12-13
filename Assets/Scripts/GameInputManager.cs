using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;


public class GameInputManager : Singleton<GameInputManager> {
	public enum GameInputDevice {KEYBOARD, RAZER};

	public SixenseInput.Controller LeftHand {
		get { return m_leftHand; }
	}

	public SixenseInput.Controller RightHand {
		get { return m_rightHand; }
	}

	public GameInputDevice CurrentInputDevice {
		get { return m_inputDevice; }
	}
	
	private GameInputDevice m_inputDevice;
	private SixenseInput.Controller m_leftHand;
	private SixenseInput.Controller m_rightHand;

	protected GameInputManager() {} // guarantee this will be always a singleton only - can't use the constructor

	// Use this for initialization
	private void Start () {
		m_leftHand = SixenseInput.Controllers[0];
		m_rightHand = SixenseInput.Controllers[1];

		m_inputDevice = GameInputDevice.KEYBOARD;
	}
	
	// Update is called once per frame
	private void Update () {
		// Check if input device has changed
		HandleDeviceChange();
	}
	
	public bool GetButtonDownJump() {
		if (m_inputDevice == GameInputDevice.KEYBOARD)
			return CrossPlatformInputManager.GetButtonDown("Jump");
		else
			return m_rightHand.GetButtonDown(SixenseButtons.ONE);
	}
	
	public bool GetButtonThrowPaint() {
		if (m_inputDevice == GameInputDevice.KEYBOARD)
			return Input.GetMouseButton(0);
		else
			return m_rightHand.GetButton(SixenseButtons.BUMPER);
	}

	public object GetButtonUpThrowPaint ()
	{
		if (m_inputDevice == GameInputDevice.KEYBOARD)
			return Input.GetMouseButtonUp(0);
		else
			return m_rightHand.GetButtonUp(SixenseButtons.BUMPER);
	}
	
	public float GetAxisMoveX() {
		if (m_inputDevice == GameInputDevice.KEYBOARD)
			return CrossPlatformInputManager.GetAxis("Horizontal");
		else
			return m_leftHand.JoystickX;
	}
	
	public float GetAxisMoveY() {
		if (m_inputDevice == GameInputDevice.KEYBOARD)
			return CrossPlatformInputManager.GetAxis("Vertical");
		else
			return m_leftHand.JoystickY;
	}
	
	public float GetAxisLookX() {
		if (m_inputDevice == GameInputDevice.KEYBOARD)
			return CrossPlatformInputManager.GetAxis("Mouse X");
		else
			return m_rightHand.JoystickX;
	}
	
	public float GetAxisLookY() {
		if (m_inputDevice == GameInputDevice.KEYBOARD)
			return CrossPlatformInputManager.GetAxis("Mouse Y");
		else
			return m_rightHand.JoystickY;
	}

	private void HandleDeviceChange(){
		if (m_inputDevice == GameInputDevice.RAZER){
			if(m_leftHand.Docked || m_rightHand.Docked)
				m_inputDevice = GameInputDevice.KEYBOARD;
			
			Debug.Log("Controllers docked/unabled, now using input : " + m_inputDevice.ToString());
		}
		else if (m_inputDevice == GameInputDevice.KEYBOARD){
			if(!m_leftHand.Docked && !m_rightHand.Docked)
				m_inputDevice = GameInputDevice.RAZER;
			
			Debug.Log("Controllers enabled/undocked, now using input : " + m_inputDevice.ToString());
		}
	}
}
