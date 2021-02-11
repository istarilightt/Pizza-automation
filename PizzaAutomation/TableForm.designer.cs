
namespace PizzaAutomation
{
    partial class TableForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.ordertype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.lblBeverageCount = new System.Windows.Forms.Label();
            this.lblPizzaCount = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.chckCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPizzaPrice = new System.Windows.Forms.Label();
            this.lblBeveragePrice = new System.Windows.Forms.Label();
            this.cmbBeverages = new System.Windows.Forms.ComboBox();
            this.cmbSelectPizza = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddBeverage = new System.Windows.Forms.Button();
            this.btnAddPizza = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordertype,
            this.ordername,
            this.orderprice});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvOrders.Location = new System.Drawing.Point(12, 82);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(464, 245);
            this.dgvOrders.TabIndex = 0;
            // 
            // ordertype
            // 
            this.ordertype.HeaderText = "Type";
            this.ordertype.Name = "ordertype";
            this.ordertype.ReadOnly = true;
            this.ordertype.Width = 65;
            // 
            // ordername
            // 
            this.ordername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ordername.HeaderText = "Name";
            this.ordername.Name = "ordername";
            this.ordername.ReadOnly = true;
            this.ordername.Width = 70;
            // 
            // orderprice
            // 
            this.orderprice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.orderprice.HeaderText = "Price";
            this.orderprice.Name = "orderprice";
            this.orderprice.ReadOnly = true;
            this.orderprice.Width = 64;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTable.Location = new System.Drawing.Point(8, 16);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(69, 24);
            this.lblTable.TabIndex = 1;
            this.lblTable.Text = "Table ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Add Order";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnComplete);
            this.panel1.Controls.Add(this.lblBeverageCount);
            this.panel1.Controls.Add(this.lblPizzaCount);
            this.panel1.Controls.Add(this.lblTotalPrice);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblTable);
            this.panel1.Controls.Add(this.dgvOrders);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 428);
            this.panel1.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Location = new System.Drawing.Point(12, 376);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(232, 47);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnComplete.Location = new System.Drawing.Point(253, 376);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(223, 47);
            this.btnComplete.TabIndex = 5;
            this.btnComplete.Text = "Order Completed";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // lblBeverageCount
            // 
            this.lblBeverageCount.AutoSize = true;
            this.lblBeverageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBeverageCount.Location = new System.Drawing.Point(431, 347);
            this.lblBeverageCount.Name = "lblBeverageCount";
            this.lblBeverageCount.Size = new System.Drawing.Size(45, 16);
            this.lblBeverageCount.TabIndex = 4;
            this.lblBeverageCount.Text = "label6";
            // 
            // lblPizzaCount
            // 
            this.lblPizzaCount.AutoSize = true;
            this.lblPizzaCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPizzaCount.Location = new System.Drawing.Point(250, 347);
            this.lblPizzaCount.Name = "lblPizzaCount";
            this.lblPizzaCount.Size = new System.Drawing.Size(45, 16);
            this.lblPizzaCount.TabIndex = 4;
            this.lblPizzaCount.Text = "label6";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalPrice.Location = new System.Drawing.Point(94, 347);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(45, 16);
            this.lblTotalPrice.TabIndex = 4;
            this.lblTotalPrice.Text = "label6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(317, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Beverage Count:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(164, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Pizza Count:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(12, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Orders";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvIngredients);
            this.panel2.Controls.Add(this.lblPizzaPrice);
            this.panel2.Controls.Add(this.lblBeveragePrice);
            this.panel2.Controls.Add(this.cmbBeverages);
            this.panel2.Controls.Add(this.cmbSelectPizza);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnAddBeverage);
            this.panel2.Controls.Add(this.btnAddPizza);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(525, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 428);
            this.panel2.TabIndex = 4;
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.AllowUserToAddRows = false;
            this.dgvIngredients.AllowUserToDeleteRows = false;
            this.dgvIngredients.AllowUserToResizeRows = false;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngredients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chckCol,
            this.id,
            this.name,
            this.price});
            this.dgvIngredients.Location = new System.Drawing.Point(17, 109);
            this.dgvIngredients.MultiSelect = false;
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.RowHeadersVisible = false;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dgvIngredients.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvIngredients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredients.Size = new System.Drawing.Size(198, 192);
            this.dgvIngredients.TabIndex = 9;
            this.dgvIngredients.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvIngredients_CellMouseUp);
            this.dgvIngredients.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngredients_CellValueChanged);
            // 
            // chckCol
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle25.NullValue = false;
            this.chckCol.DefaultCellStyle = dataGridViewCellStyle25;
            this.chckCol.HeaderText = "";
            this.chckCol.Name = "chckCol";
            this.chckCol.Width = 25;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.name.DefaultCellStyle = dataGridViewCellStyle26;
            this.name.HeaderText = "Ingredient";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // price
            // 
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.price.DefaultCellStyle = dataGridViewCellStyle27;
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 50;
            // 
            // lblPizzaPrice
            // 
            this.lblPizzaPrice.AutoSize = true;
            this.lblPizzaPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPizzaPrice.Location = new System.Drawing.Point(62, 324);
            this.lblPizzaPrice.Name = "lblPizzaPrice";
            this.lblPizzaPrice.Size = new System.Drawing.Size(12, 16);
            this.lblPizzaPrice.TabIndex = 8;
            this.lblPizzaPrice.Text = "-";
            // 
            // lblBeveragePrice
            // 
            this.lblBeveragePrice.AutoSize = true;
            this.lblBeveragePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBeveragePrice.Location = new System.Drawing.Point(62, 404);
            this.lblBeveragePrice.Name = "lblBeveragePrice";
            this.lblBeveragePrice.Size = new System.Drawing.Size(12, 16);
            this.lblBeveragePrice.TabIndex = 8;
            this.lblBeveragePrice.Text = "-";
            // 
            // cmbBeverages
            // 
            this.cmbBeverages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBeverages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbBeverages.FormattingEnabled = true;
            this.cmbBeverages.Location = new System.Drawing.Point(17, 378);
            this.cmbBeverages.Name = "cmbBeverages";
            this.cmbBeverages.Size = new System.Drawing.Size(109, 24);
            this.cmbBeverages.TabIndex = 7;
            this.cmbBeverages.SelectedIndexChanged += new System.EventHandler(this.cmbBeverages_SelectedIndexChanged);
            // 
            // cmbSelectPizza
            // 
            this.cmbSelectPizza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbSelectPizza.FormattingEnabled = true;
            this.cmbSelectPizza.Location = new System.Drawing.Point(17, 82);
            this.cmbSelectPizza.Name = "cmbSelectPizza";
            this.cmbSelectPizza.Size = new System.Drawing.Size(198, 24);
            this.cmbSelectPizza.TabIndex = 6;
            this.cmbSelectPizza.SelectedIndexChanged += new System.EventHandler(this.cmbSelectPizza_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(14, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Price:\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(14, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Select Pizza";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(14, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Price:\r\n";
            // 
            // btnAddBeverage
            // 
            this.btnAddBeverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddBeverage.Location = new System.Drawing.Point(132, 376);
            this.btnAddBeverage.Name = "btnAddBeverage";
            this.btnAddBeverage.Size = new System.Drawing.Size(83, 47);
            this.btnAddBeverage.TabIndex = 3;
            this.btnAddBeverage.Text = "Add Beverage";
            this.btnAddBeverage.UseVisualStyleBackColor = true;
            this.btnAddBeverage.Click += new System.EventHandler(this.btnAddBeverage_Click);
            // 
            // btnAddPizza
            // 
            this.btnAddPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddPizza.Location = new System.Drawing.Point(132, 307);
            this.btnAddPizza.Name = "btnAddPizza";
            this.btnAddPizza.Size = new System.Drawing.Size(83, 47);
            this.btnAddPizza.TabIndex = 3;
            this.btnAddPizza.Text = "Add Pizza";
            this.btnAddPizza.UseVisualStyleBackColor = true;
            this.btnAddPizza.Click += new System.EventHandler(this.btnAddPizza_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 452);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TableForm";
            this.Text = "TableForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Label lblBeverageCount;
        private System.Windows.Forms.Label lblPizzaCount;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.Label lblPizzaPrice;
        private System.Windows.Forms.Label lblBeveragePrice;
        private System.Windows.Forms.ComboBox cmbBeverages;
        private System.Windows.Forms.ComboBox cmbSelectPizza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddBeverage;
        private System.Windows.Forms.Button btnAddPizza;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chckCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordertype;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordername;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderprice;
    }
}