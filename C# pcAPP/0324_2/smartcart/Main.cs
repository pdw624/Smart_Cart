using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace smartcart
{
    public partial class Main : Form
    {
        Login loginForm;
        //Con_datatable db;
        public Main()
        {
            InitializeComponent();
            //db = new Con_datatable();
            //db.ConnectDB();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Checkit();
            VisibleFalseLabel();
            LblCart.Visible = true;
            LblCartInfo.Visible = true;
            LblLiveInfo.Visible = true;
            LblUsingUser.Visible = true;
            picBoxCheck1.Visible = true;
            picBoxCheck2.Visible = true;
            btnCart.BackgroundImage = Image.FromFile("menuCart2.jpg");
            pictureBox2.BackColor = Color.FromArgb(234, 234, 234);
            
            //로그인 창 띄우기
            loginForm = new Login();
            loginForm.loginEventHandler += new EventHandler(LoginSuccess);
            switch (loginForm.ShowDialog())
            {
                case DialogResult.OK:
                    loginForm.Close();
                    break;
                case DialogResult.Cancel:
                    Dispose();
                    break;
            }

            //DataGridView1에 Cart 실시간 현황 테이블 생성
            //string sql = "SELECT * FROM `cart`";
            //DataTable dt = db.GetDBTable(sql);
            //dataGridView1.DataSource = dt;

        }

        //로그인 생성 시 메시지박스 띄우기
        private void LoginSuccess(string userName)
        {
            //MessageBox.Show(userName + "님이 로그인하셨습니다.");
            //LblAdmin.Text = userName + "님 안녕하세요";
        }

        //실시간 정보 버튼 클릭 시 이벤트 
        private void btnCart_Click(object sender, EventArgs e)
        {
            SetDefaultImage();
            VisibleFalseLabel();
            Checkit();
            picBoxCheck1.Visible = true;
            picBoxCheck2.Visible = true;
            LblCart.Visible = true;
            LblCartInfo.Visible = true;
            LblUsingUser.Visible = true;
            LblLiveInfo.Visible = true;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            btnCart.BackgroundImage = Image.FromFile("menuCart2.jpg");
        }

        //회원 관리 버튼 클릭 시(회원 관리 라벨 클릭 시)
        private void btnMember_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck3.Visible = true;
            LblMember.Visible = true;
            LblMemDel.Visible = true;
            Lblmember1.Visible = true;
            LblMemDel1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            btnMember.BackgroundImage = Image.FromFile("menuMem2.jpg");
        }

        //상품 관리 버튼 클릭 시(상품 관리 라벨 클릭 시)
        private void btnProduct_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck5.Visible = true;
            LblProduct.Visible = true;
            LblPdOrder.Visible = true;
            LblPdRegi.Visible = true;
            LblPdDel.Visible = true;
            LblPriceMdfy.Visible = true;
            LblProduct1.Visible = true;
            LblPdOrder1.Visible = true;
            LblPdRegi1.Visible = true;
            LblPdDel1.Visible = true;
            LblPriceMdfy1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");
        }

        //입고 내역 버튼 클릭 시
        private void btnInbound_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck10.Visible = true;
            LblInbound.Visible = true;
            LblPdInbound.Visible = true;
            LblPdInbound1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            btnInbound.BackgroundImage = Image.FromFile("menuIB2.jpg");
        }

        //출고 내역 버튼 클릭 시
        private void btnOutbound_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck11.Visible = true;
            LblOutbound.Visible = true;
            LblPdOutbound.Visible = true;
            LblPdOutbound1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            btnOutbound.BackgroundImage = Image.FromFile("menuOB2.jpg");
        }

        //통 계 버튼 클릭 시(총매출액 그래프 라벨 클릭 시)
        private void btnChart_Click_1(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            picBoxCheck12.Visible = true;
            LblChart.Visible = true;
            LblProdChart.Visible = true;
            LblSaleChart.Visible = true;
            LblSaleChart1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            btnChart.BackgroundImage = Image.FromFile("menuChart2.jpg");
        }

        //Label visible 비활성화 함수
        private void VisibleFalseLabel()
        {
            LblCart.Visible = false;
            LblCartInfo.Visible = false;
            LblUsingUser.Visible = false;
            LblLiveInfo.Visible = false;
            LblMember.Visible = false;
            LblMemDel.Visible = false;
            LblProduct.Visible = false;
            LblPdOrder.Visible = false;
            LblPdRegi.Visible = false;
            LblPdDel.Visible = false;
            LblPriceMdfy.Visible = false;
            LblOutbound.Visible = false;
            LblPdOutbound.Visible = false;
            LblInbound.Visible = false;
            LblPdInbound.Visible = false;
            LblChart.Visible = false;
            LblProdChart.Visible = false;
            LblSaleChart.Visible = false;
            Lblmember1.Visible = false;
            LblMemDel1.Visible = false;
            LblProduct1.Visible = false;
            LblPdOrder1.Visible = false;
            LblPdRegi1.Visible = false;
            LblPdDel1.Visible = false;
            LblPriceMdfy1.Visible = false;
            LblPdOutbound1.Visible = false;
            LblPdInbound1.Visible = false;
            LblProdChart1.Visible = false;
            LblSaleChart1.Visible = false;
        }

        //메인 메뉴 버튼 기본이미지로 색깔 초기화
        private void SetDefaultImage()
        {
            btnCart.BackgroundImage = Image.FromFile("menuCart1.jpg");
            btnMember.BackgroundImage = Image.FromFile("menuMem1.jpg");
            btnProduct.BackgroundImage = Image.FromFile("menuProduct1.jpg");
            btnInbound.BackgroundImage = Image.FromFile("menuIB1.jpg");
            btnOutbound.BackgroundImage = Image.FromFile("menuOB1.jpg");
            btnChart.BackgroundImage = Image.FromFile("menuChart1.jpg");
        }

        //체크 pictureBox 전부 비활성화 함수
        private void Checkit()
        {
            picBoxCheck1.Visible = false;
            picBoxCheck2.Visible = false;
            picBoxCheck3.Visible = false;
            picBoxCheck4.Visible = false;
            picBoxCheck5.Visible = false;
            picBoxCheck6.Visible = false;
            picBoxCheck7.Visible = false;
            picBoxCheck8.Visible = false;
            picBoxCheck9.Visible = false;
            picBoxCheck10.Visible = false;
            picBoxCheck11.Visible = false;
            picBoxCheck12.Visible = false;
            picBoxCheck13.Visible = false;
        }
        
        //회원 삭제 라벨 클릭 시 
        private void LblMemDel_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblMember.Visible = true;
            LblMemDel.Visible = true;
            LblMemDel1.Visible = true;
            picBoxCheck4.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            btnMember.BackgroundImage = Image.FromFile("menuMem2.jpg");

        }

        //상품 주문 라벨 클릭 시
        private void LblPdOrder_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblProduct.Visible = true;
            LblPdOrder.Visible = true;
            LblPdOrder1.Visible = true;
            LblPdDel.Visible = true;
            LblPdRegi.Visible = true;
            LblPriceMdfy.Visible = true;
            picBoxCheck6.Visible = true;
            dataGridView2.Visible = false;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");
        }
        
        //상품 수정 라벨 클릭 시
        private void LblPriceMdfy_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblProduct.Visible = true;
            LblPdOrder.Visible = true;
            LblPdDel.Visible = true;
            LblPdRegi.Visible = true;
            LblPriceMdfy.Visible = true;
            LblPriceMdfy1.Visible = true;
            picBoxCheck7.Visible = true;
            dataGridView2.Visible = false;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");

        }

        //상품 등록 라벨 클릭 시
        private void LblPdRegi_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblProduct.Visible = true;
            LblPdOrder.Visible = true;
            LblPdDel.Visible = true;
            LblPdRegi.Visible = true;
            LblPdRegi1.Visible = true;
            LblPriceMdfy.Visible = true;
            picBoxCheck8.Visible = true;
            dataGridView2.Visible = false;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");

        }

        //상품 삭제 라벨 클릭 시
        private void LblPdDel_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblProduct.Visible = true;
            LblPdOrder.Visible = true;
            LblPdDel.Visible = true;
            LblPdDel1.Visible = true;
            LblPdRegi.Visible = true;
            LblPriceMdfy.Visible = true;
            picBoxCheck9.Visible = true;
            dataGridView2.Visible = false;
            btnProduct.BackgroundImage = Image.FromFile("menuProduct2.jpg");
        }

        //상품별 판매 그래프 라벨 클릭 시
        private void LblProdChart_Click(object sender, EventArgs e)
        {
            Checkit();
            SetDefaultImage();
            VisibleFalseLabel();
            LblChart.Visible = true;
            LblSaleChart.Visible = true;
            LblProdChart.Visible = true;
            LblProdChart1.Visible = true;
            picBoxCheck13.Visible = true;
            btnChart.BackgroundImage = Image.FromFile("menuChart2.jpg");
        }
    }
}
