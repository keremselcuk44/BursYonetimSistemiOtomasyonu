using System;
using System.Windows.Forms;
using DevExpress.Mvvm;
using DevExpress.Utils.MVVM.UI;
using DevExpress.XtraEditors;
using OgrenciBursOtomasyonu.Desktop.Common.ViewModel;
using OgrenciBursOtomasyonu.Desktop.ViewModels;

namespace OgrenciBursOtomasyonu.Desktop.Views.Kullanici
{
    [ViewType(OgrenciBursDbViewModel.KullaniciIslemleriViewDocumentType)]
    public sealed class KullaniciIslemleriView : XtraUserControl
    {
        private readonly Panel _hostPanel;
        private FrmKullaniciIslemleri _embeddedForm;

        public KullaniciIslemleriView()
        {
            _hostPanel = new Panel
            {
                Dock = DockStyle.Fill,
            };

            Controls.Add(_hostPanel);
            Dock = DockStyle.Fill;

            Load += KullaniciIslemleriView_Load;
            Messenger.Default.Register<DocumentShownMessage>(this, OnDocumentShownMessageReceived);
        }

        private void KullaniciIslemleriView_Load(object sender, EventArgs e)
        {
            EnsureEmbeddedForm();
        }

        private void EnsureEmbeddedForm()
        {
            if (_embeddedForm != null && !_embeddedForm.IsDisposed)
                return;

            _hostPanel.Controls.Clear();

            _embeddedForm = new FrmKullaniciIslemleri
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };

            _hostPanel.Controls.Add(_embeddedForm);
            _embeddedForm.Show();
        }

        private async void OnDocumentShownMessageReceived(DocumentShownMessage msg)
        {
            if (msg == null || msg.DocumentType != OgrenciBursDbViewModel.KullaniciIslemleriViewDocumentType)
                return;

            EnsureEmbeddedForm();
            try
            {
                await _embeddedForm.RefreshKullanicilarAsync();
            }
            catch
            {
                // UI'da zaten hata mesajları gösteriliyor; burada sessizce geç.
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Messenger.Default.Unregister(this);
                if (_embeddedForm != null)
                {
                    _embeddedForm.Dispose();
                    _embeddedForm = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}


