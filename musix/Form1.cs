using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;


namespace musix
{
    public partial class Form1 : Form

    {
       

        bool mousedown;
        public Form1()
        {
            

            InitializeComponent();
           

            track_list.Font = new System.Drawing.Font("Segoe UI Semibold", 12, System.Drawing.FontStyle.Regular);
            track_list.ItemHeight = 25;
            track_list.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;

            //analyzer
            Analyzer analyzer;
            analyzer = new Analyzer(progressBar3, progressBar2, spectrum1, comboBox1, chart1);
            analyzer.Enable = true;
            analyzer.DisplayEnable = true;

            try
            {
              
            }
            catch(System.IO.FileNotFoundException)
            {

            }
          


            timer1.Enabled = true;
        }

        //public void SetCurrentEffectPreset(int value)
        //{
        //    windows identity = WindowsIdentity.GetCurrent();
        //    string path = string.Format("{0}\\Software\\Microsoft\\MediaPlayer\\Preferences", identity.User.Value);
        //    RegistryKey key = Registry.Users.OpenSubKey(path, true);
        //    if (key == null)
        //        throw new Exception("Error! Registry not found!");
        //    key.SetValue("CurrentEffectPreset", value, RegistryValueKind.DWord);
        //    player.BeginInit();
        //}






        //sidebar buttons
        private void btnPlaying_Click(object sender, EventArgs e)
        {
            indicator.Top = btnPlaying.Top;
            bunifuPages1.SetPage(0);

            {
                picPlaying.Visible = true;
                picPlaylist.Visible = false;
                picAbout.Visible = false;
            }

            
           
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            indicator.Top = btnPlaylist.Top;
            bunifuPages1.SetPage(1);

            {
                picPlaylist.Visible = true;
                picPlaying.Visible = false;
                picAbout.Visible = false;
            }

           
        }


        private void btnAbout_Click(object sender, EventArgs e)
        {
            indicator.Top = btnAbout.Top;
            bunifuPages1.SetPage(2);
            {
                picAbout.Visible = true;
                picPlaylist.Visible = false;
                picPlaying.Visible = false;  
            }
        }



        //exit button
        private void btnClose1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //minimize button
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //track list
        string[] paths, files;

        private void track_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                player.URL = paths[track_list.SelectedIndex];
                player.Ctlcontrols.play();
                lbl_msg.Text = player.URL;
                timer1.Start();
            }
            catch (System.IndexOutOfRangeException)
            {

            }
            catch (System.FormatException)
            {

            }



            trackbar1.Value = 50;
            lbl_volume.Text = trackbar1.Value.ToString();

            try
            {
                TagLib.File file = TagLib.File.Create(paths[track_list.SelectedIndex]);
                lbl_title.Text = (file.Tag.Title);
                lbl_album.Text = (file.Tag.Album);
                lbl_artist.Text = (file.Tag.JoinedAlbumArtists);
                lbl_year.Text = ("date " + file.Tag.Year);

                var ff = TagLib.File.Create(paths[track_list.SelectedIndex]);
                var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                pic_art.Image = Image.FromStream(new MemoryStream(bin));

            }
            catch (System.IndexOutOfRangeException)
            {

            }
                
               
            

            

