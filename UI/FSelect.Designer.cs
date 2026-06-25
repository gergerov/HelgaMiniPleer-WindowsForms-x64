namespace Pleer.UI
{
    partial class FSelect
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
            LayContent = new FlowLayoutPanel();
            LaySearchBox = new TableLayoutPanel();
            tbSearchAudio = new TextBox();
            LayButtons = new TableLayoutPanel();
            LaySearchBox.SuspendLayout();
            SuspendLayout();
            // 
            // LayContent
            // 
            LayContent.AutoScroll = true;
            LayContent.BackColor = SystemColors.ButtonHighlight;
            LayContent.Dock = DockStyle.Top;
            LayContent.FlowDirection = FlowDirection.TopDown;
            LayContent.Location = new Point(0, 77);
            LayContent.Name = "LayContent";
            LayContent.Size = new Size(444, 342);
            LayContent.TabIndex = 0;
            LayContent.WrapContents = false;
            // 
            // LaySearchBox
            // 
            LaySearchBox.ColumnCount = 1;
            LaySearchBox.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            LaySearchBox.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            LaySearchBox.Controls.Add(tbSearchAudio, 0, 0);
            LaySearchBox.Dock = DockStyle.Top;
            LaySearchBox.Location = new Point(0, 0);
            LaySearchBox.Name = "LaySearchBox";
            LaySearchBox.RowCount = 1;
            LaySearchBox.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            LaySearchBox.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            LaySearchBox.Size = new Size(444, 30);
            LaySearchBox.TabIndex = 1;
            // 
            // tbSearchAudio
            // 
            tbSearchAudio.BorderStyle = BorderStyle.None;
            tbSearchAudio.Dock = DockStyle.Top;
            tbSearchAudio.Font = new Font("Segoe UI", 12F);
            tbSearchAudio.Location = new Point(3, 3);
            tbSearchAudio.Name = "tbSearchAudio";
            tbSearchAudio.PlaceholderText = "Поиск по названию/пути";
            tbSearchAudio.Size = new Size(438, 22);
            tbSearchAudio.TabIndex = 8;
            tbSearchAudio.TextAlign = HorizontalAlignment.Center;
            // 
            // LayButtons
            // 
            LayButtons.BackColor = SystemColors.ButtonHighlight;
            LayButtons.ColumnCount = 6;
            LayButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            LayButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            LayButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            LayButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            LayButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            LayButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            LayButtons.Dock = DockStyle.Top;
            LayButtons.Location = new Point(0, 30);
            LayButtons.Name = "LayButtons";
            LayButtons.RowCount = 1;
            LayButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            LayButtons.Size = new Size(444, 47);
            LayButtons.TabIndex = 2;
            // 
            // FSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(444, 421);
            Controls.Add(LayContent);
            Controls.Add(LayButtons);
            Controls.Add(LaySearchBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FSelect";
            StartPosition = FormStartPosition.CenterParent;
            LaySearchBox.ResumeLayout(false);
            LaySearchBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel LayContent;
        private TableLayoutPanel LaySearchBox;
        private TableLayoutPanel LayButtons;
        private TextBox tbSearchAudio;
    }
}