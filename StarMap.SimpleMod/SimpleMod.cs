using KSA;
using Brutal.ImGuiApi;
using StarMap.Types;
using Brutal.ImGuiApi.Extensions;
using System;
using Brutal.Numerics;
using Brutal.GlfwApi;

namespace StarMap.SimpleExampleMod
{
    public class SimpleMod : IStarMapMod
    {
        public bool ImmediateUnload => false;

        public void OnFullyLoaded()
        {
            Patcher.Patch();
            SimpleWindow.Create();

        }

        public void OnImmediatLoad()
        {
        }

        public void Unload()
        {
            Patcher.Unload();
        }
        internal class SimpleWindow : Popup
        {
            private float _width;
            private readonly IPopupWidget<SimpleWindow>[] _widgetMatrix;
            private readonly PopupToken[] _textList;

            private string _text = "Hello world!";

            public SimpleWindow()
            {
                this._widgetMatrix = new IPopupWidget<SimpleWindow>[]
                {
                Popup.PopupButtonOkay,
                };
                this._textList = StringTokenParser.Parse(this._text).ToArray();
            }

            public static SimpleWindow Create() { return new SimpleWindow(); }

            protected override void OnDrawUi()
            {
                ImGui.OpenPopup("SimpleMod", ImGuiPopupFlags.None);
                ImGui.BeginPopupModal("SimpleMod", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoSavedSettings | ImGuiWindowFlags.Popup | ImGuiWindowFlags.Modal);
                GlfwWindow window = Program.GetWindow();
                int2 size = window.Size;
                float2 @float = Brutal.Numerics.float2.Unpack(size, Unpack.Float.Cast);
                this._width = float.Clamp(@float.X * 0.85f, 600f * GameSettings.GetInterfaceScale(), 2048f * GameSettings.GetInterfaceScale());
                float2 float2 = new float2(this._width, -1f);
                ImGui.SetWindowSize(float2, ImGuiCond.None);
                ImGuiHelper.SetCurrentWindowToCenter(ImGuiCond.Always);
                PopupToken.Draw(this._textList);
                ImGui.Separator();
                Popup.DrawUi<SimpleWindow>(this, this._widgetMatrix);
                ImGui.EndPopup();
            }
        }
    }
}
