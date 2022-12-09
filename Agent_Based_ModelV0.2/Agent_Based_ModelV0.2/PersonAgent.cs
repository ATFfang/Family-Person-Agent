using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Agent_Based_ModelV0._1
{
    public class PersonAgent
    {
        /// <summary>
        /// 个人智能体的基础属性：年龄，性别，配偶，父母，孩子
        /// </summary>
        public int Age { get; set; }
        public int Gender { get; set; }
        public int Location { get; set; }
        public int Number { get; set; }

        public PersonAgent spouse,father,mother;
        public ArrayList children;

        //用于状态图的位置指针
        public int Condition { get; set; }
    }
}
