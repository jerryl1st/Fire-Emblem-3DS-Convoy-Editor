namespace Fire_Emblem_3DS_Convoy_Editor
{
    partial class ConvoyEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.convoyDataGridView = new System.Windows.Forms.DataGridView();
            this.itemNameColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.usesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadBtn = new MetroFramework.Controls.MetroButton();
            this.saveBtn = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.convoyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // convoyDataGridView
            // 
            this.convoyDataGridView.AllowUserToAddRows = false;
            this.convoyDataGridView.AllowUserToDeleteRows = false;
            this.convoyDataGridView.AllowUserToResizeColumns = false;
            this.convoyDataGridView.AllowUserToResizeRows = false;
            this.convoyDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convoyDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.convoyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.convoyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemNameColumn,
            this.usesColumn,
            this.quantityColumn});
            this.convoyDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.convoyDataGridView.Location = new System.Drawing.Point(13, 63);
            this.convoyDataGridView.MultiSelect = false;
            this.convoyDataGridView.Name = "convoyDataGridView";
            this.convoyDataGridView.RowHeadersVisible = false;
            this.convoyDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.convoyDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.convoyDataGridView.Size = new System.Drawing.Size(365, 339);
            this.convoyDataGridView.TabIndex = 0;
            this.convoyDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.convoyDataGridView_CellClick);
            this.convoyDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.convoyDataGridView_CellValidating);
            this.convoyDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.convoyDataGridView_CellValueChanged);
            this.convoyDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.convoyDataGridView_CurrentCellDirtyStateChanged);
            // 
            // itemNameColumn
            // 
            this.itemNameColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.itemNameColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.itemNameColumn.HeaderText = "Item";
            this.itemNameColumn.Name = "itemNameColumn";
            this.itemNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.itemNameColumn.Width = 160;
            // 
            // usesColumn
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.usesColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.usesColumn.HeaderText = "Uses";
            this.usesColumn.MaxInputLength = 5;
            this.usesColumn.Name = "usesColumn";
            this.usesColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.usesColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.usesColumn.ToolTipText = "Forge level for forgeable weapons.";
            this.usesColumn.Width = 48;
            // 
            // quantityColumn
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.quantityColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.quantityColumn.HeaderText = "Qty";
            this.quantityColumn.MaxInputLength = 2;
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.quantityColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantityColumn.ToolTipText = "Quantity";
            this.quantityColumn.Width = 48;
            // 
            // loadBtn
            // 
            this.loadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadBtn.Location = new System.Drawing.Point(222, 24);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 3;
            this.loadBtn.Text = "Load";
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(303, 24);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 25);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // ConvoyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(394, 414);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.convoyDataGridView);
            this.Name = "ConvoyEditor";
            this.Text = "Convoy Editor";
            ((System.ComponentModel.ISupportInitialize)(this.convoyDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView convoyDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn itemNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private MetroFramework.Controls.MetroButton loadBtn;
        private MetroFramework.Controls.MetroButton saveBtn;
    }
}

