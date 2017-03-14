using UnityEngine;
using System.Collections.ObjectModel;



/// <summary>
/// <see cref="Controls"/> is a set of user defined buttons and axes. It is better to store this file somewhere in your project.
/// </summary>
public static class Controls
{
    /// <summary>
    /// <see cref="Buttons"/> is a set of user defined buttons.
    /// </summary>
    public struct Buttons
    {
        public KeyMapping left;
        public KeyMapping right;

        public KeyMapping jump;
    }

    /// <summary>
    /// <see cref="Axes"/> is a set of user defined axes.
    /// </summary>
    public struct Axes
    {
        public Axis vertical;
        public Axis horizontal;

        public Axis rVertical;
        public Axis rHorizontal;
    }



	/// <summary>
	/// Set of buttons.
	/// </summary>
    public static Buttons buttons;

	/// <summary>
	/// Set of axes.
	/// </summary>
    public static Axes    axes;



	/// <summary>
	/// Initializes the <see cref="Controls"/> class.
	/// </summary>
    static Controls()
    {
        InputControl.joystickThreshold = 0.0f;

        buttons.left    = InputControl.setKey("Left",  KeyCode.A,     KeyCode.LeftArrow,  new JoystickInput(JoystickAxis.Axis1Negative, 0.0f, Joystick.Joystick1));
        buttons.right   = InputControl.setKey("Right", KeyCode.D,     KeyCode.RightArrow, new JoystickInput(JoystickAxis.Axis1Positive, 0.0f, Joystick.Joystick1));

        buttons.jump    = InputControl.setKey("Jump",  KeyCode.Space, KeyCode.JoystickButton1);

        load();
    }

	/// <summary>
	/// Nothing. It just call static constructor if needed.
	/// </summary>
    public static void init()
    {
        // Nothing. It just call static constructor if needed
    }

	/// <summary>
	/// Save controls.
	/// </summary>
    public static void save()
    {
        // It is just an example. You may remove it or modify it if you want
        ReadOnlyCollection<KeyMapping> keys = InputControl.getKeysList();

        foreach(KeyMapping key in keys)
        {
            PlayerPrefs.SetString("Controls." + key.name + ".primary",   key.primaryInput.ToString());
            PlayerPrefs.SetString("Controls." + key.name + ".secondary", key.secondaryInput.ToString());
            PlayerPrefs.SetString("Controls." + key.name + ".third",     key.thirdInput.ToString());
        }

        PlayerPrefs.Save();
    }

	/// <summary>
	/// Load controls.
	/// </summary>
    public static void load()
    {
        // It is just an example. You may remove it or modify it if you want
        ReadOnlyCollection<KeyMapping> keys = InputControl.getKeysList();

        foreach(KeyMapping key in keys)
        {
            string inputStr;

            inputStr = PlayerPrefs.GetString("Controls." + key.name + ".primary");

            if (inputStr != "")
            {
                key.primaryInput = customInputFromString(inputStr);
            }

            inputStr = PlayerPrefs.GetString("Controls." + key.name + ".secondary");

            if (inputStr != "")
            {
                key.secondaryInput = customInputFromString(inputStr);
            }

            inputStr = PlayerPrefs.GetString("Controls." + key.name + ".third");

            if (inputStr != "")
            {
                key.thirdInput = customInputFromString(inputStr);
            }
        }
    }

	/// <summary>
	/// Converts string representation of CustomInput to CustomInput.
	/// </summary>
	/// <returns>CustomInput from string.</returns>
	/// <param name="value">String representation of CustomInput.</param>
    private static CustomInput customInputFromString(string value)
    {
        CustomInput res;

        res = JoystickInput.FromString(value);

        if (res != null)
        {
            return res;
        }

		res = MouseInput.FromString(value);
		
		if (res != null)
		{
			return res;
		}

		res = KeyboardInput.FromString(value);
		
		if (res != null)
		{
			return res;
		}

        return null;
    }
}

