using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows;
using System.IO;

namespace Audits.Interop
{
    public class Email
    {
        private string _body;
        private string _subject;
        private bool _preview;
        private List<string> _attachments;
        private Outlook.NameSpace _olNamespace;
        private Outlook.Application _olApp;
        private Outlook.MAPIFolder _olFolder;
        private Outlook.MailItem _olMailItem;
        private Outlook.Recipients _olRecipients;
        private Outlook.Recipient _olRecipient;
        private List<string> _toList;
        private List<string> _ccList;
        private List<string> _bccList;
        private Outlook.OlImportance _priority;
        private const string AUDIT_EMAIL = "auditteam960@lowes.com";
        private List<string> _embeddedImages;

        public Email()
        {
            _toList = new List<string>();
            _ccList = new List<string>();
            _bccList = new List<string>();
            _attachments = new List<string>();
            _embeddedImages = new List<string>();
        }
        public bool Preview
        {
            get
            {
                return _preview;
            }
            set { _preview = value; }
        }
        public IList<string> ToList
        {
            get { return _toList; }
            set { _toList = (List<string>)value; }
        }
        public IList<string> CCList
        {
            get { return _ccList; }
            set { _ccList = (List<string>)value; }
        }
        public IList<string> BCCList
        {
            get { return _bccList; }
            set { _bccList = (List<string>)value; }
        }
        public IList<string> Attachments
        {
            get { return _attachments; }
            set { _attachments = (List<string>)value;}
        }
        public Outlook.OlImportance Priority
        {
            get
            {
                return _priority;
            }
            set { _priority = value; }
        }
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public bool IsHmtl { get; set; }
        public Outlook.MailItem Mail
        {
            get
            {
                if (_olMailItem == null)
                {
                    StartSession();
                }
                return _olMailItem;
            }
            set
            {
                _olMailItem = value;
            }
        }

        public void AddEmbeddedImage(string path, int height = 100)
        {
            string file = Path.GetFileName(path);

            Outlook.Attachment attachment = Mail.Attachments.Add(path, Outlook.OlAttachmentType.olEmbeddeditem, null, file);
            string imageCid = file + ".bmp@123";

            attachment.PropertyAccessor.SetProperty(
                "http://schemas.microsoft.com/mapi/proptag/0x3712001E",
                imageCid
                );

            string img = string.Format("<img height=\"{0}\" src=\"cid:{1)\">", height, imageCid);

            _embeddedImages.Add(img);
        }
        public void SetBody(string body, bool isHtml)
        {
            this.Body = body;
            this.IsHmtl = isHtml;
        }
        public void StartSession()
        {
            _olApp = new Outlook.Application();
            _olNamespace = _olApp.Session;

            if (_olNamespace != null)
            {
                _olNamespace.Logon(ShowDialog:true,NewSession:false);

                _olFolder = _olNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderOutbox);

                if (_olFolder != null)
                {
                    _olMailItem = _olFolder.Items.Add(Outlook.OlItemType.olMailItem);
                }
            }
        }
        public bool SendEmail()
        {
            if (_olMailItem != null)
            {
                try
                {
                    GetRecipientsCollection(ToList, Outlook.OlMailRecipientType.olTo);
                    GetRecipientsCollection(CCList, Outlook.OlMailRecipientType.olCC);
                    GetRecipientsCollection(BCCList, Outlook.OlMailRecipientType.olBCC);

                    _olMailItem.SentOnBehalfOfName = AUDIT_EMAIL;
                    _olMailItem.Subject = Subject;

                    if (Body.Contains("html"))
                    {
                        _olMailItem.HTMLBody = Body;
                    }
                    else _olMailItem.Body = Body;

                    AddAttachments();
                    _olMailItem.Importance = this.Priority;

                    if (_preview == true)
                    {
                        _olMailItem.Display();
                    }
                    else { _olMailItem.Save(); _olMailItem.Send(); }
                    return true;
                }
                catch (Exception err) { MessageBox.Show(err.Message); return false; }
            }
            return false;
        }
        private void AddAttachments()
        {
            if (Attachments.Count > 0)
            {
                Attachments.Each(a =>
                {
                    _olMailItem.Attachments.Add(a);
                });
            }
        }
        private void GetRecipientsCollection(IList<string> addresses, Outlook.OlMailRecipientType type)
        {

            if (addresses.Count > 0)
            {
                addresses.Each(r =>
                {
                    Outlook.Recipient rcp = _olMailItem.Recipients.Add(r);
                    rcp.Type = (int)type;
                });
            }
        }
        ~Email()
        {
            try
            {
                _olFolder = null;
                _olNamespace.Logoff();
                _olNamespace = null;
                //_olApp.Quit();
                _olApp = null;
            }
            catch (Exception) { }
        }
    }
}
