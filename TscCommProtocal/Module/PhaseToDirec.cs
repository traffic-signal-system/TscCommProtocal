using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TscCommProtocal.Module
{
    public class PhaseToDirec
    {
        private byte _ucId;
        private byte _ucPhase;
        private byte _ucOverlapPhase;
        private byte _ucRoadCnt;

        public byte ucId
        {
            get { return _ucId; }
            set { _ucId = value; }
        }
        public byte ucPhase
        {
            get { return _ucPhase; }
            set { _ucPhase = value; }
        }
        public byte ucOverlapPhase
        {
            get { return _ucOverlapPhase; }
            set { _ucOverlapPhase = value; }
        }
        public byte ucRoadCnt
        {
            get { return _ucRoadCnt; }
            set { _ucRoadCnt = value; }
        }
    }
}
