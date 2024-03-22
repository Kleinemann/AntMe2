using AntMeLib;
using Godot;
using System;
using System.Collections.Generic;
using System.Reflection;

public partial class Level : Node3D
{
	public static Camera3D CameraCurrent;
	Camera3D CameraDefault;
	public static bool running = true;

    List<Type> Kolonies = new List<Type>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CameraDefault = GetViewport().GetCamera3D();

        LadeKolonieen();

        NewAnt(new Vector3());
    }

    void LadeKolonieen()
    {
        Kolonies.Clear();

        var ass = new AssemblyName("AntMeKolonie");
        Assembly assembly = Assembly.Load(ass);
        Type[] types = assembly.GetExportedTypes();

        foreach (Type t in types)
        {
            if (t.BaseType.Name == "AmeiseBasis")
            {
                Kolonies.Add(t);
            }
        }

        GD.Print(ass);
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_select"))
        {
            running = !running;
        }
    }


    public void _on_static_body_3d_floor_input_event(Node camera, InputEvent @event, Vector3 position, Vector3 normal, long shapeIdx)
    {
        if (@event is InputEventMouseButton mButton)
        {
            if (mButton.Pressed)
            {
				if (!CameraDefault.Current)
					CameraDefault.Current = true;
				else
					NewAnt(position);
            }
        }
	}

	public void NewAnt(Vector3 position)
	{
        PackedScene szene = GD.Load<PackedScene>("res://ant.tscn");
		Ant a = szene.Instantiate<Ant>();
        a.Sim = (AmeiseBasis)Activator.CreateInstance(Kolonies[0]);

        float ranX = GD.Randf() - 0.5F;
        float ranZ = GD.Randf() - 0.5F;
        a.velocity = new Vector3(ranX, 0, ranZ).Normalized();

		a.Position = position;
        AddChild(a);

        a.LookAt(a.Position - a.velocity);
    }
}
