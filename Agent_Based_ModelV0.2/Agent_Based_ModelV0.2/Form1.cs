using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Agent_Based_ModelV0._1
{
    public partial class Run01 : Form
    {
        public Run01()
        {
            InitializeComponent();
        }

        //人的集合：PersonList，以储存系统中所有个人智能体
        public Dictionary<int, PersonAgent> PersonDic = new Dictionary<int, PersonAgent>();
        //家庭的集合：以户主为主键，储存一个村子里面所有的家庭
        public Dictionary<PersonAgent, FamilyAgent> FamilyDic = new Dictionary<PersonAgent, FamilyAgent>();
        //人的集合：创建想要结婚的人的集合，从该集合中寻找结婚的人。
        public ArrayList Person_to_marrayList = new ArrayList();
        //人口总数
        public Dictionary<int, int> Population = new Dictionary<int, int>();
        //家庭总数
        public Dictionary<int, int> Familynumber = new Dictionary<int, int>();

        //构建人智能体
        private void Get01_Click(object sender, EventArgs e)
        {

            if(textBoxGet01.Text!="")
            {

                int location = 215600;

                int SimulationPersonNum = Convert.ToInt32(textBoxGet01.Text);

                string value = string.Format($"{Application.StartupPath}\\data\\{"personvalue.csv"}");
                StreamReader sr0 = new StreamReader(value);
                string line0 = sr0.ReadLine();
                string[] strs0 = null;

                int i = 0;
                while ((line0 = sr0.ReadLine()) != null)
                {
                    strs0 = line0.Split(',');
                    int age = Convert.ToInt32(strs0[1]);
                    int gender = Convert.ToInt32(strs0[2]);
                    int number = Convert.ToInt32(strs0[0]);
                    PersonAgent person = new PersonAgent();
                    PersonAgent personV = ValueFunction.GetPersonValue(person, location,age,gender,number);
                    PersonDic[i] = person;
                    i++;
                }

                //读入户口数据,户口数据内容为：户主+配偶+孩子*n
                string account = string.Format($"{Application.StartupPath}\\data\\{"account.csv"}");
                StreamReader sr = new StreamReader(account);
                string line = sr.ReadLine();
                string[] strs = null;
                while ((line = sr.ReadLine()) != null)
                {
                    strs = line.Split(',');
                    int thisPerson = Convert.ToInt32(strs[0]);

                    //为户主添加配偶
                    if(strs[1]!="")
                    {
                        PersonDic[thisPerson].spouse = PersonDic[Convert.ToInt32(strs[1])];
                        //为户主的配偶添加配偶
                        PersonDic[thisPerson].spouse.spouse = PersonDic[thisPerson];
                        //为户主与配偶添加他们的孩子
                        for (int personnumber = 2; personnumber < strs.Count(); personnumber++)
                        {
                            if (strs[personnumber] != "")
                            {
                                PersonDic[thisPerson].children.Add(PersonDic[Convert.ToInt32(strs[personnumber])]);
                                PersonDic[thisPerson].spouse.children.Add(PersonDic[Convert.ToInt32(strs[personnumber])]);
                                PersonDic[Convert.ToInt32(strs[personnumber])].father = PersonDic[thisPerson];
                                PersonDic[Convert.ToInt32(strs[personnumber])].mother = PersonDic[thisPerson].spouse;
                            }
                        }
                    }

                    //以户主为主键，家人为值，构建家庭智能体，存入家庭集合（一个村子）中
                    ////找到户主
                    PersonAgent thisPersonAgent = PersonDic[thisPerson];

                    //添加家庭成员,并添加人数
                    FamilyDic[thisPersonAgent]=new FamilyAgent();

                    ////户主
                    FamilyDic[thisPersonAgent].familymember = new ArrayList();
                    FamilyDic[thisPersonAgent].familymember.Add(thisPersonAgent);
                    //FamilyDic[thisPersonAgent].familynumber = 1;
                    ////孩子
                    FamilyDic[thisPersonAgent].familymember.AddRange(thisPersonAgent.children);
                    //FamilyDic[thisPersonAgent].familynumber += thisPersonAgent.children.Count ;
                    ////配偶
                    FamilyDic[thisPersonAgent].familymember.Add(thisPersonAgent.spouse);
                    //if(thisPersonAgent.spouse!=null)
                    //{
                    //    FamilyDic[thisPersonAgent].familynumber += 1;
                    //}
                }
            }
            else
            {
                MessageBox.Show("请输入人数");
            }
        }

        //进行迭代运行，模拟时间变化
        private void button1_Click(object sender, EventArgs e)
        {
            if(Iterations.Text=="")
            {
                MessageBox.Show("输入迭代次数");
            }
            else
            {
                int PopulationTime = 0;

                int interations = Convert.ToInt32(Iterations.Text);
                for(int time=0;time<interations;time++)
                {
                    PopulationTime = time;

                    //新生的孩子
                    Dictionary<int, PersonAgent> NewPersonDic = new Dictionary<int, PersonAgent>();
                    //将死之人
                    ArrayList DeathPerson = new ArrayList();
                    

                    //遍历每个个体，年龄++，根据其Condition判断他所要做的事情
                    foreach (KeyValuePair<int,PersonAgent> pdic in PersonDic)
                    {
                        //PersonAgent p = pdic.Value;
                        pdic.Value.Age++;

                        //看每个人死不死
                        if(StatusGraph.Death(pdic.Value))
                        {
                            DeathPerson.Add(pdic.Key);
                        }

                        //如果有配偶，则转到状态2
                        if (pdic.Value.spouse!=null)
                        {
                            pdic.Value.Condition = 2;
                        }

                        //是否行为的参数
                        bool IFReadymarriage = false;

                        switch (pdic.Value.Condition)
                        {

                            //当位置为0时，考虑是否准备结婚
                            case 0: 
                                { 
                                    IFReadymarriage = StatusGraph.GetMarriage(pdic.Value);
                                    if (IFReadymarriage)
                                    {
                                        //加入要结婚的人的集合中
                                        Person_to_marrayList.Add(pdic.Value);
                                    }
                                    break;
                                }

                            //当位置为1时，考虑是否要完成结婚
                            case 1:
                                {
                                    bool IFGetMarried = false;

                                    foreach(PersonAgent pSpouse in Person_to_marrayList)
                                    {
                                        if(pSpouse!= pdic.Value && pSpouse.Gender!= pdic.Value.Gender && pSpouse.spouse==null)
                                        {
                                            if(StatusGraph.Marriaged(pdic.Value))
                                            {
                                                //确定伴侣关系
                                                pdic.Value.spouse = pSpouse;
                                                pSpouse.spouse = pdic.Value;

                                                pdic.Value.Condition++;
                                                pdic.Value.spouse.Condition++;
                                                IFGetMarried = true;

                                                //调试
                                                

                                                break;                                               
                                            }
                                        }
                                    }

                                    if(IFGetMarried)
                                    {
                                        //从婚恋市场中移除
                                        Person_to_marrayList.Remove(pdic.Value);
                                        

                                        //从原有的家庭中移除

                                        ////记录p的户主
                                        PersonAgent pHouseHold = new PersonAgent();
                                        ////记录p.spouse的户主
                                        PersonAgent pSpouseHouseHold = new PersonAgent();

                                        foreach (KeyValuePair<PersonAgent,FamilyAgent> kvl in FamilyDic)
                                        {
                                            if(kvl.Value.familymember.Contains(pdic.Value))
                                            {
                                                pHouseHold = kvl.Key;
                                                //MessageBox.Show("1");
                                            }

                                            if (kvl.Value.familymember.Contains(pdic.Value.spouse))
                                            {
                                                pSpouseHouseHold = kvl.Key;
                                                //MessageBox.Show("2");

                                            }
                                        }


                                        FamilyDic[pHouseHold].familymember.Remove(pdic.Value);
                                        if(pdic.Value.spouse!=null)
                                        {
                                            FamilyDic[pSpouseHouseHold].familymember.Remove(pdic.Value.spouse);
                                        }
                                        

                                        //组件新的家庭
                                        FamilyDic[pdic.Value] = new FamilyAgent();
                                        FamilyDic[pdic.Value].familymember = new ArrayList();
                                        FamilyDic[pdic.Value].familymember.Add(pdic.Value);
                                        FamilyDic[pdic.Value].familymember.Add(pdic.Value.spouse);
                                        FamilyDic[pdic.Value].familynumber = 2;

                                    }

                                    break;
                                }
                            //当位置为2时，考虑要不要生孩子
                            case 2:
                                {
                                    
                                    List<PersonAgent> households = new List<PersonAgent>(FamilyDic.Keys);

                                    if(StatusGraph.GiveBirth(pdic.Value) &&households.Contains(pdic.Value))
                                    {
                                        //新建一个人智能体：孩子
                                        PersonAgent child = new PersonAgent();
                                        //MessageBox.Show("生了");

                                        ValueFunction.GetRandomPersonValue(child, 215600);
                                        child.Age = 0;
                                        child.father = pdic.Value;
                                        child.mother = pdic.Value.spouse;


                                        //父母和child建立联系
                                        pdic.Value.children.Add(child);
                                        pdic.Value.spouse.children.Add(child);

                                        //child加入new person
                                        int number=PersonDic.Last().Key+1;
                                        NewPersonDic[number] = child;

                                        //child加入family
                                        FamilyDic[pdic.Value].familymember.Add(child);

                                    }
                                    
                                    break;
                                }
                           
                        }  

                    }

                    //将新生儿加入人口集合
                    PersonDic = PersonDic.Union(NewPersonDic).ToDictionary(kv => kv.Key, kv => kv.Value);

                    //将死亡人口从人口集合中移除
                    foreach(int Dkey in DeathPerson)
                    {
                        PersonDic.Remove(Dkey);
                    }

                    //总人口
                    Population[PopulationTime] = PersonDic.Count();
                    //总家庭数
                    Familynumber[PopulationTime] = FamilyDic.Count();
                }
            }

        }

        private void GetValue_Click(object sender, EventArgs e)
        {
            //chart1.Series[0] = null;
            //MessageBox.Show(PersonDic.Count().ToString());
            foreach(KeyValuePair<int,int> kvl in Population)
            {
                chart1.Series[0].Points.AddXY(kvl.Key, kvl.Value); 
            }

            Series ss1 = new Series();
            foreach (KeyValuePair<int, int> kvl in Familynumber)
            {
                ss1.Points.AddXY(kvl.Key, kvl.Value);
            }
            chart1.Series[0].ChartType = SeriesChartType.Line;

            chart1.Series[0].LegendText = "Popluation";
            
            chart1.Series.Add(ss1);
            
            chart1.Series[1].ChartType = SeriesChartType.Line;

            chart1.Series[1].LegendText = "Familynumber";

            chart1.Show();
        }
    }
}
