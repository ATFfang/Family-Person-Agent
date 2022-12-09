using System;
using System.Collections.Generic;
using System.Text;

namespace Agent_Based_ModelV0._1
{
    class StatusGraph
    {
        //状态图
        ////是否找对象
        public static bool GetMarriage(PersonAgent p)
        {
            if(p.spouse==null && p.Age>18)
            {
                System.Random r = new Random();
                if(r.NextDouble()<0.8)
                {
                    //状态往前一步
                    p.Condition++;
                    return true;
                }

                else{return false;}
            }

            else { return false; }
        }

        //是否结婚
        public static bool Marriaged(PersonAgent p)
        {
            System.Random r = new Random();
            if (r.NextDouble() < 0.6 && p.spouse == null)
            {
                //状态往前一步
                p.Condition++;
                return true;
            }

            else { return false; }
        }


        //// 生孩子概率
        private static double PGiveBirth(PersonAgent p)
        {
            if(p.children.Count<=2)
            {
                return 0.8-0.3*(p.children.Count);
            }

            else { return 0; }

        }


        //是否生孩子
        public static bool GiveBirth(PersonAgent p)
        {
            System.Random r = new Random();
            if(r.NextDouble() < PGiveBirth(p))
            {
                return true;
            }

            else { return false; }
        }

        //是否死亡
        public static bool Death(PersonAgent p)
        {
            System.Random r = new Random();
            if(p.Age>=80)
            {
                if(r.NextDouble()<=Convert.ToDouble(p.Age-80)/20)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
    }
}
