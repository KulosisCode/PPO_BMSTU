namespace BookingApp.WinApp
{
    partial class login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            kryptonTextBox2 = new Krypton.Toolkit.KryptonTextBox();
            kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlDark;
            label1.Location = new Point(44, 28);
            label1.Name = "label1";
            label1.Size = new Size(123, 45);
            label1.TabIndex = 0;
            label1.Text = "Sign In";
            label1.Click += label1_Click_1;
            // 
            // kryptonTextBox1
            // 
            kryptonTextBox1.Location = new Point(44, 113);
            kryptonTextBox1.Name = "kryptonTextBox1";
            kryptonTextBox1.Size = new Size(300, 34);
            kryptonTextBox1.StateCommon.Back.Color1 = Color.White;
            kryptonTextBox1.StateCommon.Border.Color1 = SystemColors.ActiveBorder;
            kryptonTextBox1.StateCommon.Border.Color2 = SystemColors.ActiveBorder;
            kryptonTextBox1.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonTextBox1.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            kryptonTextBox1.StateCommon.Border.Rounding = 20F;
            kryptonTextBox1.StateCommon.Border.Width = 1;
            kryptonTextBox1.StateCommon.Content.Color1 = Color.Gray;
            kryptonTextBox1.StateCommon.Content.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            kryptonTextBox1.StateCommon.Content.Padding = new Padding(10, 0, 10, 0);
            kryptonTextBox1.TabIndex = 1;
            kryptonTextBox1.Text = "Username";
            // 
            // kryptonTextBox2
            // 
            kryptonTextBox2.Location = new Point(44, 170);
            kryptonTextBox2.Name = "kryptonTextBox2";
            kryptonTextBox2.Size = new Size(300, 34);
            kryptonTextBox2.StateCommon.Back.Color1 = Color.White;
            kryptonTextBox2.StateCommon.Border.Color1 = SystemColors.ActiveBorder;
            kryptonTextBox2.StateCommon.Border.Color2 = SystemColors.ActiveBorder;
            kryptonTextBox2.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonTextBox2.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            kryptonTextBox2.StateCommon.Border.Rounding = 20F;
            kryptonTextBox2.StateCommon.Border.Width = 1;
            kryptonTextBox2.StateCommon.Content.Color1 = Color.Gray;
            kryptonTextBox2.StateCommon.Content.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            kryptonTextBox2.StateCommon.Content.Padding = new Padding(10, 0, 10, 0);
            kryptonTextBox2.TabIndex = 2;
            kryptonTextBox2.Text = "Password";
            // 
            // kryptonButton1
            // 
            kryptonButton1.CornerRoundingRadius = 20F;
            kryptonButton1.Location = new Point(44, 231);
            kryptonButton1.Name = "kryptonButton1";
            kryptonButton1.OverrideDefault.Back.Color1 = Color.FromArgb(128, 128, 255);
            kryptonButton1.OverrideDefault.Back.Color2 = Color.Cyan;
            kryptonButton1.OverrideDefault.Back.ColorAngle = 45F;
            kryptonButton1.OverrideDefault.Border.Color1 = Color.FromArgb(128, 128, 255);
            kryptonButton1.OverrideDefault.Border.Color2 = Color.Cyan;
            kryptonButton1.OverrideDefault.Border.ColorAngle = 45F;
            kryptonButton1.OverrideDefault.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonButton1.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            kryptonButton1.OverrideDefault.Border.Rounding = 20F;
            kryptonButton1.OverrideDefault.Border.Width = 1;
            kryptonButton1.OverrideDefault.Content.ShortText.Color1 = Color.White;
            kryptonButton1.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            kryptonButton1.Size = new Size(151, 47);
            kryptonButton1.StateCommon.Back.Color1 = Color.FromArgb(128, 128, 255);
            kryptonButton1.StateCommon.Back.Color2 = Color.Cyan;
            kryptonButton1.StateCommon.Back.ColorAngle = 45F;
            kryptonButton1.StateCommon.Border.Color1 = Color.FromArgb(128, 128, 255);
            kryptonButton1.StateCommon.Border.Color2 = Color.Cyan;
            kryptonButton1.StateCommon.Border.ColorAngle = 45F;
            kryptonButton1.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonButton1.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            kryptonButton1.StateCommon.Border.Rounding = 20F;
            kryptonButton1.StateCommon.Border.Width = 1;
            kryptonButton1.StateCommon.Content.ShortText.Color1 = Color.White;
            kryptonButton1.StateCommon.Content.ShortText.Color2 = Color.White;
            kryptonButton1.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonButton1.StatePressed.Back.Color1 = Color.Blue;
            kryptonButton1.StatePressed.Back.Color2 = Color.Teal;
            kryptonButton1.StatePressed.Back.ColorAngle = 135F;
            kryptonButton1.StatePressed.Border.Color1 = Color.Blue;
            kryptonButton1.StatePressed.Border.Color2 = Color.Teal;
            kryptonButton1.StatePressed.Border.ColorAngle = 135F;
            kryptonButton1.StatePressed.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonButton1.StatePressed.Border.Rounding = 20F;
            kryptonButton1.StatePressed.Border.Width = 1;
            kryptonButton1.StatePressed.Content.ShortText.Color1 = Color.White;
            kryptonButton1.StateTracking.Back.Color1 = Color.FromArgb(128, 128, 255);
            kryptonButton1.StateTracking.Back.Color2 = Color.FromArgb(192, 255, 255);
            kryptonButton1.StateTracking.Back.ColorAngle = 45F;
            kryptonButton1.StateTracking.Border.Color1 = Color.FromArgb(128, 128, 255);
            kryptonButton1.StateTracking.Border.Color2 = Color.FromArgb(192, 255, 255);
            kryptonButton1.StateTracking.Border.ColorAngle = 45F;
            kryptonButton1.StateTracking.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonButton1.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            kryptonButton1.StateTracking.Border.Rounding = 20F;
            kryptonButton1.StateTracking.Border.Width = 1;
            kryptonButton1.TabIndex = 5;
            kryptonButton1.Values.Text = "Sign In";
            // 
            // kryptonButton2
            // 
            kryptonButton2.CornerRoundingRadius = 20F;
            kryptonButton2.Location = new Point(215, 231);
            kryptonButton2.Name = "kryptonButton2";
            kryptonButton2.OverrideDefault.Back.Color1 = Color.White;
            kryptonButton2.OverrideDefault.Back.Color2 = Color.White;
            kryptonButton2.OverrideDefault.Back.ColorAngle = 45F;
            kryptonButton2.OverrideDefault.Border.Color1 = Color.FromArgb(128, 128, 255);
            kryptonButton2.OverrideDefault.Border.Color2 = Color.Cyan;
            kryptonButton2.OverrideDefault.Border.ColorAngle = 45F;
            kryptonButton2.OverrideDefault.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonButton2.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            kryptonButton2.OverrideDefault.Border.Rounding = 20F;
            kryptonButton2.OverrideDefault.Border.Width = 1;
            kryptonButton2.OverrideDefault.Content.ShortText.Color1 = Color.FromArgb(0, 192, 192);
            kryptonButton2.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            kryptonButton2.Size = new Size(129, 47);
            kryptonButton2.StateCommon.Back.Color1 = Color.White;
            kryptonButton2.StateCommon.Back.Color2 = Color.White;
            kryptonButton2.StateCommon.Back.ColorAngle = 45F;
            kryptonButton2.StateCommon.Border.Color1 = Color.Blue;
            kryptonButton2.StateCommon.Border.Color2 = Color.Cyan;
            kryptonButton2.StateCommon.Border.ColorAngle = 45F;
            kryptonButton2.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonButton2.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            kryptonButton2.StateCommon.Border.Rounding = 20F;
            kryptonButton2.StateCommon.Border.Width = 1;
            kryptonButton2.StateCommon.Content.ShortText.Color1 = Color.FromArgb(0, 192, 192);
            kryptonButton2.StateCommon.Content.ShortText.Color2 = Color.FromArgb(0, 192, 192);
            kryptonButton2.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonButton2.StatePressed.Back.Color1 = Color.Blue;
            kryptonButton2.StatePressed.Back.Color2 = Color.Teal;
            kryptonButton2.StatePressed.Back.ColorAngle = 135F;
            kryptonButton2.StatePressed.Border.Color1 = Color.Blue;
            kryptonButton2.StatePressed.Border.Color2 = Color.Teal;
            kryptonButton2.StatePressed.Border.ColorAngle = 135F;
            kryptonButton2.StatePressed.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonButton2.StatePressed.Border.Rounding = 20F;
            kryptonButton2.StatePressed.Border.Width = 1;
            kryptonButton2.StatePressed.Content.ShortText.Color1 = Color.White;
            kryptonButton2.StateTracking.Back.Color1 = Color.FromArgb(224, 224, 224);
            kryptonButton2.StateTracking.Back.Color2 = Color.FromArgb(224, 224, 224);
            kryptonButton2.StateTracking.Back.ColorAngle = 45F;
            kryptonButton2.StateTracking.Border.Color1 = Color.FromArgb(128, 128, 255);
            kryptonButton2.StateTracking.Border.Color2 = Color.FromArgb(192, 255, 255);
            kryptonButton2.StateTracking.Border.ColorAngle = 45F;
            kryptonButton2.StateTracking.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            kryptonButton2.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            kryptonButton2.StateTracking.Border.Rounding = 20F;
            kryptonButton2.StateTracking.Border.Width = 1;
            kryptonButton2.StateTracking.Content.ShortText.Color1 = Color.Cyan;
            kryptonButton2.StateTracking.Content.ShortText.Color2 = Color.Cyan;
            kryptonButton2.TabIndex = 6;
            kryptonButton2.Values.Text = "Sign Up";
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 338);
            Controls.Add(kryptonButton2);
            Controls.Add(kryptonButton1);
            Controls.Add(kryptonTextBox2);
            Controls.Add(kryptonTextBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "login";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            StateCommon.Back.Color1 = Color.FromArgb(250, 252, 252);
            StateCommon.Back.Color2 = Color.FromArgb(250, 252, 252);
            StateCommon.Border.Color1 = Color.FromArgb(250, 252, 252);
            StateCommon.Border.Color2 = Color.FromArgb(250, 252, 252);
            StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right;
            StateCommon.Header.Back.Color1 = Color.FromArgb(250, 252, 252);
            StateCommon.Header.Back.Color2 = Color.FromArgb(250, 252, 252);
            StateCommon.Header.Border.Color1 = Color.FromArgb(250, 252, 252);
            StateCommon.Header.Border.Color2 = Color.FromArgb(250, 252, 252);
            StateCommon.Header.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right;
            StateCommon.Header.Border.Rounding = 15;
            StateCommon.Header.Border.Width = 0;
            StateCommon.Header.ButtonEdgeInset = 10;
            StateCommon.Header.Content.Padding = new Padding(10, -1, -1, -1);
            Text = "Hotel System Management";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private Krypton.Toolkit.KryptonPalette kryptonPalette1;
    }
}