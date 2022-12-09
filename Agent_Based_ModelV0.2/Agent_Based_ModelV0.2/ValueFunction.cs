using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Agent_Based_ModelV0._1
{
    class ValueFunction
    {
        //智能体赋值函数
        public static PersonAgent GetPersonValue(PersonAgent p,int loaction,int age,int gender,int number)
        {
            //函数体：
            System.Random r = new Random();
            p.Age = age;
            p.Gender = gender;
            p.Location = loaction;
            p.Number = number;
            p.spouse = null;
            p.father = null;
            p.mother = null;
            p.children = new ArrayList();
            p.Condition = 0;
            return p;
        }

        public static PersonAgent GetRandomPersonValue(PersonAgent p, int loaction)
        {
            //函数体：
            System.Random r = new Random();
            p.Age = 0;
            p.Gender = r.Next(0, 2);
            p.Location = loaction;
            p.spouse = null;
            p.father = null;
            p.mother = null;
            p.children = new ArrayList();
            p.Condition = 0;
            return p;
        }

    }
}
