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

    void Start()
    {
        AIship = GetComponent<Rigidbody>();
        BlockA();
    }
	void FixedUpdate()
	{

	}
}//copy to here--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
