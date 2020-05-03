namespace smartcart_1
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnMember = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPdOrder = new System.Windows.Forms.Button();
            this.btnPdDel = new System.Windows.Forms.Button();
            this.btnPdMdfy = new System.Windows.Forms.Button();
            this.chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnPdChart = new System.Windows.Forms.Button();
            this.btnSalesChart = new System.Windows.Forms.Button();
            this.chartSales2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLogout = new System.Windows.Forms.Button();
            this.LblLogname = new System.Windows.Forms.Label();
            this.btnMemDel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIB = new System.Windows.Forms.Button();
            this.btnOB = new System.Windows.Forms.Button();
            this.btnPdRegi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1797, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "      ICD - Smart Cart 관리 프로그램                                    \r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnCart.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCart.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCart.Location = new System.Drawing.Point(21, 63);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(270, 57);
            this.btnCart.TabIndex = 1;
            this.btnCart.Text = "카트 실시간 현황";
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // btnMember
            // 
            this.btnMember.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMember.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnMember.FlatAppearance.BorderSize = 0;
            this.btnMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMember.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMember.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMember.Location = new System.Drawing.Point(297, 63);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(151, 57);
            this.btnMember.TabIndex = 1;
            this.btnMember.Text = "회원관리";
            this.btnMember.UseVisualStyleBackColor = false;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnProduct.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProduct.ForeColor = System.Drawing.SystemColors.Window;
            this.btnProduct.Location = new System.Drawing.Point(454, 63);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(151, 57);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "상품관리";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSales.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSales.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSales.Location = new System.Drawing.Point(929, 63);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(222, 57);
            this.btnSales.TabIndex = 1;
            this.btnSales.Text = "매출 그래프";
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(21, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1130, 436);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnPdOrder
            // 
            this.btnPdOrder.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPdOrder.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnPdOrder.FlatAppearance.BorderSize = 0;
            this.btnPdOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdOrder.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdOrder.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdOrder.Location = new System.Drawing.Point(24, 622);
            this.btnPdOrder.Name = "btnPdOrder";
            this.btnPdOrder.Size = new System.Drawing.Size(141, 43);
            this.btnPdOrder.TabIndex = 3;
            this.btnPdOrder.Text = "상품 주문";
            this.btnPdOrder.UseVisualStyleBackColor = false;
            this.btnPdOrder.Visible = false;
            this.btnPdOrder.Click += new System.EventHandler(this.btnPdOrder_Click);
            // 
            // btnPdDel
            // 
            this.btnPdDel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPdDel.FlatAppearance.BorderSize = 0;
            this.btnPdDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdDel.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdDel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdDel.Location = new System.Drawing.Point(320, 622);
            this.btnPdDel.Name = "btnPdDel";
            this.btnPdDel.Size = new System.Drawing.Size(143, 43);
            this.btnPdDel.TabIndex = 3;
            this.btnPdDel.Text = "상품 삭제";
            this.btnPdDel.UseVisualStyleBackColor = false;
            this.btnPdDel.Visible = false;
            this.btnPdDel.Click += new System.EventHandler(this.btnPdDel_Click);
            // 
            // btnPdMdfy
            // 
            this.btnPdMdfy.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPdMdfy.FlatAppearance.BorderSize = 0;
            this.btnPdMdfy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdMdfy.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdMdfy.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdMdfy.Location = new System.Drawing.Point(171, 622);
            this.btnPdMdfy.Name = "btnPdMdfy";
            this.btnPdMdfy.Size = new System.Drawing.Size(143, 43);
            this.btnPdMdfy.TabIndex = 3;
            this.btnPdMdfy.Text = "가격 수정";
            this.btnPdMdfy.UseVisualStyleBackColor = false;
            this.btnPdMdfy.Visible = false;
            this.btnPdMdfy.Click += new System.EventHandler(this.btnPdMdfy_Click);
            // 
            // chartSales
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSales.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSales.Legends.Add(legend1);
            this.chartSales.Location = new System.Drawing.Point(21, 141);
            this.chartSales.Name = "chartSales";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "바나나";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "수박";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "마스크";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "새우깡";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "딸기";
            this.chartSales.Series.Add(series1);
            this.chartSales.Series.Add(series2);
            this.chartSales.Series.Add(series3);
            this.chartSales.Series.Add(series4);
            this.chartSales.Series.Add(series5);
            this.chartSales.Size = new System.Drawing.Size(1130, 436);
            this.chartSales.TabIndex = 4;
            this.chartSales.Text = "매출 그래프";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "상품별 매출액";
            this.chartSales.Titles.Add(title1);
            this.chartSales.Visible = false;
            this.chartSales.Click += new System.EventHandler(this.chartSales_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Location = new System.Drawing.Point(916, 638);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(223, 25);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // btnPdChart
            // 
            this.btnPdChart.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPdChart.FlatAppearance.BorderSize = 0;
            this.btnPdChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdChart.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdChart.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdChart.Location = new System.Drawing.Point(258, 622);
            this.btnPdChart.Name = "btnPdChart";
            this.btnPdChart.Size = new System.Drawing.Size(258, 43);
            this.btnPdChart.TabIndex = 3;
            this.btnPdChart.Text = "상품별 판매 그래프";
            this.btnPdChart.UseVisualStyleBackColor = false;
            this.btnPdChart.Visible = false;
            this.btnPdChart.Click += new System.EventHandler(this.btnPdChart_Click);
            // 
            // btnSalesChart
            // 
            this.btnSalesChart.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSalesChart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalesChart.FlatAppearance.BorderSize = 0;
            this.btnSalesChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesChart.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSalesChart.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSalesChart.Location = new System.Drawing.Point(24, 622);
            this.btnSalesChart.Name = "btnSalesChart";
            this.btnSalesChart.Size = new System.Drawing.Size(228, 43);
            this.btnSalesChart.TabIndex = 3;
            this.btnSalesChart.Text = "총매출 그래프";
            this.btnSalesChart.UseVisualStyleBackColor = false;
            this.btnSalesChart.Visible = false;
            this.btnSalesChart.Click += new System.EventHandler(this.btnSalesChart_Click);
            // 
            // chartSales2
            // 
            chartArea2.Name = "ChartArea1";
            this.chartSales2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSales2.Legends.Add(legend2);
            this.chartSales2.Location = new System.Drawing.Point(21, 141);
            this.chartSales2.Name = "chartSales2";
            series6.BorderWidth = 6;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.IsValueShownAsLabel = true;
            series6.Legend = "Legend1";
            series6.Name = "price";
            this.chartSales2.Series.Add(series6);
            this.chartSales2.Size = new System.Drawing.Size(1130, 436);
            this.chartSales2.TabIndex = 6;
            this.chartSales2.Text = "chart1";
            title2.BackColor = System.Drawing.Color.White;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "총매출액";
            title2.Text = "총매출액";
            this.chartSales2.Titles.Add(title2);
            this.chartSales2.Visible = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogout.Location = new System.Drawing.Point(1039, 599);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 33);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout\r\n";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // LblLogname
            // 
            this.LblLogname.AutoSize = true;
            this.LblLogname.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblLogname.Location = new System.Drawing.Point(912, 608);
            this.LblLogname.Name = "LblLogname";
            this.LblLogname.Size = new System.Drawing.Size(93, 24);
            this.LblLogname.TabIndex = 8;
            this.LblLogname.Text = "admin님";
            this.LblLogname.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblLogname.Click += new System.EventHandler(this.LblLogname_Click);
            // 
            // btnMemDel
            // 
            this.btnMemDel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMemDel.FlatAppearance.BorderSize = 0;
            this.btnMemDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemDel.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMemDel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMemDel.Location = new System.Drawing.Point(24, 622);
            this.btnMemDel.Name = "btnMemDel";
            this.btnMemDel.Size = new System.Drawing.Size(143, 43);
            this.btnMemDel.TabIndex = 3;
            this.btnMemDel.Text = "회원 삭제";
            this.btnMemDel.UseVisualStyleBackColor = false;
            this.btnMemDel.Visible = false;
            this.btnMemDel.Click += new System.EventHandler(this.btnMemDel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1177, 80);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnIB
            // 
            this.btnIB.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnIB.FlatAppearance.BorderSize = 0;
            this.btnIB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIB.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnIB.ForeColor = System.Drawing.SystemColors.Window;
            this.btnIB.Location = new System.Drawing.Point(770, 63);
            this.btnIB.Name = "btnIB";
            this.btnIB.Size = new System.Drawing.Size(151, 57);
            this.btnIB.TabIndex = 10;
            this.btnIB.Text = "입고내역";
            this.btnIB.UseVisualStyleBackColor = false;
            this.btnIB.Click += new System.EventHandler(this.btnIB_Click);
            // 
            // btnOB
            // 
            this.btnOB.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnOB.FlatAppearance.BorderSize = 0;
            this.btnOB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOB.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOB.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOB.Location = new System.Drawing.Point(612, 63);
            this.btnOB.Name = "btnOB";
            this.btnOB.Size = new System.Drawing.Size(151, 57);
            this.btnOB.TabIndex = 10;
            this.btnOB.Text = "출고내역";
            this.btnOB.UseVisualStyleBackColor = false;
            this.btnOB.Click += new System.EventHandler(this.btnOB_Click);
            // 
            // btnPdRegi
            // 
            this.btnPdRegi.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPdRegi.FlatAppearance.BorderSize = 0;
            this.btnPdRegi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdRegi.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdRegi.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdRegi.Location = new System.Drawing.Point(469, 622);
            this.btnPdRegi.Name = "btnPdRegi";
            this.btnPdRegi.Size = new System.Drawing.Size(143, 43);
            this.btnPdRegi.TabIndex = 11;
            this.btnPdRegi.Text = "상품 등록";
            this.btnPdRegi.UseVisualStyleBackColor = false;
            this.btnPdRegi.Visible = false;
            this.btnPdRegi.Click += new System.EventHandler(this.btnPdRegi_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1174, 694);
            this.Controls.Add(this.btnPdRegi);
            this.Controls.Add(this.btnOB);
            this.Controls.Add(this.btnIB);
            this.Controls.Add(this.LblLogname);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSalesChart);
            this.Controls.Add(this.chartSales2);
            this.Controls.Add(this.btnPdChart);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.chartSales);
            this.Controls.Add(this.btnMemDel);
            this.Controls.Add(this.btnPdMdfy);
            this.Controls.Add(this.btnPdDel);
            this.Controls.Add(this.btnPdOrder);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnMember);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "관리자";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPdOrder;
        private System.Windows.Forms.Button btnPdDel;
        private System.Windows.Forms.Button btnPdMdfy;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnPdChart;
        private System.Windows.Forms.Button btnSalesChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label LblLogname;
        private System.Windows.Forms.Button btnMemDel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnIB;
        private System.Windows.Forms.Button btnOB;
        private System.Windows.Forms.Button btnPdRegi;
    }
}

