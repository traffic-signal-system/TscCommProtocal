﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TscCommProtocal.Module
{
    public class SpecFun
    {
        private byte _ucFunType;
        private byte _ucValue;
        public byte ucFunType
        {
            get { return _ucFunType; }
            set { _ucFunType = value; }
        }
        public byte ucValue
        {
            get { return _ucValue; }
            set { _ucValue = value; }
        }
    }
}
