﻿//
// Copyright (c) 2007 Ole André Vadla Ravnås <oleavr@gmail.com>
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace oSpy
{
    public partial class NewVisualizationForm : Form
    {
        public NewVisualizationForm()
        {
            InitializeComponent();

            foreach (SessionVisualizer visualizer in StreamVisualizationManager.Visualizers)
            {
                if (visualizer.Visible)
                {
                    visualizersBox.Items.Add(visualizer);
                }
            }
        }

        public SessionVisualizer[] GetSelectedVisualizers()
        {
            List<SessionVisualizer> visualizers = new List<SessionVisualizer>(2);

            foreach (object obj in visualizersBox.Items)
            {
                if (visualizersBox.GetItemChecked(visualizersBox.Items.IndexOf(obj)))
                {
                    SessionVisualizer vis = obj as SessionVisualizer;
                    visualizers.Add(vis);
                }
            }

            return visualizers.ToArray();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void visualizersBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int checkCount = (e.NewValue == CheckState.Checked) ? 1 : -1;

            if (checkCount < 1)
            {
                for (int i = 0; i < visualizersBox.Items.Count; i++)
                {
                    if (visualizersBox.GetItemChecked(i))
                        checkCount++;
                }
            }

            okBtn.Enabled = (checkCount > 0);
        }
    }
}