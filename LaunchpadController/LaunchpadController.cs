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

            Screen.TextView.AppendText("Located input and output of Launchpad MIDI\n");
            OpenConnection();
            MidiMessageHandler.Instance().Init(Input, Output);
            LaunchPageHandler.Instance().CreatePages();
            MidiMessageHandler.Instance().LaunchEventHandler.LaunchEvents += this.KeyPressedEvent;

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

        public void OpenConnection() {
            if (Input != null) {
                Input.Open();
                Input.StartReceiving(null);
            } else {
                Console.WriteLine("Input is null");
            }

            if (Output != null) {
                Output.Open();
            } else {
                Console.WriteLine("Output is null");
            }
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

        public void KeyPressedEvent(LaunchEvent launchEvent) {
            LaunchAction action = LaunchPageHandler.Instance().CurPage.GetAction(launchEvent.Key);

            if (action != null) {
                if (launchEvent.IsPressed())
                    action.Press();
                else
                    action.Release();
            }
        }

        public void Kill() {
            LaunchUtils.ResetPad();
            Process.GetCurrentProcess().Kill();
        }
    }
}
