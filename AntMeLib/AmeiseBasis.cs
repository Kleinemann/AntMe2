using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntMeLib
{
    public abstract class AmeiseBasis : iAnt
    {
        StatusEnum _status = StatusEnum.WAIT;

        public StatusEnum Status => _status;

        public void Move()
        {
            _status = StatusEnum.MOVE;
        }

        public void Stop()
        {
            _status = StatusEnum.WAIT;
        }

        public virtual void Wait()
        {
            
        }
    }
}
