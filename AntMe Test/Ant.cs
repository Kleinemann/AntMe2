using AntMeLib;
using Godot;

public partial class Ant : RigidBody3D, iAnt
{
	public Vector3 velocity = Vector3.Forward;
	float speed = 2.5f;
    float _currentRunValue;
    float turnSpeed = 5f;

    public AmeiseBasis Sim;

    #region Controll Sim Ant

    public string AntName => Sim.AntName;

    public StatusEnum Status => Sim.Status;

    public float TurnTarget => Sim.TurnTarget;

    public void Move()
    {
        Sim.Move();
    }

    public void Turn(int degrees)
    {
        float globalR = Mathf.RadToDeg(GlobalTransform.Origin.Z);

        int deg = (int)globalR + degrees;

        if (deg < 0)
            deg += 360;
        if (deg > 360)
            deg -= 360;
        Sim.Turn(deg);
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
                float globalR = Mathf.RadToDeg(GlobalTransform.Origin.Z);

                float left = globalR - TurnTarget;
                if (left < 0) left += 360;

                float right = TurnTarget - globalR;
                if (right > 360) right -= 360;

                float turnStep = 0;

                if (left <= right)
                    turnStep = left > turnSpeed ? -turnSpeed : -left;
                else
                    turnStep = right > turnSpeed ? turnSpeed : right;


                float currentR = globalR + (float)(((double)turnStep) * delta);


                float turn = Mathf.DegToRad(currentR);

                RotateY(turn);
                velocity = GlobalTransform.Basis.Z.Normalized();

                if(turn > -0.00000000001 && turn < 0.0000000001)
                    Sim.Move();

                
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
                    Level.AntSelected = this;
                }

                if (mButton.ButtonIndex == MouseButton.Right)
                {
                    Turn(45);
                }
            }
		}
    }


}
