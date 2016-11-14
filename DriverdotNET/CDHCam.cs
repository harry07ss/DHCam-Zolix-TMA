using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GxIAPINET;
using GxIAPINET.Sample.Common;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace DriverdotNET
{
    class CDHCam
    {
        IGXDevice m_objIGXDevice;
        IGXStream m_objIGXStream;
        IGXFeatureControl objIGXFeatureControl;
        public GxBitmap m_objGxBitmap;
        public delegate void OnBitmapCallbackFun(Bitmap img);
        public event OnBitmapCallbackFun onBitmapCallbackFun;
        public bool isOpen;
        String strSN;

        public CDHCam(int i, PictureBox pic_ShowImage)
        {
            List<IGXDeviceInfo> listGXDeviceInfo = new List<IGXDeviceInfo>();
            IGXFactory.GetInstance().UpdateAllDeviceList(200, listGXDeviceInfo);
            strSN = listGXDeviceInfo[i].GetSN();
            m_objIGXDevice = IGXFactory.GetInstance().OpenDeviceBySN(strSN, GX_ACCESS_MODE.GX_ACCESS_EXCLUSIVE);
            m_objGxBitmap = new GxBitmap(m_objIGXDevice, pic_ShowImage);
            isOpen = false;
        }

        private void OnFrameCallbackFun(object obj, IFrameData objIFrameData)
        {
            if (objIFrameData.GetStatus() == GX_FRAME_STATUS_LIST.GX_FRAME_STATUS_SUCCESS)
            {
                m_objGxBitmap.Show(objIFrameData);
                if(onBitmapCallbackFun!=null)
                {
                    onBitmapCallbackFun(m_objGxBitmap.Mbitmap);
                }             
            }

        }
        public bool __open()
        {
            try
            {
                
                m_objIGXStream = m_objIGXDevice.OpenStream(0);
                m_objIGXStream.RegisterCaptureCallback(m_objIGXDevice, OnFrameCallbackFun);
                objIGXFeatureControl = m_objIGXDevice.GetRemoteFeatureControl();
                objIGXFeatureControl.GetEnumFeature("AcquisitionMode").SetValue("Continuous");
                objIGXFeatureControl.GetEnumFeature("ExposureAuto").SetValue("Off");
                objIGXFeatureControl.GetFloatFeature("ExposureTime").SetValue(70000.0);
                objIGXFeatureControl.GetIntFeature("GevSCPSPacketSize").SetValue(3000);
                objIGXFeatureControl.GetIntFeature("GevSCPD").SetValue(100);
           
                isOpen = true;
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                isOpen = false;
                return false;
            }
 
        }
        public bool __start()
        {
            objIGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
            m_objIGXStream.StartGrab();
            return true;
        }
        public bool __stop()
        {
            objIGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
            m_objIGXStream.StopGrab();
            return true;
        }
        public bool __close()
        {
            m_objIGXStream.UnregisterCaptureCallback();
            m_objIGXStream.Close();
            m_objIGXDevice.Close();
            return true;
        }

    }
}
