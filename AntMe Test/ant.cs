using Godot;

public partial class Ant : RigidBody3D
{
	public Vector3 velocity = Vector3.Forward;
	float speed = 2.5f;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	//public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector3 direction = new Vector3(velocity.X, 0, velocity.Z).Normalized();
        Vector3 move = direction * (float)delta * speed;

        KinematicCollision3D coll = MoveAndCollide(move);
		if (coll != null)
		{
			Node collider = (Node)coll.GetCollider();

            if (GetTree().GetNodesInGroup("Walls").Contains(collider) || GetTree().GetNodesInGroup("Ants").Contains(collider))
			{
                GD.Print("I collided with ", collider.Name);
				velocity = velocity.Bounce(coll.GetNormal());

                LookAt(Position - velocity.Normalized());
            }
        }
    }

	
    private void MouseInput_InputEvent(Node camera, InputEvent @event, Vector3 position, Vector3 normal, long shapeIdx)
    {
		if (@event is InputEventMouseButton mButton)
		{
			if (mButton.Pressed)
			{
				GD.Print("FLOOR");
				Level.CameraCurrent = GetNode<Camera3D>("Camera3D");
				Level.CameraCurrent.Current = true;
            }
		}
    }
	
}
