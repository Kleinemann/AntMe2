using AntMeLib;
using Godot;

public partial class Ant : RigidBody3D, iAnt
{
	public Vector3 velocity = Vector3.Forward;
	float speed = 2.5f;
    float turnSpeed = 1f;

    StatusEnum _status;


    public StatusEnum Status
    {
        get => _status;
        set => _status = value;
    }

    public void Move()
    {
        _status = StatusEnum.MOVE;
    }

    public void Stop()
    {
        _status = StatusEnum.WAIT;
    }

    public void Wait()
    {
        
    }

    public override void _Ready()
    {
        _status = StatusEnum.WAIT;
    }


    public override void _PhysicsProcess(double delta)
	{
        if (Status != StatusEnum.MOVE)
            return;

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
