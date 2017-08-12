using System;
using System.Windows.Forms;
using Midi;
using Launchpad.LaunchHandler;
using Launchpad.Pages;
using System.Diagnostics;
using Launchpad.Utils;

namespace Launchpad {

    public class LaunchpadController {

        public static LaunchpadController Instance { get; set; }
        public LaunchScreen Screen { get; private set; }
        public OutputDevice Output { get; private set; }
        public InputDevice Input { get; private set; }

        public LaunchpadController() {
            Instance = this;
            InitScreen();
            FindPad();

            if (Output == null || Input == null) {
                MessageBox.Show("Unable to find MIDI input or MIDI output!", "Error", MessageBoxButtons.OK);
                return;
                
            }

            Log.Info("Located input and output of Launchpad MIDI");

            if (OpenConnection()) {
                MidiMessageHandler.Instance().Init(Input, Output);
                LaunchPageHandler.Instance().CreatePages();
            }

            Application.Run(Screen);
        }

        private void InitScreen() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Screen = new LaunchScreen();
        }

        private void FindPad() {
            for (int i = 0; i < OutputDevice.InstalledDevices.Count; ++i) {
                if (OutputDevice.InstalledDevices[i].Name.Equals("Launchpad S")) {
                    Output = OutputDevice.InstalledDevices[i];
                    break;
                }
            }

            for (int i = 0; i < InputDevice.InstalledDevices.Count; ++i) {
                if (InputDevice.InstalledDevices[i].Name.Equals("Launchpad S")) {
                    Input = InputDevice.InstalledDevices[i];
                    break;
                }
            }
        }

        public bool OpenConnection() {
            bool success = true;

            try {
                if (Input != null) {
                    Input.Open();
                    Input.StartReceiving(null);
                } else {
                    Console.WriteLine("Input is null");
                    Log.Severe("Input location of Midi device was not found!");
                    success = false;
                }

                if (Output != null && !success) {
                    Output.Open();
                } else {
                    Console.WriteLine("Output is null");
                    Log.Severe("Output location of Midi device was not found!");
                }
            } catch (Midi.DeviceException mde) {
                Console.Write(mde.ToString());
                Log.Severe("Unable to open connection to Midi device; Device already in use!");
                success = false;
            }

            return success;
        }

        public void CloseConnection(bool shutdown) {
            if (Input != null) {
                Input.Close();
                Input.StopReceiving();

                if (shutdown)
                    Input.RemoveAllEventHandlers();
            }

            if (Output != null) {
                Output.Close();
            }
        }

        public void Kill() {
            LaunchUtils.ResetPad();
            Process.GetCurrentProcess().Kill();
        }
    }
}
