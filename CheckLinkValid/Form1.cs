using CefSharp;
using CefSharp.WinForms;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckLinkValid
{
    public partial class Form1 : Form
    {
        private List<ValidateLink> ListLinkValid;
        private List<ValidateLink> ListLinkNotValid;
        private List<string> UrlChecked;
        private List<string> ListFileName;
        private ChromiumWebBrowser browser;
        public Form1()
        {
            InitializeComponent();
            InitList();
            InitChrome();
        }

        private void InitChrome()
        {
            txtUrlAdmin.Text = String.Format(CommonConstants.AdminUrl,1);
            txtUrl.Text = String.Format(CommonConstants.Url, 1); ;
            browser = new ChromiumWebBrowser(txtUrlAdmin.Text);
            browser.FrameLoadEnd += chrome_FrameLoadEnd;
            pChrome.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }

        private void InitList()
        {
            ListLinkValid = new List<ValidateLink>();
            ListLinkNotValid = new List<ValidateLink>();
            UrlChecked = new List<string>();
            ListFileName = new List<string>();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                int iPageSize = 1;
                int.TryParse(txtPageSizeAdmin.Text,out iPageSize);
                if (txtUrlAdmin.Text.Contains("?paged"))
                {
                    var domain = txtUrlAdmin.Text.Substring(0, txtUrlAdmin.Text.IndexOf("?paged"));
                    txtUrlAdmin.Text = domain + "?paged=" + iPageSize;
                    browser.Load(txtUrlAdmin.Text);
                }
                else
                {
                    browser.Load(txtUrlAdmin.Text + "?paged=" + iPageSize);
                }

                Thread.Sleep(5000);
                ListLinkValid.Clear();
                ListLinkNotValid.Clear();
                UrlChecked.Clear();
                ListFileName.Clear();
                listBoxLinkNotValid.Items.Clear();
                lblStartTime.Text = DateTime.Now.ToString();
                if (!string.IsNullOrEmpty(txtUrlAdmin.Text.Trim()))
                {
                    var strHtml = GetHTMLFromWebBrowser();
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(strHtml);
                    if (doc != null && doc.DocumentNode != null)
                    {
                        var listItem = doc.DocumentNode.SelectNodes("//div[@class='row-actions']//span[@class='view']//a");
                        foreach (var item in listItem)
                        {
                            var url = item.GetAttributeValue("href", String.Empty);
                            CheckLinkValid(url);
                        }
                    }
                }
                lblEndTime.Text = DateTime.Now.ToString();
                lblError.Text = ListLinkNotValid.Count + "/" + (ListLinkValid.Count + ListLinkNotValid.Count);
                var index = 1;
                foreach (var item in ListLinkNotValid)
                {
                    listBoxLinkNotValid.Items.Add(index++ + "\tId: " + item.ItemId + "\tRapidgator file name: " + item.NameLinkCheck);
                }
                ListFileName.AddRange(ListLinkNotValid.Select(x => x.NameLinkCheck).ToList());
                MessageBox.Show("Đã hoàn thành");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại");
            }                       
        }

        private void CheckLinkValid(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url) && !UrlChecked.Contains(url))
                {
                    UrlChecked.Add(url);
                    HtmlWeb web = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc = web.Load(url);
                    if(doc != null && doc.DocumentNode != null)
                    {
                        var itemCheck = new ValidateLink();
                        itemCheck.ItemLink = url;
                        var itemId = doc.DocumentNode.SelectSingleNode("//article").GetAttributeValue("id", "0");
                        itemCheck.ItemId = int.Parse(itemId.Replace("post-", ""));
                        itemCheck.ItemName = doc.DocumentNode.SelectSingleNode("//h1[@class='entry-title ']").InnerHtml;
                        var tagA = doc.DocumentNode.SelectSingleNode("//div[@class='entry-content']//a");
                        itemCheck.HrefLinkCheck = tagA.GetAttributeValue("href", "Not found");
                        itemCheck.NameLinkCheck = tagA.InnerHtml;
                        doc = web.Load(itemCheck.HrefLinkCheck);
                        var strHtml = doc.DocumentNode.SelectSingleNode("//head/title").InnerHtml;
                        if (strHtml.Contains(CommonConstants.TitleError))
                        {
                            itemCheck.IsValid = false;
                            ListLinkNotValid.Add(itemCheck);
                        }
                        else
                        {
                            itemCheck.IsValid = true;
                            ListLinkValid.Add(itemCheck);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetHTMLFromWebBrowser()
        {
            Task<String> taskHtml = browser.GetBrowser().MainFrame.GetSourceAsync();
            string response = taskHtml.Result;
            return response;
        }

        private void chrome_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            browser.EvaluateScriptAsync("document.querySelector('input[id=user_login]').value='" + CommonConstants.UserName + "';");
            browser.EvaluateScriptAsync("document.querySelector('input[id=user_pass]').value='" + CommonConstants.PassWord + "';");
            browser.ExecuteScriptAsync("document.getElementById('rememberme').click();");
            browser.ExecuteScriptAsync("document.getElementById('wp-submit').click();");
        }

        private void btnProcessRapidgator_Click(object sender, EventArgs e)
        {
            if (ListFileName.Count > 0)
            {
                ProcessRapidgator processRapidgator = new ProcessRapidgator();
                processRapidgator.SetListFileName(ListFileName);
                processRapidgator.TopMost = true;
                processRapidgator.Show();
            }
            else
            {
                MessageBox.Show("Không có file nào.");
            }

        }

        private void btnLoadFileFromText_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = @"D:\",
                    Title = "Browse Text Files",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "txt",
                    Filter = "txt files (*.txt)|*.txt",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };
                ListFileName.Clear();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    listBoxLinkNotValid.Items.Clear();
                    var index = 1;
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (!String.IsNullOrEmpty(line))
                            {
                                ListFileName.Add(line);
                                listBoxLinkNotValid.Items.Add(index++ + "\tRapidgator file name: " + line);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void btnCheckLink_Click(object sender, EventArgs e)
        {
            try
            {
                int iPageSize = 1;
                int.TryParse(txtPageSize.Text, out iPageSize);
                if (txtUrl.Text.Contains("/page"))
                {
                    var domain = txtUrl.Text.Substring(0, txtUrl.Text.IndexOf("/page"));
                    txtUrl.Text = domain + "/page/" + iPageSize;
                    browser.Load(txtUrl.Text);
                }
                else
                {
                    browser.Load(txtUrl.Text + "/page/" + iPageSize);
                }

                Thread.Sleep(5000);
                ListLinkValid.Clear();
                ListLinkNotValid.Clear();
                UrlChecked.Clear();
                ListFileName.Clear();
                listBoxLinkNotValid.Items.Clear();
                lblStartTime.Text = DateTime.Now.ToString();
                if (!string.IsNullOrEmpty(txtUrl.Text.Trim()))
                {
                    var strHtml = GetHTMLFromWebBrowser();
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(strHtml);
                    if (doc != null && doc.DocumentNode != null)
                    {
                        var listItem = doc.DocumentNode.SelectNodes("//h2[@class='entry-title']//a");
                        foreach (var item in listItem)
                        {
                            var url = item.GetAttributeValue("href", String.Empty);
                            CheckLinkValid(url);
                        }
                    }
                }
                lblEndTime.Text = DateTime.Now.ToString();
                lblError.Text = ListLinkNotValid.Count + "/" + (ListLinkValid.Count + ListLinkNotValid.Count);
                var index = 1;
                foreach (var item in ListLinkNotValid)
                {
                    listBoxLinkNotValid.Items.Add(index++ + "\tId: " + item.ItemId + "\tRapidgator file name: " + item.NameLinkCheck);
                }
                ListFileName.AddRange(ListLinkNotValid.Select(x => x.NameLinkCheck).ToList());
                MessageBox.Show("Đã hoàn thành");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại");
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(tabControl1.SelectedIndex == 2)
            {
                pChrome.Visible = false;
            }
            else
            {
                pChrome.Visible = true;
            }
        }
    }
}
