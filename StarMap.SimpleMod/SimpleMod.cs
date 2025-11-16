using Brutal.ImGuiApi;
using KSA;
using StarMap.API;

namespace StarMap.SimpleExampleMod
{
    [StarMapMod]
    public class SimpleMod
    {
        [StarMapAfterGui]
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

        [StarMapImmediateLoad]
        public void OnImmediateLoad(Mod mod)
        {
            Console.WriteLine("SimpleMod - On immediate loaded");

        }

        [StarMapAllModsLoaded]
        public void OnFullyLoaded()
        {
            Console.WriteLine("SimpleMod - On fully loaded");
            Patcher.Patch();

        }

        [StarMapUnload]
        public void Unload()
        {
            Console.WriteLine("SimpleMod - Unload");
            Patcher.Unload();
        }
    }
}
