using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Module;

namespace TscCommProtocal.Utils
{
    public class CheckGBTUtil
    {
        public static Message CheckGBTProtocal(byte[] b, string fun)
        {
            Message m = new Message();
            if (b[0] == 0x86)
            {
                if (b[1] == 0x05)
                {
                    // MessageBox.Show(fun + ":国标通信协议错误类型中的其它错误原因！");
                    m.flag = false;
                    m.obj = "国标错误对象0x86-" + fun;
                    m.msg = "国标通信协议错误类型中的其它错误原因！";
                    return m;
                }
                else if (b[1] == 0x01)
                {
                    //MessageBox.Show(fun + ":国标通信协议错误类型中的消息长度太长！");
                    m.flag = false;
                    m.obj = "国标错误对象0x86-" + fun;
                    m.msg = "国标通信协议错误类型中的消息长度太长！";
                    return m;
                }
                else if (b[1] == 0x02)
                {
                    //MessageBox.Show(fun + ":国标通信协议错误类型中的消息类型错误！");
                    m.flag = false;
                    m.obj = "国标错误对象0x86-" + fun;
                    m.msg = "国标通信协议错误类型中的消息类型错误！";
                    return m;
                }
                else if (b[1] == 0x03)
                {
                    //MessageBox.Show(fun + ":国标通信协议错误类型中的消息设置对象值超出规定的范围！");
                    m.flag = false;
                    m.obj = "国标错误对象0x86-" + fun;
                    m.msg = "国标通信协议错误类型中的消息设置对象值超出规定的范围！";
                    return m;
                }
                else if (b[1] == 0x04)
                {
                    //MessageBox.Show(fun + ":国标通信协议错误类型中的消息长度太短！");
                    m.flag = false;
                    m.obj = "国标错误对象0x86-" + fun;
                    m.msg = "国标通信协议错误类型中的消息长度太短！";
                    return m;
                }
                else
                {
                    //MessageBox.Show(fun + ":未知原因！");
                    m.flag = false;
                    m.obj = "国标错误对象0x86-" + fun;
                    m.msg = "未知原因！";
                    return m;
                }
            }
            m.flag = true;

            return m;


        }
    }
}
