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
     
                                                                                    
        IGXDevice            m_objIGXDevice1               = null;                            ///<设备对像
        IGXStream            m_objIGXStream1               = null;                            ///<流对像                           ///<流对像
        
        IGXDevice            m_objIGXDevice2               = null;                            ///<设备对像                           
        IGXStream            m_objIGXStream2               = null;                            ///<流对像                           ///<流对像
                               ///<远端设备属性控制器对像
                                                                              ///
        string               m_strFilePath                = "";                              ///<应用程序当前路径
        CROS ros = null;

        GxBitmap m_objGxBitmap;
        GxBitmap m_objGxBitmap2;
        private Accord.IntPoint[] correlationPoints1;
        private Accord.IntPoint[] correlationPoints2;

        private MatrixH homography;
        private int counter = 0;

        Int32[] A = new Int32[4];
        Int32[] LP = new Int32[4];
        Int32[] speed = new Int32[4];
        int i;
        IntPtr hDevice;
        USB1020.USB1020_PARA_DataList[] DL = new USB1020.USB1020_PARA_DataList[4];
        USB1020.USB1020_PARA_LCData[] LC = new USB1020.USB1020_PARA_LCData[4];		// 直线和S曲线参数

        //USB1020.USB1020_PARA_DataList DL;
        USB1020.USB1020_PARA_InterpolationAxis IA;	// 插补轴
        USB1020.USB1020_PARA_LineData LD;		// 直线插补和固定线速度直线插补参数
        USB1020.USB1020_PARA_InterpolationAxis IA2;	// 插补轴
        USB1020.USB1020_PARA_LineData LD2;		// 直线插补和固定线速度直线插补参数

        const bool withros = false;
        public GxSingleCam()
        {
            // 获取应用程序的当前执行路径
            m_strFilePath = Directory.GetCurrentDirectory().ToString();
            InitializeComponent();
        }
        void OnFrameCallbackFun(object obj, IFrameData objIFrameData)
        {
            if (objIFrameData.GetStatus()==GX_FRAME_STATUS_LIST.GX_FRAME_STATUS_SUCCESS)
            {
                m_objGxBitmap.Show(objIFrameData);        
                if(withros)
                {
                    if (ros.isConnect)
                        ros.PubMapImgL(m_objGxBitmap.Mbitmap);
                }

            }



        }
        void OnFrameCallbackFun2(object obj, IFrameData objIFrameData)
        {
            if (objIFrameData.GetStatus() == GX_FRAME_STATUS_LIST.GX_FRAME_STATUS_SUCCESS)
            {
                m_objGxBitmap2.Show(objIFrameData);
                if(withros)
                {
                    if (ros.isConnect)
                        ros.PubMapImgR(m_objGxBitmap2.Mbitmap);
                }

            
            }

        }

        /// <summary>
        /// 加载窗体执行初始化UI和库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GxSingleCam_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            try
            {
                IGXFactory.GetInstance().Init();
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
                    ros = new CROS("msi-PC", "http://192.168.0.2:11311");
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

                String strSN = listGXDeviceInfo[0].GetSN();
                m_objIGXDevice1 = IGXFactory.GetInstance().OpenDeviceBySN(strSN, GX_ACCESS_MODE.GX_ACCESS_EXCLUSIVE);

                String strSN2 = listGXDeviceInfo[1].GetSN();
                m_objIGXDevice2 = IGXFactory.GetInstance().OpenDeviceBySN(strSN2, GX_ACCESS_MODE.GX_ACCESS_EXCLUSIVE);


                m_objIGXStream1 = m_objIGXDevice1.OpenStream(0);
                m_objIGXStream2 = m_objIGXDevice2.OpenStream(0);
                //注册采集回调函数，注意第一个参数是用户私有参数，用户可以传入任何object对象，也可以是null
                //用户私有参数在回调函数内部还原使用，如果不使用私有参数，可以传入null
                m_objIGXStream1.RegisterCaptureCallback(m_objIGXDevice1, OnFrameCallbackFun);
                m_objIGXStream2.RegisterCaptureCallback(m_objIGXDevice2, OnFrameCallbackFun2);
                //开启流通道采集

                //给设备发送开采命令
                IGXFeatureControl objIGXFeatureControl = m_objIGXDevice1.GetRemoteFeatureControl();
                //objIGXFeatureControl.GetIntFeature("Height").SetValue(700);
                objIGXFeatureControl.GetEnumFeature("AcquisitionMode").SetValue("Continuous");
                objIGXFeatureControl.GetEnumFeature("ExposureAuto").SetValue("Continuous");
                objIGXFeatureControl.GetIntFeature("GevSCPSPacketSize").SetValue(1500);
                objIGXFeatureControl.GetIntFeature("GevSCPD").SetValue(1000);
                objIGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();

                IGXFeatureControl objIGXFeatureControl2 = m_objIGXDevice2.GetRemoteFeatureControl();
                //objIGXFeatureControl2.GetIntFeature("Height").SetValue(700);
                objIGXFeatureControl2.GetEnumFeature("AcquisitionMode").SetValue("Continuous");
                objIGXFeatureControl2.GetEnumFeature("ExposureAuto").SetValue("Continuous");
                objIGXFeatureControl2.GetIntFeature("GevSCPSPacketSize").SetValue(1500);
                objIGXFeatureControl2.GetIntFeature("GevSCPD").SetValue(1000);
                objIGXFeatureControl2.GetCommandFeature("AcquisitionStart").Execute();

                m_objGxBitmap = new GxBitmap(m_objIGXDevice1, m_pic_ShowImage);
                m_objGxBitmap2 = new GxBitmap(m_objIGXDevice2, m_pic2_ShowImage);

                m_objIGXStream1.StartGrab();
                m_objIGXStream2.StartGrab();



            }
            else
            {

            }
        }

        /// <summary>
        /// 关闭设备关闭流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btn_CloseDevice_Click(object sender, EventArgs e)
        {
            IGXFeatureControl objIGXFeatureControl = m_objIGXDevice1.GetRemoteFeatureControl();
            objIGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
            IGXFeatureControl objIGXFeatureControl2 = m_objIGXDevice2.GetRemoteFeatureControl();
            objIGXFeatureControl2.GetCommandFeature("AcquisitionStop").Execute();
            m_objIGXStream1.StopGrab();
            m_objIGXStream2.StopGrab();
            m_objIGXStream1.UnregisterCaptureCallback();
            m_objIGXStream2.UnregisterCaptureCallback();
            //关闭流通道
            m_objIGXStream1.Close();
            m_objIGXStream2.Close();
            m_objIGXDevice1.Close();
            m_objIGXDevice2.Close();
        }

        /// <summary>
        /// 开始采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btn_StartDevice_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 停止采集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btn_StopDevice_Click(object sender, EventArgs e)
        {
         
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
            for (i = 0; i < 4; i++)
            {
                speed[i] = (USB1020.USB1020_ReadCV(hDevice, i));		// 读当前速度
                A[i] = (USB1020.USB1020_ReadCA(hDevice, i));		// 读当前加速度
                LP[i] = USB1020.USB1020_ReadLP(hDevice, i);		// 读逻辑计数器
            }
            textBox_AD4.Text = LP[0].ToString("0.##");
            textBox_AD5.Text = LP[1].ToString("0.##");
            textBox_AD6.Text = LP[2].ToString("0.##");
            textBox_AD7.Text = LP[3].ToString("0.##");
            if(counter%5==0)
            {
                button1_Click(sender, e);
            }
            counter++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap img1 = new Bitmap(m_objGxBitmap.Width, m_objGxBitmap.Heigh, PixelFormat.Format24bppRgb);
                __UpdateBitmap(img1, m_objGxBitmap.ColorBuffer, m_objGxBitmap.Width, m_objGxBitmap.Heigh, true);
                Bitmap img2 = new Bitmap(m_objGxBitmap2.Width, m_objGxBitmap2.Heigh, PixelFormat.Format24bppRgb);
                __UpdateBitmap(img2, m_objGxBitmap2.ColorBuffer, m_objGxBitmap2.Width, m_objGxBitmap2.Heigh, true);


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
                IntPoint[] inliers1 = correlationPoints1.Submatrix(ransac.Inliers);
                IntPoint[] inliers2 = correlationPoints2.Submatrix(ransac.Inliers);

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
                  hDevice = USB1020.USB1020_CreateDevice(0);
                  if (hDevice == (IntPtr)(-1))
                  {
                      MessageBox.Show("创建设备失败！");
                      return;
                  }
                  timer1.Enabled = true;
                  for (i = 0; i < 4; i++)
                  {
                      LC[i].AxisNum = i;						// 轴号(USB1020_XAXIS:X轴; USB1020_YAXIS:Y轴;;USB1020_ZAXIS:Z轴; USB1020_UAXIS:U轴)
                      LC[i].LV_DV = USB1020.USB1020_LV;				// 驱动方式 USB1020_DV:定长驱动 USB1020_LV: 连续驱动
                      LC[i].PulseMode = USB1020.USB1020_CPDIR;		// 模式0：CW/CCW方式，1：CP/DIR方式 
                      LC[i].Line_Curve = USB1020.USB1020_LINE;		// 直线曲线(0:直线加/减速; 1:S曲线加/减速)

                      DL[i].Multiple = 15;
                      DL[i].Acceleration = 5000;				// 加速度(125~1000,000)(直线加减速驱动中加速度一直不变）
                      DL[i].Deceleration = 5000;				// 减速度(125~1000000)
                      DL[i].AccIncRate = 1000;				// 加速度变化率(仅S曲线驱动时有效)
                      DL[i].StartSpeed = 1000;					// 初始速度(1~8000)
                      DL[i].DriveSpeed = 8000;				// 驱动速度	(1~8000)	
                      LC[i].nPulseNum = 100000;				// 定量输出脉冲数(0~268435455)
                      LC[i].Direction = USB1020.USB1020_PDIRECTION;	// 转动方向 USB1020_PDirection: 正转  USB1020_MDirection:反转		
                      USB1020.USB1020_InitLVDV(						//	初始单轴化连续,定长脉冲驱动
                                      hDevice,
                                      ref DL[i],
                                      ref LC[i]);
                  }


                  IA.Axis1 = USB1020.USB1020_XAXIS;		// X轴
                  IA.Axis2 = USB1020.USB1020_ZAXIS;		// Y轴
                  IA2.Axis1 = USB1020.USB1020_YAXIS;
                  IA2.Axis2 = USB1020.USB1020_UAXIS;
                  LD.ConstantSpeed = 1;				// 固定线速度 (不固定线速度 | 固定线速度)
                  LD.Line_Curve = USB1020.USB1020_LINE;	// 直线运动
                 
                  LD.n1AxisPulseNum = 500000;		// 主轴终点脉冲数 (-8388608~8388607)
                  LD.n2AxisPulseNum = 0;			// 第二轴轴终点脉冲数 (-8388608~8388607)
                  USB1020.USB1020_InitLineInterpolation_2D(			// 初始化任意2轴直线插补运动 
                                  hDevice,					// 设备句柄
                                  ref DL[1],						// 公共参数结构体指针
                                  ref IA,						// 插补轴结构体指针
                                  ref LD);						// 直线插补结构体指针
                  USB1020.USB1020_StartLineInterpolation_2D(hDevice);	// 启动任意2轴直线插补运动 

                  USB1020.USB1020_NextWait(hDevice);					// 等待写入下一个节点的参数和命令

                  USB1020.USB1020_PARA_CircleData CD;		// 正反方向圆弧插补参数
                  CD.Direction = 0;		// 运动方向 (正方向 | 反方向)
                  CD.Center1 = 0;		// 主轴圆心坐标(脉冲数-8388608~8388607)
                  CD.Center2 = 60000;	// 第二轴轴圆心坐标(脉冲数-8388608~8388607)
                  CD.Pulse1 = 0;		// 主轴终点坐标(脉冲数-8388608~8388607)	
                  CD.Pulse2 = 100000;		// 第二轴轴终点坐标(脉冲数-8388608~8388607)
                  CD.ConstantSpeed = USB1020.USB1020_CONSTAND;	// 固定线速度
                  USB1020.USB1020_InitCWInterpolation_2D(				// 初始化任意2轴正反方向圆弧插补运动 
                                           hDevice,			// 设备句柄
                                           ref DL[1],				// 公共参数结构体指针
                                           ref IA,				// 插补轴结构体指针
                                           ref CD);				// 圆弧插补结构体指针
                  USB1020.USB1020_StartCWInterpolation_2D(hDevice, CD.Direction);

                  USB1020.USB1020_NextWait(hDevice);					// 等待写入下一个节点的参数和命令

                  LD.n1AxisPulseNum = -500000;
                  LD.n2AxisPulseNum = 0;

                  USB1020.USB1020_InitLineInterpolation_2D(			// 初始化任意2轴直线插补运动 
                                  hDevice,					// 设备句柄
                                  ref DL[1],						// 公共参数结构体指针
                                  ref IA,						// 插补轴结构体指针
                                  ref LD);						// 直线插补结构体指针
                  USB1020.USB1020_StartLineInterpolation_2D(hDevice);	// 启动任意2轴直线插补运动 

                  USB1020.USB1020_NextWait(hDevice);					// 等待写入下一个节点的参数和命令


                  CD.Center1 = 0;
                  CD.Center2 = -60000;
                  CD.Pulse1 = 0;
                  CD.Pulse2 = -100000;
                  USB1020.USB1020_InitCWInterpolation_2D(				// 初始化任意2轴正反方向圆弧插补运动 
                                           hDevice,			// 设备句柄
                                           ref DL[1],				// 公共参数结构体指针
                                           ref IA,				// 插补轴结构体指针
                                           ref CD);				// 圆弧插补结构体指针
                  USB1020.USB1020_StartCWInterpolation_2D(hDevice, CD.Direction);
                 
              }

              private void button3_Click(object sender, EventArgs e)
              {
                  timer1.Enabled = false;
                  USB1020.USB1020_DecStop(			 // 减速停止
                                           hDevice,			 // 设备句柄
                                           USB1020.USB1020_ALLAXIS);		
              }

    }
}