            btn_circle.Visible = true;
            btn_play.Visible = false;
        }


        //play button
        private void btn_play_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.play();
            //lbl_msg.Text = "Playing...";
            txt_search.Text = "Search";
            lbl_msg.Text = player.status;

            btn_circle.Visible = true;
        }

        //pause button
        private void btn_pause_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.pause();
            lbl_msg.Text = "Pause";

            btn_play.Visible = true;
            btn_circle.Visible = false;
        }

        //stop button
        private void btn_stop_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.stop();
            lbl_msg.Text = "Stopped";
            progressbar0.Value = 0;

            btn_play.Visible = true;
            btn_circle.Visible = false;
        }

        //next button
        private void btn_next_Click(object sender, EventArgs e)
        {
           
            if (track_list.SelectedIndex<track_list.Items.Count-1)
            {
                track_list.SelectedIndex = track_list.SelectedIndex + 1;
            }

            lbl_msg.Text = "Next" + player.URL;

        }

        //previous button
        private void btn_prev_Click(object sender, EventArgs e)
        {
            if(track_list.SelectedIndex>0)
            {
                track_list.SelectedIndex = track_list.SelectedIndex - 1;
            }

            lbl_msg.Text = "Previous" + player.URL;
        }

        //timer
        private void timer1_Tick(object sender, EventArgs e)
        {


            if (player.playState==WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressbar0.Maximum = (int)player.Ctlcontrols.currentItem.duration;
                progressbar0.Value = (int)player.Ctlcontrols.currentPosition;
                lbl_track_start.Text = player.Ctlcontrols.currentPositionString;
                lbl_track_end.Text = player.Ctlcontrols.currentItem.durationString.ToString();

                try
                {

                }
                catch (System.NullReferenceException)
                {

                }




            }
           
            


           
            
        }

        //volume bar
        private void trackbar1_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            player.settings.volume = trackbar1.Value;
            lbl_volume.Text = trackbar1.Value.ToString();
        }

        private void lbl_volume_Click(object sender, EventArgs e)
        {

        }

        //progress bar
        private void progressbar0_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            player.Ctlcontrols.currentPosition = progressbar0.Value;

        }

        //remove music button
        private void btn_delete_Click(object sender, EventArgs e)
        {
            track_list.Items.Clear();
        }

        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuToggleSwitch1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {

        }

        //Tab visualizer and info
        /*private void bunifuButton1_Click(object sender, EventArgs e)
        {
            tabChart.Visible = false;
            tabChart.BringToFront();
            bunifuTransition1.ShowSync(tabChart);
        }*/

        private void btnInfoslider_Click(object sender, EventArgs e)
        {
            tabChart.Visible = false;
            tabChart.BringToFront();
            bunifuTransition1.ShowSync(tabChart);
        }

        private void indicator_ShapeChanged(object sender, Bunifu.UI.WinForms.BunifuShapes.ShapeChangedEventArgs e)
        {

        }

        private void btnVisual_Click(object sender, EventArgs e)
        {
            tabDetail.Visible = false;
            tabDetail.BringToFront();
            bunifuTransition1.ShowSync(tabDetail);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void gunaSlider1_Click(object sender, EventArgs e)
        {
            tabChart.Visible = false;
            tabChart.BringToFront();
            bunifuTransition1.ShowSync(tabChart);
        }

        private void gunaSlider2_Click(object sender, EventArgs e)
        {
            tabDetail.Visible = false;
            tabDetail.BringToFront();
            bunifuTransition1.ShowSync(tabDetail);
        }

        private void gunaSlider11_Click(object sender, EventArgs e)
        {
            tabChart.Visible = false;
            tabChart.BringToFront();
            bunifuTransition1.ShowSync(tabChart);

           
        }

        private void gunaSlider22_Click(object sender, EventArgs e)
        {
            tabDetail.Visible = false;
            tabDetail.BringToFront();
            bunifuTransition1.ShowSync(tabDetail);

           



        }

        private void lbl_msg_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        //search box
        private void txt_search_MouseClick(object sender, MouseEventArgs e)
        {
            txt_search.Text = "";

            pic_search.Visible = true;
            pic_searchIcon.Visible = true;
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            int index = track_list.FindString(txt_search.Text);
            if(0<=index)
            {
                track_list.SelectedIndex = index;
            }

        }

        //list box color
        Color b_color;
        Color h_color = Color.FromArgb(255, 255, 255);

       private void track_list_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            
            b_color = e.BackColor;
            Color clr = Color.FromArgb(0, b_color);
            Brush bb = new LinearGradientBrush(e.Bounds, b_color, clr, 1);

            if(e.Index>=0)
            {
                SolidBrush sb = new SolidBrush(((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? h_color : b_color);
                e.Graphics.FillRectangle(sb, e.Bounds);
                e.Graphics.FillRectangle(bb, e.Bounds);

                string txt = track_list.Items[e.Index].ToString();
                SolidBrush tb = new SolidBrush(e.ForeColor);
                e.Graphics.DrawString(txt, e.Font, tb, track_list.GetItemRectangle(e.Index).Location);
            }
        }

        //sort button
        private void btn_sort_Click(object sender, EventArgs e)
        {

            {

               track_list.Sorted = true;
            }

        }

        private void track_list_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void track_list_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void track_list_Click(object sender, EventArgs e)
        {
           // lbl_msg.Text = player.status;
        }

        private void track_list_MouseClick(object sender, MouseEventArgs e)
        {
            // lbl_msg.Text = player.status;
            pic_search.Visible = false;
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void picAbout_Click(object sender, EventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void pic_search_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCircleProgress1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs e)
        {
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_repeat_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_mute_Click(object sender, EventArgs e)
        {
            player.settings.volume = 50;
            trackbar1.Value = 50;
            lbl_volume.Text = "50";
            lbl_msg.Text = "Unmuted";

            btn_mute.Visible = false;
            btn_fullvolume.Visible = true;
        }

        private void btn_fullvolume_Click(object sender, EventArgs e)
        {
            player.settings.volume = 0;
            trackbar1.Value = 0;
            lbl_volume.Text = "0";
            lbl_msg.Text = "Muted";

            btn_mute.Visible = true;
            btn_fullvolume.Visible = false;
        }

        private void lbl_year_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void lbl_1vol50_Click(object sender, EventArgs e)
        {
            
        }

        private void lbl_2vol50_Click(object sender, EventArgs e)
        {

        }

        private void lbl_halfvol_Click(object sender, EventArgs e)
        {
            player.settings.volume = 50;
            trackbar1.Value = 50;
            lbl_volume.Text = "50";
        }

        private void pnlSidebar_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void pnlSidebar_MouseMove(object sender, MouseEventArgs e)
        {
            

            
        }

        private void pnlSidebar_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        
   

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
           // player.currentPlaylist = track_list;
           // player.settings.setMode("shuffle", true);
           // player.Ctlcontrols.play();
        }


        //playback speed
        private void rbtn_speed0_CheckedChanged(object sender, EventArgs e)
        {
            player.settings.rate = 0.5f;
            lbl_msg.Text = "Playback Speed 0.5x";

            btn_playbackopen.Visible = true;
            rbtn_speed0.Visible = false;
            rbtn_speed1.Visible = false;
            rbtn_speed2.Visible = false;

        }

        private void rbtn_speed1_CheckedChanged(object sender, EventArgs e)
        {
            player.settings.rate = 1.0f;
            lbl_msg.Text = "Playback Speed 1.0x";

            btn_playbackopen.Visible = true;
            rbtn_speed0.Visible = false;
            rbtn_speed1.Visible = false;
            rbtn_speed2.Visible = false;

        }

        private void rbtn_speed2_CheckedChanged(object sender, EventArgs e)
        {
            player.settings.rate = 1.5f;
            lbl_msg.Text = "Playback Speed 1.5x";

            btn_playbackopen.Visible = true;
            rbtn_speed0.Visible = false;
            rbtn_speed1.Visible = false;
            rbtn_speed2.Visible = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_playbackopen_Click(object sender, EventArgs e)
        {
            rbtn_speed0.Visible = true;
            rbtn_speed1.Visible = true;
            rbtn_speed2.Visible = true;

            btn_playbackopen.Visible = false;
            
        }

        private void btn_circle_Click(object sender, EventArgs e)
        {
            lbl_msg.Text = player.status;
        }

        //Social buttons
        private void btn_facebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/DaneshwaraVidulanga");
        }

        private void btn_linkedin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/daneshwaravidulanga");
        }

        private void byn_github_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/daneshwara");
        }

        private void btn_pinterest_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/daneshwaravidulanga/");
        }

        private void btn_twitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/DVidulanga");
        }

        private void btn_gmail_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com/mail/u/0/?fs=1&to=ask.danayow@gmail.com&su=SUBJECT&body=BODY&bcc=ask.danayow@gmail.com&tf=cm");
        }

        private void bunifuRating1_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRating.ValueChangedEventArgs e)
        {

        }

        //Jump next track
        private void player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)
            {
                if (track_list.SelectedIndex != track_list.Items.Count - 1)
                {
                    BeginInvoke(new Action(() => { track_list.SelectedIndex = track_list.SelectedIndex + 1; }));

                }
                
            }

        }

        private void player_Enter(object sender, EventArgs e)
        {

        }

        private void tabChart_Click(object sender, EventArgs e)
        {

        }

        



        /*private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            player.URL = paths[track_list.SelectedIndex];
            player.Ctlcontrols.play();
            lbl_msg.Text = "Playing...";
            timer1.Start();

            trackbar1.Value = 15;
            lbl_volume.Text = trackbar1.Value.ToString() + "%";
        }*/



        //open files
        private void btn_open_Click(object sender, EventArgs e)
        {

            
            
           

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select A File";
            ofd.Filter = "MP3 files (*.mp3)|*.mp3";
            ofd.Multiselect = true;
            if(ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;
                //foreach(var tt in paths)
                for(int x=0;x<files.Length;x++)
                {
                    track_list.Items.Add(files[x]);
                    //TagLib.File file = TagLib.File.Create(tt);
                   //track_list.Items.Add(file.Tag.Title);
                }
            }
        }
    }

}
