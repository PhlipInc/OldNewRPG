
namespace InNewWorldRPG
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GamePadRichText = new System.Windows.Forms.RichTextBox();
            this.StatsButton = new System.Windows.Forms.Button();
            this.StoreButton = new System.Windows.Forms.Button();
            this.GameHelpButton = new System.Windows.Forms.Button();
            this.RunAwayButton = new System.Windows.Forms.Button();
            this.FighterItemsButton = new System.Windows.Forms.Button();
            this.EnterDungeonButton = new System.Windows.Forms.Button();
            this.FightButton = new System.Windows.Forms.Button();
            this.LeaveDungeonButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GamePadRichText
            // 
            this.GamePadRichText.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GamePadRichText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GamePadRichText.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GamePadRichText.Location = new System.Drawing.Point(12, 12);
            this.GamePadRichText.Name = "GamePadRichText";
            this.GamePadRichText.ReadOnly = true;
            this.GamePadRichText.Size = new System.Drawing.Size(628, 587);
            this.GamePadRichText.TabIndex = 0;
            this.GamePadRichText.Text = "";
            // 
            // StatsButton
            // 
            this.StatsButton.Location = new System.Drawing.Point(836, 439);
            this.StatsButton.Name = "StatsButton";
            this.StatsButton.Size = new System.Drawing.Size(160, 160);
            this.StatsButton.TabIndex = 2;
            this.StatsButton.Text = "Stats";
            this.StatsButton.UseVisualStyleBackColor = true;
            this.StatsButton.Click += new System.EventHandler(this.StatsButton_Click);
            // 
            // StoreButton
            // 
            this.StoreButton.Location = new System.Drawing.Point(663, 439);
            this.StoreButton.Name = "StoreButton";
            this.StoreButton.Size = new System.Drawing.Size(160, 160);
            this.StoreButton.TabIndex = 3;
            this.StoreButton.Text = "Store";
            this.StoreButton.UseVisualStyleBackColor = true;
            this.StoreButton.Click += new System.EventHandler(this.StoreButton_Click);
            // 
            // GameHelpButton
            // 
            this.GameHelpButton.Location = new System.Drawing.Point(1010, 439);
            this.GameHelpButton.Name = "GameHelpButton";
            this.GameHelpButton.Size = new System.Drawing.Size(160, 160);
            this.GameHelpButton.TabIndex = 4;
            this.GameHelpButton.Text = "Help";
            this.GameHelpButton.UseVisualStyleBackColor = true;
            this.GameHelpButton.Click += new System.EventHandler(this.GameHelpButton_Click);
            // 
            // RunAwayButton
            // 
            this.RunAwayButton.Enabled = false;
            this.RunAwayButton.Location = new System.Drawing.Point(836, 12);
            this.RunAwayButton.Name = "RunAwayButton";
            this.RunAwayButton.Size = new System.Drawing.Size(160, 68);
            this.RunAwayButton.TabIndex = 5;
            this.RunAwayButton.Text = "Run Away";
            this.RunAwayButton.UseVisualStyleBackColor = true;
            this.RunAwayButton.Click += new System.EventHandler(this.RunAwayButton_Click);
            // 
            // FighterItemsButton
            // 
            this.FighterItemsButton.Location = new System.Drawing.Point(663, 161);
            this.FighterItemsButton.Name = "FighterItemsButton";
            this.FighterItemsButton.Size = new System.Drawing.Size(160, 68);
            this.FighterItemsButton.TabIndex = 7;
            this.FighterItemsButton.Text = "Items";
            this.FighterItemsButton.UseVisualStyleBackColor = true;
            this.FighterItemsButton.Click += new System.EventHandler(this.FighterItemsButton_Click);
            // 
            // EnterDungeonButton
            // 
            this.EnterDungeonButton.Location = new System.Drawing.Point(1021, 161);
            this.EnterDungeonButton.Name = "EnterDungeonButton";
            this.EnterDungeonButton.Size = new System.Drawing.Size(160, 68);
            this.EnterDungeonButton.TabIndex = 8;
            this.EnterDungeonButton.Text = "Enter Dungeon";
            this.EnterDungeonButton.UseVisualStyleBackColor = true;
            this.EnterDungeonButton.Click += new System.EventHandler(this.EnterDungeonButton_Click);
            // 
            // FightButton
            // 
            this.FightButton.Enabled = false;
            this.FightButton.Location = new System.Drawing.Point(836, 161);
            this.FightButton.Name = "FightButton";
            this.FightButton.Size = new System.Drawing.Size(160, 68);
            this.FightButton.TabIndex = 9;
            this.FightButton.Text = "Fight";
            this.FightButton.UseVisualStyleBackColor = true;
            this.FightButton.Click += new System.EventHandler(this.FightButton_Click);
            // 
            // LeaveDungeonButton
            // 
            this.LeaveDungeonButton.Enabled = false;
            this.LeaveDungeonButton.Location = new System.Drawing.Point(836, 309);
            this.LeaveDungeonButton.Name = "LeaveDungeonButton";
            this.LeaveDungeonButton.Size = new System.Drawing.Size(160, 68);
            this.LeaveDungeonButton.TabIndex = 10;
            this.LeaveDungeonButton.Text = "Leave Dungeon";
            this.LeaveDungeonButton.UseVisualStyleBackColor = true;
            this.LeaveDungeonButton.Click += new System.EventHandler(this.LeaveDungeonButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 611);
            this.Controls.Add(this.LeaveDungeonButton);
            this.Controls.Add(this.FightButton);
            this.Controls.Add(this.EnterDungeonButton);
            this.Controls.Add(this.FighterItemsButton);
            this.Controls.Add(this.RunAwayButton);
            this.Controls.Add(this.GameHelpButton);
            this.Controls.Add(this.StoreButton);
            this.Controls.Add(this.StatsButton);
            this.Controls.Add(this.GamePadRichText);
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StatsButton;
        private System.Windows.Forms.Button StoreButton;
        private System.Windows.Forms.Button GameHelpButton;
        private System.Windows.Forms.Button RunAwayButton;
        private System.Windows.Forms.Button FighterItemsButton;
        private System.Windows.Forms.Button EnterDungeonButton;
        private System.Windows.Forms.Button FightButton;
        private System.Windows.Forms.Button LeaveDungeonButton;
        private System.Windows.Forms.RichTextBox GamePadRichText;
    }
}

