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
        private List<string> ListLinkUrl;
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
            //browser.FrameLoadEnd += chrome_FrameLoadEnd;
            pChrome.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }

        private void InitList()
        {
            ListLinkValid = new List<ValidateLink>();
            ListLinkNotValid = new List<ValidateLink>();
            UrlChecked = new List<string>();
            ListFileName = new List<string>();
            ListLinkUrl = new List<string>();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                ListLinkValid.Clear();
                ListLinkNotValid.Clear();
                UrlChecked.Clear();
                ListFileName.Clear();
                ListLinkUrl.Clear();
                listBoxLinkNotValid.Items.Clear();
                lblStartTime.Text = DateTime.Now.ToString();
                List<string> ListPageIndex = new List<string>();
                if (txtPageIndex.Text.Contains(","))
                {
                    ListPageIndex.AddRange(txtPageIndexAdmin.Text.Split(',').ToList());
                }
                else if (txtPageIndex.Text.Contains("-"))
                {
                    var RangPageIndex = txtPageIndexAdmin.Text.Split('-').ToList();
                    int minIndex = 0, maxIndex = 0;
                    int.TryParse(RangPageIndex[0], out minIndex);
                    int.TryParse(RangPageIndex[1], out maxIndex);
                    for (int i = minIndex; i <= maxIndex; i++)
                    {
                        ListPageIndex.Add(i.ToString());
                    }
                }
                else
                {
                    ListPageIndex.Add(txtPageIndexAdmin.Text);
                }
                foreach (var item in ListPageIndex)
                {
                    int iPageSize = 0;
                    int.TryParse(item, out iPageSize);
                    if (iPageSize > 0)
                    {
                        string strUrl = String.Empty;
                        if (txtUrlAdmin.Text.Contains("?paged"))
                        {
                            var domain = txtUrlAdmin.Text.Substring(0, txtUrlAdmin.Text.IndexOf("?paged"));
                            strUrl = domain + "?paged=" + iPageSize;
                        }
                        else
                        {
                            strUrl = txtUrlAdmin.Text + "?paged=" + iPageSize;
                        }
                        GetRapidgatorFileName(strUrl, "//div[@class='row-actions']//span[@class='view']//a");
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
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại" + ex.Message);
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
                        var itemId = doc.DocumentNode.SelectSingleNode("//article").GetAttributeValue("id", "0");
                        var IdItem = int.Parse(itemId.Replace("post-", ""));
                        var itemName = doc.DocumentNode.SelectSingleNode("//h1[@class='entry-title ']").InnerHtml;
                        //var tagA = doc.DocumentNode.SelectSingleNode("//div[@class='entry-content']//a");
                        var ListTagA = doc.DocumentNode.SelectNodes("//div[@class='entry-content']//a").ToList();
                        foreach (var tagA in ListTagA)
                        {
                            var itemCheck = new ValidateLink();
                            itemCheck.ItemLink = url;
                            itemCheck.ItemName = itemName;
                            itemCheck.ItemId = IdItem;
                            var href = tagA.GetAttributeValue("href", "Not found");
                            if (href.ToLower().Contains("rapidgator"))
                            {
                                itemCheck.HrefLinkCheck = href;
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
                //processRapidgator.TopMost = true;
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
                ListLinkValid.Clear();
                ListLinkNotValid.Clear();
                UrlChecked.Clear();
                ListFileName.Clear();
                listBoxLinkNotValid.Items.Clear();
                ListLinkUrl.Clear();
                lblStartTime.Text = DateTime.Now.ToString();
                List<string> ListPageIndex = new List<string>();
                if (txtPageIndex.Text.Contains(","))
                {
                    ListPageIndex.AddRange(txtPageIndex.Text.Split(',').ToList());
                }
                else if (txtPageIndex.Text.Contains("-"))
                {
                    var RangPageIndex = txtPageIndex.Text.Split('-').ToList();
                    int minIndex = 0, maxIndex = 0;
                    int.TryParse(RangPageIndex[0], out minIndex);
                    int.TryParse(RangPageIndex[1], out maxIndex);
                    for (int i = minIndex; i <= maxIndex; i++)
                    {
                        ListPageIndex.Add(i.ToString());
                    }
                }
                else
                {
                    ListPageIndex.Add(txtPageIndex.Text);
                }
                foreach (var item in ListPageIndex)
                {
                    int iPageSize = 0;
                    int.TryParse(item, out iPageSize);
                    if (iPageSize > 0)
                    {
                        string strUrl = String.Empty;
                        if (txtUrl.Text.Contains("/page"))
                        {
                            var domain = txtUrl.Text.Substring(0, txtUrl.Text.IndexOf("/page"));
                            strUrl = domain + "/page/" + iPageSize;
                        }
                        else
                        {
                            strUrl = txtUrl.Text + "/page/" + iPageSize;
                        }
                        GetRapidgatorFileName(strUrl, "//div[@class='entry-meta']//span[@class='posted-on']//a");
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
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại" + ex.Message);
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

        private void GetRapidgatorFileName(string strUrl, string strXPath)
        {
            browser.Load(strUrl);
            Thread.Sleep(5000);
            var address = browser.Address;
            if (ListLinkUrl.Contains(address))
            {
                return;
            }
            ListLinkUrl.Add(address);
            if (!string.IsNullOrEmpty(strUrl))
            {
                var strHtml = GetHTMLFromWebBrowser();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(strHtml);
                if (doc != null && doc.DocumentNode != null)
                {
                    var listItem = doc.DocumentNode.SelectNodes(strXPath).ToList();
                    foreach (var item in listItem)
                    {
                        var url = item.GetAttributeValue("href", String.Empty);
                        CheckLinkValid(url);
                    }
                }
            }
        }
    }
}
