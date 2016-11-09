using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Sys
{
    public partial class USB1020
    {
       // ���ò��� 

        public struct USB1020_PARA_DataList
    {
        
     public Int32 Multiple;				// ���� (1~500)
     public Int32 StartSpeed;			// ��ʼ�ٶ�(1~8000)
     public Int32 DriveSpeed;			// �����ٶ�(1~8000)
     public Int32 Acceleration;			// ���ٶ�(125~1000000)
     public Int32 Deceleration;			// ���ٶ�(125~1000000)
     public Int32 AccIncRate;			// ���ٶȱ仯��(954~62500000)
     public Int32  DecIncRate;			// ���ٶȱ仯��(954~6250000062500000)
    }


    // ֱ�ߺ�S���߲��� 
        public struct USB1020_PARA_LCData
    {
	   
       public Int32  AxisNum;				// ��� (X�� | Y�� | X��Y��)
        public Int32 LV_DV;					// ������ʽ  (���� | ���� )
        public Int32 DecMode;				// ���ٷ�ʽ  (�Զ����� | �ֶ�����)	
        public Int32  PulseMode;				// ���巽ʽ (CW/CCW��ʽ | CP/DIR��ʽ)
        public Int32 PLSLogLever;			// �趨��������ķ���Ĭ��������
        public Int32 DIRLogLever;			// �趨�����ź�������߼���ƽ��0���͵�ƽΪ����1���ߵ�ƽΪ����	
        public Int32  Line_Curve;			// �˶���ʽ	(ֱ�� | ����)
        public Int32 Direction;				// �˶����� (������ | ������)
        public Int32  nPulseNum;		    	// �������������(0~268435455)
    } 


    // �岹��
        public struct USB1020_PARA_InterpolationAxis
    {
        public Int32 Axis1;					// ����
        public Int32  Axis2;					// �ڶ���
        public Int32  Axis3;					// ��������
    } 

    // ֱ�߲岹�͹̶����ٶ�ֱ�߲岹����
        public struct USB1020_PARA_LineData	
    {
       public Int32 Line_Curve;			// �˶���ʽ	(ֱ�� | ����)
       public Int32 ConstantSpeed;			// �̶����ٶ� (���̶����ٶ� | �̶����ٶ�)
       public Int32 n1AxisPulseNum;		// �����յ������� (-8388608~8388607)
       public Int32 n2AxisPulseNum;		// �ڶ������յ������� (-8388608~8388607)
       public Int32 n3AxisPulseNum;		// ���������յ������� (-8388608~8388607)			
    } 

    // ��������Բ���岹����
        public struct USB1020_PARA_CircleData	
    {
        public Int32  ConstantSpeed;			// �̶����ٶ� (���̶����ٶ� | �̶����ٶ�)
        public Int32 Direction;				// �˶����� (������ | ������)
        public Int32  Center1;				// ����Բ������(������-8388608~8388607)
        public Int32  Center2;				// �ڶ�����Բ������(������-8388608~8388607)
        public Int32  Pulse1;				// �����յ�����(������-8388608~8388607)	
        public Int32 Pulse2;				// �ڶ������յ�����(������-8388608~8388607)608~8388607)
    } 

    /***************************************************************/
    // ���
    
                public const Int32		USB1020_XAXIS		   =0X0;				// X��
                public const Int32	USB1020_YAXIS			   =0x1;				// Y��
                public const Int32 		USB1020_ZAXIS		   =0x2;				// Z��
                public const Int32		USB1020_UAXIS		   =0x3;				// U��
                public const Int32 USB1020_ALLAXIS            = 0xF;				// ������


    /***************************************************************/
    // ������ʽ
    public const Int32		USB1020_DV				=0x0;				// ��������
    public const Int32		USB1020_LV				=0x1;				// ��������

    /***************************************************************/
    // ���ٷ�ʽ
    public const Int32		USB1020_AUTO			=0x0;				// �Զ�����
    public const Int32		USB1020_HAND			=0x1;				// �ֶ�����

    /***************************************************************/
    // ���������ʽ
    public const Int32 	USB1020_CWCCW			=0X0;				// CW/CCW��ʽ 
    public const Int32 	USB1020_CPDIR 			=0X1;				// CP/DIR��ʽ

    /***************************************************************/
    // �������뷽ʽ
    public const Int32 	USB1020_A_B			    =0X0;				// A/B�෽ʽ
    public const Int32 	USB1020_U_D 			=0X1;				// ��/���������뷽ʽ

    /***************************************************************/
    // ��������ʱ�����屶Ƶ��
    public const Int32 	USB1020_DIVRATIO_1		=0X0;				// 1��Ƶ
    public const Int32 	USB1020_DIVRATIO_2 		=0X1;				// 2��Ƶ
    public const Int32 	USB1020_DIVRATIO_4 		=0X2;				// 4��Ƶ

    /***************************************************************/
    // �˶���ʽ
    public const Int32		USB1020_LINE			=0X0;				// ֱ���˶�
    public const Int32		USB1020_CURVE			=0X1;				// S�����˶�

    /***************************************************************/
    // �˶�����
    public const Int32		USB1020_MDIRECTION		=0x0;				// ������
    public const Int32		USB1020_PDIRECTION		=0x1;				// ������

    /***************************************************************/
    //�̶����ٶ�
    public const Int32		USB1020_NOCONSTAND		=0X0;				// ���̶����ٶ�
    public const Int32		USB1020_CONSTAND		=0X1;				// �̶����ٶ�

    /***************************************************************/
    // �����λ���߼�ʵλ������ѡ��������ⲿԽ���źŵ�ֹͣ��ʽ�������ⲿֹͣ�źŵ�ֹͣ��ѡ��
    /***************************************************************/
    // ���������
    public const Int32		USB1020_LOGIC			=0x0;				// �߼�λ������
    public const Int32		USB1020_FACT			=0x1;				// ʵλ������

    /***************************************************************/
    // �ⲿֹͣ�ź�
    public const Int32 	USB1020_IN0				=0X0;				// ֹͣ�ź�0
    public const Int32 	USB1020_IN1				=0X1;				// ֹͣ�ź�1
    public const Int32 	USB1020_IN2				=0X2;				// ֹͣ�ź�2
    public const Int32 	USB1020_IN3				=0X3;				// ֹͣ�ź�3

    /***************************************************************/
    // ֹͣ��ʽ
    public const Int32		USB1020_SUDDENSTOP		=0x0;				// ����ֹͣ
    public const Int32		USB1020_DECSTOP			=0X1;				// ����ֹͣ

    /********************************************************************/
    // ����л�
    public const Int32		USB1020_GENERALOUT		=0x0;				// ͨ�����
    public const Int32		USB1020_STATUSOUT		=0X1;				// ״̬���

    /********************************************************************/
    public const Int32		USB1020_ERROR			=0XFF;			// ����

    /****************************************************************/
    // �����ж�λʹ��
    public struct USB1020_PARA_Interrupt      
    {
             public UInt32  PULSE;			// 1���ж�ʹ�ܣ��ж��ź��ɸ���������������ش��� 0����ֹ�ж�
             public UInt32  PBCM;			// 1���ж�ʹ�ܣ����߼�/ʵ��λ�ü�������ֵ���ڵ���COMP-�Ĵ�����ֵʱ���ж��ź� 0����ֹ�ж�
             public UInt32 PSCM;			// 1���ж�ʹ�ܣ����߼�/ʵ��λ�ü�������ֵС��COMP-�Ĵ�����ֵʱ���ж��ź� 0����ֹ�ж�
             public UInt32 PSCP;			// 1���ж�ʹ�ܣ����߼�/ʵ��λ�ü�������ֵС��COMP+�Ĵ�����ֵʱ���ж��ź� 0����ֹ�ж�
             public UInt32  PBCP;			// 1���ж�ʹ�ܣ����߼�/ʵ��λ�ü�������ֵ���ڵ���COMP+�Ĵ�����ֵ���ж��ź� 0����ֹ�ж�
             public UInt32  CDEC;			// 1���ж�ʹ�ܣ��ڼ�/���������У�����ʼ����ʱ���ж��ź� 0����ֹ�ж�
             public UInt32 CSTA;			// 1���ж�ʹ�ܣ��ڼ�/���������У�����ʼ����ʱ���ж��ź� 0����ֹ�ж�
             public UInt32  DEND;			// 1���ж�ʹ�ܣ�����������ʱ���ж��ź� 0����ֹ�ж�
             public UInt32 CIINT;			// 1���ж�ʹ�ܣ�������д����һ���ڵ�����ʱ�����ж� 0����ֹ�ж�
             public UInt32  BPINT;			// 1���ж�ʹ�ܣ���λ�岹��ջ��������ֵ��2��Ϊ1ʱ�����ж� 0����ֹ�ж�
    } 

    // ����ͬ������(����)
    public struct USB1020_PARA_SynchronActionOwnAxis    
    {
      public UInt32  PBCP;			// 1�����߼�/ʵλ��������ֵ���ڵ���COMP+�Ĵ���ʱ������ͬ������ 0����Ч
      public UInt32  PSCP;			// 1�����߼�/ʵλ��������ֵС��COMP+�Ĵ���ʱ������ͬ������ 0����Ч
      public UInt32  PSCM;			// 1�����߼�/ʵλ��������ֵС��COMP-�Ĵ���ʱ������ͬ������ 0����Ч
      public UInt32  PBCM;			// 1�����߼�/ʵλ��������ֵ���ڵ���COMP-�Ĵ���ʱ������ͬ������ 0����Ч
      public UInt32  DSTA;			// 1����������ʼʱ������ͬ������ 0����Ч
      public UInt32 DEND;			// 1������������ʱ������ͬ������ 0����Ч
      public UInt32  IN3LH;			// 1����IN3����������ʱ������ͬ������ 0����Ч
      public UInt32 IN3HL;			// 1����IN3�����½���ʱ������ͬ������ 0����Ч
      public UInt32 LPRD;			// 1�������߼�λ�ü�����ʱ������ͬ������ 0����Ч
      public UInt32  CMD;			// 1����д��ͬ����������ʱ������ͬ�����ͬ������ 0����Ч
      public UInt32 AXIS1;			// 1��ָ�����Լ���ͬ������  0��û��ָ��
      public UInt32 AXIS2;			// 1��ָ�����Լ���ͬ������  0��û��ָ��
      public UInt32 AXIS3;			// 1��ָ�����Լ���ͬ������  0��û��ָ��
                                 // ��ǰ��	AXIS3		AXIS2		AXIS1  
                                // X��		 U��		 Z��		 Y��
                                // Y��		 U��		 Z��		 X��
                                // Z��		 U��		 Y��		 X��
                                // U��		 Z��		 Y��		 X��
    } 

    // ����ͬ������(������)
    public struct USB1020_PARA_SynchronActionOtherAxis    
    {
     public UInt32 FDRVP;			// 1�����������򶨳����� 0����Ч
     public UInt32  FDRVM;			// 1�����������򶨳����� 0����Ч
     public UInt32  CDRVP;			// 1�������������������� 0����Ч
     public UInt32  CDRVM;			// 1�������������������� 0����Ч
     public UInt32 SSTOP;			// 1������ֹͣ 0����Ч
     public UInt32  ISTOP;			// 1������ֹͣ 0����Ч
     public UInt32  LPSAV;			// 1���ѵ�ǰ�߼��Ĵ���LPֵ���浽ͬ������Ĵ���BR 0����Ч
     public UInt32 EPSAV;			// 1���ѵ�ǰʵλ�Ĵ���EPֵ���浽ͬ������Ĵ���BR 0����Ч
     public UInt32 LPSET;			// 1����WR6��WR7��ֵ�趨���߼��Ĵ���LP�� 0����Ч
     public UInt32  EPSET;			// 1����WR6��WR7��ֵ�趨���߼��Ĵ���EP�� 0����Ч 
     public UInt32 OPSET;			// 1����WR6��WR7��ֵ�趨���߼��Ĵ���LP�� 0����Ч
     public UInt32  VLSET;			// 1����WR6��ֵ�趨Ϊ�����ٶ�V 0����Ч
     public UInt32  OUTN;			// 1����nDCC�������ͬ������  0��nDCC���ͬ��������Ч������
     public UInt32   INTN;			// 1�������ж�  0���������ж�
    } 

    // ������������

    public struct USB1020_PARA_ExpMode
    {
        public UInt32  EPCLR;			// 1����IN2������Чʱ���ʵλ������ 0����Ч
        public UInt32 FE0;			// 1���ⲿ�����ź�EMGN��nLMTP��nLMTM��nIN0��nIN1�˲�����Ч 0����Ч
        public UInt32  FE1;			// 1���ⲿ�����ź�nIN2�˲�����Ч 0����Ч
        public UInt32  FE2;			// 1���ⲿ�����ź�nALARM��nINPOS�˲�����Ч 0����Ч
        public UInt32  FE3;			// 1���ⲿ�����ź�nEXPP��nEXPM��EXPLS�˲�����Ч 0����Ч
        public UInt32  FE4;			// 1���ⲿ�����ź�nIN3�˲�����Ч 0����Ч
        public UInt32  FL0;			// �˲�����ʱ�䳣�� 
        //	FL2 FL1 FL0	 �˲���ʱ�䳣��	 �ź��ӳ�
        public UInt32 FL1;			//		0��			1.75��S			2��S
        public UInt32  FL2;			//		1��			224��S			256��S
                                    //		2��			448��S			512��S
                                    //		3��			896��S			1.024m��S
                                    //		4��			1.792mS			2.048mS
                                    //		5��			3.584mS			4.096mS
                                    //		6��			7.168mS			8.012mS
                                    //		7��			14.336mS		16.384mS
    } 


    // ƫ��������������
    public struct USB1020_PARA_DCC
    {
       public UInt32  DCCE;			// 1��ʹ��ƫ������������� 0����Ч
       public UInt32  DCCL;			// 1��ƫ����������������߼���ƽΪ�͵�ƽ  0��ƫ����������������߼���ƽΪ�ߵ�ƽ
       public UInt32  DCCW0;			// ����ָ��ƫ���������������������
       public UInt32  DCCW1;			//  DCCW2 DCCW1 DCCW0 �����������(��S)
       public UInt32  DCCW2;			// 	  0		0	  0		  10         	  1	 0  0		1000
                                        // 	  0		0	  1		  20			  1	 0  1		2000
                                        // 	  0		1	  0		  100			  1	 1  0		10000
                                        // 	  0		1	  1		  200			  1	 1  1		20000
    } 

    // �Զ�ԭ����Ѱ����
    public struct USB1020_PARA_AutoHomeSearch
    {
    public UInt32  ST1E;			// 1����һ��ʹ�� 0����Ч
    public UInt32  ST1D;			// ��һ������Ѱ��ת���� 0��������  1��������
    public UInt32  ST2E;			// 1���ڶ���ʹ�� 0����Ч
    public UInt32  ST2D;			// �ڶ�������Ѱ��ת���� 0��������  1��������
    public UInt32  ST3E;			// 1��������ʹ�� 0����Ч
    public UInt32   ST3D;			// ����������Ѱ��ת���� 0��������  1��������
    public UInt32  ST4E;			// 1�����Ĳ�ʹ�� 0����Ч
    public UInt32  ST4D;			// ���Ĳ�����Ѱ��ת���� 0��������  1��������
    public UInt32  PCLR;			// 1�����Ĳ�����ʱ����߼���������ʵλ������ 0����Ч
    public UInt32  SAND;			// 1��ԭ���źź�Z���ź���Чʱֹͣ���������� 0����Ч 
    public UInt32  LIMIT;			// 1������Ӳ����λ�ź�(nLMTP��nLMPM)����ԭ����Ѱ 0����Ч
    public UInt32  HMINT;			// 1�����Զ�ԭ����������ʱ�����ж� 0����Ч
    } 

    // IO���
    public struct USB1020_PARA_DO      
    {
       public UInt32  OUT0;			// ���0
       public UInt32  OUT1;			// ���1
       public UInt32  OUT2;			// ���2
       public UInt32  OUT3;			// ���3
       public UInt32  OUT4;			// ���4
       public UInt32  OUT5;			// ���5
       public UInt32  OUT6;			// ���6
       public UInt32  OUT7;			// ���7
    } 

    // ״̬�Ĵ���RR0
    public struct USB1020_PARA_RR0      
    {
	    public UInt32 XDRV;			// X�������״̬  1������������� 0��ֹͣ����
	    public UInt32 YDRV;			// Y�������״̬  1������������� 0��ֹͣ����
	    public UInt32 ZDRV;			// Z�������״̬  1������������� 0��ֹͣ����
	    public UInt32 UDRV;			// U�������״̬  1������������� 0��ֹͣ����
	    public UInt32 XERROR;		// X��ĳ���״̬  X���RR2�Ĵ������κ�һλΪ1����λ��Ϊ1
	    public UInt32 YERROR;		// Y��ĳ���״̬  Y���RR2�Ĵ������κ�һλΪ1����λ��Ϊ1
	    public UInt32 ZERROR;		// Z��ĳ���״̬  Z���RR2�Ĵ������κ�һλΪ1����λ��Ϊ1
	    public UInt32 UERROR;		// U��ĳ���״̬  U���RR2�Ĵ������κ�һλΪ1����λ��Ϊ1
	    public UInt32 IDRV;			// �岹����״̬   1�������ڲ岹ģʽ  0��δ���ڲ岹ģʽ
	    public UInt32 CNEXT;			// ��ʾ����д�������岹����һ������  1������д�� 0��������д��
	                        // �����������岹�ж�ʹ�ܺ�CNEXTΪ1��ʾ�������жϣ����жϳ���д����һ���岹����󣬸�λ���㲢���ж��źŻص��ߵ�ƽ
	    public UInt32 ZONE0;			// ZONE2��ZONE1��ZONE0��ʾ��Բ���岹���������ڵ�����
	    public UInt32 ZONE1;			// 000 ����0����   001����1����  010����2����  011����3����
	    public UInt32 ZONE2;			// 100 ����4����   101����5����	 110����6����  111����7����
	    public UInt32 BPSC0;			// BPSC1��BPSC0��ʾ��λ�岹�����ж�ջ������(SC)����ֵ
	    public UInt32 BPSC1;			// 00�� 0   01��1   10�� 2   11��3
						    // ����λ�岹�ж�ʹ�ܺ󣬵�SC��ֵ��2��Ϊ1ʱ�������жϣ�
	                        // ����λ�岹��ջд���µ����ݻ����USB1020_ClearInterruptStatus���жϽ����
    } 

    // ״̬�Ĵ���RR1��ÿһ���ᶼ��RR1�Ĵ��������ĸ�Ҫָ�����
    public struct USB1020_PARA_RR1    
    {
          public UInt32  XDRV;			// X�������״̬  1������������� 0��ֹͣ����
          public UInt32  YDRV;			// Y�������״̬  1������������� 0��ֹͣ����
          public UInt32 ZDRV;			// Z�������״̬  1������������� 0��ֹͣ����
          public UInt32  UDRV;			// U�������״̬  1������������� 0��ֹͣ����
          public UInt32  XERROR;		// X��ĳ���״̬  X���RR2�Ĵ������κ�һλΪ1����λ��Ϊ1
          public UInt32  YERROR;		// Y��ĳ���״̬  Y���RR2�Ĵ������κ�һλΪ1����λ��Ϊ1
          public UInt32  ZERROR;		// Z��ĳ���״̬  Z���RR2�Ĵ������κ�һλΪ1����λ��Ϊ1
          public UInt32  UERROR;		// U��ĳ���״̬  U���RR2�Ĵ������κ�һλΪ1����λ��Ϊ1
          public UInt32  IDRV;			// �岹����״̬   1�������ڲ岹ģʽ  0��δ���ڲ岹ģʽ
          public UInt32  CNEXT;			// ��ʾ����д�������岹����һ������  1������д�� 0��������д��
                                        // �����������岹�ж�ʹ�ܺ�CNEXTΪ1��ʾ�������жϣ����жϳ���д����һ���岹����󣬸�λ���㲢���ж��źŻص��ߵ�ƽ
            public UInt32  ZONE0;			// ZONE2��ZONE1��ZONE0��ʾ��Բ���岹���������ڵ�����
            public UInt32  ZONE1;			// 000 ����0����   001����1����  010����2����  011����3����
            public UInt32  ZONE2;			// 100 ����4����   101����5����	 110����6����  111����7����
            public UInt32 BPSC0;			// BPSC1��BPSC0��ʾ��λ�岹�����ж�ջ������(SC)����ֵ
            public UInt32  BPSC1;			// 00�� 0   01��1   10�� 2   11��3
                                            // ����λ�岹�ж�ʹ�ܺ󣬵�SC��ֵ��2��Ϊ1ʱ�������жϣ�
                                            // ����λ�岹��ջд���µ����ݻ����USB1020_ClearInterruptStatus���жϽ����
    } 

    // ״̬�Ĵ���RR2��ÿһ���ᶼ��RR2�Ĵ��������ĸ�Ҫָ�����

    public struct USB1020_PARA_RR2     
    {
	    public UInt32 SLMTP;			// ���������������λ���������������У��߼�/ʵλ����������COMP+�Ĵ���ֵʱ��Ϊ1
	    public UInt32 SLMTM;			// ���÷����������λ���ڷ����������У��߼�/ʵλ������С��COMP-�Ĵ���ֵʱ��Ϊ1
	    public UInt32 HLMTP;			// �ⲿ�����������ź�(nLMTP)������Ч��ƽʱ��Ϊ1
	    public UInt32 HLMTM;			// �ⲿ�����������ź�(nLMTM)������Ч��ƽʱ��Ϊ1
	    public UInt32 ALARM;			// �ⲿ�ŷ���ﱨ���ź�(nALARM)����Ϊ��Ч��������Ч״̬ʱ��Ϊ1
	    public UInt32 EMG;			// �ⲿ����ֹͣ�źŴ��ڵ͵�ƽʱ��Ϊ1
	    public UInt32 HOME;			// ��Z������ź����Զ���Ѱԭ�����ʱΪ1
	    public UInt32 HMST0;			// HMST0-4(HMST4-0)��ʾ�Զ�ԭ����Ѱ��ִ�еĲ���
	    public UInt32 HMST1;			//	 0���ȴ��Զ�ԭ����Ѱ����
	    public UInt32 HMST2;			//	 3���ȴ�IN0�ź���ָ����������Ч	
	    public UInt32 HMST3;			//	 8��12��15���ȴ�IN1�ź���ָ����������Ч
	    public UInt32 HMST4;			//	 20��IN2�ź���ָ����������Ч
						    //	 25�����Ĳ�
    } 

    // ״̬�Ĵ���RR3
    public struct USB1020_PARA_RR3      
    {
	    public UInt32 XIN0;			// �ⲿֹͣ�ź�XIN0�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 XIN1;			// �ⲿֹͣ�ź�XIN1�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 XIN2;			// �ⲿֹͣ�ź�XIN2�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 XIN3;			// �ⲿֹͣ�ź�XIN3�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 XEXPP;			// �ⲿ������㶯�����ź�XEXPP�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 XEXPM;			// �ⲿ������㶯�����ź�XEXPM�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 XINPOS;		// �ⲿ�ŷ������λ�ź�XINPOS�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 XALARM;		// �ⲿ�ŷ���ﱨ���ź�XALARM�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 YIN0;			// �ⲿ�����ź�YIN0�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 YIN1;			// �ⲿ�����ź�YIN1�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 YIN2;			// �ⲿ�����ź�YIN2�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 YIN3;			// �ⲿ�����ź�YIN3�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 YEXPP;			// �ⲿ������㶯�����ź�YEXPP�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 YEXPM;			// �ⲿ������㶯�����ź�YEXPM�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 YINPOS;		// �ⲿ�ŷ������λ�ź�YINPOS�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 YALARM;		// �ⲿ�ŷ���ﱨ���ź�YALARM�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
    } 

    // ״̬�Ĵ���RR4
    public struct USB1020_PARA_RR4     
    {
	    public UInt32 ZIN0;			// �ⲿֹͣ�ź�YIN0�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 ZIN1;			// �ⲿֹͣ�ź�YIN1�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 ZIN2;			// �ⲿֹͣ�ź�YIN2�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 ZIN3;			// �ⲿֹͣ�ź�YIN3�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 ZEXPP;			// �ⲿ������㶯�����ź�ZEXPP�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 ZEXPM;			// �ⲿ������㶯�����ź�ZEXPM�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 ZINPOS;		// �ⲿ�ŷ������λ�ź�ZINPOS�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 ZALARM;		// �ⲿ�ŷ���ﱨ���ź�ZALARM�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 UIN0;			// �ⲿֹͣ�ź�UIN0�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 UIN1;			// �ⲿֹͣ�ź�UIN1�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 UIN2;			// �ⲿֹͣ�ź�UIN2�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 UIN3;			// �ⲿֹͣ�ź�UIN3�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 UEXPP;			// �ⲿ������㶯�����ź�UEXPP�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 UEXPM;			// �ⲿ������㶯�����ź�UEXPM�ĵ�ƽ״̬ 1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 UINPOS;		// �ⲿ�ŷ������λ�ź�UINPOS�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
	    public UInt32 UALARM;		// �ⲿ�ŷ���ﱨ���ź�UALARM�ĵ�ƽ״̬  1���ߵ�ƽ 0���͵�ƽ
    } 

    // ״̬�Ĵ���RR5  �����жϲ���ʱ����Ӧ���жϱ�־Ϊ1���ж�����ź�Ϊ�͵�ƽ
    // ����CPU����RR5�Ĵ������жϱ�־��RR5�ı�־��Ϊ0���ж��źŻָ����ߵ�ƽ
    public struct USB1020_PARA_RR5     
    {
	    public UInt32 PULSE;			// ����һ����������ʱΪ1
	    public UInt32 PBCM;			// �߼�/ʵ��λ�ü�������ֵ���ڵ���COMP-�Ĵ�����ֵʱΪ1
	    public UInt32 PSCM;			// �߼�/ʵ��λ�ü�������ֵС��COMP-�Ĵ�����ֵʱΪ1
	    public UInt32 PSCP;			// �߼�/ʵ��λ�ü�������ֵС��COMP+�Ĵ�����ֵʱΪ1
	    public UInt32 PBCP;			// �߼�/ʵ��λ�ü�������ֵ���ڵ���COMP+�Ĵ�����ֵΪ1
	    public UInt32 CDEC;			// �ڼ�/����ʱ�����忪ʼ����ʱΪ1
	    public UInt32 CSTA;			// �ڼ�/����ʱ����ʼ����ʱΪ1
	    public UInt32 DEND;			// ��������ʱΪ1
	    public UInt32 HMEND;			// �Զ�ԭ����������ʱΪ1
	    public UInt32 SYNC;			// ͬ���������ж�
    } 

    //######################## �豸��������� #################################
    // �����ڱ��豸�����������	
    
    [DllImport("USB1020_64.DLL")]
public static extern  IntPtr  USB1020_CreateDevice(			// �������
							int DeviceID);				// �豸ID��
     [DllImport("USB1020_64.DLL")]
public static extern int  USB1020_GetDeviceCount(			// ����豸����
							IntPtr hDevice);			// �豸���
     [DllImport("USB1020_64.DLL")]
public static extern int  USB1020_GetDeviceCurrentID(		// ȡ�õ�ǰ�豸������ID�ź��߼�ID��
							IntPtr hDevice,				// �豸���
							ref  Int32  lpDeviceLgcID,		// �߼�ID��
							ref  Int32  lpDevicePhysID);		// ����ID��
     [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_ReleaseDevice(			// �ͷ��豸
							IntPtr hDevice);			// �豸���
     [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_Reset(				 // ��λ����USB�豸
							IntPtr  hDevice);		 // �豸���
    //*******************************************************************
    // ���õ�����߼���������ʵ��λ�ü����������ټ�����ƫ��
        
         [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_PulseOutMode(         // �����������ģʽ
						IntPtr hDevice,			 // �豸���
						Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)  
						Int32 Mode,				 // ģʽ
					    Int32 PLSLogLever,		 // �趨��������ķ���Ĭ��������
					    Int32 DIRLogLever);		 // �趨�����ź�������߼���ƽ��0���͵�ƽΪ����1���ߵ�ƽΪ����
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_PulseInputMode(       // ������������ģʽ
							IntPtr hDevice,			 // �豸���
						    Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)  
				            Int32 Mode);				 // ģʽ
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_SetR(				 // ���ñ���(1-500)	
						IntPtr hDevice,			 // �豸���
						Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)  
						Int32 Data);				 // ����ֵ(1-500)
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_SetA(				 // ���ü��ٶ�
						IntPtr hDevice,			 // �豸���
						Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)     
						Int32 Data);				 // ���ٶ�(125-1000000)
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean  USB1020_SetDec(				 // ���ü��ٶ�
						IntPtr hDevice,			 // �豸���
						Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						Int32  Data);				 // ���ٶ�ֵ(125-1000000)
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_SetAccIncRate(		 // ���ٶȱ仯��  
							IntPtr hDevice,			 // �豸���
						    Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)   
						    Int32 Data);				 // ����(954-62500000)
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean  USB1020_SetDecIncRate(		 // ���ٶȱ仯��  
						IntPtr hDevice,			 // �豸���
					    Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						Int32  Data);				 // ����
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean  USB1020_SetSV(				 // ���ó�ʼ�ٶ�
						IntPtr hDevice,			 // �豸���
						Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)   
						Int32  Data);				 // �ٶ�ֵ
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_SetV(				 // ���������ٶ�
					IntPtr hDevice,			 // �豸���
					Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)     
				    Int32 Data);				 // �����ٶ�ֵ
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean  USB1020_SetHV(				 // ����ԭ����Ѱ�ٶ�
					    IntPtr hDevice,			 // �豸���
						Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)	
						Int32 Data);				 // ԭ����Ѱ�ٶ�ֵ(1-8000)
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean  USB1020_SetP(				 // ���ö���������
					        IntPtr hDevice,			 // �豸���
							Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
							Int32  Data);			     // ����������(0-268435455)
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_SetIP(				 // ���ò岹�յ�������(-8388608-+8388607)
					IntPtr hDevice,			 // �豸���
					Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
				    Int32  Data);				 // �岹�յ�������(-8388608-+8388607)
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_SetC(                 // ����Բ������(������)  
							IntPtr hDevice,			 // �豸���
                            Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
                            Int32 Data);				 // Բ��������������Χ(-2147483648-+2147483647)
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_SetLP(				 // �����߼�λ�ü�����
                        IntPtr hDevice,			 // �豸���
                        Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
                            Int32 Data);				 // �߼�λ�ü�����ֵ(-2147483648-+2147483647)
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_SetEP(				 // ����ʵλ������ 
                        IntPtr hDevice,			 // �豸���
                        Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
                        Int32 Data);				 // ʵλ������ֵ(-2147483648-+2147483647)
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_SetAccofst(			 // ���ü��ټ�����ƫ��
                        IntPtr hDevice,			 // �豸���
                            Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
                        Int32 Data);				 // ƫ�Ʒ�Χ(0-65535)
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_SelectLPEP(			 // ѡ���߼���������ʵλ������
                                IntPtr hDevice,			 // �豸���
                                Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
                                Int32 LogicFact);		 // ѡ���߼�λ�ü�������ʵλ������ USB1020_LOGIC���߼�λ�ü����� USB1020_FACT��ʵλ������	
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_SetCOMPP(			 // ����COMP+�Ĵ���
                                IntPtr hDevice,			 // �豸��
                                Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)  
							    UInt16 LogicFact,		 // ѡ���߼�λ�ü�������ʵλ������ USB1020_LOGIC���߼�λ�ü����� USB1020_FACT��ʵλ������	
                                Int32 Data);
 [DllImport("USB1020_64.DLL")]
 public static extern Boolean  USB1020_SetCOMPM(			 // ����COMP-�Ĵ���
                            IntPtr hDevice,			 // �豸��
                            Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						    UInt16 LogicFact,		 // ѡ���߼�λ�ü�������ʵλ������ USB1020_LOGIC���߼�λ�ü����� USB1020_FACT��ʵλ������	
                        Int32 Data);
    //*******************************************************************
    // ����ͬ��λ
        [DllImport("USB1020_64.DLL")]
    public static extern Boolean  USB1020_SetSynchronAction(	 // ����ͬ��λ
						IntPtr hDevice,			 // �豸���
						Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						ref USB1020_PARA_SynchronActionOwnAxis pPara1,// �Լ���Ĳ�������
						ref USB1020_PARA_SynchronActionOtherAxis pPara2);// ������Ĳ�������
        [DllImport("USB1020_64.DLL")]
    public static extern Boolean USB1020_SynchronActionDisable(// ����ͬ��λ��Ч
                            IntPtr hDevice,			 // �豸���
						Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)
						ref USB1020_PARA_SynchronActionOwnAxis pPara1,// �Լ���Ĳ�������
						ref USB1020_PARA_SynchronActionOtherAxis pPara2);// ������Ĳ�������
        [DllImport("USB1020_64.DLL")]
     public static extern Boolean USB1020_WriteSynchronActionCom(// дͬ����������
                        IntPtr hDevice,			 // �豸���
						Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 

    //*******************************************************************
    //  ����DCC������ģʽ

        [DllImport("USB1020_64.DLL")]     
 public static extern Boolean USB1020_SetDCC(				 // ��������ź�nDCC�������ƽ�͵�ƽ���
							IntPtr hDevice,			 // �豸���
						Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						ref USB1020_PARA_DCC pPara);// DCC�źŲ����ṹ��ָ��
        [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_StartDCC(			   // ����ƫ�����������������
                        IntPtr hDevice,			   // �豸���
						Int32  AxisNum);			   // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
        [DllImport("USB1020_64.DLL")]
 public static extern Boolean  USB1020_ExtMode(				   // ��������ģʽ
                        IntPtr hDevice,			   // �豸���
						Int32  AxisNum,			   // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						ref USB1020_PARA_ExpMode pPara);// ���������ṹ��ָ��
    //*******************************************************************
    // �����Զ�ԭ����Ѱ
        [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_SetInEnable(			// �����Զ�ԭ����Ѱ��һ���ڶ����������ⲿ�����ź�IN0-2����Ч��ƽ
					IntPtr  hDevice,			// �豸��
					Int32  AxisNum,			// ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)	
                    Int32 InNum,				// ֹͣ��
			        Int32 LogLever);			// ��Ч��ƽ
        [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_SetAutoHomeSearch(   // �����Զ�ԭ����Ѱ����
					IntPtr hDevice,			// �豸���
                    Int32 AxisNum,			// ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)
				    ref USB1020_PARA_AutoHomeSearch pPara);// �Զ���Ѱԭ������ṹ��ָ��
        [DllImport("USB1020_64.DLL")]
 public static extern Boolean USB1020_StartAutoHomeSearch( // �����Զ�ԭ����Ѱ
                        IntPtr hDevice,			// �豸���		
                        Int32 AxisNum);			// ���(1:X��; 2:Y��)	
    //*******************************************************************
    // ���ñ����������ź�����
        [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_SetEncoderSignalType(// ���ñ����������ź�����
						IntPtr hDevice,			// �豸���
							Int32 AxisNum,			// ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)	
							Int32 Type,				// �����ź����� 0��2���������� 1����/����������
						    Int32  DivRatio);			// ����ı�Ƶ��
//*******************************************************************
// ֱ��S���߳�ʼ������������
        [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_InitLVDV(				// ��ʼ������,������������
                        IntPtr hDevice,				// �豸���
						ref USB1020_PARA_DataList pDL, // ���������ṹ��ָ��
						ref USB1020_PARA_LCData pLC);	// ֱ��S���߲����ṹ��ָ��
        [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_StartLVDV(				// ��������,������������
                        IntPtr hDevice,				// �豸���
				        Int32 AxisNum);				// ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
        [DllImport("USB1020_64.DLL")]
public static extern Boolean 	USB1020_Start4D(IntPtr  hDevice);// 4��ͬʱ����						           
//*******************************************************************
// ����2��ֱ�߲岹��ʼ������������
        [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_InitLineInterpolation_2D(// ��ʼ������2��ֱ�߲岹�˶� 
                        IntPtr hDevice,				// �豸���
						ref USB1020_PARA_DataList pDL, // ���������ṹ��ָ��
						ref USB1020_PARA_InterpolationAxis pIA,// �岹��ṹ��ָ��
					    ref USB1020_PARA_LineData pLD);// ֱ�߲岹�ṹ��ָ��
        [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_StartLineInterpolation_2D(// ��������2��ֱ�߲岹�˶� 
                        IntPtr hDevice);			 // �豸���
							
//*******************************************************************
// ����3��ֱ�߲岹��ʼ������������
        [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_InitLineInterpolation_3D(// ��ʼ������3��ֱ�߲岹�˶�	
                    IntPtr hDevice,				// �豸���
						ref USB1020_PARA_DataList pDL, // ���������ṹ��ָ��
						ref USB1020_PARA_InterpolationAxis pIA,// �岹��ṹ��ָ��
						ref USB1020_PARA_LineData pLD);// ֱ�߲岹�ṹ��ָ��
        [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_StartLineInterpolation_3D(// ��������3��ֱ�߲岹�˶� 				
                        IntPtr hDevice);			 // �豸���
	
//*******************************************************************
// ����2����������Բ���岹��ʼ������������
        [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_InitCWInterpolation_2D(	// ��ʼ������2����������Բ���岹�˶� 
                    IntPtr hDevice,				// �豸���
					ref USB1020_PARA_DataList pDL, // ���������ṹ��ָ��
					ref USB1020_PARA_InterpolationAxis pIA,// �岹��ṹ��ָ��
					ref USB1020_PARA_CircleData pCD);// Բ���岹�ṹ��ָ��
        [DllImport("USB1020_64.DLL")]           
public static extern Boolean  USB1020_StartCWInterpolation_2D( // ��������2������������Բ���岹�˶� 
                    IntPtr hDevice,				// �豸���
	                Int32  Direction);			// ���� ��ת��USB1020_PDIRECTION ��ת��USB1020_MDIRECTION  
        [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_SetCWRadius(				// ����Բ���뾶
                        IntPtr hDevice,				// �豸���
						Int32 mainCerter,			// ����Բ������
						Int32  secondCerter);         // �ڶ�����Բ������           
    //*************************************************************************
    // λ�岹��غ���
            [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_InitBitInterpolation_2D(	// ��ʼ������2��λ�岹����
							IntPtr hDevice,				// �豸���
							ref USB1020_PARA_InterpolationAxis pIA,// �岹��ṹ��ָ��
							ref USB1020_PARA_DataList pDL);// ���������ṹ��ָ��
             [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_InitBitInterpolation_3D(// ��ʼ������2��λ�岹����
						IntPtr  hDevice,			   // �豸���
						ref USB1020_PARA_InterpolationAxis pIA,// �岹��ṹ��ָ��
					ref USB1020_PARA_DataList pDL);// ���������ṹ��ָ��
             [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_AutoBitInterpolation_2D( // ��������2��λ�岹���߳�
					IntPtr  hDevice,				// �豸���
						ref Int16    pBuffer,				// λ�岹����ָ��	
						UInt32 nCount);				// ��������
             [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_AutoBitInterpolation_3D( // ��������3��λ�岹���߳�
							IntPtr hDevice,				// �豸���
						ref Int16  pBuffer,				// λ�岹����ָ��	
							UInt32  nCount);				// ��������
             [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_ReleaseBitInterpolation(	// �ͷ�BP�Ĵ���
						IntPtr hDevice);			// �豸���
             [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_SetBP_2D(                // ��������2��λ�岹����
						IntPtr hDevice,				// �豸��� 
						Int32  BP1PData,				// 1����������������
						Int32  BP1MData,				// 1�ᷴ������������
						Int32  BP2PData,				// 2����������������
						Int32  BP2MData);				// 2�ᷴ������������
             [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_SetBP_3D(				// ��������3��λ�岹����	
						IntPtr  hDevice,				// �豸���
						UInt32  BP1PData,			// 1����������������
						UInt32  BP1MData,			// 1�ᷴ������������
						UInt32  BP2PData,			// 2����������������
						UInt32  BP2MData,			// 2�ᷴ������������
						UInt32  BP3PData,			// 3����������������
						UInt16 BP3MData);			// 3�ᷴ������������
             [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_BPRegisterStack(			// BPλ���ݶ�ջ����ֵ
                            IntPtr hDevice);			// �豸���
             [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_StartBitInterpolation_2D(// ��������2��λ�岹
                        IntPtr hDevice);			// �豸���
             [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_StartBitInterpolation_3D(// ��������3��λ�岹
                          IntPtr hDevice);			// �豸���
             [DllImport("USB1020_64.DLL")]
public static extern Boolean   USB1020_BPWait(					// �ȴ�λ�岹����һ�������趨
                          IntPtr hDevice,				// �豸���
						ref Boolean pbRun);
             [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_ClearBPData(				// ���BP�Ĵ�������
                           IntPtr hDevice);			// �豸���
    //*******************************************************************
    // �����岹��غ���
             [DllImport("USB1020_64.DLL")]
 public static extern Boolean  USB1020_NextWait(				// �ȴ������岹��һ���ڵ������趨
						IntPtr hDevice);			// �豸���

//*******************************************************************
// �����岹����
             [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_SingleStepInterpolationCom(// ����������Ƶ����岹�˶�
					IntPtr  hDevice);			// �豸���	
             [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_StartSingleStepInterpolation(// ����������
						IntPtr hDevice);
             [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_SingleStepInterpolationExt(// �����ⲿ���Ƶ����岹�˶�
							IntPtr  hDevice);			// �豸���
             [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_ClearSingleStepInterpolation(// ��������岹����
						IntPtr  hDevice);			// �豸���
    
//*******************************************************************
// �ж�λ���á��岹�ж�״̬���
          [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_SetInterruptBit(			// �����ж�λ
						IntPtr hDevice,				// �豸���
							Int32 AxisNum,				// ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
					ref USB1020_PARA_Interrupt pPara);// �ж�λ�ṹ��ָ��
          [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_ClearInterruptStatus(	// ����岹�ж�״̬ 
							IntPtr hDevice);			// �豸���

//*******************************************************************
// �ⲿ�ź��������������������������
          [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_SetOutEnableDV(		 // �����ⲿʹ�ܶ�������(�½�����Ч)
					    IntPtr hDevice,			 // �豸���
						Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
		      [DllImport("USB1020_64.DLL")]                
public static extern Boolean  USB1020_SetOutEnableLV(		 // �����ⲿʹ����������(���ֵ͵�ƽ��Ч)
						IntPtr  hDevice,			 // �豸���
					    Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 

//*******************************************************************
// ���������λ��Ч����Ч
          [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_SetPDirSoftwareLimit( // ���������������λ
						IntPtr hDevice,			 // �豸���
						Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						Int32  LogicFact,			 // �߼�/ʵλ������ѡ�� USB1020_LOGIC���߼�λ�ü����� USB1020_FACT��ʵλ������	
						Int32  Data);				 // �����λ����
          [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_SetMDirSoftwareLimit( // ���÷����������λ
					IntPtr  hDevice,			 // �豸���
					Int32 AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
					Int32  LogicFact,			 // �߼�/ʵλ������ѡ�� USB1020_LOGIC���߼�λ�ü����� USB1020_FACT��ʵλ������	
					Int32  Data);				 
          [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_ClearSoftwareLimit(	 // ��������λ
						IntPtr  hDevice,			 // �豸���
						Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)

//******************************************************************* 
// �����ⲿ�����źŵ���Ч����Ч		
           [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_SetPDirLMTEnable(	 // �����ⲿԽ���źŵ���Ч��ֹͣ��ʽ	
						IntPtr hDevice,			 // �豸���
						Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						Int32  StopMode,           // USB1020_DECSTOP������ֹͣ��USB1020_SUDDENSTOP������ֹͣ
						Int32  LogLever);			 // ��Ч��ƽ��Ĭ�ϵ͵�ƽ��Ч��
           [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_SetMDirLMTEnable(	 // �����ⲿԽ���źŵ���Ч��ֹͣ��ʽ	
						IntPtr  hDevice,			 // �豸���
						Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						Int32  StopMode,           // USB1020_DECSTOP������ֹͣ��USB1020_SUDDENSTOP������ֹͣ
				        Int32  LogLever);			 // ��Ч��ƽ��Ĭ�ϵ͵�ƽ��Ч��
           [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_SetStopEnable(		 // �����ⲿֹͣ�ź���Ч
						IntPtr  hDevice,			 // �豸���
						Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						Int32  StopNum,			 // ֹͣ��
						Int32  LogLever);			 // ��Ч��ƽ��Ĭ�ϵ͵�ƽ��Ч��
           [DllImport("USB1020_64.DLL")]

public static extern Boolean USB1020_SetStopDisable(		 // �����ⲿֹͣ�ź���Ч
						    IntPtr  hDevice,			 // �豸���
							Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)
							Int32  StopNum);			 // ֹͣ��
           [DllImport("USB1020_64.DLL")]											
public static extern Boolean USB1020_SetALARMEnable(       // �����ŷ������ź���Ч 
						IntPtr hDevice,			 // �豸���
							Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)  
							Int32  LogLever);			 // ��Ч��ƽ��Ĭ�ϵ͵�ƽ��Ч��
           [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_SetALARMDisable(      // �����ŷ������ź���Ч  
							IntPtr hDevice,			 // �豸���
							Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)  
           [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_SetINPOSEnable(		 // �����ŷ���ﶨλ��������ź���Ч 
				IntPtr hDevice,			 // �豸���	
				Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
				Int32  LogLever);			 // ��Ч��ƽ��Ĭ�ϵ͵�ƽ��Ч��
           [DllImport("USB1020_64.DLL")]
public static extern Boolean  USB1020_SetINPOSDisable(		 // �����ŷ���ﶨλ��������ź���Ч
							IntPtr  hDevice,			 // �豸���
						    Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 

    //*******************************************************************
// ���ٺ�������
        [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_DecValid(			 // ������Ч
						IntPtr  hDevice);		 // �豸��
 [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_DecInvalid(			 // ������Ч
					IntPtr  hDevice);		 // �豸���
     [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_DecStop(				 // ����ֹͣ
							IntPtr  hDevice,			 // �豸���
						   Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)  
 [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_InstStop(			 // ����ֹͣ
							IntPtr  hDevice,			 // �豸���
					    	Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
 [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_AutoDec(				 // �Զ�����
						IntPtr  hDevice,			 // �豸���
						Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
 [DllImport("USB1020_64.DLL")]
public static extern Boolean USB1020_HanDec(				 // �ֶ����ٵ��趨
							IntPtr hDevice,			 // �豸���
							Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						    Int32 Data);				 // �ֶ����ٵ����ݣ���Χ(0 - 4294967295)

   //*************************************************************************
// �����״̬���߼���������ʵ��λ�ü���������ǰ�ٶȡ���/���ٶ�
         [DllImport("USB1020_64.DLL")]
  public static extern Int32  USB1020_ReadLP(				 // ���߼�������
							IntPtr  hDevice,			 // �豸���
							Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
         [DllImport("USB1020_64.DLL")]
  public static extern Int32  USB1020_ReadEP(				 // ��ʵλ������
					IntPtr hDevice,			 // �豸���
				    Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
         [DllImport("USB1020_64.DLL")]
  public static extern Int32  USB1020_ReadBR(				 // ��ͬ������Ĵ���
								IntPtr hDevice,			 // �豸���
							    Int32 AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)
         [DllImport("USB1020_64.DLL")]
  public static extern Int32  USB1020_ReadCV(				 // ����ǰ�ٶ�
								IntPtr hDevice,			 // �豸���
						    	Int32  AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
         [DllImport("USB1020_64.DLL")]
  public static extern Int32 USB1020_ReadCA(				 // ����ǰ���ٶ�
							IntPtr hDevice,			 // �豸���
					        Int32 AxisNum);			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��)

    //*******************************************************************
// ��������л���ͨ�����
        [DllImport("USB1020_64.DLL")]
 public static extern Boolean  USB1020_OutSwitch(			 // ��������л�
						IntPtr  hDevice,			 // �豸���
						Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						Int32  StatusGeneralOut);	 // ״̬�����ͨ�����ѡ�� USB1020_STATUS:״̬��� USB1020_GENERAL:ͨ�����
        [DllImport("USB1020_64.DLL")]
 public static extern  Boolean USB1020_SetDeviceDO(
						IntPtr hDevice,	 	 // �豸��
					    Int32  AxisNum,			 // ���
					    ref USB1020_PARA_DO pPara);
//*******************************************************************
// ��״̬�Ĵ�����λ״̬
        [DllImport("USB1020_64.DLL")]
 public static extern Int32 USB1020_ReadRR(				 // ��RR�Ĵ���
							IntPtr  hDevice,			 // �豸���
							Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						    Int32  Num);				 // �Ĵ�����
        [DllImport("USB1020_64.DLL")]
 public static extern Int32 USB1020_GetRR0Status(		 // �����״̬�Ĵ���RR0��λ״̬
							IntPtr  hDevice,			 // �豸���
							ref USB1020_PARA_RR0 pPara);// RR0�Ĵ���״̬
        [DllImport("USB1020_64.DLL")]
 public static extern Int32  USB1020_GetRR1Status(		 // ���״̬�Ĵ���RR1��λ״̬
						IntPtr  hDevice,			 // �豸���
						Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						ref USB1020_PARA_RR1 pPara);// RR1�Ĵ���״̬			
        [DllImport("USB1020_64.DLL")]
 public static extern Int32  USB1020_GetRR2Status(		 // ���״̬�Ĵ���RR2��λ״̬
						IntPtr  hDevice,			 // �豸���
						Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
						ref USB1020_PARA_RR2 pPara);// RR2�Ĵ���״̬			
        [DllImport("USB1020_64.DLL")]
 public static extern Int32  USB1020_GetRR3Status(		 // ���״̬�Ĵ���RR3��λ״̬
							IntPtr  hDevice,			 // �豸���
							ref USB1020_PARA_RR3 pPara);// RR3�Ĵ���״̬			
        [DllImport("USB1020_64.DLL")]
 public static extern Int32  USB1020_GetRR4Status(		 // ���״̬�Ĵ���RR4��λ״̬
							IntPtr  hDevice,			 // �豸���
						    ref USB1020_PARA_RR4 pPara);// RR4�Ĵ���״̬
        [DllImport("USB1020_64.DLL")]
 public static extern Int32 USB1020_GetRR5Status(
							IntPtr  hDevice,			 // �豸��
						    Int32  AxisNum,			 // ���(USB1020_XAXIS:X��,USB1020_YAXIS:Y��, USB1020_ZAXIS:Z��,USB1020_UAXIS:U��) 
							ref USB1020_PARA_RR5 pPara);// RR5�Ĵ���״̬


    }
}
