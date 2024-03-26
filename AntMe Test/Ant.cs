using AntMeLib;
using Godot;

public partial class Ant : RigidBody3D, iAnt
{
	public Vector3 velocity = Vector3.Forward;
	float speed = 2.5f;
    float turnSpeed = 5f;

    public AmeiseBasis Sim;

    #region Controll Sim Ant

    public string AntName => Sim.AntName;

    public StatusEnum Status => Sim.Status;

    public void Move()
    {
        Sim.Move();
    }

    public void Turn(int degrees)
    {
        //Sim.Turn(degrees);
    }

    public void Stop()
    {
        Sim.Stop();
    }

    public void Wait()
    {
        Sim.Wait();
    }

    #endregion

    public override void _Ready()
    {
        Sim.Stop();
    }


    public override void _PhysicsProcess(double delta)
    {
        if (!Level.running)
            return;

        switch (Sim.Status)
        {
            case StatusEnum.MOVE:
                Vector3 direction = new Vector3(velocity.X, 0, velocity.Z).Normalized();
                Vector3 move = direction * (float)delta * speed;

                KinematicCollision3D coll = MoveAndCollide(move);
                if (coll != null)
                {
                    Node collider = (Node)coll.GetCollider();

                    if (GetTree().GetNodesInGroup("Walls").Contains(collider) || GetTree().GetNodesInGroup("Ants").Contains(collider))
                    {
                        if(collider is Ant)
                            GD.Print(string.Format("{0}: zusammenstoß mit {1}", AntName, ((collider) as Ant).AntName));
                        else
                            GD.Print(string.Format("{0}: zusammenstoß mit {1}", AntName, collider.Name)); 

                        velocity = velocity.Bounce(coll.GetNormal());

                        LookAt(Position - velocity.Normalized());
                    }
                }
                break;

            case StatusEnum.WAIT:
                Sim.Wait();
                break;

            case StatusEnum.TURN:
                break;
        }
    }

	
    private void MouseInput_InputEvent(Node camera, InputEvent @event, Vector3 position, Vector3 normal, long shapeIdx)
    {
		if (@event is InputEventMouseButton mButton)
		{
			if (mButton.Pressed)
			{
                if (mButton.ButtonIndex == MouseButton.Left)
                {

                    GD.Print("FLOOR");
                    Level.CameraCurrent = GetNode<Camera3D>("Camera3D");
                    Level.CameraCurrent.Current = true;
                }

                if (mButton.ButtonIndex == MouseButton.Right)
                {

                }
            }
		}
    }


}
