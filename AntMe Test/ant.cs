using Godot;
using System;
using System.Diagnostics;

public partial class ant : CharacterBody3D
{
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		//if (Input.IsActionPressed("ui_up"))
			//Velocity.Z = 1;

		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		/*
		KinematicCollision3D coll = MoveAndCollide(velocity * Speed * (float)delta);
		if(coll != null)
		{
			Debug.WriteLine("KJDASKFLDSLFJLFJSLKF");
		}
		*/
		
		
		if (MoveAndSlide())
		{
			KinematicCollision3D coll = GetLastSlideCollision();

			StaticBody3D obj = coll.GetCollider() as StaticBody3D;
			Node3D n = obj as Node3D;
			Node3D p = n.GetParent() as Node3D;
			if (p.Name == "Floor")
				return;

			/*
			Vector3 cV3 = coll.GetNormal();


            Vector3 v3 = Velocity.Bounce(n.Rotation);
			float angle = coll.GetAngle();// velocity.AngleTo(v3);
			*/
			Rotation = Rotation - obj.Rotation;
            //Rotate(Vector3.Up, coll.GetAngle());
            //Rotate(Vector3.Up, Velocity.AngleTo(v3));

			
			Debug.WriteLine(p.Name);
		}

    }
}
