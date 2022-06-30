using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    partial class Vehicle
    {
        public float Speed { get; set; }
        public abstract void Move();
        public abstract void Stop();
    }
}
