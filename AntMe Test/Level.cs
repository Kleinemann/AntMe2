using AntMeLib;
using Godot;
using System;

public partial class Level : Node3D
{
	public static Camera3D CameraCurrent;
	Camera3D CameraDefault;
	bool running = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CameraDefault = GetViewport().GetCamera3D();			
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_select"))
        {
            running = !running;

            foreach (var a in GetTree().GetNodesInGroup("Ants"))
            {
                Ant ant = a as Ant;
                if (running)
                    ant.Move();
                else
                    ant.Stop();
            }
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

		float ranX = GD.Randf() - 0.5F;
        float ranZ = GD.Randf() - 0.5F;
        a.velocity = new Vector3(ranX, 0, ranZ).Normalized();

		a.Position = position;
        AddChild(a);

        a.LookAt(a.Position - a.velocity);

        if(running)
            a.Move();
    }
}
