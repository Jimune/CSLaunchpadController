using System;
using Midi;
using Launchpad.Utils;
using Launchpad.Pages.Actions;
using Launchpad.Pages;

namespace Launchpad.LaunchHandler {

    public class MidiMessageHandler {

        public LaunchEventHandler LaunchEventHandler { get; private set; }
        
        private static MidiMessageHandler instance;
        private InputDevice input;
        private OutputDevice output;

        private MidiMessageHandler() { }

        public static MidiMessageHandler Instance() {
            if (instance == null)
                instance = new MidiMessageHandler();

            return instance;
        }

        public void Init(InputDevice input, OutputDevice output) {
            this.input = input;
            this.output = output;
            this.LaunchEventHandler = LaunchEventHandler.Instance();

            LaunchEventHandler.LaunchEvents += new LaunchEventHandler.KeyPressedHandler(this.KeyPressedEvent);
            input.ControlChange += new InputDevice.ControlChangeHandler(this.ControlChange);
            input.NoteOn += new InputDevice.NoteOnHandler(this.NoteOnHandler);
            input.NoteOff += new InputDevice.NoteOffHandler(this.NoteOffHandler);
        }

        private void KeyPressedEvent(LaunchEvent launchEvent) {
            LaunchAction action = LaunchPageHandler.Instance().CurPage.GetAction(launchEvent.Key);

            if (action != null) {
                if (launchEvent.IsPressed())
                    action.Press();
                else
                    action.Release();
            }
        }

        private void ControlChange(ControlChangeMessage msg) {
            this.LaunchEventHandler.CallEvent(new LaunchEvent((int)msg.Control, msg.Value == 127 ? KeyState.Pressed : KeyState.Released));
            Console.WriteLine("Got Control message; C: {0} | V: {1} | C: {2}", msg.Channel, msg.Value, msg.Control);
        }

        private void NoteOnHandler(NoteOnMessage msg) {
            this.LaunchEventHandler.CallEvent(new LaunchEvent((int)msg.Pitch, msg.Velocity == 127 ? KeyState.Pressed : KeyState.Released));
            Console.WriteLine("Got Note message; C: {0} | P: {1} | V: {2}", msg.Channel, (int)msg.Pitch, msg.Velocity);
        }

        private void NoteOffHandler(NoteOffMessage msg) {
            this.LaunchEventHandler.CallEvent(new LaunchEvent((int)msg.Pitch, msg.Velocity == 127 ? KeyState.Pressed : KeyState.Released));
            Console.WriteLine("Got Note message; C: {0} | P: {1} | V: {2}", msg.Channel, (int)msg.Pitch, msg.Velocity);
        }

        public void SendMessage(int key, int color) {
            if (output != null)
                output.SendNoteOn(Channel.Channel1, (Pitch)key, color);
            else
                Log.Severe("Output connection was not made but a message was attempted to send!");
        }

        public void ClearPad() {
            if (output != null)
                output.SendControlChange(Channel.Channel1, 0, 0);
            else
                Log.Severe("Output connection was not made but a message was attempted to send!");
        }
    }
}
