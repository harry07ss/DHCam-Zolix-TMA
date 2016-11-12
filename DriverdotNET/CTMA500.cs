using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sys;
namespace DriverdotNET
{
    class CTMA500
    {


        public Int32[] A = new Int32[4];
        public Int32[] LP = new Int32[4];
        public Int32[] speed = new Int32[4];
        int i;
        IntPtr hDevice;
        USB1020.USB1020_PARA_DataList[] DL = new USB1020.USB1020_PARA_DataList[4];
        USB1020.USB1020_PARA_LCData[] LC = new USB1020.USB1020_PARA_LCData[4];		// 直线和S曲线参数

        USB1020.USB1020_PARA_InterpolationAxis IA;	// 插补轴
        USB1020.USB1020_PARA_LineData LD;		// 直线插补和固定线速度直线插补参数
        USB1020.USB1020_PARA_InterpolationAxis IA2;	// 插补轴
        USB1020.USB1020_PARA_LineData LD2;		// 直线插补和固定线速度直线插补参数

        public CTMA500()
        {
            hDevice = USB1020.USB1020_CreateDevice(0);
            if (hDevice == (IntPtr)(-1))
            {
                Console.WriteLine("创建设备失败！");
                return;
            }
            for (i = 0; i < 4; i++)
            {
                LC[i].AxisNum = i;						// 轴号(USB1020_XAXIS:X轴; USB1020_YAXIS:Y轴;;USB1020_ZAXIS:Z轴; USB1020_UAXIS:U轴)
                LC[i].LV_DV = USB1020.USB1020_LV;				// 驱动方式 USB1020_DV:定长驱动 USB1020_LV: 连续驱动
                LC[i].PulseMode = USB1020.USB1020_CPDIR;		// 模式0：CW/CCW方式，1：CP/DIR方式 
                LC[i].Line_Curve = USB1020.USB1020_LINE;		// 直线曲线(0:直线加/减速; 1:S曲线加/减速)

                DL[i].Multiple = 20;
                DL[i].Acceleration = 5000;				// 加速度(125~1000,000)(直线加减速驱动中加速度一直不变）
                DL[i].Deceleration = 5000;				// 减速度(125~1000000)
                DL[i].AccIncRate = 1000;				// 加速度变化率(仅S曲线驱动时有效)
                DL[i].StartSpeed = 1000;					// 初始速度(1~8000)
                DL[i].DriveSpeed = 8000;				// 驱动速度	(1~8000)	
                LC[i].nPulseNum = 100000;				// 定量输出脉冲数(0~268435455)
                LC[i].Direction = USB1020.USB1020_MDIRECTION;	// 转动方向 USB1020_PDirection: 正转  USB1020_MDirection:反转		
                USB1020.USB1020_InitLVDV(						//	初始单轴化连续,定长脉冲驱动
                                hDevice,
                                ref DL[i],
                                ref LC[i]);
            }
        }

        public void __update()
        {
            for (i = 0; i < 4; i++)
            {
                speed[i] = (USB1020.USB1020_ReadCV(hDevice, i));		// 读当前速度
                A[i] = (USB1020.USB1020_ReadCA(hDevice, i));		// 读当前加速度
                LP[i] = USB1020.USB1020_ReadLP(hDevice, i);		// 读逻辑计数器
            }
        }

        public void __stop()
        {
            USB1020.USB1020_DecStop(			 // 减速停止
                                          hDevice,			 // 设备句柄
                                          USB1020.USB1020_ALLAXIS);		
        }
        public void __start()
        {
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

    }
}
