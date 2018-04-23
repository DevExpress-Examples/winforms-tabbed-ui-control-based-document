using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraRichEdit;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;
using DevExpress.XtraBars.Docking2010.Views;

namespace DcoumentManagerContentGenerator {
    public partial class Form1 : Form {
        int index = 1;
        public Form1() {
            InitializeComponent();
            documentManager2.View.DocumentProperties.UseFormIconAsDocumentImage = false;
            documentManager2.View.UseDocumentSelector = DevExpress.Utils.DefaultBoolean.True;
            tabbedView1.FloatingDocumentContainer = FloatingDocumentContainer.DocumentsHost;
        }
        void AddNewTextDoc(string s, bool tabbed) {
            RichEditControl newTB = new RichEditControl();
            newTB.Size = new Size(400, 170);
            newTB.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            newTB.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.PrintLayout;
            newTB.Views.PrintLayoutView.ZoomFactor = 0.7f;
            newTB.Name = s + index.ToString();
            newTB.Text = s + " " + index.ToString();
            documentManager2.View.BeginUpdate();
            if (tabbed == true) {
                documentManager2.View.AddDocument(newTB);
            }
            else documentManager2.View.AddFloatDocument(newTB);
            documentManager2.View.EndUpdate();
            index++;
        }

        private void addTabbedDoc(object sender, ItemClickEventArgs e) {
            AddNewTextDoc("Document", true);
        }

        private void addFloatDoc(object sender, ItemClickEventArgs e) {
            AddNewTextDoc("Document", false);
        }

        private void closeAllDocs(object sender, ItemClickEventArgs e) {
            documentManager2.View.Controller.CloseAll();
            index = 1;
        }
    }
}
