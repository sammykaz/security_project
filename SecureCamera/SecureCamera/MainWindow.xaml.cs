using System;
using System.Windows;
using Ozeki.Camera;


namespace SecureCamera
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GuiThread(Action action)
        {
            Dispatcher.BeginInvoke(action);
        }

        void GetIpCameras()
        {
            IPCameraFactory.DeviceDiscovered += IPCameraFactory_DeviceDiscovered;
            IPCameraFactory.DiscoverDevices();
        }

        private void IPCameraFactory_DeviceDiscovered(object sender, DiscoveryEventArgs e)
        {
            GuiThread(() => DiscoveredDeviceList.Items.Add("[IPCamera] Host: " + e.Device.Host + " Port: " + e.Device.Port));
        }

        private void DiscoverButton(object sender, RoutedEventArgs e)
        {
            DiscoveredDeviceList.Items.Clear();
            IPCameraFactory.DeviceDiscovered -= IPCameraFactory_DeviceDiscovered;
           
            GetIpCameras();
        }
    }
}
