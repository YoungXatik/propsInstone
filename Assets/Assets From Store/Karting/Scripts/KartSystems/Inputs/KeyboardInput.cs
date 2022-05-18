using UnityEngine;

namespace KartGame.KartSystems
{
    public class KeyboardInput : BaseInput
    {
        public string TurnInputName = "Horizontal";
        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";
        public FloatingJoystick joystick;
        public override InputData GenerateInput()
        {
            return new InputData
            {
                Accelerate = true,
                Brake = false,
                TurnInput = joystick.Horizontal
            };
        }
    }
}
