using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;  // For DLL import
using ZedGraph; // For graphing stuff - ZedGraph used here....

namespace Pedal_Power_Interface_v2
{
    public partial class Form1 : Form
    {
        // This function gets the version number of the DLL
        [DllImport("mpusbapi.dll")]
        private static extern int _MPUSBGetDLLVersion();

        // Ths function counts the number of devices on the USB
        [DllImport("mpusbapi.dll")]
        private static extern int _MPUSBGetDeviceCount(byte[] array);

        // This opens a link to the PIC
        [DllImport("mpusbapi.dll")]
        private static extern IntPtr _MPUSBOpen(int a, byte[] b, byte[] c, int d, int e);
        [DllImport("mpusbapi.dll")]
        private static extern IntPtr _MPUSBWrite(IntPtr a, byte[] b, int c, ref int d, int e);
        [DllImport("mpusbapi.dll")]
        private static extern IntPtr _MPUSBRead(IntPtr a, byte[] b, int c, ref int d, int e);
        [DllImport("mpusbapi.dll")]
        private static extern IntPtr _MPUSBReadInt(IntPtr a, byte[] b, int c, int[] d, int e);
        [DllImport("mpusbapi.dll")]
        private static extern bool _MPUSBClose(IntPtr a);

        //************* These are the global variables ***************************************//    
        private static IntPtr outPipe;  // Pointer for the outpipe
        private static IntPtr inPipe;   // Pointer for the in pipe
        private enum MP_MODE { MP_WRITE, MP_READ }; // List of modes that the pipes can be in

        bool AttachedState = false;
        bool opened_usb = false;
        double energy_max;

        string voltage_str;     // The voltage value XX.X
        string current_str;     // The current value XX.X
        string power_str;       // The power value XXX.X
        string energy_str;      // The energy value in the form XXXXX.XX
        string max_power_str;   // The maximum power in the form XXXXX.XX
        string ave_power_str;   // The average power in the form XXXXX.XX
        string time_str;        // The time in the form xxhxxmxxs

        // This is the default PIC vendor and product id numbers
        byte[] vid_pid = Encoding.ASCII.GetBytes("vid_04d8&pid_000c");
        // This is the output data stream pipe (End Point 1)
        byte[] out_pipe = Encoding.ASCII.GetBytes("\\MCHP_EP1");
        // This is the input data stream pipe (End Point 1)
        byte[] in_pipe = Encoding.ASCII.GetBytes("\\MCHP_EP1");


        public Form1()
        {
            InitializeComponent();
            InitialiseGraph();
        }

