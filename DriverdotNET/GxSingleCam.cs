using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;

using XmlRpc_Wrapper;
using GxIAPINET;
using GxIAPINET.Sample.Common;
using Messages;
using Ros_CSharp;
using System.Runtime.InteropServices;

using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.Math;
using Accord.Collections;
using Accord.Math.Distances;
using Accord;
//using AForge;

using Sys;

namespace DriverdotNET
{
    public partial class GxSingleCam : Form
    {
        CDHCam camr;
        CDHCam caml;
        string m_strFilePath  = "";
        CROS ros = null;

        private Accord.IntPoint[] correlationPoints1;
        private Accord.IntPoint[] correlationPoints2;

        private MatrixH homography;
        private int counter = 0;

        private CTMA500 tma;
       

        const bool withros = false;
        public GxSingleCam()
        {
            // 获取应用程序的当前执行路径
            m_strFilePath = Directory.GetCurrentDirectory().ToString();
            InitializeComponent();
        }

        /// <summary>
        /// 加载窗体执行初始化UI和库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GxSingleCam_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            tma = new CTMA500();
            try
            {
                IGXFactory.GetInstance().Init();
                List<IGXDeviceInfo> listGXDeviceInfo = new List<IGXDeviceInfo>();
                IGXFactory.GetInstance().UpdateAllDeviceList(200, listGXDeviceInfo);
                foreach (IGXDeviceInfo objDeviceInfo in listGXDeviceInfo)
                {
                    Console.WriteLine("#######################");
                    Console.WriteLine(objDeviceInfo.GetModelName());
                    Console.WriteLine(objDeviceInfo.GetVendorName());
                    Console.WriteLine(objDeviceInfo.GetUserID());
                    Console.WriteLine(objDeviceInfo.GetIP());
                    Console.WriteLine(objDeviceInfo.GetSN());
                    //更多的设备信息详见IGXDeviceInfo接口
                }

                if (listGXDeviceInfo.Count > 1)
                {
                    caml = new CDHCam(0, m_pic_ShowImage);
                    camr = new CDHCam(1, m_pic2_ShowImage);
                }
                else
                {
                    MessageBox.Show("摄像头初始化失败~");
                }
            }
            catch (CGalaxyException ex)
            {
                string strErrorInfo = "错误码为:" + ex.GetErrorCode().ToString() + "错误描述信息为:" + ex.Message;
                Console.WriteLine(strErrorInfo);
            }

            if(withros)
            {
                try
                {
                    ros = new CROS("msi-PC", "http://192.168.1.2:11311");
                    System.Threading.Thread initthread = new Thread(new ParameterizedThreadStart(Init));
                    initthread.Start();

                }
                catch (Exception ex)
                {
                    string strErrorInfo = "错误码为:" + ex.ToString() + "错误描述信息为:" + ex.Message;
                    Console.WriteLine(strErrorInfo);
                }
            }


        }
        void Init(object obj)
        {
            ros.init();
            
        }
        /// <summary>
        /// 打开设备打开流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btn_OpenDevice_Click(object sender, EventArgs e)
        {
            caml.__open();
            camr.__open();
               
        }

        /// <summary>
        /// 关闭设备关闭流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btn_CloseDevice_Click(object sender, EventArgs e)
        {
            caml.__close();
            camr.__close();
        }

        /// <summary>
        /// 开始采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btn_StartDevice_Click(object sender, EventArgs e)
        {
            caml.__start();
            camr.__start();
        }

        /// <summary>
        /// 停止采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btn_StopDevice_Click(object sender, EventArgs e)
        {
            caml.__stop();
            camr.__stop();
        }


        /// <summary>
        /// 窗体关闭、关闭流、关闭设备、反初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GxSingleCam_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(withros)
                ros.uninit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tma.__update();
            textBox_AD4.Text = tma.LP[0].ToString("0.##");
            textBox_AD5.Text = tma.LP[1].ToString("0.##");
            textBox_AD6.Text = tma.LP[2].ToString("0.##");
            textBox_AD7.Text = tma.LP[3].ToString("0.##");
            if(counter%5==0)
            {
                //button1_Click(sender, e);
            }
            counter++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap img1 = new Bitmap(caml.m_objGxBitmap.Width, caml.m_objGxBitmap.Heigh, PixelFormat.Format24bppRgb);
                //__UpdateBitmap(img1, m_objGxBitmap.ColorBuffer, m_objGxBitmap.Width, m_objGxBitmap.Heigh, true);
                Bitmap img2 = new Bitmap(camr.m_objGxBitmap.Width, camr.m_objGxBitmap.Heigh, PixelFormat.Format24bppRgb);
                //__UpdateBitmap(img2, m_objGxBitmap2.ColorBuffer, m_objGxBitmap2.Width, m_objGxBitmap2.Heigh, true);


                FastRetinaKeypointDetector freak = new FastRetinaKeypointDetector();
                FastRetinaKeypoint[] keyPoints1;
                FastRetinaKeypoint[] keyPoints2;
                keyPoints1 = freak.ProcessImage(img1).ToArray();
                keyPoints2 = freak.ProcessImage(img2).ToArray();

                var matcher = new KNearestNeighborMatching<byte[]>(5, new Hamming());
                IntPoint[][] matches = matcher.Match(keyPoints1, keyPoints2);

                // Get the two sets of points
                correlationPoints1 = matches[0];
                correlationPoints2 = matches[1];

                RansacHomographyEstimator ransac = new RansacHomographyEstimator(0.001, 0.99);
                homography = ransac.Estimate(correlationPoints1, correlationPoints2);

                // Plot RANSAC results against correlation results
                //IntPoint[] inliers1 = correlationPoints1.Submatrix(ransac.Inliers);
                //IntPoint[] inliers2 = correlationPoints2.Submatrix(ransac.Inliers);

                Blend blend = new Blend(homography, img1);
                m_stitpic_box.Image = blend.Apply(img2);


            }
           catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


            private void __UpdateBitmap(Bitmap bitmap, byte[] byBuffer, int nWidth, int nHeight, bool bIsColor)
            {
                //给BitmapData加锁
                BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);

                //得到一个指向Bitmap的buffer指针
                IntPtr ptrBmp = bmpData.Scan0;
                int nImageStride = __GetStride(nWidth, bIsColor);
                //图像宽能够被4整除直接copy
                if (nImageStride == bmpData.Stride)
                {
                    Marshal.Copy(byBuffer, 0, ptrBmp, bmpData.Stride * bitmap.Height);
                }
                else    
                {
                    for (int i = 0; i < bitmap.Height; ++i)
                    {
                        Marshal.Copy(byBuffer, i * nImageStride, new IntPtr(ptrBmp.ToInt64() + i * bmpData.Stride), nWidth);
                    }
                }
                //BitmapData解锁
                bitmap.UnlockBits(bmpData);
            }
            private int __GetStride(int nWidth, bool bIsColor)
              {
                    return bIsColor ? nWidth * 3 : nWidth;
              }

            private void button2_Click(object sender, EventArgs e)
              {              
                  timer1.Enabled = true;
                  tma.__start();               
              }

            private void button3_Click(object sender, EventArgs e)
            {
                timer1.Enabled = false;
                tma.__stop();
            }

    }
}
