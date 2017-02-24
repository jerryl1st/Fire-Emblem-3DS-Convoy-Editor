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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.convoyDataGridView = new System.Windows.Forms.DataGridView();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.itemNameColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.usesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.convoyDataGridView.Location = new System.Drawing.Point(13, 41);
            this.convoyDataGridView.MultiSelect = false;
            this.convoyDataGridView.Name = "convoyDataGridView";
            this.convoyDataGridView.RowHeadersVisible = false;
            this.convoyDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.convoyDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.convoyDataGridView.Size = new System.Drawing.Size(280, 209);
            this.convoyDataGridView.TabIndex = 0;
            this.convoyDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.convoyDataGridView_CellClick);
            this.convoyDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.convoyDataGridView_CellValidating);
            this.convoyDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.convoyDataGridView_CellValueChanged);
            this.convoyDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.convoyDataGridView_CurrentCellDirtyStateChanged);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(12, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(218, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.usesColumn.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.quantityColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantityColumn.HeaderText = "Qty";
            this.quantityColumn.MaxInputLength = 2;
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.quantityColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantityColumn.ToolTipText = "Quantity";
            this.quantityColumn.Width = 48;
            // 
            // ConvoyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(309, 262);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.convoyDataGridView);
            this.Name = "ConvoyEditor";
            this.Text = "Convoy Editor";
            ((System.ComponentModel.ISupportInitialize)(this.convoyDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView convoyDataGridView;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn itemNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
    }
}