        private void InitialiseGraph()
        {
            //******** Initialise the graph**************
            GraphPane myPane = zgc1.GraphPane;
            myPane.Title.IsVisible = false;
            myPane.XAxis.Title.Text = "Time (S)";
            myPane.YAxis.Title.Text = "Power (W)";
            // Change the color of the title
            myPane.YAxis.Title.FontSpec.FontColor = Color.Blue;

            myPane.Y2Axis.Title.Text = "Energy (Wh)";
            // Change the color of the title
            myPane.Y2Axis.Title.FontSpec.FontColor = Color.Red;
            myPane.Y2Axis.IsVisible = true;

            // Save 1200 points.  At 50 ms sample rate, this is one minute
            // The RollingPointPairList is an efficient storage class that always
            // keeps a rolling set of point data without needing to shift any data values
            RollingPointPairList energy_list = new RollingPointPairList(60000);
            RollingPointPairList power_list = new RollingPointPairList(60000);

            // Initially, a curve is added with no data points (list is empty)
            // Color is blue, and there will be no symbols
            LineItem curve1 = myPane.AddCurve("ENERGY", energy_list, Color.Blue, SymbolType.None);
            curve1.Label.IsVisible = false;
            LineItem curve2 = myPane.AddCurve("POWER", power_list, Color.Red, SymbolType.None);
            curve2.Label.IsVisible = false;

            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;

            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.IsOpposite = false;

            // Scale the axes
            zgc1.AxisChange();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //int test = _MPUSBGetDLLVersion();

            int count = _MPUSBGetDeviceCount(vid_pid); // This checks for a connection

            if ((count >= 1)&&(opened_usb==false))
            {
                // This case if there is a connection

                //ConnectData.Text = "Connected to Power Meter";
                AttachedState = true; // tell the global variable so this can be used to make decisions
                LED1.Text=("ATTACHED");
                LED1.BackColor = Color.Lime;
                // If there is a connection then you want to open the in and out pipes for EP1
                // The generic code is _MPUSBOpen( device number, vid_pid, end point, type of connection (0=write(out),1=read(in))
                outPipe = _MPUSBOpen(0, vid_pid, out_pipe, (int)MP_MODE.MP_WRITE, 0);
                inPipe = _MPUSBOpen(0, vid_pid, in_pipe, (int)MP_MODE.MP_READ, 0);
                opened_usb = true;

                //MessageBox.Show("Opened Data Pipes - Communications start ");
                txtest.Text = "Opening....";
            }
            else if (count < 1)
            {
                // This is the case if the device has been unplugged

                //MessageBox.Show("Failed to open data pipes...please try again");
                //ConnectData.Text = "No Connection";
                    
                // Must close the pipe we have opened so that there are no errors
                bool close;
                close = _MPUSBClose(outPipe);
                close = _MPUSBClose(inPipe);

                AttachedState = false; // tell the global variable so this can be used to make decisions
                LED1.Text = ("DISCONNECTED");
                LED1.BackColor = Color.Red;
                // Application.Exit(); // This will close the form if required
                opened_usb = false;
                txtest.Text = "Disconnected and closed";
            }
            else if (AttachedState == true&&opened_usb==true)
            {
                txtest.Text = "Attached and OK";
                byte[] pipeOutData = new byte[3];  // This defines the size (6 bytes) of the output data message (pipeOut)
                byte[] pipeInData = new byte[50];    // This is the incmming data array (pipeIn).

                // This is where we send a command
                pipeOutData[0] = 0x43;  //Send value to return data

                // Data arrives as:
                // VoltStr[0:3], I_out_Str[0:4], P_O_Str[0:4], E_O_Str[0:6]
                // P_Max_Str[0:6], P_Ave_Str[0:6], temp_run_time_s_str[0:9]
       
                // It must be big enough to contain all the data expected on the pipe.
                int ActualLength = 0;   // Not sure why you need an actual length????

                // The _MPUSBWrite takes the inputs (outpipe pointer, outpipe data to send, length of data, Sent data length, Receive Delay)
                _MPUSBWrite(outPipe, pipeOutData, 3, ref ActualLength, 100);	//Send the command now over USB  

                // The _MPUSBRead takes the inputs (inpipe pointer, inpipe data, length of data, Sent data length, Receive Delay)            
                _MPUSBRead(inPipe, pipeInData, 50, ref ActualLength, 100);	//Receive the answer from the device firmware through USB

                // Now want to re-create the data as a full string (eg. 52.7)

                voltage_str = string.Concat(Convert.ToChar(pipeInData[1]), Convert.ToChar(pipeInData[2]), Convert.ToChar(pipeInData[3]), Convert.ToChar(pipeInData[4]));

                current_str = string.Concat(Convert.ToChar(pipeInData[5]), Convert.ToChar(pipeInData[6]), Convert.ToChar(pipeInData[7]), Convert.ToChar(pipeInData[8]), Convert.ToChar(pipeInData[9]));
                
                power_str = string.Concat(Convert.ToChar(pipeInData[10]), Convert.ToChar(pipeInData[11]), Convert.ToChar(pipeInData[12]), Convert.ToChar(pipeInData[13]), Convert.ToChar(pipeInData[14]));
                txPOWER.Text = power_str;

                energy_str = string.Concat(Convert.ToChar(pipeInData[15]), Convert.ToChar(pipeInData[16]), Convert.ToChar(pipeInData[17]), Convert.ToChar(pipeInData[18]), Convert.ToChar(pipeInData[19]), Convert.ToChar(pipeInData[20]), Convert.ToChar(pipeInData[21]));
                txENERGY.Text = energy_str;

                max_power_str = string.Concat(Convert.ToChar(pipeInData[22]), Convert.ToChar(pipeInData[23]), Convert.ToChar(pipeInData[24]), Convert.ToChar(pipeInData[25]), Convert.ToChar(pipeInData[26]));
                txMAX_POWER.Text = max_power_str;

                ave_power_str = string.Concat(Convert.ToChar(pipeInData[27]), Convert.ToChar(pipeInData[28]), Convert.ToChar(pipeInData[29]), Convert.ToChar(pipeInData[30]), Convert.ToChar(pipeInData[31]));
                txAVE_POWER.Text = ave_power_str;

                
                // This is a bodge to try and fix a problem with random data left in the pipe
                // This should be fixed on the PIC side of things by nulling all values
                //for (int n = 32; n <= 39; n++)
                //{
                    //if (pipeInData[n] == 0)
                    //{
                     //   pipeInData[n + 1] = 0;
                    //}
                //}
                
                time_str = string.Concat(Convert.ToChar(pipeInData[32]), Convert.ToChar(pipeInData[33]), Convert.ToChar(pipeInData[34]), Convert.ToChar(pipeInData[35]), Convert.ToChar(pipeInData[36]), Convert.ToChar(pipeInData[37]), Convert.ToChar(pipeInData[38]), Convert.ToChar(pipeInData[39]));

                tx1.Text = Convert.ToString(pipeInData[32]);
                tx2.Text = Convert.ToString(pipeInData[33]);
                tx3.Text = Convert.ToString(pipeInData[34]);
                tx4.Text = Convert.ToString(pipeInData[35]);
                tx5.Text = Convert.ToString(pipeInData[36]);
                tx6.Text = Convert.ToString(pipeInData[37]);
                tx7.Text = Convert.ToString(pipeInData[38]);
                tx8.Text = Convert.ToString(pipeInData[39]);
                
                // Here the second data is processed to give minutes and second (not hours)
                double Num;
                double time_db;
                int time_sec=0;
                int time_min=0;
                string time_units_str;

                // This next line is a bit of a trick to check to see if the data is numeric - if not then
                // Device has been unplugged. This stops the program crashing at that point.
                
                bool isNum = double.TryParse(time_str, out Num);

                if (isNum)
                {
                   time_db = Convert.ToDouble(time_str);
                }
                else
                {
                    time_db = 0;
                    time_str = "0";
                }


                time_min = Convert.ToInt32( Math.Floor(time_db / 60) );
                time_sec = Convert.ToInt32( time_db - (time_min*60));

                time_units_str = string.Concat(Convert.ToString(time_min), 'm', ' ', Convert.ToString(time_sec), 's');

                txTIME.Text = time_units_str;

                //test.Text = time_units_str;
                // ***Must only use numbers - change PIC code to send as sinlge integer of seconds*****
                // ***Convert value to hrs/mins/srcs in this program

                // Display all the values for the diagnostics....
                textBox1.Text = voltage_str;
                textBox2.Text = current_str;
                textBox3.Text = power_str;
                textBox4.Text = energy_str;
                textBox5.Text = max_power_str;
                textBox6.Text = ave_power_str;
                textBox7.Text = time_str;

                //*************This is all for the graph test********************//
                double time;

                // if the time is zero then want to reset the graph etc...

                if (time_db==0)
                {

                    time = 0;
                    // Here want to clear the data on the curve/power_list

                    // Get the first CurveItem in the graph
                    LineItem curve1 = zgc1.GraphPane.CurveList[1] as LineItem;
                    // Get the PointPairList
                    IPointListEdit energy_list = curve1.Points as IPointListEdit;

                    // Get the first CurveItem in the graph
                    LineItem curve2 = zgc1.GraphPane.CurveList[0] as LineItem;
                    // Get the PointPairList
                    IPointListEdit power_list = curve2.Points as IPointListEdit;

                    power_list.Clear();
                    power_list.Add(time, 0);

                    energy_list.Clear();
                    energy_list.Add(time, 0);

                    Scale xScale = zgc1.GraphPane.XAxis.Scale;

                    xScale.Max = time + 5;
                    xScale.Min = 0;

                    // Make sure the Y axis is rescaled to accommodate actual data
                    zgc1.AxisChange();
                    // Force a redraw
                    zgc1.Refresh();

                    // Reset the maximum energy value for the scale
                    energy_max = 0;

                
                }
                else
                {
                    // ***Here want to use the value for seconds as the time base for the graph****
                    time = Convert.ToDouble(time_str);

                    // Get the first CurveItem in the graph
                    LineItem curve1 = zgc1.GraphPane.CurveList[1] as LineItem;
                    // Get the PointPairList
                    IPointListEdit energy_list = curve1.Points as IPointListEdit;
                    energy_list.Add(time, (Convert.ToDouble(energy_str)));
                    // Associate this curve with the Y2 axis
                    curve1.IsY2Axis = true;

                    // This finds the energy maximum to sort out the Y2axis scale
                    if (Convert.ToDouble(energy_str) > energy_max)
                    {
                        energy_max = Convert.ToDouble(energy_str);
                    }

                    // Get the first CurveItem in the graph
                    LineItem curve2 = zgc1.GraphPane.CurveList[0] as LineItem;
                    // Get the PointPairList
                    IPointListEdit power_list = curve2.Points as IPointListEdit;
                    power_list.Add(time, (Convert.ToDouble(power_str)));

                    // Make both curves thicker
                    curve1.Line.Width = 2.0F;
                    curve2.Line.Width = 2.0F;

                    // Fill the area under the curves
                    curve1.Line.Fill = new Fill(Color.White, Color.Red, 45F);
                    //curve2.Line.Fill = new Fill(Color.White, Color.Blue, 45F);

                    // Keep the X scale at a rolling 30 second interval, with one
                    // major step between the max X value and the end of the axis
                    Scale xScale = zgc1.GraphPane.XAxis.Scale;
                    Scale yScale = zgc1.GraphPane.YAxis.Scale;
                    Scale y2Scale = zgc1.GraphPane.Y2Axis.Scale;

                    xScale.Max = time + 5; 
                    xScale.Min = 0;

                    yScale.Min = 0;
                    
                    y2Scale.Min = 0;
                    y2Scale.Max = energy_max+2;

                    // Make sure the Y axis is rescaled to accommodate actual data
                    zgc1.AxisChange();
                    // Force a redraw
                    zgc1.Refresh();

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LED1.Font = new Font(LED1.Font.FontFamily, 12);
            txPOWER.Font = new Font(txPOWER.Font.FontFamily, 26);
            txPOWER.ForeColor = Color.Blue;
            txENERGY.Font = new Font(txENERGY.Font.FontFamily, 26);
            txENERGY.ForeColor = Color.Red;
            txTIME.Font = new Font(txTIME.Font.FontFamily, 26);
            txMAX_POWER.Font = new Font(txMAX_POWER.Font.FontFamily, 16);
            txAVE_POWER.Font = new Font(txAVE_POWER.Font.FontFamily, 16);

            Power_lbl.Font = new Font(Power_lbl.Font.FontFamily, 16, FontStyle.Bold);
            Power_lbl.ForeColor = Color.Blue;
            W_lbl.Font = new Font(Power_lbl.Font.FontFamily, 16, FontStyle.Bold);
            W_lbl.ForeColor = Color.Blue;
            Energy_lbl.Font = new Font(Energy_lbl.Font.FontFamily, 16, FontStyle.Bold);
            Energy_lbl.ForeColor = Color.Red;
            Wh_lbl.Font = new Font(Power_lbl.Font.FontFamily, 16, FontStyle.Bold);
            Wh_lbl.ForeColor = Color.Red;
            time_lbl.Font = new Font(time_lbl.Font.FontFamily, 16, FontStyle.Bold);
            max_power_lbl.Font = new Font(max_power_lbl.Font.FontFamily, 12);
            W_max_lbl.Font = new Font(max_power_lbl.Font.FontFamily, 12);
            ave_power_lbl.Font = new Font(ave_power_lbl.Font.FontFamily, 12);
            W_ave_lbl.Font = new Font(max_power_lbl.Font.FontFamily, 12);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.re-innovation.co.uk", null);
        }

    }
}
