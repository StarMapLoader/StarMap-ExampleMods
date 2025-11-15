using Brutal.ImGuiApi;
using StarMap.API;

namespace StarMap.SimpleExampleMod
{
    public class SimpleMod : IStarMapMod, IStarMapOnUi
    {
        public bool ImmediateUnload => false;

        public void OnAfterUi(double dt)
        {
            ImGuiWindowFlags flags = ImGuiWindowFlags.MenuBar;

            ImGui.Begin("MyWindow", flags);
            if (ImGui.BeginMenuBar())
            {
                if (ImGui.BeginMenu("SimpleMod"))
                {
                    if (ImGui.MenuItem("Show Message"))
                    {
                        Console.WriteLine("Hello from SimpleMod!");
                    }
                    ImGui.EndMenu();
                }
                ImGui.EndMenuBar();
            }
            ImGui.Text("Hello from SimpleMod!");
            ImGui.End();

            ImGui.Begin("MyWindow", flags);
            if (ImGui.BeginMenuBar())
            {
                if (ImGui.BeginMenu("SimpleMod 2"))
                {
                    if (ImGui.MenuItem("Show Message 2"))
                    {
                        Console.WriteLine("Hello from SimpleMod 2!");
                    }
                    ImGui.EndMenu();
                }
                ImGui.EndMenuBar();
            }
            ImGui.Text("Hello from SimpleMod 2!");
            ImGui.End();

            flags = ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoBackground | ImGuiWindowFlags.NoSavedSettings | ImGuiWindowFlags.MenuBar;

            ImGui.Begin((ImString)"Menu Bar", flags);
            if (ImGui.BeginMenuBar())
            {
                if (ImGui.BeginMenu((ImString)"SimpleMod 2"))
                {
                    if (ImGui.MenuItem("Show Message 2"))
                    {
                        Console.WriteLine("Hello from SimpleMod 2!");
                    }
                    ImGui.EndMenu();
                }
                ImGui.EndMenuBar();
            }
            ImGui.Text("Hello from SimpleMod 2!");
            ImGui.End();
        }

        public void OnBeforeUi(double dt)
        {
        }

        public void OnFullyLoaded()
        {
            Patcher.Patch();

        }

        public void OnImmediatLoad()
        {
        }

        public void Unload()
        {
            Patcher.Unload();
        }
    }
}
