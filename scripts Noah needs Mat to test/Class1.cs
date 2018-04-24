using System;

public class Class1
{
    void rotateTowardsPlayer()
    {
        //put your code here
    }
    void BlockA()
    {
        //referece to flowchart
    }
    
    //copy from here--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+-
    private Rigidbody AIship = new Rigidbody();
    private GameObject CurrentBullet;
    private Vector3 relative_transform_to_gun;

    void Start()
    {
        AIship = GetComponent<Rigidbody>();
        BlockA();
    }
	void FixedUpdate()
	{
        rotateTowardsPlayer();
        FireGun();

	}

    void fireGun()
    {
        for (int y = -60; y > 61; y += 10)
            for(int x = -60 + Math.Abs(y);x>61-Math.Abs(y);x+=10) //This should form a nice pattern, needs testing. Not done writing this yet though.
            {
                CurrentBullet = Instantiate(bullet, new Vector3(AIship.position/*add relative_transform_to_gun here*/), Quaternion.identity/*Need to find a way to specify a 10deg relative rotation with quaternions...that may be tricky*/);
                CurrentBullet.AddComponent(/*Script that tells object to move relative-forward. Or relative-right if K. makes it. Also script should add rigidbody with tag so player hit detection will work.*/);
                //either add rigidbody by movement script or add it here. Whichever is easier.
            }
    }
}//copy to here--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
