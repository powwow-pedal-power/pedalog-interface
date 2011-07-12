/* Form1.cs
 *
 * Copyright (c) 2011 Renewable Energy Innovation (http://www.re-innovation.co.uk)
 *
 * This file is part of pedalog-interface.
 *
 * pedalog-interface is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * pedalog-interface is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with pedalog-interface.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;  // For DLL import
using ZedGraph; // For graphing stuff - ZedGraph used here....
using Pwpp.Pedalog;

namespace Pedal_Power_Interface_v2
{
    public partial class Form1 : Form
    {
		private Device[] devices;
		private double energy_max;

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
			
			this.Invalidate();
		}
		
        private void timer1_Tick(object sender, EventArgs e)
        {
			try
			{
				// Find all the connected Pedalog devices if we need to
				if (devices == null)
				{
					devices = Device.FindAll();
				}
	
	            if (devices.Length < 1)
	            {
	                // No device is connected, so check again next timer tick
					devices = null;
	
	                //MessageBox.Show("Failed to open data pipes...please try again");
	                //ConnectData.Text = "No Connection";
	            }
	            else
	            {
					Data? nullableData = devices[0].ReadData();
					
					if (nullableData.HasValue)
					{
						Data data = nullableData.Value;
						
						txPOWER.Text = data.Power.ToString();
						txENERGY.Text = data.Energy.ToString();
						txMAX_POWER.Text = data.MaxPower.ToString();
						txAVE_POWER.Text = data.AvgPower.ToString();
						
		                string time_str = data.Time.ToString().PadRight(8);
		
		                tx1.Text = time_str[0].ToString();
		                tx2.Text = time_str[1].ToString();
		                tx3.Text = time_str[2].ToString();
		                tx4.Text = time_str[3].ToString();
		                tx5.Text = time_str[4].ToString();
		                tx6.Text = time_str[5].ToString();
		                tx7.Text = time_str[6].ToString();
		                tx8.Text = time_str[7].ToString();
						
		                // Here the second data is processed to give minutes and second (not hours)
		                int time_sec;
		                int time_min;
		                string time_units_str;
						
		                time_min = Convert.ToInt32( Math.Floor((double)data.Time / 60) );
		                time_sec = Convert.ToInt32( data.Time - (time_min*60));
		
		                time_units_str = string.Concat(Convert.ToString(time_min), 'm', ' ', Convert.ToString(time_sec), 's');
		
		                txTIME.Text = time_units_str;
		
		                //test.Text = time_units_str;
		                // ***Must only use numbers - change PIC code to send as sinlge integer of seconds*****
		                // ***Convert value to hrs/mins/srcs in this program
		
		                // Display all the values for the diagnostics....
		                textBox1.Text = data.Voltage.ToString();
		                textBox2.Text = data.Current.ToString();
		                textBox3.Text = data.Power.ToString();
		                textBox4.Text = data.Energy.ToString();
		                textBox5.Text = data.MaxPower.ToString();
		                textBox6.Text = data.AvgPower.ToString();
		                textBox7.Text = data.Time.ToString();
		
		                //*************This is all for the graph test********************//
		                double time;
		
		                // if the time is zero then want to reset the graph etc...
		
		                if (data.Time==0)
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
		                    energy_list.Add(time, (Convert.ToDouble(data.Energy)));
		                    // Associate this curve with the Y2 axis
		                    curve1.IsY2Axis = true;
		
		                    // This finds the energy maximum to sort out the Y2axis scale
		                    if (Convert.ToDouble(data.Energy) > energy_max)
		                    {
		                        energy_max = Convert.ToDouble(data.Energy);
		                    }
		
		                    // Get the first CurveItem in the graph
		                    LineItem curve2 = zgc1.GraphPane.CurveList[0] as LineItem;
		                    // Get the PointPairList
		                    IPointListEdit power_list = curve2.Points as IPointListEdit;
		                    power_list.Add(time, (Convert.ToDouble(data.Power)));
		
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
					else
					{
						// The device has been connected since we last read it - our array
						// of devices is now out of date and should be refreshed next timer tick
						devices = null;
					}
				}
				
				// Update the connection indicator
				if (devices != null)
				{
	                LED1.Text= "ATTACHED";
	                LED1.BackColor = Color.Lime;
					Error_lbl.Text = String.Empty;
					
	                txtest.Text = "Attached and OK";
				}
				else
				{
					LED1.Text = "DISCONNECTED";
					LED1.BackColor = Color.Red;
					Error_lbl.Text = String.Empty;
	
					txtest.Text = "Disconnected and closed";
				}
			}
			catch (PedalogException ex)
			{
				LED1.Text = "ERROR";
				LED1.BackColor = Color.Red;
				Error_lbl.Text = ex.Message;
	
				txtest.Text = ex.Message;
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
