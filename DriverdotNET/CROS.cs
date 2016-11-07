using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using String = Messages.std_msgs.String;
using Ros_CSharp;
using XmlRpc_Wrapper;
using Messages;
using System.Runtime.InteropServices;
namespace GxIAPINET.Sample.Common
{
    class CROS
    {
     
        Publisher<Messages.sensor_msgs.Image> imager;
        Publisher<Messages.sensor_msgs.Image> imagel;
        //Publisher<Messages.std_msgs.String> test;
    
        

        public bool isConnect = false;

        public delegate void onInitHandler(int time);
        public event onInitHandler OnInitProcess;

        public CROS(string host_name, string master_url)
        {
            if (OnInitProcess != null)
                OnInitProcess(0);
            ROS.ROS_HOSTNAME = host_name;
            ROS.ROS_MASTER_URI = master_url;
            if (OnInitProcess != null)
                OnInitProcess(20);
            ROS.Init(new string[0], "Windows_node");
            if (OnInitProcess != null)
                OnInitProcess(40);
        }
        public void init()
        {
            NodeHandle nh = new NodeHandle();
            if (OnInitProcess != null)
            OnInitProcess(60);        

            imagel = nh.advertise<Messages.sensor_msgs.Image>("/imagel", 1, true);
            imager = nh.advertise<Messages.sensor_msgs.Image>("/imager", 1, true);
            //test = nh.advertise<Messages.std_msgs.String>("/Top2Slam_name", 1, true);
            if (OnInitProcess != null)
                OnInitProcess(80);
        
            //pose_sub = nh.subscribe<Messages.geometry_msgs.Point>("/Slam2Top_pos", 1, pos_subCallback, true);
         
            isConnect = true;
            if (OnInitProcess != null)
               OnInitProcess(100);
            
        }
        public void uninit()
        {
            ROS.shutdown();
            ROS.waitForShutdown();
            
            isConnect = false;
        }

        public void PubMapImg(Bitmap srcl, Bitmap srcr)
        {
            Messages.sensor_msgs.Image dstl,dstr;
            ConvertBitmapToMat(srcl, out dstl);
            ConvertBitmapToMat(srcr, out dstr);
            imagel.publish(dstl);
            imager.publish(dstr);
        }
        public void PubMapImgR(Bitmap src)
        {
            Messages.sensor_msgs.Image dst=new Messages.sensor_msgs.Image();
            //ConvertBitmapToMat(src, out dst);   
            //imager.publish(dst);
        }
        public void PubMapImgL(Bitmap src)
        {
            Messages.sensor_msgs.Image dst = new Messages.sensor_msgs.Image();
            ConvertBitmapToMat(src, out dst);      
            imagel.publish(dst);

        }
           
        int ConvertBitmapToMat(System.Drawing.Bitmap bmpImg, out Messages.sensor_msgs.Image Img)  
        {  
            int retVal = 0;

            Img = new Messages.sensor_msgs.Image();

            if(bmpImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)  // 灰度图像  
            {

                //锁定Bitmap数据  
                System.Drawing.Imaging.BitmapData bmpData = bmpImg.LockBits(
                    new System.Drawing.Rectangle(0, 0, bmpImg.Width, bmpImg.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadWrite, bmpImg.PixelFormat);
 

                Byte[] data = new Byte[bmpData.Stride * bmpData.Height];
                Marshal.Copy(bmpData.Scan0, data, 0, bmpData.Stride * bmpData.Height);
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = (byte)(data[i]);
                }
			    Img.height = Convert.ToUInt32(bmpData.Height);
                Img.width = Convert.ToUInt32(bmpData.Width);
                Img.step = Convert.ToUInt32(bmpData.Stride);
			    Img.encoding = "mono8";
                Img.data = data;
                bmpImg.UnlockBits(bmpData); 
            }  
            else
            {
                Bitmap b = bmpImg;
                System.Drawing.Imaging.BitmapData bmpData = b.LockBits(
                  new System.Drawing.Rectangle(0, 0, b.Width, b.Height),
                  System.Drawing.Imaging.ImageLockMode.ReadWrite, b.PixelFormat);
                Byte[] data = new Byte[bmpData.Stride * bmpData.Height];
                Marshal.Copy(bmpData.Scan0, data, 0, bmpData.Stride * bmpData.Height);
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = (byte)(data[i]);
                }
                Img.height = Convert.ToUInt32(b.Height);
                Img.width = Convert.ToUInt32(b.Width);
                Img.step = Convert.ToUInt32(bmpData.Stride);
                Img.encoding = "bgr8";
                Img.data = data;
                b.UnlockBits(bmpData); 
            }
            //解锁Bitmap数据                        
            return (retVal);  
        }  
      
    }

}

