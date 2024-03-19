using Godot;
using System;
using System.Diagnostics;

public partial class ant : RigidBody3D
{
	//CollisionObject3D MouseInput;

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
			if (((Node)coll.GetCollider()).Name == "Wall")
			{
				GD.Print("I collided with ", ((Node)coll.GetCollider()).Name);
				velocity = velocity.Bounce(coll.GetNormal());
				//LookAt(GlobalTransform.Origin + velocity + Vector3.Up);
				//RotateY((float)Math.Atan2(velocity.X, velocity.Z));
            }
        }

    }


    public override void _Ready()
    {
        base._Ready();
        //MouseInput.InputEvent += MouseInput_InputEvent;
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
