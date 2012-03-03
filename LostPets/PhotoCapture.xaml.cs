using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Devices;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace LostPets
{
    public partial class PhotoCapture : PhoneApplicationPage
    {
        private PhotoCamera camera;
        
        public PhotoCapture()
        {
            InitializeComponent();
            StartCameraService();
        }

        private void CapturePicture(object sender, GestureEventArgs e) {
            throw new NotImplementedException();
        }

        private void StartCameraService()
        {
            camera = new PhotoCamera(CameraType.FrontFacing);
            // Event is fired when the PhotoCamera object has been initialized.
            /*camera.Initialized += cam_Initialized;

            // Event is fired when the capture sequence is complete and an image is available.
            camera.CaptureImageAvailable += cam_CaptureImageAvailable;
            camera.CaptureImageAvailable += cam_CaptureImageCompleted;

            // Event is fired when the capture sequence is complete and a thumbnail image is available.
            camera.CaptureThumbnailAvailable += cam_CaptureThumbnailAvailable;

            // The event is fired when auto-focus is complete.
            camera.AutoFocusCompleted += cam_AutoFocusCompleted;

            cameraInitialized = false;*/
            viewFinderBrush.SetSource(camera);
        }
    }
}