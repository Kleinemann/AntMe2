namespace AntMeLib
{
    public enum StatusEnum
    {
        WAIT, MOVE, TURN
    };

    public interface iAnt
    {
        public string AntName
        {        
            get; 
        }

        public StatusEnum Status
        {
            get;
        }

        public void Turn(int degrees);

        public void Wait();
        public void Stop();
        public void Move();
    }
}