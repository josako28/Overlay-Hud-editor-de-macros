using System;

namespace GamepadHudFullV2.VirtualGamepad
{
    /// <summary>
    /// Gestiona el ciclo de vida del mando virtual.
    /// No interfiere con el resto del sistema.
    /// </summary>
    public static class VirtualGamepadManager
    {
        private static VirtualXbox360Gamepad _pad;
        private static bool _initialized;

        public static void Initialize()
        {
            if (_initialized)
                return;

            _pad = new VirtualXbox360Gamepad();
            _pad.Connect();   // 🔥 AQUÍ se crea el mando virtual REAL

            _initialized = true;
        }

        public static void Shutdown()
        {
            if (!_initialized)
                return;

            _pad.Disconnect();
            _pad = null;
            _initialized = false;
        }

        // (Más adelante se usará esto)
        public static void Press(string token) => _pad?.Press(token);
        public static void Release(string token) => _pad?.Release(token);
        public static void Reset() => _pad?.Reset();
    }
}
