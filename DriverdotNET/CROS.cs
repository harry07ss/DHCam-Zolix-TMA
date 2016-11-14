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
using System.Drawing.Drawing2D;

namespace DriverdotNET
{
    class CROS
    {
     
        Publisher<Messages.sensor_msgs.Image> imager;
        Publisher<Messages.sensor_msgs.Image> imagel;
        Publisher<Messages.cham_msgs.ChamInfo> chaminfo;
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
            chaminfo = nh.advertise<Messages.cham_msgs.ChamInfo>("/chaminfo", 1, true);

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
            ConvertBitmapToMat(src, out dst);
            imager.publish(dst);
        }

        public void PubChamInfo(CTMA500 tma)
        {
            Messages.cham_msgs.ChamInfo msg = new Messages.cham_msgs.ChamInfo();
            tma.__update();
            msg.xl = tma.PD[1];
            msg.xr = tma.PD[0];
            msg.yl = tma.PD[3];
            msg.yr = tma.PD[2];          
            chaminfo.publish(msg);
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
                Bitmap b1= KiResizeImage(bmpImg, bmpImg.Width / 3, bmpImg.Height / 3, 0);
                Bitmap b = RGB2Gray(b1);
                System.Drawing.Imaging.BitmapData bmpData = b.LockBits(
                  new System.Drawing.Rectangle(0, 0, b.Width, b.Height),
                  System.Drawing.Imaging.ImageLockMode.ReadWrite, b.PixelFormat);
                Byte[] data = new Byte[bmpData.Stride * bmpData.Height];
                Marshal.Copy(bmpData.Scan0, data, 0, bmpData.Stride * bmpData.Height);
                Img.height = Convert.ToUInt32(b.Height);
                Img.width = Convert.ToUInt32(b.Width);
                Img.step = Convert.ToUInt32(bmpData.Stride);
                Img.encoding = "mono8";
                Img.data = data;
                b.UnlockBits(bmpData); 
            }
            //解锁Bitmap数据                        
            return (retVal);  
        }

        public  Bitmap RGB2Gray(Bitmap srcBitmap)
        {

            int wide = srcBitmap.Width;

            int height = srcBitmap.Height;

            Rectangle rect = new Rectangle(0, 0, wide, height);

            //将Bitmap锁定到系统内存中,获得BitmapData

            BitmapData srcBmData = srcBitmap.LockBits(rect,

            ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //创建Bitmap

            Bitmap dstBitmap = CreateGrayscaleImage(wide, height);//这个函数在后面有定义

            BitmapData dstBmData = dstBitmap.LockBits(rect,

            ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行

            System.IntPtr srcPtr = srcBmData.Scan0;

            System.IntPtr dstPtr = dstBmData.Scan0;

            //将Bitmap对象的信息存放到byte数组中

            int src_bytes = srcBmData.Stride * height;

            byte[] srcValues = new byte[src_bytes];

            int dst_bytes = dstBmData.Stride * height;

            byte[] dstValues = new byte[dst_bytes];

            //复制GRB信息到byte数组

            System.Runtime.InteropServices.Marshal.Copy(srcPtr, srcValues, 0, src_bytes);

            System.Runtime.InteropServices.Marshal.Copy(dstPtr, dstValues, 0, dst_bytes);

            //根据Y=0.299*R+0.114*G+0.587B,Y为亮度

            for (int i = 0; i < height; i++)

                for (int j = 0; j < wide; j++)
                {

                    //只处理每行中图像像素数据,舍弃未用空间

                    //注意位图结构中RGB按BGR的顺序存储

                    int k = 3 * j;

                    byte temp = (byte)(srcValues[i * srcBmData.Stride + k + 2] * .299

                    + srcValues[i * srcBmData.Stride + k + 1] * .587

                    + srcValues[i * srcBmData.Stride + k] * .114);

                    dstValues[i * dstBmData.Stride + j] = temp;

                }

            System.Runtime.InteropServices.Marshal.Copy(dstValues, 0, dstPtr, dst_bytes);

            //解锁位图

            srcBitmap.UnlockBits(srcBmData);

            dstBitmap.UnlockBits(dstBmData);

            return dstBitmap;

        }
        public  Bitmap CreateGrayscaleImage(int width, int height)
        {

            // create new image

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);

            // set palette to grayscale

            SetGrayscalePalette(bmp);

            // return new image

            return bmp;

        }

        ///<summary>

        /// Set pallete of the image to grayscale

        ///</summary>

        ///
        /// Resize图片
        ///
        /// 原始Bitmap
        /// 新的宽度
        /// 新的高度
        /// 保留着，暂时未用
        /// 处理以后的图片
        public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH, int Mode)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);

                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }
        public  void SetGrayscalePalette(Bitmap srcImg)
        {

            // check pixel format

            if (srcImg.PixelFormat != PixelFormat.Format8bppIndexed)

                throw new ArgumentException();

            // get palette

            ColorPalette cp = srcImg.Palette;

            // init palette

            for (int i = 0; i < 256; i++)
            {

                cp.Entries[i] = Color.FromArgb(i, i, i);

            }

            srcImg.Palette = cp;

        }
      
    }

}

