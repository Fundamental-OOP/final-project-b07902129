using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Rules
{
    public class Rand : ARule
    {
        public float probability;
        private System.Random rand = new System.Random();
        private int bigNum;
        override public bool Satisfy()
        {
            return probability*bigNum > rand.Next(1,bigNum);
        }
    }
}
