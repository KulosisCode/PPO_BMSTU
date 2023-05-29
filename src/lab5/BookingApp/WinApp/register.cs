using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using GUIManager;

namespace BookingApp.WinApp
{
    public partial class register : KryptonForm
    {
        private GUIUser loginManager;
        private GUIRoom roomManager;
        private GUIGuest guestManager;
        private GUIStaff staffManager;
        private GUIRequest requestManager;
        private GUIHistory historyManager;
        public register(GUIUser loginManager, GUIRoom roomManager, GUIGuest guestManager, GUIStaff staffManager, GUIRequest requestManager, GUIHistory historyManager)
        {
            InitializeComponent();
            this.loginManager = loginManager;
            this.roomManager = roomManager;
            this.guestManager = guestManager;
            this.staffManager = staffManager;
            this.requestManager = requestManager;
            this.historyManager = historyManager;
        }

        private void kryptonPalette1_PalettePaint(object sender, Krypton.Toolkit.PaletteLayoutEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {

        }
    }
}
