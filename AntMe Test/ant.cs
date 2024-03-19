using Godot;
using System;
using System.Diagnostics;
using System.Linq;

public partial class ant : RigidBody3D
{
	Vector3 velocity = Vector3.Forward;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector3 move = new Vector3(velocity.X * (float)delta, velocity.Y, velocity.Z * (float)delta);
		move *= 2;
		KinematicCollision3D coll = MoveAndCollide(move);
		if (coll != null)
		{
			Node collider = (Node)coll.GetCollider();
            if (GetTree().GetNodesInGroup("Walls").Contains(collider))
			{
                GD.Print("I collided with ", collider.Name);
				velocity = velocity.Bounce(coll.GetNormal());

				LookAt(GlobalTransform.Origin + velocity + Vector3.Up);
            }
        }

    }


    public override void _Ready()
    {
        base._Ready();
    }

	
    private void MouseInput_InputEvent(Node camera, InputEvent @event, Vector3 position, Vector3 normal, long shapeIdx)
    {
		if (@event is InputEventMouseButton mButton)
		{
			if (mButton.Pressed)
			{
				level.CameraCurrent = GetNode<Camera3D>("Camera3D");
				level.CameraCurrent.Current = true;
            }
		}
    }
	
}
